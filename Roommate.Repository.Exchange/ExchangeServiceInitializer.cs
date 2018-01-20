using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Exchange.WebServices.Data;
using System.Configuration;

namespace Roommate.Repository.Outlook
{
    public class ExchangeServiceInitializer : IExchangeServiceInitializer
    {
        private string _exchangeUsername;
        private string _exchangePassword;
        private string _exchangeDomain;
        private string _exchangeUrl;
        private string _roomEmailAddress;

        public ExchangeServiceInitializer(string exchangeUsername, 
                                          string exchangePassword, 
                                          string exchangeDomain, 
                                          string exchangeUrl,
                                          string roomEmailAddress)
        {
            _exchangeUsername = exchangeUsername;
            _exchangePassword = exchangePassword;
            _exchangeDomain = exchangeDomain;
            _exchangeUrl = exchangeUrl;
            _roomEmailAddress = roomEmailAddress;
        }

        public string RoomEmailAddress => _roomEmailAddress;

        public ExchangeService GetService()
        {
            ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2013_SP1);
            service.Credentials = new WebCredentials(
                _exchangeUsername,
                _exchangePassword,
                _exchangeDomain);

            service.Url = new Uri(_exchangeUrl);

            return service;
        }

        private static bool RedirectionUrlValidationCallback(string redirectionUrl)
        {
            // The default for the validation callback is to reject the URL.
            bool result = false;

            Uri redirectionUri = new Uri(redirectionUrl);

            // Validate the contents of the redirection URL. In this simple validation
            // callback, the redirection URL is considered valid if it is using HTTPS
            // to encrypt the authentication credentials. 
            if (redirectionUri.Scheme == "https")
            {
                result = true;
            }
            return result;
        }
    }
}
