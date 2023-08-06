using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGV.StockControl.Library
{

    public static class Tools
    {
        public static string FirstCharToUpperOrDefault(this string input) =>
                input switch
                {
                    null => "",
                    "" => "",
                    _ => string.Concat(input[0].ToString().ToUpper(), input.AsSpan(1))
                };
    }
}
