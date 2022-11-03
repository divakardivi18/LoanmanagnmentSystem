﻿using LoanManagementSystemProject.Models;
using LoanManagementSystemProject.Repository_DI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagementSystemProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        readonly IAdmin admin = null;

        public AdminController(IAdmin admin)
        {
            this.admin = admin;
        }

        [HttpPost]
        public async Task<IActionResult> AdminRegistration(AdminModel registerAdmin)
        {
            var ar = await admin.Create(registerAdmin);
            return Ok(ar);
        }

        [HttpGet("{id},{Password}")]
        public async Task<IActionResult> AdminLogin(int id, string Password)
        {
            var ar = await admin?.Login(id, Password);
            return Ok(ar);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, AdminModel editAdmin)
        {
            var ar = await admin.UpdateAdmin(id,editAdmin);
            return Ok(ar);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ar = await admin.DeleteAdmin(id);
            return Ok(ar);
        }

        //[HttpGet]
        //public async Task<IActionResult> ShowAll()
        //{
        //    var ar = await admin.ShowAllAdmin();
        //    return Ok(ar);
        //}
    }
}
