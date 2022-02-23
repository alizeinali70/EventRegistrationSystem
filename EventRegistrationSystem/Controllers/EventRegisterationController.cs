using EventRegistrationSystem.Context;
using EventRegistrationSystemModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EventRegistrationSystem.Controllers
{
    public class EventRegisterationController : Controller
    {
        private CompanyContext _companyContext;

        public EventRegisterationController(CompanyContext companyContext)
        {
            _companyContext = companyContext;
        }

        [HttpGet]
        [Route("api/ShowAllEvents")]
        public List<string> ShowAllEvents()
        {
            try
            {
                var result = _companyContext.events.Select(x => new { x.event_id, x.event_name }).ToList();
                List<string> events = new List<string>();
                foreach (var item in result)
                {
                    events.Add(item.ToString());
                }
                return events;
            }
            catch (System.Exception)
            {
                throw;
            }

        }
        [HttpPost]
        [Route("api/EventDetails")]        
        public JsonResult EventDetails(int id)
        {
            try
            {
                
               var result = _companyContext.events.Where(x => x.event_id == id);
                return Json(result);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
