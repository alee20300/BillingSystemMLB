using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;

namespace Domin.Models
{
    public class Patient : AuditEntity

    {
        
        public string Id { get; set; }
       
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(15)]
        public string IdCardNumber { get; set; }
        [StringLength(100)]

        public string PermAddress { get; set; }
        [StringLength(2)]
        public string Sex { get; set; }
        public DateTime DateOfBirth { get; set; }
        [StringLength(20)]
        public string Contact { get; set; }
        [StringLength(50)]
        
        
        public string Country { get; set; }
        [StringLength(5)]
        public int AtollId { get; set; }
        
        public int IslandId { get; set; }
        
        public Island Island { get; set; }
        [StringLength(50)]
        public string Email { get; set; }

        public List<Memo> Memos { get; set; } = new List<Memo>();    }


}
