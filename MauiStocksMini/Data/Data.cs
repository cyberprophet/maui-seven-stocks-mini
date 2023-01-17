using Newtonsoft.Json;

using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace DevExpress.Maui.Demo.Stocks
{
    public static class Data
    {
        static readonly string logicalName = "symbols";

        static IList<Symbol> symbols;

        public static IList<Symbol> Symbols
        {
            get
            {
                symbols ??= GetSymbols();

                return symbols;
            }
        }
        static IList<Symbol> GetSymbols()
        {
            List<Symbol> symbols = null;

            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(logicalName))
            {
                using (StreamReader reader = new(stream, Encoding.UTF8))
                {
                    var json = reader.ReadToEnd();

                    symbols = JsonConvert.DeserializeObject<List<Symbol>>(json);
                }
            }
            return symbols;
        }
    }
}