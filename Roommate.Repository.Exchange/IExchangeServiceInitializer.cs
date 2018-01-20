using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roommate.Repository.Outlook
{
    public interface IExchangeServiceInitializer
    {
        string RoomEmailAddress { get; }
        ExchangeService GetService();
    }
}
