using CoreServices.Models;
using CoreServices.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreServices.Repository
{
    public class PostRepository : IPostRepository
    {
        BlogDBContext db;
        public PostRepository(BlogDBContext _db)
        {
            db = _db;
        }


        public async Task AddCommPref(CommunicationPrefs[] commpreflist)
        {
            if (db != null)
            {
                foreach(CommunicationPrefs  commpref in commpreflist)
                {
                    await db.CommunicationPrefs.AddAsync(commpref);
                    
                }
                await db.SaveChangesAsync();
            }
        }

 
        public async Task<int?> GetTransactionId(string transactionCategory)
        {
            int id = 0;

            if (db != null)
            {
                //Find the transaction id from the transaction category
                var tranId = await db.Transactions.FirstOrDefaultAsync(x => x.Transactioncategory == transactionCategory);
                return tranId.Transactionid;
            }

            return id;
        }
    }
}