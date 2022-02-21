using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EventRegistrationSystemModels
{
    public class Customers
    {
        [Key]
        public double customer_id { get; set; }
        [ForeignKey("Permissions")]
        public Permissions customer_permission_id { get; set; }
        public string customer_name { get; set; }
        public string customer_phone { get; set; }
        public string customer_email { get; set; }
    }
}
