using ClientCertAuthWebApi.Authentication;
using Owin;

namespace ClientCertAuthWebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            appBuilder.UseClientCertificateAuthentication(new ClientCertificateValidator());
        }
    }
}