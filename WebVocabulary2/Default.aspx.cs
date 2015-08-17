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
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VocabularyContext context = new VocabularyContext();
            int currentLanguageID = context.Languages.SingleOrDefault(l => l.Name == CultureInfo.CurrentUICulture.Name).ID;
            lvCategories.DataSource = context.Categories.Where(c => c.LanguageID == currentLanguageID).ToList();            
            lvCategories.DataBind();

            
        }

        protected void lvCateories_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            Category category = (e.Item.DataItem as Category);
            
            if (category != null)
            {
                VocabularyContext context = new VocabularyContext();
                int wordCount = context.Word.Count(w => w.CategoryID == category.ID);
                
                Label lblWordCountInCategory = e.Item.FindControl("lblWordCountInCategory") as Label;
                lblWordCountInCategory.Text = wordCount.ToString();                
            }            
                       
        }
    }
}