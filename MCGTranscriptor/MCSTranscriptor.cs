using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCGTranscriptor
{
    public class MCSTranscriptor
    {
        //int indentacionActual = 0;

        public static void escribirArchivo()
        {
            string[] lines = { "using System;", "using System.Collections.Generic;", "using System.IO;", "using System.Linq;", "using System.Text;", "using System.Threading.Tasks;",
                               "", "namespace Bob", "{", "public struct Globals", "{", "public static void hola()", "{", "}", "}", "}"                            
                             };
            File.WriteAllLines(@"C:\Users\bgarelli\Desktop\Globals.cs", lines);
        }
    }
}
