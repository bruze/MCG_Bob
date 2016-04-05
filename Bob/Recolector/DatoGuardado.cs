using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bob.Colector
{
    public struct DatoGuardado
    {
        /*TODO*/
        public Dictionary<int, List<double>> datos/* = new Dictionary<int,List<double>>()*/;

        public List<double> extraerSecuencia(int p)
        {
            return datos[p];
        }
        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        static public bool cargar()
        {
            return true;
        }
        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        public bool guardar()
        {
            return true;
        }
    }
}
