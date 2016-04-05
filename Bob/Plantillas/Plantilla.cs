using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bob.Plantillas
{
    class Plantilla
    {
        private string Nombre;
        private FileStream[] Flujos;

        public Plantilla(string pNombre)
        {
            using (var fileStream = new FileStream(@"c:\file.txt", FileMode.CreateNew))
            {
                // write to just created file
            }
            this.Nombre = pNombre;
            
        }

        public Plantilla(string pNombre, string codigoBase)
        {
        }
    }
}
