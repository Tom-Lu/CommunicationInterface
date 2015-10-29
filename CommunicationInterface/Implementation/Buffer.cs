using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Globalization;
using Communication.Interface;

namespace Communication.Interface.Implementation
{
    public class Buffer : IBufferInternal, IBuffer
    {
        private const string line_splitter = "\r\n";
        private byte[] buffer = null;
        private long index = 0;
        internal Buffer(int Capacity)
        {
            buffer = new byte[Capacity];
        }

        #region IBufferInternal

        public bool IsEmpty()
        {
            return index == 0;
        }

        public byte[] GetBytes()
        {
            if (index > 0)
            {
                byte[] result_array = new byte[index];
                Array.Copy(buffer, result_array, index);
                return result_array;
            }
            return null;
        }

        public void Append(IBufferInternal source)
        {
            byte[] source_array = source.GetBytes();
            if (source_array != null)
            {
                foreach (byte data in source_array)
                {
                    Append(data);
                }
            }
        }

        public void Append(byte data)
        {
            if (index == buffer.Length)
            {
                // buffer full, increase 1k size
                byte[] old_buffer = buffer;
                buffer = new byte[buffer.Length + 1024];
                Array.Copy(old_buffer, buffer, old_buffer.Length);
                old_buffer = null;
            }
            buffer[index++] = data;
        }

        public void Copy(IBufferInternal source)
        {
            byte[] source_array = source.GetBytes();
            if (source_array.Length > buffer.Length)
            {
                buffer = new byte[source_array.Length];
            }
            Array.Copy(source_array, buffer, source_array.Length);
            index = source_array.Length;
        }

        public void Copy(StringBuilder source)
        {
            byte[] source_array = Encoding.Default.GetBytes(source.ToString());
            if (source_array.Length > buffer.Length)
            {
                buffer = new byte[source_array.Length];
            }
            Array.Copy(source_array, buffer, source_array.Length);
            index = source_array.Length;
        }

        #endregion

        #region IBuffer

        public void Clear()
        {
            index = 0;
        }

        override public string ToString()
        {
            byte[] buffer_data = GetBytes();

            if (buffer_data != null)
            {
                return Encoding.Default.GetString(buffer_data);
            }

            return string.Empty;
        }

        public bool Contains(string Lookup)
        {
            return ToString().Contains(Lookup);
        }

        public bool DoesNotContain(string Lookup)
        {
            return !Contains(Lookup);
        }

        public bool EndsWith(string Lookup)
        {
            return ToString().EndsWith(Lookup);
        }

        public bool ReadString(string Lookup, out string OutputString)
        {
            bool status = false;
            OutputString = string.Empty;
            string buffer_content = ToString();

            int index = buffer_content.IndexOf(Lookup);
            if (index != -1)
            {
                string temp_string = buffer_content.Substring(index + Lookup.Length);
                string[] Lines = temp_string.Split(new string[] { line_splitter }, StringSplitOptions.RemoveEmptyEntries);
                if (Lines.Length > 0)
                {
                    string[] Words = Lines[0].Split(new char[] { ' ', ',', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    if (Words.Length > 0)
                    {
                        OutputString = Words[0];
                        status = true;
                    }
                }
            }

            return status;
        }

        public bool ReadInt32(string Lookup, out int value)
        {
            string value_string = string.Empty;
            value = -1;
            bool status = ReadString(Lookup, out value_string);
            
            if (status)
            {
                status = int.TryParse(value_string, out value);
            }

            return status;
        }

        public bool ReadDouble(string Lookup, out double value)
        {
            string value_string = string.Empty;
            value = -1;
            bool status = ReadString(Lookup, out value_string);

            if (status)
            {
                status = double.TryParse(value_string, out value);
            }

            return status;
        }

        public bool ReadHex(string Lookup, out long value)
        {
            string value_string = string.Empty;
            value = -1;
            bool status = ReadString(Lookup, out value_string);

            if (status)
            {
                status = long.TryParse(value_string, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out value); 
            }

            return status;
        }

        public bool ContainsRegExp(string Pattern)
        {
            return Regex.IsMatch(ToString(), Pattern);
        }

        public bool DoesNotContainRegExp(string Pattern)
        {
            return !ContainsRegExp(Pattern);
        }

        public bool ReadStringRegExp(string Pattern, string GroupName, out string OutputString)
        {
            bool status = false;
            OutputString = string.Empty;
            string buffer_content = ToString();

            Match RegMatch = Regex.Match(buffer_content, Pattern, RegexOptions.Multiline);
            if (RegMatch.Success)
            {
                Group MatchGroup = RegMatch.Groups[GroupName];
                if (MatchGroup != null)
                {
                    OutputString = MatchGroup.Value;
                    status = true;
                }
            }

            return status;
        }

        public bool ReadInt32RegExp(string Pattern, string GroupName, out int value)
        {
            string value_string = string.Empty;
            value = -1;
            bool status = ReadStringRegExp(Pattern, GroupName, out value_string);

            if (status)
            {
                status = int.TryParse(value_string, out value);
            }

            return status;
        }

        public bool ReadDoubleRegExp(string Pattern, string GroupName, out double value)
        {
            string value_string = string.Empty;
            value = -1;
            bool status = ReadStringRegExp(Pattern, GroupName, out value_string);

            if (status)
            {
                status = double.TryParse(value_string, out value);
            }

            return status;
        }

        public bool ReadHexRegExp(string Pattern, string GroupName, out long value)
        {
            string value_string = string.Empty;
            value = -1;
            bool status = ReadStringRegExp(Pattern, GroupName, out value_string);

            if (status)
            {
                status = long.TryParse(value_string, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out value);
            }

            return status;
        }

        public void Save(string FileName, bool Overwrite)
        {
            if (File.Exists(FileName) && Overwrite)
            {
                File.Delete(FileName);
            }

            File.AppendAllText(FileName, ToString());
        }

        #endregion

    }
}
