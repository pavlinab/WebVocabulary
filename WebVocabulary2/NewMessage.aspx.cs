using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebVocabulary2.Models;

namespace WebVocabulary2
{
    public partial class NewMessage : System.Web.UI.Page
    {
        User currentUser = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["currentUser"] == null)
                {
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    currentUser = (User)Session["currentUser"];
                    
                    switch (currentUser.Role)
                    {
                        case "user":
                            tbRecipient.Text = "Admin";
                            tbRecipient.Enabled = false;
                            break;
                        case "admin":
                            tbRecipient.Enabled = true;
                            break;
                    }
                    PrepareAnswerMessage();
                }
            }
        }

        private int GetRecipientID(string recipientName)// call when send
        {
            VocabularyContext context = new VocabularyContext();
            User user = context.Users.SingleOrDefault(u => u.Name == recipientName);
            if (user != null)
                return user.ID;
            else return 0;
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            if (Session["currentUser"] != null)
            {
                VocabularyContext context = new VocabularyContext();
                User currentUser = (User)Session["currentUser"];
                Message newMessage = new Message();
                newMessage.MessageDate = DateTime.Now;
                newMessage.Content = tbMessageText.Text;
                newMessage.UserDeletedThis = 0;
                newMessage.SenderID = currentUser.ID;
                newMessage.RecipientID = GetRecipientID(tbRecipient.Text);

                context.Messages.Add(newMessage);
                context.SaveChanges();
            }
        }

        protected void PrepareAnswerMessage()
        {
            if(Request.QueryString["p"] != null)
            {
                int messageID;
                if(int.TryParse(Request.QueryString["p"].ToString(), out messageID))
                {
                    VocabularyContext context = new VocabularyContext();
                    Message message = context.Messages.SingleOrDefault(m => m.ID == messageID);
                    if (message != null) 
                    {
                        if(currentUser.Role == "admin")
                        {
                            if(currentUser.ID != message.RecipientID)
                            {
                                //current user is the sender (this is from message object) and send message to the recipient again
                                tbRecipient.Text = context.Users.SingleOrDefault(u => u.ID == message.RecipientID).Name;
                            }
                            else
                            {
                                //current user is the recipient (this is from message object) and send back message to the sender
                                tbRecipient.Text = context.Users.SingleOrDefault(u => u.ID == message.SenderID).Name;
                            }
                        }

                        tbMessageText.Text = System.Environment.NewLine + message.Content;
                        tbMessageText.Focus();
                    }
                }
            }
        }
    }
}