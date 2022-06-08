using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace referinteBibliografice
{
    public partial class Form1 : Form
    {
        Form2 form = new Form2();
        string connString;
        public Form1()
        {
            InitializeComponent();
            connString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=Autori.accdb";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void adaugaManualToolStripMenuItem2_Click(object sender, EventArgs e)
        {

            form.Show();
            //this.Hide();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {

            listView2.Items.Clear();
            //foreach(Autor autor in form.autori)
            //{
            //    ListViewItem itm=new ListViewItem(autor.Nume);
            //    itm.SubItems.Add(autor.GradDidactic);
            //    itm.SubItems.Add(autor.Marca.ToString());
            //    listView2.Items.Add(itm);
            //}
            OleDbConnection conexiune = new OleDbConnection(connString);
            OleDbCommand comanda = new OleDbCommand();
            try { 
                conexiune.Open();
                comanda.Connection = conexiune;
                comanda.CommandText = "Select * from autori";
                OleDbDataReader reader=comanda.ExecuteReader();
                while (reader.Read())
                {
                    ListViewItem itm = new ListViewItem(reader["nume"].ToString());
                    itm.SubItems.Add(reader["gradDidactic"].ToString());
                    itm.SubItems.Add(reader["marca"].ToString());
                    listView2.Items.Add(itm);
                }
                reader.Close();
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message);

            }
            finally {
                conexiune.Close();
            }



            listView1.Items.Clear();
            foreach (Carte carte in form.carti)
            {
                ListViewItem itm = new ListViewItem(carte.Titlu);
                itm.SubItems.Add(carte.ISBN1);
                itm.SubItems.Add(carte.Pret.ToString());
                listView1.Items.Add(itm);

            }

        }
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
        private void stergereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(listView2.SelectedItems.Count >0)
            {
                listView2.SelectedItems[0].Remove();
            }
        }
        private void actualizareToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {   
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem itm in listView2.Items)
            {   //public Autor[] autori2 = new Autor[Form1.autori.Length + 1];
                if (itm.Checked)
                {
                    

                    // form.autori[].Append(itm);
                    //form.autori = new Autor[form.autori.Length + 1];
                    string nume = itm.SubItems[0].ToString();
                    string grad = itm.SubItems[1].ToString();
                    int marca = Convert.ToInt32(itm.SubItems[2].Text);
                    Autor a = new Autor(nume, grad, marca);
                    //form.autori[form.autori.Length - 1] = a;
                    
                 }
            }
        }
    }
}
