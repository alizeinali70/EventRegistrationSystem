﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EventRegistrationSystemModels
{
    public class Ref_Event_Type
    {
        [Key]
        public int event_type_code { get; set; }
        public string event_type_description { get; set; }
    }
}
