using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EventRegistrationSystemModels
{
    public class Event_Registration
    {
        [Key]
        public int booking_id { get; set; }
        [ForeignKey("Customers")]
        public Customers customer_id { get; set; }
        [ForeignKey("Events")]
        public Events event_id { get; set; }
        public DateTime event_datetime { get; set; }
        public int booking_seat_count { get; set; }
    }
}
