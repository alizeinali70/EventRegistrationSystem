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
        [Route("api/ShowCurrentEvents")]
        public List<string> ShowCurrentEvents()
        {
            try
            {
                var result = _companyContext.events.Where(x => x.event_start_date >= DateTime.Now.Date).Select(x => new { x.event_name, x.event_start_date });
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

        [HttpGet]
        [Route("api/ShowAllEvents")]
        public List<string> ShowAllEvents(int permission_id)
        {
            List<string> events = new List<string>();
            try
            {
                if (Is_Admin(permission_id))
                {
                    var result = _companyContext.events.Select(x => new { x.event_id, x.event_name, x.event_start_date, x.event_end_date }).ToList();

                    foreach (var item in result)
                    {
                        events.Add(item.ToString());
                    }
                    return events;
                }
                else
                {
                    events.Add("You Do not Have the Right permission!!!");
                    return events;
                }
            }
            catch (System.Exception)
            {
                throw;
            }

        }

        [HttpPost]
        [Route("api/EventDetails")]
        [Consumes("application/x-www-form-urlencoded")]
        public JsonResult EventDetails(int event_id)
        {
            try
            {
                var result = _companyContext.events.Where(x => x.event_id == event_id);
                return Json(result);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("api/EventFullDetails")]
        [Consumes("application/x-www-form-urlencoded")]
        public JsonResult EventFullDetails(int event_id, int permission_id)
        {
            try
            {
                if (Is_Admin(permission_id))
                {
                    var result = _companyContext.events.Join(
                        _companyContext.event_Registrations,
                        x => x.event_id,
                        y => y.event_id,
                        (events, event_Registrations) => new
                        {
                            event_id = events.event_id,
                            event_name = events.event_name,
                            event_startdate = events.event_start_date,
                            event_enddate = events.event_end_date,
                            customer = event_Registrations.customer_email_phonenumber,
                            identification_id = event_Registrations.identificationd_id
                        }).Where(y => y.event_id == event_id);
                    return Json(result);
                }
                else
                {
                    return Json("You Do not Have the Right permission!!!");
                }
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
                if (!Is_Exist(customer_email_phonenumber))
                {
                    Event_Registration event_Registration = new Event_Registration();
                    event_Registration.event_id = events.event_id;
                    event_Registration.event_datetime = DateTime.Now;
                    event_Registration.booking_seat_count = Get_Book_Seat_Count(events) + 1;
                    event_Registration.permission_id = permissions.permission_id;
                    event_Registration.customer_email_phonenumber = customer_email_phonenumber;
                    event_Registration.identificationd_id = Create_identificationd_id();

                    _companyContext.event_Registrations.Add(event_Registration);
                    _companyContext.SaveChanges();

                    return new JsonResult(event_Registration.identificationd_id);
                }
                else
                    return Json("You Have been Registered!!!");
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public int Get_Book_Seat_Count(Events events)
        {
            var last_count = _companyContext.event_Registrations.Where(x => x.events.event_id == events.event_id);
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
        [HttpPost]
        [Route("api/IsExist")]
        [Consumes("application/x-www-form-urlencoded")]
        public bool Is_Exist(string customer_email_phonenumber)
        {
            var Customer = _companyContext.event_Registrations.Where(x => x.customer_email_phonenumber == customer_email_phonenumber);

            if (Customer.Count() <= 0)
                return false;
            else
                return true;

        }

        [HttpPost]
        [Route("api/FilterEvents")]
        [Consumes("application/x-www-form-urlencoded")]
        public bool Is_Admin(int permission_id)
        {
            if (permission_id == 1)
                return true;
            else
                return false;
        }
        [HttpPost]
        [Route("api/FilterEvents")]
        [Consumes("application/x-www-form-urlencoded")]
        public JsonResult FilterEvents(DateTime startdate, DateTime enddate, int permission_id)
        {
            List<string> events = new List<string>();
            try
            {
                if (Is_Admin(permission_id))
                {
                    var result = _companyContext.events.Where(x => x.event_start_date >= startdate && x.event_end_date <= enddate).Select(x => new { x.event_id, x.event_name, x.event_start_date, x.event_end_date }).ToList();

                    foreach (var item in result)
                    {
                        events.Add(item.ToString());
                    }
                    return Json(events);
                }
                else
                {
                    events.Add("You Do not Have the Right permission");
                    return Json(events);
                }
            }
            catch (System.Exception)
            {
                throw;
            }

        }

       
    }
}
