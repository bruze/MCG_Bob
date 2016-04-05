///Dependencias por Defecto
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
///
using System.Drawing;
using System.Windows.Forms;

namespace MCGTracer
{
    public enum MCGTracer_EVENTOS {MUp=1, MEnter, MHover, MMove, MLeave, MDown, MWhell }

    /// <summary>
    /// 
    /// </summary>
    /// 
    public sealed class MCSTracer
    {
        //private Form.ControlCollection misForms = null;
        
        private static volatile MCSTracer instancia;
        private static object sincroRaiz = new Object();

        private MCSTracer() {}

        public static MCSTracer Instar
        {
            get
            {
                ///Double-Lock Checking
                ///
                if (instancia == null)
                {
                    lock (sincroRaiz)
                    {
                        if (instancia == null)
                            instancia = new MCSTracer();
                    }
                }
                return instancia;
            }
        }

        private void procesAcoplaEventos(List<MCGTracer_EVENTOS> eventos, Form aQuien, mouseSoltado delegar, mouseEntrado delega2)
        {
            foreach (MCGTracer_EVENTOS evento in eventos)
            {
                if (evento.Equals(MCGTracer_EVENTOS.MUp))
                {
                    aQuien.MouseUp += new MouseEventHandler(delegar);
                }
                else if (evento.Equals(MCGTracer_EVENTOS.MEnter))
                {
                    aQuien.MouseEnter += new EventHandler(delega2);
                }
                else if (evento.Equals(MCGTracer_EVENTOS.MHover))
                {
                    aQuien.MouseHover += new EventHandler(delega2);
                }
                else if (evento.Equals(MCGTracer_EVENTOS.MLeave))
                {
                    aQuien.MouseLeave += new EventHandler(delega2);
                }
                else if (evento.Equals(MCGTracer_EVENTOS.MMove))
                {
                    aQuien.MouseMove += new MouseEventHandler(delegar);
                }
                else if (evento.Equals(MCGTracer_EVENTOS.MDown))
                {
                    aQuien.MouseDown += new MouseEventHandler(delegar);
                }
                else if (evento.Equals(MCGTracer_EVENTOS.MWhell))
                {
                    aQuien.MouseWheel += new MouseEventHandler(delegar);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aCoplar"></param>
        /// <param name="aQueEventos"></param>
        public void AcoplarForm(Form aCoplar, List<MCGTracer_EVENTOS> aQueEventos, mouseSoltado delegar, mouseEntrado delega2)
        {
            /*Agregar a mis forms
            **Si la coleccion es nula crearla
             */
            /*if (misForms == null)
            {
                misForms = new Form.ControlCollection(aCoplar);
            }
            else
            {
                misForms.Add(aCoplar);
            }*/
            procesAcoplaEventos(aQueEventos, aCoplar, delegar, delega2);
        }

        /*
         * Eventos 'locales'
         */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        public delegate void mouseSoltado(object sender, MouseEventArgs e);
        /*{
            // Update the mouse path with the mouse information
            Point mouseLocation = new Point(e.X, e.Y);
        }*/
        public delegate void mouseEntrado(object sender, EventArgs e);
        //{
            // Update the mouse path with the mouse information
            //bool track = true;
        //}
        public delegate void mouseSobre(object sender, EventArgs e);
        //{
            // Update the mouse path with the mouse information
            //bool track = true;
        //}
        public delegate void mouseDejado(object sender, EventArgs e);
        //{
            // Update the mouse path with the mouse information
            //bool track = true;
        //}
        public delegate void mouseMovido(object sender, MouseEventArgs e);
        //{
            // Update the mouse path with the mouse information
            //Point mouseLocation = new Point(e.X, e.Y);
        //}
        public delegate void mousePresionado(object sender, MouseEventArgs e);
        //{
            // Update the mouse path with the mouse information
            //Point mouseLocation = new Point(e.X, e.Y);
        //}
        public delegate void mouseRueda(object sender, MouseEventArgs e);
        //{
            // Update the mouse path with the mouse information
            //Point mouseLocation = new Point(e.X, e.Y);
        //}
    }
}
