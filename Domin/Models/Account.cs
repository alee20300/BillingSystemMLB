using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domin.Models
{
    public class Account :AuditEntity

    {


        [KeyAttribute()]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(50)]
        public string AccountName { get; set; }
        [StringLength(10)]
        public string AccountCode { get; set; }

        public List<Memo> Memos { get; set; } = new List<Memo>();

    }
}
