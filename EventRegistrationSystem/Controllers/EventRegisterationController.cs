using EventRegistrationSystem.Context;
using EventRegistrationSystemModels;
using Microsoft.AspNetCore.Mvc;
using System;
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
        [Consumes("application/x-www-form-urlencoded")]
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

        [HttpPost]
        [Route("api/EventRegistration")]
        [Consumes("application/x-www-form-urlencoded")]
        public JsonResult EventRegistration(Events events, Permissions permissions, string customer_email_phonenumber)
        {
            try
            {
                Events selectd_event = new Events();

                Event_Registration event_Registration = new Event_Registration();
                event_Registration.event_id.event_id = events.event_id;
                event_Registration.event_datetime = System.DateTime.Now;
                event_Registration.booking_seat_count = Get_Book_Seat_Count(events) + 1;
                event_Registration.permission_id.permission_id = permissions.permission_id;
                event_Registration.customer_email_phonenumber = customer_email_phonenumber;
                event_Registration.identificationd_id = Create_identificationd_id();

                _companyContext.event_Registrations.Add(event_Registration);
                _companyContext.SaveChanges();

                return null;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public int Get_Book_Seat_Count(Events events)
        {
            var last_count = _companyContext.event_Registrations.Where(x => x.event_id.event_id == events.event_id);
            int Seat_Count = 0;
            if (last_count != null)
            {

                foreach (var item in last_count)
                {
                    Seat_Count = item.booking_seat_count;
                }
                return Seat_Count;
            }
            else
                return Seat_Count;
        }

        public string Create_identificationd_id()
        {
            Random random = new Random();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 5)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
