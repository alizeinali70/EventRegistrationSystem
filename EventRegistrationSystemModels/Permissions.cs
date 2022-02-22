using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EventRegistrationSystemModels
{
    [Table("T_Permissions")]
    public class Permissions
    {
        [Key]
        public double permission_id { get; set; }
        public string permission_description { get; set; }
        
    }
}
