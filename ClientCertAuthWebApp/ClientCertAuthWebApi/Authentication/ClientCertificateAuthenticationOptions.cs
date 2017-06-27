using Microsoft.Owin.Security;

namespace ClientCertAuthWebApi.Authentication
{
    public class ClientCertificateAuthenticationOptions : AuthenticationOptions
    {
        public ClientCertificateAuthenticationOptions() : base("X.509")
        { }
    }
}