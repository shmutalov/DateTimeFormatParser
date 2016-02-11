using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeFormatParser.Models
{
    /// <summary>
    /// Date time format info
    /// </summary>
    public class DateTimeFormat
    {
        /// <summary>
        /// Is time 24-hour based or not
        /// </summary>
        public bool Is24HoursInTime { get; set; }

        /// <summary>
        /// Format token list
        /// </summary>
        public List<DateTimeFormatToken> Tokens { get; } = new List<DateTimeFormatToken>();
    }
}
