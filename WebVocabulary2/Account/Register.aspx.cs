using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using WebVocabulary2.Models;

namespace WebVocabulary2.Account
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlDialog.Visible = false;
        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Page.Validate("Register");
            if(Page.IsValid)
            {
                try
                {
                    User user = new User();
                    VocabularyContext ctx = new VocabularyContext();
                    user = ctx.Users.SingleOrDefault(u => u.Name == tbUserName.Text);

                    if(user != null)
                    {
                        hfResult.Value = "1";
                        pnlDialog.Visible = true;
                        litResult.Text = GetLocalResourceObject("ExistUser").ToString();
                    }
                    else
                    {
                        user = new User { Name = tbUserName.Text, Role = "user", Password = tbPassword.Text };
                        ctx.Users.Add(user);
                        ctx.SaveChanges();

                        //Login user
                        Session["currentUser"] = user;
                        Response.Redirect("~/Default.aspx");
                    }
                }
                catch (Exception ex)
                {
                    string s = ex.Message;
                    hfResult.Value = "0";
                    pnlDialog.Visible = true;
                    litResult.Text = GetLocalResourceObject("Fail").ToString();
                }
            }
        }
    }
}