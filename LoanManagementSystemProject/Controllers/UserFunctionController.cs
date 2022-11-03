using LoanManagementSystemProject.Repository_DI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LoanManagementSystemProject.Models;
using System.Threading.Tasks;

namespace LoanManagementSystemProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserFunctionController : ControllerBase
    {
        private readonly IUserFunctions userFunctions = null;

        public UserFunctionController(IUserFunctions userFunctions)
        {
            this.userFunctions = userFunctions; 
        }

        [HttpPost]
        public async Task<IActionResult> ApplyForLoan(int userId, int loanId, int adminId, int income, int LoanAmout, string PropertyAddress)
        {

            var query = await userFunctions.ApplyLoan(userId, loanId, adminId, income, LoanAmout, PropertyAddress);
            return Ok(query);

        }

        [HttpGet]
        public async Task<IActionResult> DisplayLoanTypes()
        {
            var loantypes = await userFunctions.DisplayLoanTypes();
            return Ok(loantypes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLoanStatus(int id)
        {
            var loantypes = await userFunctions.GetLoanStatus(id);
            return Ok(loantypes);
        }

    }
}
