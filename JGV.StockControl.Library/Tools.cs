using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGV.StockControl.Library
{

    public static class Tools
    {
        public static string FirstCharToUpperOrEmptyStringAsDefault(this string input) =>
                input switch
                {
                    null => "",
                    "" => "",
                    _ => string.Concat(input[0].ToString().ToUpper(), input.AsSpan(1))
                };
        public static decimal ExtractNumericValue(string currencyString)
        {
            CultureInfo cultureInfo = CultureInfo.GetCultureInfo("pt-BR");
            NumberFormatInfo nfi = cultureInfo.NumberFormat;

            // Remove any non-numeric characters (like currency symbols, commas, etc.)
            string numericPart = string.Concat(currencyString.Where(c => char.IsDigit(c) || c == nfi.CurrencyDecimalSeparator[0]));

            // Parse the numeric value
            decimal numericValue;
            decimal.TryParse(numericPart, NumberStyles.Any, nfi, out numericValue);

            return numericValue;
        }
        public static string ExtractCurrencyString(decimal value)
        => value.ToString("C", new CultureInfo("pt-BR"));
    }
}
