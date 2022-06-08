using System;
using System.Collections.Generic;
using System.Text;

namespace referinteBibliografice
{
    public class Autor
    {
        private string nume;
        private string gradDidactic;
        private readonly int marca;

        public Autor(string nume, string gradDidactic, int marca)
        {
            this.nume = nume;
            this.gradDidactic = gradDidactic;
            this.marca = marca;
        }

        public Autor()
        {
            this.nume ="Anonim" ;
            this.gradDidactic ="Niciunul" ;
            this.marca =-1 ;
        }
        public string Nume { get => nume; set => nume = value; }
        public string GradDidactic { get => gradDidactic; set => gradDidactic = value; }
        public int Marca => marca;

        public override string ToString()
        {
            return "autorul "+ this.nume+" are gradul didactic "+this.gradDidactic+" si marca "+this.marca;
        }
    }
}
