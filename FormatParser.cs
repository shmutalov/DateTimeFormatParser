using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using DateTimeFormatParser.Constants;
using DateTimeFormatParser.Enums;
using DateTimeFormatParser.Models;
using JetBrains.Annotations;

namespace DateTimeFormatParser
{
    public static class FormatParser
    {
        private static readonly object SyncRoot = new object();
        private static readonly IDictionary<DateTimeFormatType, string> TokenToFormatMap;
        private static readonly IDictionary<string, DateTimeFormatType> FormatToTokenMap;

        static FormatParser()
        {
            TokenToFormatMap = new ConcurrentDictionary<DateTimeFormatType, string>();
            FormatToTokenMap = new ConcurrentDictionary<string, DateTimeFormatType>();

            lock (SyncRoot)
            {
                TokenToFormatMap[DateTimeFormatType.Year] = FormatParts.Year;
                TokenToFormatMap[DateTimeFormatType.Month] = FormatParts.Month;
                TokenToFormatMap[DateTimeFormatType.ShortMonthName] = FormatParts.ShortMonthName;
                TokenToFormatMap[DateTimeFormatType.LongMonthName] = FormatParts.LongMonthName;
                TokenToFormatMap[DateTimeFormatType.Day] = FormatParts.Day;
                TokenToFormatMap[DateTimeFormatType.Hour] = FormatParts.Hour;
                TokenToFormatMap[DateTimeFormatType.AmPmHour] = FormatParts.AmPmHour;
                TokenToFormatMap[DateTimeFormatType.Minute] = FormatParts.Minute;
                TokenToFormatMap[DateTimeFormatType.Second] = FormatParts.Second;
                TokenToFormatMap[DateTimeFormatType.Millisecond] = FormatParts.Millisecond;
                TokenToFormatMap[DateTimeFormatType.AmPm] = FormatParts.AmPm;

                FormatToTokenMap[FormatParts.Year] = DateTimeFormatType.Year;
                FormatToTokenMap[FormatParts.Month] = DateTimeFormatType.Month;
                FormatToTokenMap[FormatParts.ShortMonthName] = DateTimeFormatType.ShortMonthName;
                FormatToTokenMap[FormatParts.LongMonthName] = DateTimeFormatType.LongMonthName;
                FormatToTokenMap[FormatParts.Day] = DateTimeFormatType.Day;
                FormatToTokenMap[FormatParts.Hour] = DateTimeFormatType.Hour;
                FormatToTokenMap[FormatParts.AmPmHour] = DateTimeFormatType.AmPmHour;
                FormatToTokenMap[FormatParts.Minute] = DateTimeFormatType.Minute;
                FormatToTokenMap[FormatParts.Second] = DateTimeFormatType.Second;
                FormatToTokenMap[FormatParts.Millisecond] = DateTimeFormatType.Millisecond;
                FormatToTokenMap[FormatParts.AmPm] = DateTimeFormatType.AmPm;
            }
        }

        /// <summary>
        /// Get next date part token from format string
        /// </summary>
        /// <param name="format">Datetime format string</param>
        /// <param name="startPosition">Initial position</param>
        /// <returns></returns>
        private static DateTimeFormatToken NextToken([NotNull] string format, int startPosition)
        {
            if (startPosition == format.Length)
                return null;

            var result = new DateTimeFormatToken
            {
                FormatType = DateTimeFormatType.Delimiter,
            };

            var ch = format[startPosition].ToString();

            if (FormatToTokenMap.ContainsKey(ch))
            {
                var type = FormatToTokenMap[ch];
                var length = 1;

                result.Index = startPosition;
                result.FormatType = type;

                switch (type)
                {
                    case DateTimeFormatType.Month:
                        {
                            if (format.Substring(startPosition).StartsWith(FormatParts.LongMonthName))
                            {
                                result.FormatType = DateTimeFormatType.LongMonthName;
                                length = 5;
                            }
                            else if (format.Substring(startPosition).StartsWith(FormatParts.ShortMonthName))
                            {
                                result.FormatType = DateTimeFormatType.ShortMonthName;
                                length = 3;
                            }
                            else
                            {
                                DateTimeFormatToken token;

                                while ((token = NextToken(format, ++startPosition)) != null)
                                {
                                    if (token.FormatType != type)
                                        break;

                                    length++;
                                }
                            }
                        }
                        break;
                    default:
                        {
                            DateTimeFormatToken token;

                            while ((token = NextToken(format, ++startPosition)) != null)
                            {
                                if (token.FormatType != type)
                                    break;

                                length++;
                            }
                        }
                        break;
                }

                result.Length = length;
                result.Text = format.Substring(result.Index, length);
            }
            else
            {
                result.Index = startPosition;
                result.Length = 1;
                result.Text = ch;
            }
            
            return result;
        }

        /// <summary>
        /// Parses datetime format string
        /// </summary>
        /// <param name="format">Datetime format string</param>
        /// <returns>DateTimeFormat will be returned on successful parse, otherwise null</returns>
        public static DateTimeFormat Parse([NotNull] string format)
        {
            if (format.Length == 0)
                return null;

            var result = new DateTimeFormat();

            var startIndex = 0;
            DateTimeFormatToken token;

            while ((token = NextToken(format, startIndex)) != null)
            {
                if (token.FormatType == DateTimeFormatType.Hour)
                    result.Is24HoursInTime = true;

                result.Tokens.Add(token);

                startIndex += token.Length;
            }

            return result.Tokens.Count == 0 ? null : result;
        }

        /// <summary>
        /// Maps format to new datetime format from map dictionary
        /// </summary>
        /// <param name="format">Source format</param>
        /// <param name="map">Format dictionary to map</param>
        /// <returns>On successful map returns rebuilded string, otherwise empty string will be returned</returns>
        public static string MapToFormat(DateTimeFormat format, Dictionary<DateTimeFormatType, Dictionary<int, string>> map)
        {
            return string.Empty;
        }
    }
}
