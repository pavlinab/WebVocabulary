using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebVocabulary2.Models;

namespace WebVocabulary2
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;
       
        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Session["currentUser"] == null)
                {
                    liMessages.Visible = false;
                    liVocabulary.Visible = false;
                    liUsers.Visible = false;
                    ulLoggedIn.Visible = false;
                    ulAnonymous.Visible = true;
                }
                else
                {
                    User currentUser = (User)Session["currentUser"];
                    litHelloUser.Text = GetLocalResourceObject("HelloUser").ToString() + currentUser.Name;
                    switch(currentUser.Role)
                    {
                        case "admin":   liMessages.Visible = true;
                                        liVocabulary.Visible = true;
                                        liUsers.Visible = true;
                                        ulLoggedIn.Visible = true;
                                        ulAnonymous.Visible = false;
                                        break;
                        case "user":    liMessages.Visible = true;
                                        liVocabulary.Visible = false;
                                        liUsers.Visible = false;
                                        ulLoggedIn.Visible = true;
                                        ulAnonymous.Visible = false;
                                        break;
                    }
                }
            }
        }

        
        protected void lbEnglish_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("CurrentLanguage");
            cookie.Value = "en-US";
            Response.SetCookie(cookie);
            Response.Redirect(Request.RawUrl);
        }

        protected void lbBulgarian_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("CurrentLanguage");
            cookie.Value = "bg-BG";
            Response.SetCookie(cookie);
            Response.Redirect(Request.RawUrl);
        }

        protected void lbSearch_Click(object sender, EventArgs e)
        {            
            if(!string.IsNullOrEmpty(inputSearch.Value))
            {
                string searchedWord = HttpUtility.UrlEncode(inputSearch.Value);
                Response.Redirect("Results.aspx?p=" + searchedWord);
            }
        }

        protected void lbExit_Click(object sender, EventArgs e)
        {
            Session["currentUser"] = null;
            Response.Redirect("Default.aspx");
        }
    }

}