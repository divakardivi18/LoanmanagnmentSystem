using LoanManagementSystemProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoanManagementSystemProject.Repository_DI
{
    public interface IUserFunctions
    {
       

        Task<List<LoanModel>> DisplayLoanTypes();

        Task<string> GetLoanStatus(int id);

        Task<LoanMaster> ApplyLoan(int userId, int loanId, int adminId, int income, int LoanAmout, string PropertyAddress);


    }
}
