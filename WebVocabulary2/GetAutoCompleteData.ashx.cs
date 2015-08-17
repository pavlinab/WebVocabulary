using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using WebVocabulary2.Models;

namespace WebVocabulary2
{
    /// <summary>
    /// Summary description for GetAutoCompleteData
    /// </summary>
    public class GetAutoCompleteData : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";
            string autoCompleteParameter = context.Request.Form["q"].ToString();
            string result = null;

            if(!string.IsNullOrEmpty(autoCompleteParameter))
            { 
                switch(context.Request.PathInfo)
                {
                    case "/LoadUsers":
                        result = LoadUsers(autoCompleteParameter);
                        break;
                    case "/LoadWords":
                        result = LoadWords(autoCompleteParameter);
                        break;
                    default: break;
                }
            }

            if(!string.IsNullOrEmpty(result))
            {
                context.Response.Write(result);
            }
            else
                context.Response.Write("-");
        }

        string LoadUsers(string partOfName)
        {
            VocabularyContext ctx = new VocabularyContext();
            List<User> userList = ctx.Users.Where(u => u.Name.StartsWith(partOfName) == true).ToList();

            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(userList);
        }

        string LoadWords(string partOfName)
        {
            VocabularyContext ctx = new VocabularyContext();
            List<Word> wordList = ctx.Word.Where(w => w.Name.StartsWith(partOfName) == true).ToList();

            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(wordList);
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}