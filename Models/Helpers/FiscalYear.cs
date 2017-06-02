using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternalPortal.Models.Helpers
{
    public class FiscalYear
    {
        public DateTime DateToProcess { get; set; }
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
    }
}

