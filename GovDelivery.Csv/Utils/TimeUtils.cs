﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace GovDelivery.Csv.Utils
{
    public class TimeUtils
    {
        public const string DATE_FORMAT = "MM/dd/yyyy";
        public const string TIME_FORMAT = "hh:mm tt z";

        protected static Dictionary<string, string> TimeZoneUtcOffsetLookup = new Dictionary<string, string>
        {
            // Arranged east to west; daylight first, standard second:
            { "EDT", "-4" },
            { "EST", "-5" },
            { "CDT", "-5" },
            { "CST", "-6" },
            { "MDT", "-6" },
            { "MST", "-7" },
            { "PDT", "-7" },
            { "PST", "-8" },
            { "AKDT", "-8" },
            { "AKST", "-9" },
            { "HADT", "-9" },
            { "HAST", "-10" },
        };

        public static string ReplaceTimeZoneWithUtcOffset(string dateString) => 
            TimeZoneUtcOffsetLookup.Aggregate(dateString, (ds, kvp) => ds.Replace(kvp.Key, kvp.Value));


        /// <summary>
        /// GovDelivery date strings are not valid ISO date strings. Thus, they must be corrected before they can be imported.
        /// </summary>
        public static DateTime DateStringToDateTimeUtc(string dateString)
        {
            var correctedDateString = ReplaceTimeZoneWithUtcOffset(dateString);
            var localTime = DateTime.ParseExact(correctedDateString, $"{DATE_FORMAT} {TIME_FORMAT}", CultureInfo.CurrentCulture);
            return localTime.ToUniversalTime();
        }
        
    }

}