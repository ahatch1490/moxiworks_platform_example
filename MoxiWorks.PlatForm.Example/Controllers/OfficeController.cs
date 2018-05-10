using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoxiWorks.Platform;
using MoxiWorks.Platform.Interfaces;
namespace MoxiWorksPlatForm.Example.Controllers
{
    public class OfficeController : Controller
    {
        private IOfficeService _officeService;
        private IAgentService _agentService; 

        public OfficeController(IOfficeService service, IAgentService agentService)
        {
            _officeService = service;
            _agentService = agentService; 
        }
        
        // GET
        
        public IActionResult Index(string companyId, int page = 1)
        {
            var result =_officeService.GetCompanyOfficesAsync(companyId).Result;
            ViewBag.Result = result;
            ViewBag.CompanyId = companyId; 
            return View();
        }


        public IActionResult Show(string moxiWorksCompanyId, string moxiWorksOfficeId)
        {
            var office = _officeService.GetOfficeAsync(moxiWorksOfficeId,moxiWorksCompanyId).Result;
            var agents = _agentService.GetAgentsAsync(moxiWorksCompanyId, moxiWorksOfficeId).Result;
            ViewBag.Office = office;
            ViewBag.Agents = agents;
            ViewBag.CompanyId = moxiWorksCompanyId; 
            return View();
        }
    }
}