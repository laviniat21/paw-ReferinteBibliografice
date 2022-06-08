using System;
using System.Collections.Generic;
using System.Text;

namespace referinteBibliografice
{
    public class Carte : Publicatie
    {
        private readonly string ISBN;
        private string categorie;
        Autor[] autori = new Autor[10];

        public Carte(string iSBN, string categorie, Autor[] autori, string titlu, float pret):base(titlu,pret)
        {
            ISBN = iSBN;
            this.categorie = categorie;
            this.autori = (Autor[])autori.Clone();
            
        }
        public Carte(string iSBN, string categori, string titlu, float pret) : base(titlu, pret)
        {
            ISBN = iSBN;
            this.categorie = categori;
        }

        public string ISBN1 => ISBN;
        public string Categorie { get => categorie; set => categorie = value; }
        public Autor[] Autori { get => autori; set => autori = value; }
        public override string genereazaReferinta()
        {
            string totiAut="";
            for (int i = 0; i < this.autori.Length; i++)
            { totiAut += this.autori[i];
                if (i != this.autori.Length - 1)
                    totiAut += ", ";
            }
            return totiAut + " -  " + base.Titlu + ", " + ISBN;
        }

        public static Carte operator +(Carte c, Autor a)
        {
            Autor[] b = new Autor[c.Autori.Length + 1];
            b = (Autor[])c.autori.Clone();
            b[b.Length - 1] = a;
            c.Autori = (Autor[])b.Clone();
            return c;
        }
           

    }
}
