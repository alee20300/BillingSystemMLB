using Domin.Models;

namespace UwpApp.Report
{
    public class ReportService
    {
        public ReportService(Memo memo, bool isPriview)
        {

        }

        private bool _isPreview;

        public bool IsPreview { get => _isPreview; set => _isPreview = value; }


        public void MakeMemo()
        {

        }
    }
}
