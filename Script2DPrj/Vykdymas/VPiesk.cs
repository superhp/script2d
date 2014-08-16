using System;
using System.Collections.Generic;

namespace Script2D
{
    class VPiesk
    {
        private PFiguros p;

        public VPiesk(PFiguros p)
        {           
            this.p = p;
        }

        //teksto isskyrimas
        public string Tekstas(ref string saltinis)
        {
            //teksto iskirpimui
            string txt = "";
            if (saltinis.Contains("`"))
            {
                string[] tmp = saltinis.Split('`');
                txt = tmp[1];
                saltinis = saltinis.Replace(" " + txt + " ", "");
            }
            return txt;
        }

        //piesiamu figuru variantai
        public void Go(string fig, List<float> pp, string txt)
        {
            switch (fig)
            {
                case "teksta":
                    p.Tekstas(txt, pp);
                    break;

                //TUSCIAVIDURES FIGUROS
                case "linija":
                    p.Linija(pp);
                    break;
                case "staciakampi":
                    p.Staciakampis(pp);
                    break;
                case "taska":
                    pp.Add(1);  pp.Add(1);
                    p.Staciakampis(pp);
                    break;
                case "elipse":
                    p.Elipse(pp);
                    break;
                case "apskritima":
                    pp.Add(pp[pp.Count-1]);
                    p.Elipse(pp);
                    break;
                case "trikampi":
                    p.Poligonas(pp);
                    break;
                case "poligona":
                    p.Poligonas(pp);
                    break;

                //PILNAVIDURES FIGUROS
                case "pstaciakampi":
                    p.PStaciakampis(txt, pp);
                    break;
                case "pelipse":
                    p.PElipse(txt, pp);
                    break;
                case "papskritima":
                    pp.Add(pp[pp.Count - 1]);
                    p.PElipse(txt, pp);
                    break;
                case "ptrikampi":
                    p.PPoligonas(txt, pp);
                    break;
                case "ppoligona":
                    p.PPoligonas(txt, pp);
                    break;
            }
        }
    }
}