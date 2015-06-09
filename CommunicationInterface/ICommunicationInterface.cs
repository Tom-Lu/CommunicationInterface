using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Communication.Interface
{
    public delegate void OnWriteEvent(string WriteBuffer);
    public delegate void OnBufferUpdatedEvent(string ReadBuffer);

    /// <summary>
    /// Communication interface defination
    /// </summary>
    public interface ICommunicationInterface
    {
        /// <summary>
        /// Return whether current interface instance is opened or not. 
        /// </summary>
        bool IsOpened { get; }

        /// <summary>
        /// Stop token used by methods WriteWaitToken, WriteWaitTokenUntil, WriteLineWaitToken, WriteLineWaitTokenUntil, 
        /// those methods will stop reading operation when Stop Token is out come from interface.
        /// Usually this is the command line prompt.
        /// </summary>
        string StopToken { get; set; }

        /// <summary>
        /// Echo write content in communication viewr window
        /// </summary>
        bool WriteEcho { get; set; }

        /// <summary>
        /// Internal delay(seconds) between write and read operation
        /// </summary>
        double WriteReadInterval { get; set; }

        /// <summary>
        /// Internal delay(seconds) between WriteRead loop
        /// </summary>
        double WriteReadLoopInterval { get; set; }

        /// <summary>
        /// Characters for write line operation
        /// </summary>
        string LineFeed { get; set; }

        /// <summary>
        /// Default timeout(seconds) for all read operation when timeout is not specified
        /// </summary>
        double Timeout { get; set; }

        /// <summary>
        /// Friendly Name for represent current interface instance  
        /// </summary>
        string FriendlyName { get; }

        /// <summary>
        /// Configuration string used for interface initialization
        /// </summary>
        string ConfigString { get; }

        /// <summary>
        /// Buffer for last read operation
        /// </summary>
        IBuffer ReadBuffer { get; }

        /// <summary>
        /// Buffer for global read operation, contains all read content since interface opened
        /// </summary>
        IBuffer GlobalBuffer { get; }

        /// <summary>
        /// Read buffer content change event, trigger when read buffer changed/
        /// Used by communication indicator to display trace information
        /// </summary>
        event OnBufferUpdatedEvent BufferUpdatedHandler;

        /// <summary>
        /// Interface write event, trigger when write operation performed
        /// </summary>
        event OnWriteEvent WriteEventHandler;
 
        /// <summary>
        /// Open interface, various between different interface
        /// For serial port it means port open operation, for telnel it means establish socket connection
        /// </summary>
        void Open();

        /// <summary>
        /// Close interface
        /// </summary>
        void Close();

        /// <summary>
        /// Flushes data from interface
        /// </summary>
        void Flush();

        /// <summary>
        /// Read all output from interface, stop reading if no more out come from interface
        /// </summary>
        /// <returns>All content read from interface</returns>
        string ReadAll();

        /// <summary>
        /// Read all output from interface with specific time span
        /// </summary>
        /// <param name="Timespan">Timespan specific how long the reading operation will performed</param>
        /// <returns></returns>
        string ReadAll(double Timespan);

        /// <summary>
        /// Keep reading until the specific output present from interface, read operation will stop when default timeout reached
        /// </summary>
        /// <param name="StopFlag">Stop flag for current read operation</param>
        /// <returns></returns>
        string ReadUntil(string StopFlag);

        /// <summary>
        /// Write single byte to interface
        /// </summary>
        /// <param name="Data">Data to write</param>
        void Write(byte Data);

        /// <summary>
        /// Write byte array to interface
        /// </summary>
        /// <param name="Data">Data to write</param>
        void Write(byte[] Data);

        /// <summary>
        /// Write string to interface
        /// </summary>
        /// <param name="Command">command string to write</param>
        void Write(string Command);

        /// <summary>
        /// Write string to interface, line feed will append to command stirng
        /// </summary>
        /// <param name="Command">command string to write</param>
        void WriteLine(string Command);

        /// <summary>
        /// Write string to interface and read after specific delay time
        /// </summary>
        /// <param name="Command">command string to write</param>
        /// <param name="Delay">delay time for read operation</param>
        void WriteRead(string Command, double Delay);

        /// <summary>
        /// Write string with line feed to interface and read after specific delay time
        /// </summary>
        /// <param name="Command">command string to write</param>
        /// <param name="Delay">delay time for read operation</param>
        void WriteLineRead(string Command, double Delay);

        /// <summary>
        /// Write string to interface and wait for stop token output from interface
        /// Read operation will stop when default timeout reached
        /// </summary>
        /// <param name="Command">command string to write</param>
        /// <returns>Indicate if the Stop Token is present or not</returns>
        bool WriteWaitToken(string Command);

        /// <summary>
        /// Repeat write string to interface and wait for stop token output from interface
        /// </summary>
        /// <param name="Command">command string to write</param>
        /// <param name="Pattern">read operation will stop if this pattern string output from interface</param>
        /// <param name="Timeout">Read operation will stop when specific timeout reached</param>
        /// <returns>Indicate if the pattern string is present or not</returns>
        bool WriteWaitTokenUntil(string Command, string Pattern, double Timeout);

        /// <summary>
        /// Write string with line feed to interface and wait for stop token output from interface
        /// Read operation will stop when default timeout reached
        /// </summary>
        /// <param name="Command">command string to write</param>
        /// <returns>Indicate if the Stop Token is present or not</returns>
        bool WriteLineWaitToken(string Command);

        /// <summary>
        /// Repeat write string with line feed to interface and wait for stop token output from interface
        /// </summary>
        /// <param name="Command">command string to write</param>
        /// <param name="Pattern">read operation will stop if this pattern string output from interface</param>
        /// <param name="Timeout">read operation will stop when specific timeout reached</param>
        /// <returns>Indicate if the pattern string is present or not</returns>
        bool WriteLineWaitTokenUntil(string Command, string Pattern, double Timeout);

        /// <summary>
        /// Keep read operation until specific pattern output from interface or timeout reached
        /// </summary>
        /// <param name="Pattern">read operation will stop if this pattern string output from interface</param>
        /// <param name="Timeout">read operation will stop when specific timeout reached</param>
        /// <returns>Indicate if the pattern string is present or not</returns>
        bool WaitForString(string Pattern, double Timeout);

        /// <summary>
        /// Keep read operation until no output from interface within specific quiet time
        /// </summary>
        /// <param name="QuietTime">quiet time for this operation</param>
        /// <param name="Timeout">read operation will stop when specific timeout reached</param>
        /// <returns>Indicate if quite is reached or not</returns>
        bool WaitForQuiet(double QuietTime, double Timeout);
    }
}
