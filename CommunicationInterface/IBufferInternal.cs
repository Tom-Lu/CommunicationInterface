using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Communication.Interface
{
    /// <summary>
    /// Buffer interface for internal use
    /// </summary>
    public interface IBufferInternal
    {

        Stream BufferStream { get; }

        /// <summary>
        /// Clear all buffer content
        /// </summary>
        void Clear();

        /// <summary>
        /// Clear if buffer is empty
        /// </summary>
        bool IsEmpty();

        /// <summary>
        /// Return byte sequence for current buffer content
        /// </summary>
        /// <returns>Byte sequence</returns>
        byte[] GetBytes();

        /// <summary>
        /// Copy buffer content from source buffer
        /// </summary>
        /// <param name="source">source buffer</param>
        void Copy(IBufferInternal source);

        /// <summary>
        /// Copy string content from source
        /// </summary>
        /// <param name="source">string source</param>
        void Copy(StringBuilder source);

        /// <summary>
        /// Append source buffer content to current buffer
        /// </summary>
        /// <param name="source">source buffer</param>
        void Append(IBufferInternal source);

        /// <summary>
        /// Append byte data to current buffer
        /// </summary>
        /// <param name="data">byte data</param>
        void Append(byte data);
    }
}
