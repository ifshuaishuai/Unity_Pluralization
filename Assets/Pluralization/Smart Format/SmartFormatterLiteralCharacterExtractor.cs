using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Localization.SmartFormat.Core.Extensions;
using UnityEngine.Localization.SmartFormat.Core.Formatting;
using UnityEngine.Localization.SmartFormat.Core.Parsing;

namespace UnityEngine.Localization.SmartFormat
{
    internal class SmartFormatterLiteralCharacterExtractor : SmartFormatter
    {
        IEnumerable<char> m_Characters;

        public SmartFormatterLiteralCharacterExtractor(SmartFormatter parent)
        {
            Settings = parent.Settings;
            Parser = parent.Parser;
            SourceExtensions.AddRange(parent.SourceExtensions);
            FormatterExtensions.AddRange(parent.FormatterExtensions);
        }

        public IEnumerable<char> ExtractLiteralsCharacters(string value)
        {
            m_Characters = "";
            Format(value, null);
            return m_Characters;
        }

        public override void Format(FormattingInfo formattingInfo)
        {
            foreach (var item in formattingInfo.Format.Items)
            {
                if (item is LiteralText literalItem)
                {
                    m_Characters = m_Characters.Concat(item.ToEnumerable());
                    continue;
                }

                // Otherwise, the item must be a placeholder.
                var placeholder = (Placeholder)item;
                var childFormattingInfo = formattingInfo.CreateChild(placeholder);

                int startIndex = childFormattingInfo.Placeholder.FormatterNameIndex.Item1;
                int formatLength = childFormattingInfo.Placeholder.FormatterNameIndex.Item2;
                
                ReadOnlySpan<char> formatterName = childFormattingInfo.Placeholder.baseString.AsSpan(startIndex, formatLength);

                // Evaluate the named formatter (or, evaluate all "" formatters)
                foreach (var formatterExtension in FormatterExtensions)
                {
                    if (formatterExtension is IFormatterLiteralExtractor literalExtractor)
                    {
                        if (formatterExtension.Names.IsArrayContains(formatterName))
                        {
                            literalExtractor.WriteAllLiterals(childFormattingInfo);
                        }
                    }
                }
            }
        }
    }
}
