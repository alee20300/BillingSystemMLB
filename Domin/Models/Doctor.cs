﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domin.Models
{
    public class Doctor: DbObject   
    {
        public int Id { get; set; }
        [StringLength(50)]
        public String DoctorName { get; set; }
        
    }
}
