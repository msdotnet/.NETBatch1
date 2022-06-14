using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureConverter
{
   public static class DateTimeExtensions
   {
      public static string FormatToIndianStandard(this DateTime dateTime)
      {
         return dateTime.ToString("dd/MM/yyyy");
      }
   }
}
