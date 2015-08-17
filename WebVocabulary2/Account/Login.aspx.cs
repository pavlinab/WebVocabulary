using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using WebVocabulary2.Models;

namespace WebVocabulary2.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void LogIn(object sender, EventArgs e)
        {
           
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            VocabularyContext context = new VocabularyContext();
            User user = context.Users.SingleOrDefault(u => u.Name == tbUserName.Text && u.Password == tbPassword.Text);
            if(user != null)
            {
                Session["currentUser"] = user;
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                lblFail.Text = GetLocalResourceObject("fail").ToString();
                lblFail.ForeColor = System.Drawing.Color.Red;
                lblFail.Visible = true;
            }
            
        }
    }
}