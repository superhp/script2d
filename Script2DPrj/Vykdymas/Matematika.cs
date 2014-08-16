using System;
using System.Collections.Generic;

namespace Script2D
{
    class Matematika
    {
        private Dictionary<string, string> vars;

        public Matematika(Dictionary<string, string> vars)
        {
            this.vars = vars;
        }

        public string Nunulinimas(string s, char ka)
        {
            for (int i = 0; i < s.Length - 1; i++)
            {
                for (int j = 0; j < s.Length - 1; j++)
                {
                    if (s[j] == ka && s[j] == s[j + 1])
                    {
                        s = s.Remove(j + 1, 1);
                    }
                }
            }
            return s;
        }

        public string Aritmetika(string eil)
        {
            string[] args = eil.Split(' ');
            if (vars.ContainsKey(args[0]))
            {
                args[0] = vars[args[0]];
            }
            if (vars.ContainsKey(args[2]))
            {
                args[2] = vars[args[2]];
            }
            switch (args[1])
            {
                case "+":
                    return (Convert.ToDouble(args[0]) + Convert.ToDouble(args[2])).ToString();
                case "-":
                    return (Convert.ToDouble(args[0]) - Convert.ToDouble(args[2])).ToString();
                case "*":
                    return (Convert.ToDouble(args[0]) * Convert.ToDouble(args[2])).ToString();
                case "/":
                    return (Convert.ToDouble(args[0]) / Convert.ToDouble(args[2])).ToString();
                default:
                    return "0";
            }
        }

        public bool Salyga(string param)
        {
            string[] args = param.Split(' ');

            if (vars.ContainsKey(args[0]))
            {
                args[0] = vars[args[0]];
            }          
            if (vars.ContainsKey(args[2]))
            {
                args[2] = vars[args[2]];
            }

            switch (args[1])
            {
                case "=":
                    return args[0] == args[2];
                case "<>":
                    return args[0] != args[2];
                case "<":
                    return Convert.ToDouble(args[0]) < Convert.ToDouble(args[2]);
                case "<=":
                    return Convert.ToDouble(args[0]) <= Convert.ToDouble(args[2]);
                case ">":
                    return Convert.ToDouble(args[0]) > Convert.ToDouble(args[2]);
                case ">=":
                    return Convert.ToDouble(args[0]) >= Convert.ToDouble(args[2]);
                default:
                    return false;
            }
        }


    }
}