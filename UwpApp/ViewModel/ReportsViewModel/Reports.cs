﻿using Domin.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UwpApp.ViewModel.ReportsViewModel
{
    public class Reports : BindableBase
    {
        public Reports()
        {
            Loadmemo();
            

        }

        public Memo memo { get; set; }

        public void Loadmemo()
        {


            var result = App.Repository.Memo.getreposrt(3);

            memo = result;
        }


        public  IList LoadReport()
        {
            List<ReportViewModelM> reportslist = new List<ReportViewModelM>();
 reportslist.Add(new ReportViewModelM(memo));
 return reportslist;
            
        }

       
        public IList loadmemodetail()
        {
            List<ReportMemoDetailVM> reportMemoDetailVMs = new List<ReportMemoDetailVM>();
            
            var memoDetails = memo.MemoDetails;
            foreach (var memod in memoDetails)
            {
                reportMemoDetailVMs.Add(new ReportMemoDetailVM( memod));
            }

            return reportMemoDetailVMs;
        }
    }


}
