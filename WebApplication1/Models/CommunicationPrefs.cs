using System;
using System.Collections.Generic;

namespace CoreServices.Models
{
    public partial class CommunicationPrefs
    {
        public int Id { get; set; }
        public string Membernumber { get; set; }
        public int? Transactionid { get; set; }
        public string Email { get; set; }
        public string Sms { get; set; }
        public string Mail { get; set; }
        public string Onlinenotification { get; set; }
    }
}
