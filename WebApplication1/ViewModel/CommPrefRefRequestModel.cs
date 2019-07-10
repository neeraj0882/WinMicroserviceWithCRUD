using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreServices.ViewModel
{
    public class CommPrefRefRequestModel
    {
        public string MemberNumber { get; set; }
        public CommPrefModel[] commpref { get; set; }

    }
}
