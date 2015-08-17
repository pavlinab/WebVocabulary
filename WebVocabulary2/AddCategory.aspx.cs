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
    public partial class AddCategory : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlDialog.Visible = false;   
     
            if(!IsPostBack)
            {
                Models.User currentUser = (Models.User)Session["currentUser"];
                if (currentUser == null || currentUser.Role != "admin")
                    Response.Redirect("Default.aspx");
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

        protected void cvExistingCategory_ServerValidate(object source, ServerValidateEventArgs args)
        {
            VocabularyContext context = new VocabularyContext();
            Category category = context.Categories.SingleOrDefault(c => c.Name == args.Value);
            if(category == null)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }

        protected void btnAddCategory_Click(object sender, EventArgs e)
        {
            Page.Validate("AddCategory");
            if (Page.IsValid)
            {
                try
                {
                    Category category = new Category();
                    //fill word data on english
                    category.Name = tbCategoryEn.Text;
                    category.LanguageID = Helpers.EnLangID;

                    VocabularyContext context = new VocabularyContext();
                    context.Categories.Add(category);
                    context.SaveChanges();

                    ////////////////////////////////////

                    //fill word data on bulgarian
                    category = new Category();
                    category.Name = tbCategoryBg.Text;
                    category.LanguageID = Helpers.BgLangID;

                    context.Categories.Add(category);
                    context.SaveChanges();

                    tbCategoryEn.Text = string.Empty;
                    tbCategoryBg.Text = string.Empty;

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
    }
}