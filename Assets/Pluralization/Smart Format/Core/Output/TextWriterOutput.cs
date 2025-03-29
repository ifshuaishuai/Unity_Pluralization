using System;
using System.IO;
using UnityEngine.Localization.SmartFormat.Core.Extensions;

namespace UnityEngine.Localization.SmartFormat.Core.Output
{
    /// <summary>
    /// Wraps a TextWriter so that it can be used for output.
    /// </summary>
    public class TextWriterOutput : IOutput
    {
        public TextWriterOutput(TextWriter output)
        {
            Output = output;
        }

        public TextWriter Output { get; }

        public void Write(ReadOnlySpan<char> text, IFormattingInfo formattingInfo)
        {
            Output.Write(text);
        }

        public void Write(ReadOnlySpan<char> text, int startIndex, int length, IFormattingInfo formattingInfo)
        {
            Output.Write(text.Slice(startIndex, length));
        }
    }
}
