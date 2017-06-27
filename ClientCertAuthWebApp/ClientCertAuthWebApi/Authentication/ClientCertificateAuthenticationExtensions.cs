using ClientCertAuthWebApi.Authentication;


namespace Owin
{
    public static class ClientCertificateAuthenticationExtensions
    {
        public static void UseClientCertificateAuthentication(this IAppBuilder appBuilder, IClientCertificateValidator clientCertificateValidator)
        {
            appBuilder.Use<ClientCertificateAuthMiddleware>(new ClientCertificateAuthenticationOptions(), clientCertificateValidator);
        }
    }
}