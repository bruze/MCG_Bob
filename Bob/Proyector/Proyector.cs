using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//////
using Bob.Colector;
using MCGDelegator;

namespace Bob
{
    class Proyector
    {
        public delegate void datosRecibidos(DatoGuardado dato);
        
        public datosRecibidos delegadoEnRecibirDatos;
        public Form form;
        public Proyector()
        {
            //MCSDelegator del = new MCSDelegator();
            //del.tipo = typeof(datosRecibidos);

            /*using (*/
            form = new Form();/*)
            {*/
                form.Text = "About Us";

                // form.Controls.Add(...);

                //form.ShowDialog();
            //}
               // Proyecta();
        }

        /*Por ahora el acercamiento es procesar en recolector
         * public void ProcesarDatos()
        { 
        }*/

        public void Proyecta()
        {
            System.Drawing.Pen myPen;
            myPen = new System.Drawing.Pen(System.Drawing.Color.Red);
            System.Drawing.Graphics formGraphics = form.CreateGraphics();
            formGraphics.DrawLine(myPen, 0, 0, 200, 200);
            myPen.Dispose();
            formGraphics.Dispose();
        }

        public void recibirMouse(object sender, MouseEventArgs e)
        {
            //bool track = true;
            ///TODO: Modify existing data
            ///Se podria probar operar con bits para ciertas
            ///cosas
            DatoGuardado d = new DatoGuardado();
            d.datos = new Dictionary<int, List<double>>();
            d.datos.Add(1, new List<double>(){e.X, e.Y});///TODO: puntero entre X e Ys???
            delegadoEnRecibirDatos(d);
        }

    }
}
