namespace ForensicLabProblem
{
    public class ForensicReport
    {
        private SortedDictionary<string,DateOnly> _reportMap;

        public ForensicReport()
        {
            _reportMap = new SortedDictionary<string, DateOnly>();
        }

        public void AddReportDetails(string reportingOfficerName,DateOnly date)
        {
            _reportMap.Add(reportingOfficerName,date);
        }

        public List<string> GetOfficersWhoFiledReportsOnDate(DateOnly date)
        {
            List<string> officersList = new List<string>();
            foreach(var report in _reportMap)
            {
                if(report.Value == date)
                    officersList.Add(report.Key);

            }
            return officersList;
        }

        public void Print(List<string> officers)
        {
            foreach(string officer in officers)
            {
                Console.WriteLine(officer);
            }
        }
    }
}