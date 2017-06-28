using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roommate.Outlook.Business
{
    public interface IExchangeServiceInitializer
    {
        ExchangeService GetService();
    }
}
