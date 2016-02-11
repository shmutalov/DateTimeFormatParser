using System;
using NUnit.Framework;
using DateTimeFormatParser;
using DateTimeFormatParser.Enums;

namespace DateTimeFormatParserTest
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestParsing()
        {
            var format = FormatParser.Parse("yyyy-MM Mon, Month, dd hh:mm:ss.xxxxxx");

            Assert.IsNotNull(format);

            Assert.IsFalse(format.Is24HoursInTime);

            Console.WriteLine("Tokens count: {0}", format.Tokens.Count);
            Assert.AreEqual(19, format.Tokens.Count);

            var tokenId = 0;

            // year
            Assert.AreEqual(DateTimeFormatType.Year, format.Tokens[tokenId].FormatType);
            Assert.AreEqual("yyyy", format.Tokens[tokenId].Text);
            Assert.AreEqual(0, format.Tokens[tokenId].Index);
            Assert.AreEqual(4, format.Tokens[tokenId].Length);
            tokenId++;

            // [minus] delimiter
            Assert.AreEqual(DateTimeFormatType.Delimiter, format.Tokens[tokenId].FormatType);
            Assert.AreEqual("-", format.Tokens[tokenId].Text);
            Assert.AreEqual(4, format.Tokens[tokenId].Index);
            Assert.AreEqual(1, format.Tokens[tokenId].Length);
            tokenId++;

            // month
            Assert.AreEqual(DateTimeFormatType.Month, format.Tokens[tokenId].FormatType);
            Assert.AreEqual("MM", format.Tokens[tokenId].Text);
            Assert.AreEqual(5, format.Tokens[tokenId].Index);
            Assert.AreEqual(2, format.Tokens[tokenId].Length);
            tokenId++;

            // [space] delimiter
            Assert.AreEqual(DateTimeFormatType.Delimiter, format.Tokens[tokenId].FormatType);
            Assert.AreEqual(" ", format.Tokens[tokenId].Text);
            Assert.AreEqual(7, format.Tokens[tokenId].Index);
            Assert.AreEqual(1, format.Tokens[tokenId].Length);
            tokenId++;

            // short month
            Assert.AreEqual(DateTimeFormatType.ShortMonthName, format.Tokens[tokenId].FormatType);
            Assert.AreEqual("Mon", format.Tokens[tokenId].Text);
            Assert.AreEqual(8, format.Tokens[tokenId].Index);
            Assert.AreEqual(3, format.Tokens[tokenId].Length);
            tokenId++;

            // [comma] delimiter
            Assert.AreEqual(DateTimeFormatType.Delimiter, format.Tokens[tokenId].FormatType);
            Assert.AreEqual(",", format.Tokens[tokenId].Text);
            Assert.AreEqual(11, format.Tokens[tokenId].Index);
            Assert.AreEqual(1, format.Tokens[tokenId].Length);
            tokenId++;

            // [space] delimiter
            Assert.AreEqual(DateTimeFormatType.Delimiter, format.Tokens[tokenId].FormatType);
            Assert.AreEqual(" ", format.Tokens[tokenId].Text);
            Assert.AreEqual(12, format.Tokens[tokenId].Index);
            Assert.AreEqual(1, format.Tokens[tokenId].Length);
            tokenId++;

            // long month
            Assert.AreEqual(DateTimeFormatType.LongMonthName, format.Tokens[tokenId].FormatType);
            Assert.AreEqual("Month", format.Tokens[tokenId].Text);
            Assert.AreEqual(13, format.Tokens[tokenId].Index);
            Assert.AreEqual(5, format.Tokens[tokenId].Length);
            tokenId++;

            // [comma] delimiter
            Assert.AreEqual(DateTimeFormatType.Delimiter, format.Tokens[tokenId].FormatType);
            Assert.AreEqual(",", format.Tokens[tokenId].Text);
            Assert.AreEqual(18, format.Tokens[tokenId].Index);
            Assert.AreEqual(1, format.Tokens[tokenId].Length);
            tokenId++;

            // [space] delimiter
            Assert.AreEqual(DateTimeFormatType.Delimiter, format.Tokens[tokenId].FormatType);
            Assert.AreEqual(" ", format.Tokens[tokenId].Text);
            Assert.AreEqual(19, format.Tokens[tokenId].Index);
            Assert.AreEqual(1, format.Tokens[tokenId].Length);
            tokenId++;

            // day
            Assert.AreEqual(DateTimeFormatType.Day, format.Tokens[tokenId].FormatType);
            Assert.AreEqual("dd", format.Tokens[tokenId].Text);
            Assert.AreEqual(20, format.Tokens[tokenId].Index);
            Assert.AreEqual(2, format.Tokens[tokenId].Length);
            tokenId++;

            // [space] delimiter
            Assert.AreEqual(DateTimeFormatType.Delimiter, format.Tokens[tokenId].FormatType);
            Assert.AreEqual(" ", format.Tokens[tokenId].Text);
            Assert.AreEqual(22, format.Tokens[tokenId].Index);
            Assert.AreEqual(1, format.Tokens[tokenId].Length);
            tokenId++;

            // hour
            Assert.AreEqual(DateTimeFormatType.AmPmHour, format.Tokens[tokenId].FormatType);
            Assert.AreEqual("hh", format.Tokens[tokenId].Text);
            Assert.AreEqual(23, format.Tokens[tokenId].Index);
            Assert.AreEqual(2, format.Tokens[tokenId].Length);
            tokenId++;

            // [doubledot] delimiter
            Assert.AreEqual(DateTimeFormatType.Delimiter, format.Tokens[tokenId].FormatType);
            Assert.AreEqual(":", format.Tokens[tokenId].Text);
            Assert.AreEqual(25, format.Tokens[tokenId].Index);
            Assert.AreEqual(1, format.Tokens[tokenId].Length);
            tokenId++;

            // minute
            Assert.AreEqual(DateTimeFormatType.Minute, format.Tokens[tokenId].FormatType);
            Assert.AreEqual("mm", format.Tokens[tokenId].Text);
            Assert.AreEqual(26, format.Tokens[tokenId].Index);
            Assert.AreEqual(2, format.Tokens[tokenId].Length);
            tokenId++;

            // [doubledot] delimiter
            Assert.AreEqual(DateTimeFormatType.Delimiter, format.Tokens[tokenId].FormatType);
            Assert.AreEqual(":", format.Tokens[tokenId].Text);
            Assert.AreEqual(28, format.Tokens[tokenId].Index);
            Assert.AreEqual(1, format.Tokens[tokenId].Length);
            tokenId++;

            // second
            Assert.AreEqual(DateTimeFormatType.Second, format.Tokens[tokenId].FormatType);
            Assert.AreEqual("ss", format.Tokens[tokenId].Text);
            Assert.AreEqual(29, format.Tokens[tokenId].Index);
            Assert.AreEqual(2, format.Tokens[tokenId].Length);
            tokenId++;

            // [dot] delimiter
            Assert.AreEqual(DateTimeFormatType.Delimiter, format.Tokens[tokenId].FormatType);
            Assert.AreEqual(".", format.Tokens[tokenId].Text);
            Assert.AreEqual(31, format.Tokens[tokenId].Index);
            Assert.AreEqual(1, format.Tokens[tokenId].Length);
            tokenId++;

            // millisecond
            Assert.AreEqual(DateTimeFormatType.Millisecond, format.Tokens[tokenId].FormatType);
            Assert.AreEqual("xxxxxx", format.Tokens[tokenId].Text);
            Assert.AreEqual(32, format.Tokens[tokenId].Index);
            Assert.AreEqual(6, format.Tokens[tokenId].Length);
            tokenId++;

            Assert.IsTrue(tokenId == format.Tokens.Count);
        }

        [Test]
        public void TestMapping()
        {
            Assert.Fail();
        }
    }
}
