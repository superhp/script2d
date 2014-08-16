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
    class Piesimas
    {
        //laukai
        protected PictureBox obj;
        protected Bitmap bmp;                  //formuojamas bitmapas
        protected Graphics g1, g;              //einamasis grafikos objektas pictureboxe ir bitmape
        private Stack<Graphics> mem;         //grafikos objektu kopiju stekas del back f-jos     
   
        protected Pen pen;                     //piestuko" objektas
        protected Font font;
        
        private Label vk, vd, ad;

        //konstruktorius
        public Piesimas(PictureBox objektas, Label vk, Label vd, Label ad)
        {
            obj = objektas;

            g1 = obj.CreateGraphics();         //formos picturebox            

            //formuojamas bitmapas
            NaujasBMP(new Bitmap(440, 330));
            
            //labels            
            this.vk = vk;
            this.vd = vd;
            this.ad = ad;            

            pen = new Pen(Brushes.Red, 2);                  //priskiriam piestuko objekta: raudona, 2 dydzio     
            font = new Font("Arial", 30);                   //priskiriamas fontas tekstui formuoti
        }

        private void NaujasBMP(Bitmap bitmapas)
        {     
            bmp = bitmapas;
            //bmp.SetResolution(300, 300);                  //rezoliucija             

            g = Graphics.FromImage(bmp);
            g.Clear(Color.White);            
            g.SmoothingMode = SmoothingMode.AntiAlias;      //graziau

            //Certesian koordinaciu sistema
            Matrix mx = new Matrix(1, 0, 0, -1, 0, 0);
            mx.Translate(0, -bmp.Height);
            g.Transform = mx;

            g1.DrawImage(bmp, 0, 0, obj.Width, obj.Height);
        }

        //Spalvu atrinkimas
        protected Brush Spalvos(string sp)
        {
            switch (sp)
            {
                case "balta":
                    return Brushes.White;               
                case "raudona":
                    return Brushes.Red;
                case "melyna":
                    return Brushes.Blue;
                case "zalia":
                    return Brushes.Green;
                case "geltona":
                    return Brushes.Yellow;
                case "ruda":
                    return Brushes.Brown;
                case "oranzine":
                    return Brushes.Orange;
                case "violetine":
                    return Brushes.Purple;
                case "pilka":
                    return Brushes.Gray;
            default:
                    return Brushes.Black;
            }      
        }       

        //issaugoti pav.
        public void Eksportavimas(string pvd, string url, string fmat)
        {
            switch (fmat)
            { 
                case "bmp":
                    bmp.Save(url + pvd, System.Drawing.Imaging.ImageFormat.Bmp);
                    break;
                case "icon":
                    bmp.Save(url + pvd, System.Drawing.Imaging.ImageFormat.Icon);
                    break;
                case "gif":
                    bmp.Save(url + pvd, System.Drawing.Imaging.ImageFormat.Gif);
                    break;
                case "png":
                    bmp.Save(url + pvd, System.Drawing.Imaging.ImageFormat.Png);
                    break;
                default:
                    bmp.Save(url + pvd, System.Drawing.Imaging.ImageFormat.Jpeg);
                    break;
            }                
        }

        //keisti paveikslelio lango dydi
        public void Dydis(int x, int y, int x0d, int y0d, int xdn, int ydn)
        {     
            obj.SetBounds( x0d, y0d, xdn, ydn );

            vk.Text = "(0, " + y.ToString() + ")";
            vd.Text = "(" + x.ToString() + ", " + y.ToString() + ")";
            ad.Text = "(" + x.ToString() + ", 0)";

            //bmp resaizinimas
            NaujasBMP(new Bitmap(bmp, x, y));            
        }

        //Piestuko keitimas: spalva ir dydis
        public void Piestukas(string sspalva, uint dydis)
        {
            Brush spalva = Spalvos(sspalva);
            pen = new Pen(spalva, dydis);
        }

        //Trinti piesini
        public void Trinti()
        {
            g1.Clear(Color.White);
            NaujasBMP(new Bitmap(440, 330));
            Dydis(440, 330, 29, 49, 440, 330);
        }        
    }
}