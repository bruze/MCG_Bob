using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
//////////////////////////////////
using MCGTracer;
using Bob.Colector;
using MCG_DEL = MCGDelegator.MCSDelegator;
using MCG_ENS = MCGEnsamblaje.MCSEnsamblador;
using MCG_ENS_DOM = MCGEnsamblaje.MCSEnsambladorCodeDOM;
using System.CodeDom.Compiler;
using System.IO;

namespace Bob
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MCSTracer tracer = MCSTracer.Instar;
            Form baseForm = new Form1();
            
            List<MCGTracer_EVENTOS> lEventos = new List<MCGTracer_EVENTOS>();
            lEventos.Add(MCGTracer_EVENTOS.MUp);
            Proyector p = new Proyector();
            tracer.AcoplarForm(baseForm, lEventos, p.recibirMouse, null);

            Recolector r = new Recolector();

            p.delegadoEnRecibirDatos =  MCG_DEL.crearDelegado<Proyector.datosRecibidos>(r, "procesaDatos");

            ///Ensamblaje
            //Dictionary<string, string> dic = new Dictionary<string, string>() { { "nombrensamblado", "MiEnsamble" }, { "versionsamblado", "1.0.0.0" } };
            //MCG_ENS.Ensamblar(dic);
            
            //.exe
            //MCG_ENS_DOM.Ensamblar();

            Application.Run(baseForm);
            
        }
        
    }
}
