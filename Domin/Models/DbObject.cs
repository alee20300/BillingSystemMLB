using System;
using System.Collections.Generic;
using System.Text;

namespace Domin.Models
{
     public class DbObject
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
