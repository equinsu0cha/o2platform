﻿using System;
using System.Diagnostics;
using System.IO;

namespace O2.Kernel.O2CmdShell
{
    public class ShellIO
    {
        public TextReader inputTextReader;
        public TextWriter outputTextWriter;
        public string lastExecutionResult = "";

        public ShellIO()
        {
            Console.OpenStandardInput();
            Console.OpenStandardOutput();
            inputTextReader = Console.In;
            outputTextWriter = Console.Out;
        }
        public ShellIO(TextWriter _outputTextWriter) : this()
        {
            outputTextWriter = _outputTextWriter;
        }


        public void write(string textWithFormat, params object[] formatArguments)
        {
            try
            {
                outputTextWriter.Write(string.Format(textWithFormat, formatArguments));
            }
            catch (Exception ex)
            {
                Trace.Write("Error in ShellIO.write: " + textWithFormat + " : " + ex.Message);
            }
        }

        public void writeLine(string textWithFormat, params object[] formatArguments)
        {
            try
            {
                outputTextWriter.WriteLine(string.Format(textWithFormat, formatArguments));
            }
            catch (Exception ex)
            {
                Trace.Write("Error in ShellIO.writeLine: " + textWithFormat + " : " + ex.Message);
            }
        }

        public void writeLineWithPreAndPostNewLine(string textWithFormat, params object[] formatArguments)
        {
            try
            {
                outputTextWriter.WriteLine();
                outputTextWriter.WriteLine(string.Format(textWithFormat, formatArguments));
                outputTextWriter.WriteLine();
            }
            catch (Exception ex)
            {
                Trace.Write("Error in ShellIO.writeLine: " + textWithFormat + " : " + ex.Message);
            }
        }

        /*public void writeLine(string value)
        {
            outputTextReader.WriteLine(value);

        }*/

        public string readLine()
        {
            return inputTextReader.ReadLine();
        }
        
    }
}