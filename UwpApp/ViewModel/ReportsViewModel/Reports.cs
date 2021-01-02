using Domin.Models;
using System.Collections;
using System.Collections.Generic;

namespace UwpApp.ViewModel.ReportsViewModel
{
    public class Reports : BindableBase
    {
        public Reports( Memo memoId)
        {
            memoidInt = memoId.MemoId;
            Loadmemo(memoidInt);
            

        }


        public int memoidInt { get; set; }
        public Memo memo { get; set; }

        public void Loadmemo(int memoid)
        {


            var result = App.Repository.Memo.getreposrt(memoid);

            memo = result;
        }
        public List<ReportViewModelM> reportslist = new List<ReportViewModelM>();

        public  IList LoadReport()
        {

            reportslist.Add(new ReportViewModelM(memo));
            return reportslist;
            
        }


        public List<ReportMemoDetailVM> reportMemoDetailVMs = new List<ReportMemoDetailVM>();

        public IList loadmemodetail()
        {
            
            
            var memoDetails = memo.MemoDetails;
            foreach (var memod in memoDetails)
            {
                reportMemoDetailVMs.Add(new ReportMemoDetailVM( memod));
            }

            return reportMemoDetailVMs;
        }
    }


}

