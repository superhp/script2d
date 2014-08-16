using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Script2D
{
    class PFiguros : Piesimas
    {
        public PFiguros(PictureBox objektas, Label vk, Label vd, Label ad) : base (objektas, vk, vd, ad){}        

        //tekstas
        public void Tekstas(string txt, List<float> pp)
        {
            //del apvertimo
            Matrix mx = new Matrix(1, 0, 0, 1, 0, 0);
            mx.Translate(0, bmp.Height-font.Height);          
            g.Transform = mx;            

            g.DrawString(txt, font, Brushes.Black, pp[0], -pp[1]);   
            g1.DrawImage(bmp, 0, 0, obj.Width, obj.Height);

            mx = new Matrix(1, 0, 0, -1, 0, 0);
            mx.Translate(0, -bmp.Height);
            g.Transform = mx;
        }

        //--------------------------------------------------------------------------------------------------
        //--------------TUSCIAVIDURES-----------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------
        //linija
        public void Linija(List<float> pp)
        {
            g.DrawLine(pen, pp[0], pp[1], pp[2], pp[3]);
            g1.DrawImage(bmp, 0, 0, obj.Width, obj.Height);
        }

        //staciakampis
        public void Staciakampis(List<float> pp)
        {
            g.DrawRectangle(pen, pp[0], pp[1], pp[2], pp[3]);
            g1.DrawImage(bmp, 0, 0, obj.Width, obj.Height);
        }

        //apskritimas
        public void Elipse(List<float> pp)
        {
            g.DrawEllipse(pen, pp[0], pp[1], pp[2], pp[3]);
            g1.DrawImage(bmp, 0, 0, obj.Width, obj.Height);
        }   

        //poligonas
        public void Poligonas(List<float> pp)
        {
            int n = (int) (pp.Count / 2);
            PointF[] virsunes = new PointF[n];
            for (int i = 0; i < n; i++)
            {
                virsunes[i] = new PointF(pp[0], pp[1]);
                pp.RemoveRange(0, 2);
            }

            g.DrawPolygon(pen, virsunes);
            g1.DrawImage(bmp, 0, 0, obj.Width, obj.Height);            
        }

        //--------------------------------------------------------------------------------------------------
        //--------------PILNAVIDURES-----------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------

        //staciakampis
        public void PStaciakampis(string sp, List<float> pp)
        {
            g.FillRectangle(Spalvos(sp), pp[0], pp[1], pp[2], pp[3]);
            g1.DrawImage(bmp, 0, 0, obj.Width, obj.Height);
        }

        //apskritimas
        public void PElipse(string sp, List<float> pp)
        {
            g.FillEllipse(Spalvos(sp), pp[0], pp[1], pp[2], pp[3]);
            g1.DrawImage(bmp, 0, 0, obj.Width, obj.Height);
        }

        //poligonas
        public void PPoligonas(string sp, List<float> pp)
        {
            int n = (int)(pp.Count / 2);
            PointF[] virsunes = new PointF[n];
            for (int i = 0; i < n; i++)
            {
                virsunes[i] = new PointF(pp[0], pp[1]);
                pp.RemoveRange(0, 2);
            }

            g.FillPolygon(Spalvos(sp), virsunes);
            g1.DrawImage(bmp, 0, 0, obj.Width, obj.Height);
        }
    }
}