using System;
using System.Collections.Generic;

namespace Script2D
{
    class VKeisti
    {
        private Dictionary<string, string> vars;
        private PFiguros p;

        public VKeisti(Dictionary<string, string> vars, PFiguros p)
        {
            this.vars = vars;
            this.p = p;
        }

        public void Piestukas(string param)
        {           
            //pagalvoti apie split - juk dvi dalys
            string spalva = param.Substring(0, param.IndexOf(' '));
            if (vars.ContainsKey(spalva))
            {
                string tmp = vars[spalva];
                param = param.Replace(spalva, tmp);
                spalva = tmp;
            }

            string storis = param.Replace(spalva + " ", "");
            if (vars.ContainsKey(storis))
            {
                storis = vars[storis];
            }

            p.Piestukas(spalva, Convert.ToUInt32(storis));
           
        }

        public void Dydis(string param)
        {
            string[] xy = param.Split(' ');

            if (vars.ContainsKey(xy[0]))
            {
                xy[0] = vars[xy[0]];
            }
            if (vars.ContainsKey(xy[1]))
            {
                xy[1] = vars[xy[1]];
            }

            int x = Convert.ToInt32(xy[0]);
            int y = Convert.ToInt32(xy[1]);

            //------------------------------------------
            int xd = 440, xdn = xd,
                yd = 330, ydn = yd;
            int x0d = 29,
                y0d = 46;

            float tmp = (float)y / (float)x;

            if (tmp < 0.75)
            {
                ydn = (int)(yd * tmp);
                y0d = y0d + (int)((yd - ydn) / 2);
            }
            if (tmp > 0.75)
            {
                if (tmp < 1)
                {
                    xdn = (int)(xd * tmp);
                    x0d = x0d + (int)((xd - xdn) / 2);
                }
                else
                {
                    xdn = (int)(xd / tmp);
                    x0d = x0d + (int)((xd - xdn) / 2);
                }
            }

            p.Dydis(x, y, x0d, y0d, xdn, ydn);
        }
    }
}