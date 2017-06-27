using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace ClientCertAuthWebApi.Authentication
{
    public class ClientCertificateValidator : IClientCertificateValidator
    {
        public ClientCertificateValidationResult Validate(X509Certificate2 certificate)
        {
            var isValid = false;
            var exceptions = new List<string>();
            try
            {
                var chain = new X509Chain();
                var chainPolicy = new X509ChainPolicy
                {
                    RevocationMode = X509RevocationMode.NoCheck,
                    RevocationFlag = X509RevocationFlag.EntireChain
                };
                chain.ChainPolicy = chainPolicy;
                if (chain.Build(certificate))
                    isValid = true;
                else
                    foreach (X509ChainElement chainElement in chain.ChainElements)
                    {
                        foreach (X509ChainStatus chainStatus in chainElement.ChainElementStatus)
                        {
                            exceptions.Add(chainStatus.StatusInformation);
                        }
                    }
            }
            catch (Exception ex)
            {
                exceptions.Add(ex.Message);
            }
            var result = new ClientCertificateValidationResult(isValid);
            result.AddValidationExceptions(exceptions);
            return result;
        }
    }
}