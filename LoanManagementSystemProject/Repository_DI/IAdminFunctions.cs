using LoanManagementSystemProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoanManagementSystemProject.Repository_DI
{
    public interface IAdminFunctions
    {
        Task<List<LoanMaster>> DisplayAllLoans(int adid);

        Task<LoanMaster> acceptorreject(int loanumber,string status);
    }
}
