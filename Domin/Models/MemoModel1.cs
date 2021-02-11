using Domin.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domin.Models
{
    public class MemoModel1
    {
        public MemoModel1()
        {
        }

        public int MemoModelId { get; set; }
        public DateTime MemoDate { get; set; }
        public bool Ispaid { get; set; }
        public ICollection<MemoDetailModel> MemoDetailModels { get; set; } = new List<MemoDetailModel>();

    }
}
