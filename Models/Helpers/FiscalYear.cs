using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace InternalPortal.Models.Helpers
{
    public class FiscalYear
    {
        public DateTime DateToProcess { get; set; }
        public DateTime StartDateToProcess { get; set; }
        public DateTime EndDateToProcess { get; set; }
        public static string GetFiscalYearByDateTime(DateTime dateToProcess)
        {
            FiscalYear fy = new FiscalYear
            {
                DateToProcess = dateToProcess
            };
            
            var year = dateToProcess.Year;
            var month = dateToProcess.Month;
            var day = dateToProcess.Day;

            if (month >= 4 && month <= 12)
            {
                return year.ToString() + (year + 1).ToString();
            }
            if (month >= 1 && month <= 3)
            {
                return (year - 1).ToString() + year.ToString();
            }

            return null;

        }
        public static List<string> GetFiscalYearByDateTimeRange(DateTime startdate, DateTime enddate)
        {
            var year1 = FiscalYear.GetFiscalYearByDateTime(startdate);
            var year2 = FiscalYear.GetFiscalYearByDateTime(enddate);
            var intStartYear1 = Convert.ToInt32(year1.Substring(0, 4));
            var intStartYear2 = Convert.ToInt32(year2.Substring(0, 4));
            var intEndYear1 = Convert.ToInt32(year1.Substring(4, 4));            
            var intEndYear2 = Convert.ToInt32(year2.Substring(4, 4));
            var numberOfYears = intEndYear2 - intEndYear1;
            if (numberOfYears == 0)
            {
                numberOfYears = numberOfYears + 1;
            }
            List<string> fiscalYears = new List<string>();
            for (var i=0; i<=numberOfYears;i++)
            {
                string yr = (intStartYear1 + i).ToString() + (intEndYear1 + i).ToString();
                fiscalYears.Add(yr);
            }           
            return fiscalYears;            
        }        
    }
}

