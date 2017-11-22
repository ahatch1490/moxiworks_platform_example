using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoxiWorks.Platform;
using MoxiWorks.Platform.Interfaces;
namespace MoxiWorksPlatForm.Example.Controllers
{
    public class CompanyController : Controller
    {
        private ICompanyService _companyService;

        public CompanyController(ICompanyService service)
        {
            _companyService = service;
        }

        public IActionResult Index()
        {
            var result = _companyService.GetCompanyAsync("windermere").Result;
            ViewBag.Result = result;
            return View();
        }
    }
}