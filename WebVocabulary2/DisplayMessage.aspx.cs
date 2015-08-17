using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebVocabulary2.Models;

namespace WebVocabulary2
{
    public partial class DisplayMessage : System.Web.UI.Page
    {
        User currentUser = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["currentUser"] != null)
                {
                    currentUser = (User)Session["currentUser"];

                    if (Request.QueryString["p"] == null)
                        Response.Redirect("MessageBox.aspx?p=ReceivedMessages");
                }
                else Response.Redirect("Default.aspx");
            }
        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public WebVocabulary2.Models.Message fvMessage_GetItem([QueryString("p")] int id)
        {
            VocabularyContext context = new VocabularyContext();
            return context.Messages.SingleOrDefault(m => m.ID == id);
        }

        protected void fvMessage_DataBound(object sender, EventArgs e)
        {
            if(fvMessage.DataItem != null)
            {
                Message message = (Message)fvMessage.DataItem;
                VocabularyContext context = new VocabularyContext();
                
                if(message.SenderID != message.RecipientID)
                {
                    if(currentUser.ID == message.SenderID )
                    {
                        Label lblSender = (Label)fvMessage.FindControl("lblSender");
                        lblSender.Text = GetLocalResourceObject("from").ToString() + " " + currentUser.Name;

                        Label lblRecipient = (Label)fvMessage.FindControl("lblRecipient");
                        lblRecipient.Text = GetLocalResourceObject("to").ToString() + " " 
                                            + context.Users.SingleOrDefault(u => u.ID == message.RecipientID).Name;
                    }
                    if (currentUser.ID == message.RecipientID)
                    {
                        Label lblRecipient = (Label)fvMessage.FindControl("lblRecipient");
                        lblRecipient.Text = GetLocalResourceObject("to").ToString() + " " + currentUser.Name;

                        Label lblSender = (Label)fvMessage.FindControl("lblSender");
                        lblSender.Text = GetLocalResourceObject("from").ToString() + " " 
                                        + context.Users.SingleOrDefault(u => u.ID == message.SenderID).Name;
                    }
                } 
            }
        }

        protected void ibtnDeleteMessage_Command(object sender, CommandEventArgs e)
        {
            
            int messageID;
            if(int.TryParse(e.CommandArgument.ToString(), out messageID))
            {
                VocabularyContext context = new VocabularyContext();
                Message message = context.Messages.SingleOrDefault(m => m.ID == messageID);

                if (Session["currentUser"] != null)
                {
                    currentUser = (User)Session["currentUser"];
                
                    string redirectPage;
                    if (currentUser.ID == message.SenderID)
                    {
                        redirectPage = "MessageBox.aspx?p=SendedMessages";
                    }
                    else
                    {
                        redirectPage = "MessageBox.aspx?p=ReceivedMessages";
                    }

                    if(message.UserDeletedThis == 0)
                    {
                        message.UserDeletedThis = currentUser.ID;
                        context.SaveChanges();                
                    }
                    else
                    {
                        context.Messages.Remove(message);
                        context.SaveChanges();
                    }
                    Response.Redirect(redirectPage);
                }

            }
            
        }
        
    }
}