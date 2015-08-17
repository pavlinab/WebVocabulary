using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebVocabulary2.Models;

namespace WebVocabulary2
{
    public partial class AddWord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlDialog.Visible = false;
            if(!IsPostBack)
            {
                Models.User currentUser = (Models.User)Session["currentUser"];
                if (currentUser == null || currentUser.Role != "admin")
                    Response.Redirect("Default.aspx");

                VocabularyContext context = new VocabularyContext();
                ddlCategoriesEn.DataSource = context.Categories.Where(c => c.LanguageID == Helpers.EnLangID).ToList();//get English category
                ddlCategoriesEn.DataTextField = "Name";
                ddlCategoriesEn.DataValueField = "ID";
                ddlCategoriesEn.DataBind();
                

                ddlCategoriesBg.DataSource = context.Categories.Where(c => c.LanguageID == Helpers.BgLangID).ToList();//get Bulgarian category
                ddlCategoriesBg.DataTextField = "Name";
                ddlCategoriesBg.DataValueField = "ID";
                ddlCategoriesBg.DataBind();
                
            }
        }

        protected void btnAddWord_Click(object sender, EventArgs e)
        {
            Page.Validate("AddWord");
            if(Page.IsValid)
            {
                try
                {
                    Word word = new Word();
                    //fill word data on english
                    word.Name = tbWordEn.Text;
                    word.Description = ftbMeaningEn.Text;
                    word.LanguageID = Helpers.EnLangID;
                    int resultID;
                    if (int.TryParse(ddlCategoriesEn.SelectedValue, out resultID))
                    {
                        word.CategoryID = resultID;
                    }

                    VocabularyContext context = new VocabularyContext();
                    context.Word.Add(word);
                    context.SaveChanges();

                    ////////////////////////////////////

                    //fill word data on bulgarian
                    word = new Word();
                    word.Name = tbWordBg.Text;
                    word.Description = ftbMeaningBg.Text;
                    word.LanguageID = Helpers.BgLangID;
                    resultID = 0;
                    if (int.TryParse(ddlCategoriesBg.SelectedValue, out resultID))
                    {
                        word.CategoryID = resultID;
                    }
                    context.Word.Add(word);
                    context.SaveChanges();

                    tbWordEn.Text = string.Empty;
                    ftbMeaningEn.Text = string.Empty;
                    tbWordBg.Text = string.Empty;
                    ftbMeaningBg.Text = string.Empty;
                    hfResult.Value = "1";
                    pnlDialog.Visible = true;
                    litResult.Text = GetLocalResourceObject("Success").ToString();
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

        protected void cvCyrillic_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Regex.IsMatch(args.Value, @"\p{IsCyrillic}"))
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }
        protected void cvLatin_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Regex.IsMatch(args.Value, @"\p{IsBasicLatin}"))
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }

        protected void cvExistingWordBg_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int categoryID;
            if (int.TryParse(ddlCategoriesBg.SelectedValue, out categoryID))
            {
                Word word = new Word();
                VocabularyContext context = new VocabularyContext();

                //Check if this word for the specified category is already existing into Data base
                word = context.Word.SingleOrDefault(w => w.CategoryID == categoryID && w.Name == args.Value);

                if(word == null)//word does not exist => it can be added to Data base
                {
                    args.IsValid = true;
                }
                else // word exist - message appears
                {
                    args.IsValid = false;
                }
            }
        }

        protected void cvExistingWordEn_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int categoryID;
            if (int.TryParse(ddlCategoriesEn.SelectedValue, out categoryID))
            {
                Word word = new Word();
                VocabularyContext context = new VocabularyContext();

                //Check if this word for the specified category is already existing into Data base
                word = context.Word.SingleOrDefault(w => w.CategoryID == categoryID && w.Name == args.Value);

                if (word == null)//word does not exist => it can be added to Data base
                {
                    args.IsValid = true;
                }
                else // word exist - message appears
                {
                    args.IsValid = false;
                }
            }
        }
    }
}