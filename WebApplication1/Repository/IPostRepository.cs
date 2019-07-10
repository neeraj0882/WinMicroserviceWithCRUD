using CoreServices.Models;
using CoreServices.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreServices.Repository
{
    public interface IPostRepository
    {

        Task AddCommPref(CommunicationPrefs[] commpref);
        Task<int?> GetTransactionId(string transactionCategory);
    }
}
