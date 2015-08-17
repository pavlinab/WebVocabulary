using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebVocabulary2.Startup))]
namespace WebVocabulary2
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
