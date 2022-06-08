using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace referinteBibliografice
{
    public partial class Form2 : Form
    {
       public List<Carte> carti = new List<Carte>();
       public List<string> categorii = new List<string>();
        public Autor[] autori = new Autor[] { new Autor("Ion Creanga", "Autor",1), 
            new Autor("Vasile Alecsandri","Poet",2), 
            new Autor("Ciurea","prof",3)};
        public Form2()
        {
            InitializeComponent();
            incarcareCB();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbISBN.Text == "")
                errorProvider1.SetError(tbISBN,"Introduceti ISBN-ul!");
            else 
                if ((float)Convert.ToDouble(tbPret.Text)<0)
                    errorProvider2.SetError(tbPret, "Pretul nu poate fi negativ!");
                else
                    if (tbTitlu.Text == "")
                        errorProvider3.SetError(tbTitlu, "Introduceti titlul!");
            else 
            { 
            try
            {
                    errorProvider1.Clear();
                    errorProvider2.Clear();
                    errorProvider3.Clear();
                    string titlu=tbTitlu.Text;
                string ISBN = tbISBN.Text;
                float pret = (float)Convert.ToDouble(tbPret.Text);
                string categorie = cbCategorie.Text;
                Carte carte = new Carte(ISBN, categorie, titlu, pret);
                carti.Add(carte);
                    MessageBox.Show(carte.genereazaReferinta());
                    

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                tbISBN.Clear();
                tbTitlu.Clear();
                tbPret.Clear();
               // cbCategorie..Clear();

            }
            }
        }

       private void cbCategorie_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void incarcareCB()
        {

            categorii.Add("Dragoste");
            categorii.Add("Matematica");
            categorii.Add("Psihologie");
            categorii.Add("IT");
            cbCategorie.DataSource = categorii;


        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            foreach (Autor autor in autori)
            {
                ListViewItem itm = new ListViewItem(autor.Nume);
                itm.SubItems.Add(autor.GradDidactic);
                itm.SubItems.Add(autor.Marca.ToString());
                listView1.Items.Add(itm);
            }
        }
    }
}
