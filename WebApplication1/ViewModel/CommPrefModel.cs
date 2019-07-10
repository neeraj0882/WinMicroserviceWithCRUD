using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreServices.ViewModel
{
    public class CommPrefModel
    {
        public string transactionCategory { get; set; }
        public string emailFlag { get; set; }
        public string smsFlag { get; set; }
        public string mailFlag { get; set; }
        public string onlineNotificationFlag { get; set; }
    }
}
