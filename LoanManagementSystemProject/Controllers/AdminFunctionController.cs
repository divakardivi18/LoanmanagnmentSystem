using LoanManagementSystemProject.Repository_DI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LoanManagementSystemProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminFunctionController : ControllerBase
    {
        private readonly IAdminFunctions adminFunctions = null;

        public AdminFunctionController(IAdminFunctions adminFunctions)
        {
            this.adminFunctions = adminFunctions;
        }

        [HttpGet]
        public async Task<IActionResult> DisplayAllLoans(int adid)
        {
            var loantypes = await adminFunctions.DisplayAllLoans(adid);
            return Ok(loantypes);
        }

        [HttpPut]
        public async Task<IActionResult> Acceptorreject(int loannumber,string status)
        {
            var loantypes = await adminFunctions.acceptorreject(loannumber,status);
            return Ok(loantypes);
        }

    }
}
