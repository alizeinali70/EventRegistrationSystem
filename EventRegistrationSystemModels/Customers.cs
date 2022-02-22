using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EventRegistrationSystemModels
{
    [Table("T_Customers")]
    public class Customers
    {
        [Key]
        public double customer_id { get; set; }
        [ForeignKey("Permissions")]
        public double customer_permission_id { get; set; }
        public Permissions perrmission { get; set; }
        public string customer_name { get; set; }
        public string customer_phone { get; set; }
        public string customer_email { get; set; }
        
    }
}
