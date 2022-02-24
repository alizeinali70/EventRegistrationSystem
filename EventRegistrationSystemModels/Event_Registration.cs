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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int booking_id { get; set; }        
        [ForeignKey("event_id")]
        public virtual Events events { get; set; }
        public int event_id { get; set; }
        public DateTime event_datetime { get; set; }
        public int booking_seat_count { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        public string customer_email_phonenumber { get; set; }
        public string identificationd_id { get; set; }
        [ForeignKey("permission_id")]
        public virtual Permissions permission { get; set; }
        public int permission_id { get; set; }

    }
}
