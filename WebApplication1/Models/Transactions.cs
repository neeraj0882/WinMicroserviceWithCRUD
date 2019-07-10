using System;
using System.Collections.Generic;

namespace CoreServices.Models
{
    public partial class Transactions
    {
        public int Id { get; set; }
        public int? Transactionid { get; set; }
        public string Transactioncategory { get; set; }
        public string Defaultcomm { get; set; }
    }
}
