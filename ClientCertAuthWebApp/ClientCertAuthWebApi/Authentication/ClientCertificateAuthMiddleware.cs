using System;
using Microsoft.Owin;
using Microsoft.Owin.Security.Infrastructure;

namespace ClientCertAuthWebApi.Authentication
{
    public class ClientCertificateAuthMiddleware : AuthenticationMiddleware<ClientCertificateAuthenticationOptions>
    {
        private readonly IClientCertificateValidator _clientCertificateValidator;

        public ClientCertificateAuthMiddleware(OwinMiddleware nextMiddleware, ClientCertificateAuthenticationOptions authOptions,
            IClientCertificateValidator clientCertificateValidator)
            : base(nextMiddleware, authOptions)
        {
            if (clientCertificateValidator == null)
                throw new ArgumentNullException("ClientCertificateValidator");
            _clientCertificateValidator = clientCertificateValidator;
        }

        protected override AuthenticationHandler<ClientCertificateAuthenticationOptions> CreateHandler()
        {
            return new ClientCertificateAuthenticationHandler(_clientCertificateValidator);
        }
    }
}