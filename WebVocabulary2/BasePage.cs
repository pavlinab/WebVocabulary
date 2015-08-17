using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace WebVocabulary2
{
    public class BasePage : Page
    {
        protected override void InitializeCulture()
        {
            //Check if cookie exists, then change our website culture to the desired language
        //else set our website culture to the default language (EN) here and 
        //create the cookie with this value

        
            string language = string.Empty;
            HttpCookie cookie = Request.Cookies["CurrentLanguage"];

            if (cookie != null && cookie.Value != null)
            {
                language = cookie.Value;
                CultureInfo culture = CultureInfo.CreateSpecificCulture(language);
                
                System.Threading.Thread.CurrentThread.CurrentUICulture = culture;
                System.Threading.Thread.CurrentThread.CurrentCulture = culture;
            }
            else
            {
                if (string.IsNullOrEmpty(language)) language = "en-US";
                CultureInfo culture = CultureInfo.CreateSpecificCulture(language);

                System.Threading.Thread.CurrentThread.CurrentUICulture = culture;
                System.Threading.Thread.CurrentThread.CurrentCulture = culture;

                HttpCookie cookie_new = new HttpCookie("CurrentLanguage");
                cookie_new.Value = language;
                Response.SetCookie(cookie_new);
            }
            base.InitializeCulture();
        }
    }
}