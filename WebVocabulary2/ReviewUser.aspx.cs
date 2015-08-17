using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebVocabulary2.Models;

namespace WebVocabulary2
{
    public partial class ReviewUser : System.Web.UI.Page
    {
        public string RequestedUserName            
        {
            get { return (string)ViewState["RequestedUserName"]; }
            set { ViewState["RequestedUserName"] = tbUserName.Text; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Models.User currentUser = (Models.User)Session["currentUser"];
                if (currentUser == null || currentUser.Role != "admin")
                    Response.Redirect("Default.aspx");

                divContainerBorder.Visible = false;                
            }
        }
        
        protected void btnSearchUsers_Click(object sender, EventArgs e)
        {
            VocabularyContext context = new VocabularyContext();
            List<User> userList = context.Users.ToList();
            lvUserList.DataSource = userList.FindAll(u => u.Name.Contains(tbUserName.Text));
            RequestedUserName = tbUserName.Text;
            lvUserList.DataBind();
            divContainerBorder.Visible = true;
            tbUserName.Text = string.Empty;
        }

        protected void ibtnDeleteUser_Command(object sender, CommandEventArgs e)
        {
            VocabularyContext context = new VocabularyContext();
            int userID = Convert.ToInt32(e.CommandArgument);
            User user = context.Users.SingleOrDefault(u => u.ID == userID);
            if(user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();

                List<User> userList = context.Users.ToList();
                lvUserList.DataSource = userList.FindAll(u => u.Name.Contains(RequestedUserName));
                lvUserList.DataBind();
            }
            
        }
    }
}