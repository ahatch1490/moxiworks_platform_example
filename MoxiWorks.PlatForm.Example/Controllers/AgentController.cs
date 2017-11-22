using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage;
using MoxiWorks.Platform.Interfaces;

namespace MoxiWorksPlatForm.Example.Controllers
{
    public class AgentController : Controller
    {
        private IAgentService _service;

        public AgentController(IAgentService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            var result =  _service.GetAgentsAsync("windermere", null, DateTime.Now.AddDays(-100)).Result.Item;
            
            ViewBag.Agents = result; 
            return View(ViewBag);
        }
    }
}