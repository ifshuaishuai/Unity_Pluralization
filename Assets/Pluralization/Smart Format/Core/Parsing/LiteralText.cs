using System;
using System.Globalization;
using UnityEngine.Localization.SmartFormat.Core.Settings;

namespace UnityEngine.Localization.SmartFormat.Core.Parsing
{
    /// <summary>
    /// Represents the literal text that is found
    /// in a parsed format string.
    /// </summary>
    public class LiteralText : FormatItem
    {
        public ReadOnlySpan<char> GetString()
        {
            return SmartSettings.ConvertCharacterStringLiterals
                ? ConvertCharacterLiteralsToUnicode()
                : RawText;
        }
        
        private ReadOnlySpan<char> ConvertCharacterLiteralsToUnicode()
        {
            var source = RawText;

            if (source.Length == 0) return source;

            // No character literal escaping - nothing to do
            if (source[0] != Parser.m_CharLiteralEscapeChar)
                return source;

            // The string length should be 2: escape character \ and literal character
            if (source.Length < 2) throw new ArgumentException($"Missing escape sequence in literal: \"{source.ToString()}\"");

            char c;
            switch (source[1])
            {
                case '\'':
                    c = '\'';
                    break;
                case '\"':
                    c = '\"';
                    break;
                case '\\':
                    c = '\\';
                    break;
                case '0':
                    c = '\0';
                    break;
                case 'a':
                    c = '\a';
                    break;
                case 'b':
                    c = '\b';
                    break;
                case 'f':
                    c = '\f';
                    break;
                case 'n':
                    c = '\n';
                    break;
                case 'r':
                    c = '\r';
                    break;
                case 't':
                    c = '\t';
                    break;
                case 'v':
                    c = '\v';
                    break;
                case 'u':
                    ReadOnlySpan<char> subSpan = source.Slice(2, source.Length - 2);
                    if (!int.TryParse(subSpan, NumberStyles.HexNumber, null, out var result))
                        throw new ArgumentException($"Failed to parse unicode escape sequence in literal: \"{source.ToString()}\"");
                    c = (char)result;
                    break;
                default:
                    throw new ArgumentException($"Unrecognized escape sequence in literal: \"{source.ToString()}\"");
            }

            return c.ToString();
        }
    }
}
