using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternalPortal.Models.Helpers
{
    public class OnlyDateConverter : IsoDateTimeConverter
    {
        public OnlyDateConverter()
        {
            DateTimeFormat = "yyyy-MM-dd";
        }
    }
}
