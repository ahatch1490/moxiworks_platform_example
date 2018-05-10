using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MoxiWorks.Platform;
using MoxiWorks.Platform.Interfaces;
namespace MoxiWorksPlatForm.Example.Controllers
{
    public class CompanyController : Controller
    {
        private ICompanyService _companyService;
        private IConfiguration _configuration;

        public CompanyController(ICompanyService service, IConfiguration configuration)
        {
            _companyService = service;
            _configuration = configuration; 
        }

        public IActionResult Index()
        {
            var result = _companyService.GetCompanyAsync(_configuration["MoxiWorksCompanyId"]).Result;
            ViewBag.Result = result;
            return View();
        }
    }
}