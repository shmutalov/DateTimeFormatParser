using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeFormatParser.Enums
{
    /// <summary>
    /// Date part token type
    /// </summary>
    public enum DateTimeFormatType
    {
        /// <summary>
        /// 0000-9999
        /// </summary>
        Year,

        /// <summary>
        /// 01-12
        /// </summary>
        Month,

        /// <summary>
        /// Jan, Feb, 
        /// Mar, Apr, May, 
        /// Jun, Jul, Aug, 
        /// Sep, Oct, Nov, 
        /// Dec
        /// </summary>
        ShortMonthName,

        /// <summary>
        /// January, February, 
        /// March, April, May, 
        /// June, July, August, 
        /// September, October, November, 
        /// December
        /// </summary>
        LongMonthName,

        /// <summary>
        /// 01-31
        /// </summary>
        Day,

        /// <summary>
        /// 00-23
        /// </summary>
        Hour,

        /// <summary>
        /// 01-12
        /// </summary>
        AmPmHour,

        /// <summary>
        /// 00-59
        /// </summary>
        Minute,

        /// <summary>
        /// 00-59
        /// </summary>
        Second,

        /// <summary>
        /// 000000-999999
        /// </summary>
        Millisecond,

        /// <summary>
        /// AM, PM, A.M., P.M.
        /// </summary>
        AmPm,

        /// <summary>
        /// - [minus],   [space], . [dot], : [doubledot], , [comma], + [plus], / [slash], ' [quote]
        /// </summary>
        Delimiter,
    }
}
