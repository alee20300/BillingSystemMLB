using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domin.Models
{
    public class Service
    {

        public int ServiceId { get; set; }

        [StringLength(10)]
        public string ServiceCode { get; set; }


        [StringLength(50)]
        public string ServiceName { get; set; }



        [StringLength(10)]
        public string ICode { get; set; }

        [StringLength(10)]
        public String LisCode { get; set; }

        public decimal Rate { get; set; }

        public bool IsActive { get; set; }




        public ICollection<MemoDetail> MemoDetails { get; set; } = new List<MemoDetail>();
        public ICollection<AccountServicePrice> AccountServicePrices { get; set; } = new List<AccountServicePrice>();
        public int CatogoryId { get; set; }
        [ForeignKey("CatogoryId")]
        public Catogory Catogory { get; set; }

    }
}
