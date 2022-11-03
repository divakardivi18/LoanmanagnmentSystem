using LoanManagementSystemProject.DataAccessLayer;
using LoanManagementSystemProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagementSystemProject.Repository_DI
{
    public class UserFunctionRespository : IUserFunctions
    {
        readonly LMSDbContext lMSDbContext = null;
        public UserFunctionRespository(LMSDbContext lMSDbContext)
        {
            this.lMSDbContext = lMSDbContext;
        }
    
        

        public async Task<LoanMaster> ApplyLoan(int userId, int loanId, int adminId, int income, int LoanAmout, string PropertyAddress)
        {
            LoanMaster addLoan = new LoanMaster();
            addLoan.CustomerId = userId;
            addLoan.LoanAmount = LoanAmout;
            addLoan.PropertyAddress = PropertyAddress;
            addLoan.DateOfApproval = DateTime.Now;
            addLoan.LoanStatus = "Applied";
            addLoan.Income = income;
            addLoan.LoanId = loanId;
            addLoan.AdminId = adminId;

            lMSDbContext.LoanMasters.Add(addLoan);
            await lMSDbContext.SaveChangesAsync();
            return addLoan;
        }

        public async Task<List<LoanModel>> DisplayLoanTypes()
        {
            var ar = await lMSDbContext.LoanModels.ToListAsync();
            return ar;
        }

        public async Task<string> GetLoanStatus(int id)
        {
            var ar = await lMSDbContext.LoanMasters.Where(x => x.LoanNumber == id).FirstOrDefaultAsync();
            if(ar != null)
            {
                return ar.LoanStatus;
            }
            else
            {
                return null;
            }
        }
    }
}
