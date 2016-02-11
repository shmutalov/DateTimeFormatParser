using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DateTimeFormatParser.Enums;

namespace DateTimeFormatParser.Models
{
    /// <summary>
    /// Date part token
    /// </summary>
    public class DateTimeFormatToken
    {
        /// <summary>
        /// Token type
        /// </summary>
        public DateTimeFormatType FormatType { get; set; }

        /// <summary>
        /// Token start index
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Token length
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// Token source text
        /// </summary>
        public string Text { get; set; }
    }
}
