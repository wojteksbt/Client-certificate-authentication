using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Infrastructure;

namespace ClientCertAuthWebApi.Authentication
{
    public class ClientCertificateAuthenticationHandler : AuthenticationHandler<ClientCertificateAuthenticationOptions>
    {
        private readonly IClientCertificateValidator _clientCertificateValidator;
        private readonly string _owinClientCertKey = "ssl.ClientCertificate";

        public ClientCertificateAuthenticationHandler(IClientCertificateValidator clientCertificateValidator)
        {
            if(clientCertificateValidator == null)
             throw new ArgumentNullException("ClientCertificateValidator");
            _clientCertificateValidator = clientCertificateValidator;
        }
        

        protected override async Task<AuthenticationTicket> AuthenticateCoreAsync()
        {
            ClientCertificateValidationResult validationResult = await Task.Run(() => ValidateCertificate(Request.Environment));
            if (validationResult.IsCertificateValid)
            {
                AuthenticationProperties authProperties = new AuthenticationProperties
                {
                    IssuedUtc = DateTime.UtcNow,
                    ExpiresUtc = DateTime.UtcNow.AddDays(1),
                    AllowRefresh = true,
                    IsPersistent = true
                };
                IList<Claim> claimCollection = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "Wojtek")
                    , new Claim(ClaimTypes.Country, "PL")
                    , new Claim(ClaimTypes.Gender, "M")
                    , new Claim(ClaimTypes.Surname, "Sabat")
                    , new Claim(ClaimTypes.Email, "wojsabat@gmail.com")
                    , new Claim(ClaimTypes.Role, "IT")
                    , new Claim("HasValidClientCertificate", "true")
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claimCollection, "X.509");
                AuthenticationTicket ticket = new AuthenticationTicket(claimsIdentity, authProperties);
                return ticket;
            }
            return await Task.FromResult<AuthenticationTicket>(null);
        }

        private ClientCertificateValidationResult ValidateCertificate(IDictionary<string, object> owinEnvironment)
        {
            if (owinEnvironment.ContainsKey(_owinClientCertKey))
            {
                X509Certificate2 clientCert = Context.Get<X509Certificate2>(_owinClientCertKey);
                return _clientCertificateValidator.Validate(clientCert);
            }

            ClientCertificateValidationResult invalid = new ClientCertificateValidationResult(false);
            invalid.AddValidationException("There's no client certificate attached to the request.");
            return invalid;
        }
    }
}