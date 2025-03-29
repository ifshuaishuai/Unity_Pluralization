using System;
using System.Text.RegularExpressions;

namespace UnityEngine.Localization
{
    static class StringExtensionMethods
    {
        static readonly Regex s_WhitespaceRegex = new Regex(@"\s+");

        public static string ReplaceWhiteSpaces(this string str, string replacement = "")
        {
            return s_WhitespaceRegex.Replace(str, replacement);
        }

        public static bool IsArrayContains(this string[] names, ReadOnlySpan<char> span)
        {
            foreach (string name in names)
            {
                bool isSame = MemoryExtensions.Equals(name, span, StringComparison.Ordinal);

                if (isSame)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
