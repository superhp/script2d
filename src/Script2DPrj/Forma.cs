using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Script2D
{
    public partial class Forma : Form
    {
        Vykdymas v;         //vykdymo klase
        PFiguros psm;       //piesinio klase

        int nm            = 0;
        List<string> mem  = new List<string>();    //naudotu komandu stekas     

        //default fontas
        Font dfnt = new Font("Verdana", 10F, FontStyle.Regular, GraphicsUnit.Point);

        public Forma()
        {
            InitializeComponent();

            psm = new PFiguros(pb, xy_vk, xy_vd, xy_ad);
            v = new Vykdymas(psm);
            ivestis.KeyPress += new KeyPressEventHandler(NaujaKomanda);           
        }
                
        //si algoritma PERSIDARYT
        public String generateRandomString(int length)
        {
            Random random = new Random();            
            String randomString = "";
            int randNumber;
            
            for (int i = 0; i < length; i++)
            {
                if (random.Next(1, 3) == 1)
                    randNumber = random.Next(97, 123); 
                else
                    randNumber = random.Next(48, 58); 
               
                randomString = randomString + (char)randNumber;
            }
           
            return randomString;
        }

        private void KodoZymejimas(RichTextBox tb)
        {
            int pask;
            string tmp;
            List<string> f = new List<string>(new string[] { "piestuka", "dydi", "teksta", "linija", "trikampi", "staciakampi", "elipse", "poligona",
                                                             "taska", "ptrikampi", "pstaciakampi", "pelipse", "ppoligona", "taska" });
            List<string> k = new List<string>(new string[] { "naudok", "piesk", "kol", "jei", "eksportuok", "valyk", "keisk", "   <--- sintaksės klaida!" });
            k.InsertRange(k.Count, f);            
            
            Font fnt = new Font("Verdana", 11F, FontStyle.Italic, GraphicsUnit.Point);           

            foreach (string s in k)
            {
                if (tb.Find(s) >= 0)
                {
                    tmp = tb.Text;
                    pask = tb.Text.LastIndexOf(s);
                    do
                    {
                        tb.SelectionStart = tmp.IndexOf(s);
                        tmp = generateRandomString(tb.SelectionStart + s.Length) + tmp.Substring(tb.SelectionStart + s.Length);
                        tb.SelectionLength = s.Length;
                        tb.SelectionFont = fnt;
                        tb.SelectionColor = Color.CadetBlue;
                        if (f.Contains(s))
                        {
                            tb.SelectionFont = dfnt;
                            tb.SelectionColor = Color.Blue;
                        }
                        if (s == "   <--- sintaksės klaida!")
                            tb.SelectionColor = Color.Red;
                    } while (tb.SelectionStart < pask);                    
                    tb.Select(tb.Text.Length, 0);
                }
            }            
        }    

        private void NaujaKomanda(object sender, KeyPressEventArgs e)        
        {           
            //des tarpeliu panaikinimo - palieka tik max po viena
            Matematika m = new Matematika(null);
            string ttext = ivestis.Text;
            ttext = m.Nunulinimas(ttext, ' ');
                
            //pabandyti ivesti nulinima, nes dabar veiks tik su dviem pozicijom                
            if (e.KeyChar == (char)13 &&
                (ttext.Length == 1 ||
                ((ttext.Length > 1 && (ttext[ttext.Length - 2] != ',' && ttext[ttext.Length - 2] != ':')) &&
                (ttext.Length > 2 && (ttext[ttext.Length - 3] != ',' && ttext[ttext.Length - 3] != ':')))))
            {      
                                  
                nm = 0;
                mem.Add(ivestis.Text);

                isvestis.Text += mem[mem.Count - 1];
                ivestis.Text = "";
                try
                 {
                    v.Nauja(mem[mem.Count - 1]);
                 }
                 catch (Exception e2)
                 {
                     string tmp = isvestis.Text;
                     isvestis.Text = tmp.Substring(0, tmp.Length - 1) + "   <--- sintaksės klaida!\n";
                 }

                //kodo zymejimas
                KodoZymejimas(isvestis);
            }        
            

            //po <
            if (e.KeyChar == 'B' && mem.Count >= 1 && nm < mem.Count)
            {                
                ivestis.Text = mem[mem.Count-nm-1];
                nm++;
            }
            //po >
            if (e.KeyChar == 'F' && nm >= 1 && nm >= 0 && nm < mem.Count)
            {               
                ivestis.Text = mem[mem.Count-nm-1];
                nm--;
            }

            //kodo zymejimas
            KodoZymejimas(ivestis);        
            ivestis.SelectionColor = Color.Black;
            ivestis.SelectionFont = dfnt;
        }

        private void išeitiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void apieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Apie ap = new Apie();            
            ap.Show();
        }   
       
    }
}