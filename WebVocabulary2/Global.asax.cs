using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using WebVocabulary2.Models;

namespace WebVocabulary2
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Database.SetInitializer(new DbInitializer());
        }

        void Application_BeginRequest(object sender, EventArgs e)
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
        }
    }
}