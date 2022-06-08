using System;
using System.Collections.Generic;
using System.Text;

namespace referinteBibliografice
{
    public abstract class Publicatie 
    {
        private string titlu;
        private float pret;
        protected Publicatie(string titlu, float pret)
        {
            this.titlu = titlu;
            this.pret = pret;
        }
        protected Publicatie()
        {
            this.titlu = "Inexistent";
            this.pret = 0;
        }
        public string Titlu { get => titlu; set => titlu = value; }
        public float Pret { get => pret; set => pret = value; }

        public override string ToString()
        {
            return "Publicatia "+this.titlu+" costa "+this.pret+" lei";
        }
        public abstract string genereazaReferinta();
        
    }
}
