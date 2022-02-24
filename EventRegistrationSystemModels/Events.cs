using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EventRegistrationSystemModels
{
    [Table("T_Events")]
    public class Events
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int event_id { get; set; }
        [ForeignKey("Ref_Event_Type")]
        public Ref_Event_Type event_type_code { get; set; }       
        public string event_name { get; set; }
        public DateTime event_start_date { get; set; }
        public DateTime event_end_date { get; set; }
        

    }
}
