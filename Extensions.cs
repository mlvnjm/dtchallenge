using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace DealerTrack
{
    public static class Extensions
    {
        public static string FormatPriceToDisplay(this decimal price)
        {
            return $"{new RegionInfo("en-CA").ISOCurrencySymbol} {price.ToString("C", CultureInfo.CreateSpecificCulture("en-CA"))}";
        }

        public static string FormatDateToDisplay(this DateTime date)
        {
            return date.ToString(@"MM\/dd\/yyyy");
        }
    }
}
