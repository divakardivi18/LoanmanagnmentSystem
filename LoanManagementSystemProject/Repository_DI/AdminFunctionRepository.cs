using LoanManagementSystemProject.DataAccessLayer;
using LoanManagementSystemProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagementSystemProject.Repository_DI
{
    public class AdminFunctionRepository : IAdminFunctions
    {
        readonly LMSDbContext dbContext = null;
        public AdminFunctionRepository(LMSDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<LoanMaster>> DisplayAllLoans(int adid)
        {
            //var ar = await dbContext.LoanMasters.Where(x => x.AdminId == adid).FirstOrDefaultAsync();
            var ar= await dbContext.LoanMasters.ToListAsync();
            List<LoanMaster> loans = new List<LoanMaster>();
            foreach (LoanMaster loan in ar)
            {
                if(loan.AdminId == adid)
                {
                    loans.Add(loan);
                }
            }
            return loans;

           
            
            
        }

        public async Task<LoanMaster> acceptorreject(int loannumber, string status)
        {
            var ar = await dbContext.LoanMasters.Where(x => x.LoanNumber == loannumber).FirstOrDefaultAsync();
            ar.LoanStatus = status;
            await dbContext.SaveChangesAsync();
            return ar;

        }

        
    }
}
