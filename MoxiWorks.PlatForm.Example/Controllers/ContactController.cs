using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoxiWorks.Platform;
namespace MoxiWorksPlatForm.Example.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            var service = new ContactService(new MoxiWorksClient());
            var contacts = service.GetContactsUpdatedSinceAsync("", AgentIdType.AgentUuid);

            ViewBag.Contacts = contacts; 
           
            return View(ViewBag);
        }
    }
}