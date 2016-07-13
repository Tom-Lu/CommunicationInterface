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
        private MemoryStream buffer_stream = null;
        internal Buffer(int Capacity)
        {
            buffer_stream = new MemoryStream(Capacity);
            RegexMatchOption = RegexOptions.Multiline;
        }

        #region IBufferInternal

        public Stream BufferStream
        {
            get
            {
                return buffer_stream;
            }
        }

        public RegexOptions RegexMatchOption { get; set; }

        public bool IsEmpty()
        {
            return buffer_stream.Length <= 0;
        }

        public byte[] GetBytes()
        {
            return buffer_stream.GetBuffer();
        }

        public void Append(IBufferInternal source)
        {
            if (source != null)
            {
                source.BufferStream.Position = 0; // Importent
                source.BufferStream.CopyTo(buffer_stream);
            }
        }

        public void Append(byte data)
        {
            buffer_stream.WriteByte(data);
        }

        public void Copy(IBufferInternal source)
        {
            if (source != null)
            {
                buffer_stream.SetLength(0);
                source.BufferStream.Position = 0; // Importent
                source.BufferStream.CopyTo(buffer_stream);
            }
        }

        public void Copy(StringBuilder source)
        {
            if (source != null)
            {
                byte[] source_array = Encoding.ASCII.GetBytes(source.ToString());
                buffer_stream.SetLength(0);
                buffer_stream.Write(source_array, 0, source_array.Length);
            }
        }

        #endregion

        #region IBuffer

        public void Clear()
        {
            buffer_stream = new MemoryStream(buffer_stream.Capacity);
        }

        override public string ToString()
        {
            byte[] temp_buffer = new byte[buffer_stream.Length];
            Array.Copy(buffer_stream.GetBuffer(), temp_buffer, temp_buffer.Length);
            return Encoding.ASCII.GetString(temp_buffer);
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
            string BufferString = ToString();

            int index = BufferString.IndexOf(Lookup);
            if (index != -1)
            {
                string temp_string = BufferString.Substring(index + Lookup.Length);
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

            Match RegMatch = Regex.Match(buffer_content, Pattern, RegexMatchOption);
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

        public bool Extract(string BeginText, string EndText, int Index, out string OutputString)
        {
            OutputString = string.Empty;
            string buffer_content = ToString();
            if (string.IsNullOrEmpty(buffer_content) == false)
            {
                // Search Begin
                int start = -1;
                // search with number of occurs
                for (int i = 1; i <= Index; i++)
                    start = buffer_content.IndexOf(BeginText, start + 1);

                if (start < 0)
                    return false;
                start += BeginText.Length;


                // Search End
                if (string.IsNullOrEmpty(EndText))
                {
                    OutputString = buffer_content.Substring(start);
                    return true;
                }

                int end = buffer_content.IndexOf(EndText, start);
                if (end < 0)
                {
                    return false;
                }

                end -= start;

                OutputString = buffer_content.Substring(start, end);
                // End Final
                return true;
            }
            else
            {
                return false;
            }

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
