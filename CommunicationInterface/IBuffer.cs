using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Communication.Interface
{
    /// <summary>
    /// Communication buffer defination
    /// </summary>
    public interface IBuffer
    {
        /// <summary>
        /// RegexOptions for all Regular Expressions read function
        /// </summary>
        RegexOptions RegexMatchOption { get; set; }

        /// <summary>
        /// Clear all buffer content
        /// </summary>
        void Clear();

        /// <summary>
        /// Convert buffer content to string
        /// </summary>
        /// <returns>buffer content string</returns>
        string ToString();

        /// <summary>
        /// Check if buffer containts lookup string
        /// </summary>
        /// <param name="Lookup">lookup string</param>
        /// <returns>return true if buffer contains lookup string, otherwise return false</returns>
        bool Contains(string Lookup);

        /// <summary>
        ///  Check if buffer not containts lookup string
        /// </summary>
        /// <param name="Lookup">lookup string</param>
        /// <returns>return true if buffer not contains lookup string, otherwise return false</returns>
        bool DoesNotContain(string Lookup);

        /// <summary>
        ///  Check if buffer ends with lookup string
        /// </summary>
        /// <param name="Lookup">lookup string</param>
        /// <returns>return true if buffer ends with lookup string, otherwise return false</returns>
        bool EndsWith(string Lookup);

        /// <summary>
        /// Read string from buffer based on specified lookup string
        /// Example:
        ///           Buffer Content - software version: 1.0.1
        ///           Lookup - software version:
        ///           OutputString - 1.0.1
        /// </summary>
        /// <param name="Lookup">lookup string</param>
        /// <param name="OutputString">result string</param>
        /// <returns>true if succeed</returns>
        bool ReadString(string Lookup, out string OutputString);

        /// <summary>
        /// Read Int32 value from buffer based on specified lookup string
        /// Example:
        ///           Buffer Content - Temperature: 28 degree
        ///           Lookup - Temperature:
        ///           value - 28
        /// </summary>
        /// <param name="Lookup">lookup string</param>
        /// <param name="value">result Int32</param>
        /// <returns>true if succeed</returns>
        bool ReadInt32(string Lookup, out int value);

        /// <summary>
        /// Read Double value from buffer based on specified lookup string
        /// Example:
        ///           Buffer Content - Voltage: 3.3 volts
        ///           Lookup - Voltage:
        ///           value - 3.3
        /// </summary>
        /// <param name="Lookup">lookup string</param>
        /// <param name="value">result Double</param>
        /// <returns>true if succeed</returns>
        bool ReadDouble(string Lookup, out double value);

        /// <summary>
        /// Read Hex value from buffer based on specified lookup string
        /// Example:
        ///           Buffer Content - Data: 0xFF
        ///           Lookup - Data:
        ///           value - 0xFF
        /// </summary>
        /// <param name="Lookup">lookup string</param>
        /// <param name="value">result Hex</param>
        /// <returns>true if succeed</returns>
        bool ReadHex(string Lookup, out long value);

        /// <summary>
        /// Check if buffer content match input regular expression
        /// </summary>
        /// <param name="Regex">regular expression string</param>
        /// <returns>match result</returns>
        bool ContainsRegExp(string Regex);

        /// <summary>
        /// Check if buffer content not match input regular expression
        /// </summary>
        /// <param name="Regex">regular expression string</param>
        /// <returns>not match result</returns>
        bool DoesNotContainRegExp(string Regex);

        /// <summary>
        /// Read string from buffer based on input regular expression
        /// </summary>
        /// <param name="Regex">regular expression string</param>
        /// <param name="GroupName">regular expression group name for capture result</param>
        /// <param name="OutputString">output string</param>
        /// <returns>true if succeed</returns>
        bool ReadStringRegExp(string Regex, string GroupName, out string OutputString);

        /// <summary>
        /// Read Int32 value from buffer based on input regular expression
        /// </summary>
        /// <param name="Regex">regular expression string</param>
        /// <param name="GroupName">regular expression group name for capture result</param>
        /// <param name="value">Int32 value</param>
        /// <returns>true if succeed</returns>
        bool ReadInt32RegExp(string Regex, string GroupName, out int value);

        /// <summary>
        /// Read double value from buffer based on input regular expression
        /// </summary>
        /// <param name="Regex">regular expression string</param>
        /// <param name="GroupName">regular expression group name for capture result</param>
        /// <param name="value">Double value</param>
        /// <returns>true if succeed</returns>
        bool ReadDoubleRegExp(string Regex, string GroupName, out double value);

        /// <summary>
        /// Read hex value from buffer based on input regular expression
        /// </summary>
        /// <param name="Regex">regular expression string</param>
        /// <param name="GroupName">regular expression group name for capture result</param>
        /// <param name="value">Hex value</param>
        /// <returns>true if succeed</returns>
        bool ReadHexRegExp(string Regex, string GroupName, out long value);

        /// <summary>
        /// Extract buffer content based begin text and end text
        /// </summary>
        /// <param name="BeginText">Begin string to search for</param>
        /// <param name="EndText">End string to search for</param>
        /// <param name="Index">Specify number of begin string match for extract content, if no enough begin text found, then return false</param>
        /// <param name="OutputString">The extracted content per input</param>
        /// <returns>true if output string validate, false if unable extract any content per input</returns>
        bool Extract(string BeginText, string EndText, int Index, out string OutputString);

        /// <summary>
        /// Save buffer content to file
        /// </summary>
        /// <param name="FileName">file name</param>
        /// <param name="Overwrite">true - overwrite file if exist, false - append to file if exist</param>
        void Save(string FileName, bool Overwrite);
    }
}
