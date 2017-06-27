using System.Security.Cryptography.X509Certificates;

namespace ClientCertAuthWebApi.Authentication
{
    public interface IClientCertificateValidator
    {
        ClientCertificateValidationResult Validate(X509Certificate2 certificate);
    }
}