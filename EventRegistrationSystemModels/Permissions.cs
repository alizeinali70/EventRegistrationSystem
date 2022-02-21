using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EventRegistrationSystemModels
{
    public class Permissions
    {
        [Key]
        public int permission_id { get; set; }
        public string permission_description { get; set; }
        public IEnumerable<Customers> customers { get; set; }
    }
}
