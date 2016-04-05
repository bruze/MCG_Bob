using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCGDelegator
{
    public class MCSDelegator
    {
        public Type tipo;
        public MCSDelegator()
        {
        }

        public static T crearDelegado<T>(object objetivoFuncion, string nombreFuncion) where T : class
        {
            Type tipoDelegado = typeof(T);
            Delegate d = Delegate.CreateDelegate(tipoDelegado, objetivoFuncion, nombreFuncion);

            return d as T;
        }

        public static T crearDelegadoParaMetodoEstatico<T>(Type tipoDelegado, Type claseTipo, string nombreFuncion) where T : class
        {
            var methodInfo = claseTipo.GetMethod(nombreFuncion);
            Delegate d = Delegate.CreateDelegate(typeof(T), methodInfo);

            return d as T;
        }
    }
}
