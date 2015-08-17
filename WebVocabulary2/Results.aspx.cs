using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebVocabulary2.Models;

namespace WebVocabulary2
{
    public partial class Results : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //bind list view
            VocabularyContext context = new VocabularyContext();
            int languageID = Helpers.GetCurrentLanguageID();

            if (Request.QueryString["p"] == null)
                Response.Redirect("Default.aspx");

            string inputtedWord = HttpUtility.UrlDecode(Request.QueryString["p"].ToString());
            List<Word> wordList = context.Word.Where(w => w.Name == inputtedWord && w.LanguageID == languageID).ToList();
            if(wordList.Count == 1)
            {
                Response.Redirect("DisplayWord.aspx?pid=" + wordList[0].ID);
            }
            else
            {
                lvResults.DataSource = wordList;
                lvResults.DataBind();
            }
        }

        protected void lvResults_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if(e.Item.DataItem != null)
            {
                VocabularyContext context = new VocabularyContext();
                int languageID = Helpers.GetCurrentLanguageID();
                Word word = (Word)e.Item.DataItem;

                Label lblCategory = e.Item.FindControl("lblCategory") as Label; 
                if (lblCategory != null)
                {
                    lblCategory.Text = context.Categories.SingleOrDefault(c => c.ID == word.CategoryID).Name;
                }
            }
        }
    }
}