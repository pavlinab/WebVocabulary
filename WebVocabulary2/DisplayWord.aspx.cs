using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebVocabulary2.Models;

namespace WebVocabulary2
{
    public partial class DisplayWord : System.Web.UI.Page
    {
        string currentLanguage = CultureInfo.CurrentUICulture.Name;
        string userRole = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Session["currentUser"] != null)
                {
                    User currentUser = (User)Session["currentUser"];
                    if(currentUser.Role == "admin")
                    {
                        userRole = "admin";
                    }
                }
                if (Request.QueryString["pid"] == null)
                    Response.Redirect("Default.aspx");
            }
        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public WebVocabulary2.Models.Word fvWord_GetItem([QueryString("pid")] int id)
        {
            VocabularyContext context = new VocabularyContext();
            int languageID = context.Languages.SingleOrDefault(l => l.Name == currentLanguage).ID;
            Word word = context.Word.SingleOrDefault(w => w.ID == id && w.LanguageID == languageID);
            string resultContent = PrepareWordMeaning(word);
            word.Description = Server.HtmlDecode(resultContent);

            Page.Title = word.Name;
            return word;
        }

        private string PrepareWordMeaning(Word word)
        {
            VocabularyContext context = new VocabularyContext();
            List<Word> wordList = context.Word.Where(w => w.CategoryID == word.CategoryID).ToList();
            string wordMeaning = word.Description;
                        
            if(wordList.Count > 0)
            {
                for (int i = 0; i < wordList.Count; i++)
                {
                    wordMeaning = Regex.Replace(wordMeaning, 
                                                wordList[i].Name, 
                                                new MatchEvaluator(delegate(Match match){ return GetRightReplacementString(match, wordList[i].ID); }), 
                                                RegexOptions.IgnoreCase);                    
                }
            }
            return wordMeaning;
        }

        private string GetRightReplacementString(Match match, int currentWordListItemID)
        {
            // Each Term(Word) name in to DataBase begins with UpperCase!!!
            // We set as inner text - currentMatch cause we can access it only here. It can contains string with 1st Upper case letter or lower case letter
            string currentMatch = match.Value;            
            return "<a href='DisplayWord.aspx?pid=" + currentWordListItemID + "'>" + currentMatch + "</a>";           
        }

        protected void fvWord_DataBound(object sender, EventArgs e)
        {
           if(fvWord.DataItem != null)
           {
               ImageButton ibtnDeleteWord = fvWord.FindControl("ibtnDeleteWord") as ImageButton;
               if(userRole == "admin")
               {
                   ibtnDeleteWord.Visible = true;
               }
               else
               {
                   ibtnDeleteWord.Visible = false;
               }
               VocabularyContext context = new VocabularyContext();

               int languageID = context.Languages.SingleOrDefault(l => l.Name == currentLanguage).ID;
               Word word = (Word)fvWord.DataItem;

               Literal litCategory = fvWord.FindControl("litCategory") as Literal;
               litCategory.Text = context.Categories.SingleOrDefault(c => c.ID == word.CategoryID && c.LanguageID == languageID).Name;
           }
        }
        
        protected void ibtnDeleteWord_Command(object sender, CommandEventArgs e)
        {
            VocabularyContext context = new VocabularyContext();
            Word word = context.Word.SingleOrDefault(w => w.ID == (int)e.CommandArgument);
            if (word != null)
            {
                context.Word.Remove(word);
                context.SaveChanges();
            }
        }
    }
}