using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Exchange.WebServices.Data;
using System.Configuration;

namespace Roommate.Outlook.Business
{
    public class ExchangeServiceInitializer : IExchangeServiceInitializer
    {
        public ExchangeService GetService()
        {
            ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2013_SP1);
            service.Credentials = new WebCredentials(
                ConfigurationManager.AppSettings["ExchangeUsername"],
                ConfigurationManager.AppSettings["ExchangePassword"],
                ConfigurationManager.AppSettings["ExchangeDomain"]);

            service.Url = new Uri(ConfigurationManager.AppSettings["ExchangeUrl"]);
          
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
