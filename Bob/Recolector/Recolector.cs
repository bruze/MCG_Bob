using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bob.Colector
{
    class Recolector
    {
        public List<DatoGuardado> almacen = new List<DatoGuardado>();
        //public delegate void datosRecibidos(DatoGuardado dato);

        public void procesaDatos(/*object datos*/DatoGuardado dato)
        {
            ///TODO: autocreate DatoGuardado with anydata
            almacen.Add(dato);
        }
    }
}
