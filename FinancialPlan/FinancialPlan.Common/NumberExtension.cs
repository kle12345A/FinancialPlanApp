using Serilog;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPlan.Common
{
    public static class NumberExtension
    {
        public static int GetIntFromString(this string str)
        {
            try
            {
                var isTrue = int.TryParse(str, out var result);
                return isTrue ? result : int.MinValue;
            }
            catch (Exception ex)
            {
                Log.Information($"{MethodBase.GetCurrentMethod()}: {ex.Message} - {ex.StackTrace}");
                return int.MinValue;
            }
        }

        public static decimal GetDecimalFromString(this string str, decimal? defaulValue = null)
        {
            var defaultResult = defaulValue.HasValue ? defaulValue.Value : decimal.MinValue;
            if (!string.IsNullOrWhiteSpace(str))
            {
                return 0;
            }
            if (decimal.TryParse(str, NumberStyles.Float, CultureInfo.InvariantCulture, out decimal result))
            {
                return Decimal.Round(result, 28);
            }


            return defaultResult;
        }
    }
}
