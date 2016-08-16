using Microsoft.Owin;
using Owin;
using Chat;


[assembly: OwinStartupAttribute(typeof(Chat.Startup))]
namespace Chat
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
            app.MapSignalR(); // ← この行を追加
        }
    }
}