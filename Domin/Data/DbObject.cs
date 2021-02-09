using System;

namespace Domin.Models
{
    public class DbObject
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
