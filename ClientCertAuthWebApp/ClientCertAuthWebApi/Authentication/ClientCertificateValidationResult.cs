using System.Collections.Generic;
using System.Linq;

namespace ClientCertAuthWebApi.Authentication
{
    public class ClientCertificateValidationResult
    {
        private readonly bool _isCertificateValid;
        private readonly IEnumerable<string> _validationExceptions;

        public ClientCertificateValidationResult(bool isCertificateValid)
        {
            _isCertificateValid = isCertificateValid;
            _validationExceptions = new List<string>();
        }

        public void AddValidationExceptions(IEnumerable<string> validationExceptions)
        {
            _validationExceptions.Concat(validationExceptions);
        }

        public void AddValidationException(string validationException)
        {
            _validationExceptions.Concat(new[] { validationException });
        }

        public bool IsCertificateValid => _isCertificateValid;
    }
}