using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bob
{
    class Escriba
    {
        private static volatile Escriba instancia;
        private Escriba(){}
        public static Escriba Instanciar
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new Escriba();
                }

                return instancia;
            }
        }

        public bool generaArchivo()
        {
            
            return false;
        }
    }
}
