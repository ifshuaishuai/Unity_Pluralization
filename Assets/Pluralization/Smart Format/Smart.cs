using System;
using UnityEngine.Localization.SmartFormat.Extensions;

namespace UnityEngine.Localization.SmartFormat
{
    /// <summary>
    /// This class holds a Default instance of the SmartFormatter.
    /// The default instance has all extensions registered.
    /// </summary>
    public static class Smart
    {
        private static object[] s_ArrayCache1 = new object[1];
        private static object[] s_ArrayCache2 = new object[2];
        private static object[] s_ArrayCache3 = new object[3];
        private static object[] s_ArrayCache4 = new object[4];
        private static object[] s_ArrayCache5 = new object[5];
        private static object[] s_ArrayCache6 = new object[6];
        private static object[] s_ArrayCache7 = new object[7];
        private static object[] s_ArrayCache8 = new object[8];
        
            
        /// <inheritdoc cref="SmartFormatter.Format(string, object[])"/>
        public static string Format(string format, params object[] args)
        {
            return Default.Format(format, args);
        }

        /// <inheritdoc cref="SmartFormatter.Format(IFormatProvider, string, object[])"/>
        public static string Format<T1>(IFormatProvider provider, string format, T1 arg1)
        {
            s_ArrayCache1[0] = arg1;
            string result = Default.Format(provider, format, s_ArrayCache1);
            
            Array.Clear(s_ArrayCache1, 0, s_ArrayCache1.Length);
            return result;
        }
        
        public static string Format<T1, T2>(IFormatProvider provider, string format, T1 arg1, T2 arg2)
        {
            s_ArrayCache2[0] = arg1;
            s_ArrayCache2[1] = arg2;
            string result = Default.Format(provider, format, s_ArrayCache2);
            
            Array.Clear(s_ArrayCache2, 0, s_ArrayCache2.Length);
            return result;
        }
        
        
        public static string Format<T1, T2, T3>(IFormatProvider provider, string format, T1 arg1, T2 arg2, T3 arg3)
        {
            s_ArrayCache3[0] = arg1;
            s_ArrayCache3[1] = arg2;
            s_ArrayCache3[2] = arg3;
            string result = Default.Format(provider, format, s_ArrayCache3);
            
            Array.Clear(s_ArrayCache3, 0, s_ArrayCache3.Length);
            return result;
        }
        
        public static string Format<T1, T2, T3, T4>(IFormatProvider provider, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            s_ArrayCache4[0] = arg1;
            s_ArrayCache4[1] = arg2;
            s_ArrayCache4[2] = arg3;
            s_ArrayCache4[3] = arg4;
            string result = Default.Format(provider, format, s_ArrayCache4);
            
            Array.Clear(s_ArrayCache4, 0, s_ArrayCache4.Length);
            return result;
        }
        
        public static string Format<T1, T2, T3, T4, T5>(IFormatProvider provider, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            s_ArrayCache5[0] = arg1;
            s_ArrayCache5[1] = arg2;
            s_ArrayCache5[2] = arg3;
            s_ArrayCache5[3] = arg4;
            s_ArrayCache5[4] = arg5;
            string result = Default.Format(provider, format, s_ArrayCache5);
            
            Array.Clear(s_ArrayCache5, 0, s_ArrayCache5.Length);
            return result;
        }
        
        public static string Format<T1, T2, T3, T4, T5, T6>(IFormatProvider provider, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
        {
            s_ArrayCache6[0] = arg1;
            s_ArrayCache6[1] = arg2;
            s_ArrayCache6[2] = arg3;
            s_ArrayCache6[3] = arg4;
            s_ArrayCache6[4] = arg5;
            s_ArrayCache6[5] = arg6;
            string result = Default.Format(provider, format, s_ArrayCache6);
            
            Array.Clear(s_ArrayCache6, 0, s_ArrayCache6.Length);
            return result;
        }
        
        public static string Format<T1, T2, T3, T4, T5, T6, T7>(IFormatProvider provider, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
        {
            s_ArrayCache7[0] = arg1;
            s_ArrayCache7[1] = arg2;
            s_ArrayCache7[2] = arg3;
            s_ArrayCache7[3] = arg4;
            s_ArrayCache7[4] = arg5;
            s_ArrayCache7[5] = arg6;
            s_ArrayCache7[6] = arg7;
            string result = Default.Format(provider, format, s_ArrayCache7);
            
            Array.Clear(s_ArrayCache7, 0, s_ArrayCache7.Length);
            return result;
        }
        
        public static string Format<T1, T2, T3, T4, T5, T6, T7, T8>(IFormatProvider provider, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
        {
            s_ArrayCache8[0] = arg1;
            s_ArrayCache8[1] = arg2;
            s_ArrayCache8[2] = arg3;
            s_ArrayCache8[3] = arg4;
            s_ArrayCache8[4] = arg5;
            s_ArrayCache8[5] = arg6;
            s_ArrayCache8[6] = arg7;
            s_ArrayCache8[7] = arg8;
            string result = Default.Format(provider, format, s_ArrayCache8);
            
            Array.Clear(s_ArrayCache8, 0, s_ArrayCache8.Length);
            return result;
        }

        /// <inheritdoc cref="Format(string, object[])"/>
        public static string Format(string format, object arg0, object arg1, object arg2)
        {
            return Format(format, new[] { arg0, arg1, arg2 });
        }

        /// <inheritdoc cref="Format(string, object[])"/>
        public static string Format(string format, object arg0, object arg1)
        {
            return Format(format, new[] { arg0, arg1 });
        }

        /// <inheritdoc cref="SmartFormatter.Format(string, object[])"/>
        public static string Format(string format, object arg0)
        {
            return Default.Format(format, arg0); // call Default.Format in order to avoid infinite recursive method call
        }

        /// <summary>
        /// The default formatter that is used when no formatter is explicitly used.
        /// </summary>
        public static SmartFormatter Default { get; set; } = CreateDefaultSmartFormat();

        /// <summary>
        /// Creates a new formatter with default settings.
        /// </summary>
        /// <returns>The new formatter.</returns>
        public static SmartFormatter CreateDefaultSmartFormat()
        {
            // Register all default extensions here:
            var formatter = new SmartFormatter();
            // Add all extensions:
            // Note, the order is important; the extensions
            // will be executed in this order:

            var listFormatter = new ListFormatter(formatter);

            // sources for specific types must be in the list before ReflectionSource
            formatter.AddExtensions(
                listFormatter, // ListFormatter MUST be first
                // new PersistentVariablesSource(formatter),
                // new DictionarySource(formatter),
                // new ValueTupleSource(formatter),
                // new XmlSource(formatter),
                // new ReflectionSource(formatter),

                // The DefaultSource reproduces the string.Format behavior:
                new DefaultSource(formatter)
            );
            formatter.AddExtensions(
                listFormatter,
                new PluralLocalizationFormatter(),
                // new ConditionalFormatter(),
                // new TimeFormatter(),
                // new XElementFormatter(),
                // new ChooseFormatter(),
                // new SubStringFormatter(),
                // new IsMatchFormatter(),
                new DefaultFormatter()
            );

            return formatter;
        }
    }
}
