using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EventRegistrationSystemModels
{
    [Table("T_Event_Registration")]
    public class Event_Registration
    {
        [Key]
        public double booking_id { get; set; }
        [ForeignKey("Customers")]
        public double customer_id { get; set; }
        [ForeignKey("Events")]
        public double event_id { get; set; }
        public DateTime event_datetime { get; set; }
        public int booking_seat_count { get; set; }
       
    }
}
