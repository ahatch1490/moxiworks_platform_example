using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoxiWorks.Platform;
using MoxiWorks.Platform.Interfaces;
namespace MoxiWorksPlatForm.Example.Controllers
{
    public class OfficeController : Controller
    {
        private IOfficeService _officeService;

        public OfficeController(IOfficeService service)
        {
            _officeService = service; 
        }
        
        // GET
        
        public IActionResult Index(string companyId, int page = 1)
        {
            var result =_officeService.GetCompanyOfficesAsync(companyId).Result;
            ViewBag.Result = result;
            
            return View();
        }
    }
}