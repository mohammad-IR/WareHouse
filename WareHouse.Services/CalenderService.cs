using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouse.Services
{
    public class CalenderService
    {
        public static DateTime ConvertPersianCalenderToGregorianCalender(DateTime persian)
        {

            return new DateTime(persian.Year, persian.Month, persian.Day, persian.Hour , persian.Minute, persian.Second,  new PersianCalendar());
        }
        
    }
}
