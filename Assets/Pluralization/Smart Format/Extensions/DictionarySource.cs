using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Localization.SmartFormat.Core.Extensions;

namespace UnityEngine.Localization.SmartFormat.Extensions
{
    /// <summary>
    /// Provides the ability to extract an object with a matching Key from an
    /// [IDictionary](https://docs.microsoft.com/en-us/dotnet/api/system.collections.idictionary) or
    /// [IDictionary&lt;string, object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.idictionary-2).
    /// </summary>
    [Serializable]
    public class DictionarySource : ISource
    {
        /// <summary>
        /// Creates a new instance of the formatter.
        /// </summary>
        /// <param name="formatter">The formatter that the source will be added to.</param>
        public DictionarySource(SmartFormatter formatter)
        {
            // Add some special info to the parser:
            formatter.Parser.AddAlphanumericSelectors(); // (A-Z + a-z)
            formatter.Parser.AddAdditionalSelectorChars("_");
            formatter.Parser.AddOperators(".");
        }

        /// <inheritdoc/>
        public bool TryEvaluateSelector(ISelectorInfo selectorInfo)
        {
            var current = selectorInfo.CurrentValue;
            var selector = selectorInfo.SelectorText.ToString();

            // See if current is a IDictionary and contains the selector:
            var rawDict = current as IDictionary;
            if (rawDict != null)
                foreach (DictionaryEntry entry in rawDict)
                {
                    var key = entry.Key as string ?? entry.Key.ToString();

                    if (key.Equals(selector, selectorInfo.FormatDetails.Settings.GetCaseSensitivityComparison()))
                    {
                        selectorInfo.Result = entry.Value;
                        return true;
                    }
                }

            // this check is for dynamics and generic dictionaries
            if (current is IDictionary<string, object> dict)
            {
                var val = dict.FirstOrDefault(x =>
                    x.Key.Equals(selector, selectorInfo.FormatDetails.Settings.GetCaseSensitivityComparison())).Value;
                if (val != null)
                {
                    selectorInfo.Result = val;
                    return true;
                }
            }

            return false;
        }
    }
}
