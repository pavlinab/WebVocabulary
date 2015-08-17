using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebVocabulary2.Models;

namespace WebVocabulary2
{
    public partial class MessageBox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["currentUser"] == null)
                {
                    Response.Redirect("Default.aspx");
                }
                if(Request.QueryString["p"] != null)
                { 
                    string requestedView = Request.QueryString["p"].ToString();
                    setRightView(requestedView);
                }
            }
        }

        private void setRightView(string viewName)
        {
            if(Session["currentUser"] != null)
            {
                User currentUser = (User)Session["currentUser"];
                VocabularyContext context = new VocabularyContext();
                switch (viewName)
                {
                    case "SendedMessages": mvMessageBox.SetActiveView(vSendedMessages);
                                            lvSendedMessages.DataSource = context.Messages.Where(m => m.SenderID == currentUser.ID && m.UserDeletedThis != currentUser.ID).ToList();
                                            lvSendedMessages.DataBind();
                                            break;
                    case "ReceivedMessages": mvMessageBox.SetActiveView(vReceivedMessages);
                                            lvReceivedMessages.DataSource = context.Messages.Where(m => m.RecipientID == currentUser.ID && m.UserDeletedThis != currentUser.ID).ToList();
                                             lvReceivedMessages.DataBind();
                                             break;
                    default: Response.Redirect("Default.aspx"); break;
                }
            }
        }

        protected void lvSendedMessages_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.DataItem != null)
            {
                VocabularyContext context = new VocabularyContext();
                Message message = (Message)e.Item.DataItem;

                Label lblRecipient = e.Item.FindControl("lblRecipient") as Label;
                if (lblRecipient != null)
                {
                    lblRecipient.Text = context.Users.SingleOrDefault(u => u.ID == message.RecipientID).Name;
                }
            }
        }

        protected void lvReceivedMessages_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.DataItem != null)
            {
                VocabularyContext context = new VocabularyContext();
                Message message = (Message)e.Item.DataItem;

                Label lblSender = e.Item.FindControl("lblSender") as Label;
                if (lblSender != null)
                {
                    lblSender.Text = context.Users.SingleOrDefault(u => u.ID == message.SenderID).Name;
                }
            }
        }
    }
}