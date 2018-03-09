using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RegistroJugadores.Startup))]
namespace RegistroJugadores
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
