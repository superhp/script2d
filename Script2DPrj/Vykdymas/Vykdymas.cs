using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Script2D
{
    //komandu interpretatorius
    //sinchronizuoja su piesimo klase
    class Vykdymas
    {
        //pagalbines klases
        private Matematika Mat;
        private VKeisti Vk;
        private VPiesk Vp;

        private PFiguros p;                                                               //piesimo klase      
        protected Dictionary<string, string> vars = new Dictionary<string, string>();       //skaiciu kintamuju klase

        public Vykdymas(PFiguros psm)
        {            
            p = psm;
            Mat = new Matematika(vars);
            Vk = new VKeisti(vars, p);
            Vp = new VPiesk(p);
        }      
                      
        //patiklslingi kintamuju logika: kom, tmp...
        public void Nauja(string kodas)
        {
            kodas = Mat.Nunulinimas(kodas, ' ');               //paliekam tik po viena ' '   
            kodas = Mat.Nunulinimas(kodas, '\n');              //paliekam tik po viena '\n'          
           
            //kodas BUTINAI turi baigtis nauja eilute!
            if (kodas[kodas.Length - 1] != '\n')
            {
                kodas += "\n";
            }
            
            List<string> rinkinys = new List<string>();            
            string tmp;
            int kur;

            string kom = "";
            string param;

            //skaido i atskiras komandas
            do
            {
                kur = kodas.IndexOf('\n');               
                tmp = kodas.Substring(0, kur);
                kom += tmp;

                // jei viena raide
                if (tmp.Length == 1 ||
                    ((tmp.Length > 1 && ((tmp[tmp.Length - 1] != ',' && tmp[tmp.Length - 1] != ':')) &&
                                         (tmp[tmp.Length - 2] != ',' && tmp[tmp.Length - 2] != ':'))))
                {
                    rinkinys.Add(kom);
                    kom = "";
                }                               
                
                kodas = kodas.Replace(tmp + "\n", "");
            } while (kodas.Length > 0);

            //vykdo atskiras komandas
            foreach (string k in rinkinys)
            {
                if (k.Length > 0)    //apsauga del "" AR TIKRAI REIKIA???
                {
                    tmp = k;
                    tmp = tmp.Replace("\n", "");         //istrina visus \n, sujungia eilutes i viena, pvz., cikle  

                    //jei pries komanda lieka ' ', trinam
                    if (tmp[0] == ' ')
                    {
                        tmp = tmp.Substring(1);
                    }
                    //jei komandos gale lieka ' ', trinam
                    if (tmp[tmp.Length-1] == ' ')
                    {
                        tmp = tmp.Remove(tmp.Length-1);
                    }

                    //jei komanda - kintamasis
                    if (vars.ContainsKey(tmp))
                    {
                        tmp = vars[tmp];
                    }

                    if (tmp[0] != ';')
                    {
                        kom = tmp.Substring(0, tmp.IndexOf(' '));
                        param = tmp.Substring(kom.Length + 1);     //replace netinka, del a = / a + 1                      
                        Komandos(kom, param);
                    }
                }
            }
        }

        private void Komandos(string kom, string param)
        {            
            if (vars.ContainsKey(param))
            {
                param = vars[param];
            }
           
            switch (kom)
            { 
                case "naudok":
                    Naudok(param);
                    break;
                case "piesk":
                    Piesk(param);
                    break;
                case "keisk":
                    Keisti(param);
                    break;          
                case "eksportuok":
                    Eksportavimas(param);
                    break;
                case "valyk":
                    p.Trinti();
                    break;
                case "kol":
                    Ciklas_kol(param);
                    break;
                case "jei":
                    Salyga_jei(param);
                    break;
                default:
                    Kintamasis(kom + " " + param);
                    break;
            }
        }

        private void Naudok(string param)
        {
            StreamReader sr = new StreamReader(param);
            string kodas = sr.ReadToEnd();
            sr.Close();

            //nuskaicius is failo, reikia istrinti nereikalingus simbolius
            kodas = kodas.Replace("\r", "");
            kodas = kodas.Replace("\t", "");
            
            Nauja(kodas);
        }

        private void Eksportavimas(string param)
        {
            //pvd url format - NEBAIGTA
            string[] pms = param.Split(' ');

            if (vars.ContainsKey(pms[0]))
            {
                pms[0] = vars[pms[0]];
            }
            if (vars.ContainsKey(pms[1]))
            {
                pms[1] = vars[pms[1]];
            }
            if (vars.ContainsKey(pms[2]))
            {
                pms[2] = vars[pms[2]];
            }

            p.Eksportavimas(pms[0], pms[1], pms[2]);
        }

        //"kol" ir "jei" pagalbine f-ja
        private string[] KolJeiP(string param, out string log)
        {
            //atskirti salyga nuo vykdymo
            param = param.Replace(" : ", ":");
            param = param.Replace(": ", ":");
            param = param.Replace(" :", ":");

            string[] args = param.Split(':');

            //komandos eiluteje - 3 variantai
            string skoms = args[1].Replace(", ", ",");
            skoms = args[1].Replace(" ,", ",");
            skoms = args[1].Replace(" , ", ",");

            log = args[0];

            if (vars.ContainsKey(log))
            {
                log = vars[log];
            }

            //komandos sarase
            return skoms.Split(',');
        }
                
        private void Salyga_jei(string param)
        {
            string log;
            string[] koms = KolJeiP(param, out log);

            if (Mat.Salyga(log))
            {
                foreach (string k in koms)
                {
                    if (vars.ContainsKey(k))
                    {
                        Nauja(vars[k]);
                    }
                    else if (k.Length > 0)
                    {
                        Nauja(k);
                    }
                }
            }
        }

        private void Ciklas_kol(string param)
        {
            string log;
            string[] koms = KolJeiP(param, out log);           

            while (Mat.Salyga(log))
            {
                foreach (string k in koms)
                {
                    if (vars.ContainsKey(k))
                    {
                        Nauja(vars[k]);
                    }
                    else if (k.Length > 0)
                    {
                        Nauja(k);
                    }
                }
            }
        }        

        private void Keisti(string eil)
        {
            string kom = eil.Substring(0, eil.IndexOf(' '));
            string param = eil.Replace(kom + " ", "");

            //if (vars.ContainsKey(kom))
            //{
            //    kom = vars[kom];
            //}
            if (vars.ContainsKey(param))
            {
                param = vars[param];
            }

            switch (kom)
            {
                case "piestuka":
                    Vk.Piestukas(param);
                    break;
                case "dydi":
                    Vk.Dydis(param);
                    break;
            }

        }        

        //skaicius, parametras - bet kokia eilute
        private void Kintamasis(string param)
        {
            string fig = param.Substring(0, param.IndexOf('=') - 1);
            string fpar = param.Replace(fig + " = ", "");            

            //jei a +-*/ b - skaiciams
            if (fpar[0] == '/')
            {
                fpar = fpar.Substring(2);
                fpar = Mat.Aritmetika(fpar);
            }
            //jei a = b
            if (vars.ContainsKey(fpar))
            {
                fpar = vars[fpar];
            }
            //jei a = a
            if (vars.ContainsKey(fig))
            {
                vars[fig] = fpar;
            }
            //jei a = 5
            else
            {
                vars.Add(fig, fpar);
            }
        }            

        //sinchronizavimas su piesimo klase
        private void Piesk(string param)
        {
            string fig     = param.Substring(0, param.IndexOf(' '));
            string fpar    = param.Replace(fig + " ", "");

            //if (vars.ContainsKey(fig))
            //{
            //    fig = vars[fig];
            //}
            if (vars.ContainsKey(fpar))
            {
                fpar = vars[fpar];
            }
            
            //tekstui
            string txt = Vp.Tekstas(ref fpar),
                   txt2 = "";

            string[] pars = fpar.Split(' '); 
            List<float> pp = new List<float>();
            foreach (string p in pars)
            {
                string tmp = p;
                if (vars.ContainsKey(p))
                {
                    tmp = vars[p];
                    txt2 = Vp.Tekstas(ref tmp);
                    if (txt2 != "")
                        txt = txt2;        
                }
                try
                {
                    pp.Add((float)Convert.ToDouble(tmp));
                }
                catch (Exception e){ }
            }

            if (vars.ContainsKey(txt))
            {
                txt = vars[txt];
            }         

            Vp.Go(fig, pp, txt);
        }
    }
}