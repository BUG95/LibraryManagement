using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lib
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Person> personList = new List<Person>();
        private void ReadPersonList()
        {
            personList = Person.ReadPersonList();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string temp1 = txtNume.Text;
            string temp2 = txtPrenume.Text;
            if (temp1.Count() < 3 || temp2.Count() < 3)
                MessageBox.Show("Completati ambele campuri: \"Nume\", \"Prenume\"!");
            else
            {
                if (temp1.Contains("1") && temp1.Contains("2") && temp1.Contains("3") &&
                        temp1.Contains("4") && temp1.Contains("5") && temp1.Contains("6")
                        && temp1.Contains("7") && temp1.Contains("8") && temp1.Contains("9")
                        && temp1.Contains("0") && temp1.Contains(".") && temp1.Contains(",")
                        && temp1.Contains("/") && temp1.Contains("!") && temp1.Contains("?")
                        && temp1.Contains("-") && temp1.Contains("\\") && temp1.Contains("=")) 
                    MessageBox.Show("Atentie! Caractere invalide!");
                else
                {
                    bool gasit = false;
                    foreach (var person in personList)
                    {
                        if (person.Nume == txtNume.Text && person.Prenume == txtPrenume.Text)
                        {
                            Console.WriteLine("gasit!!");
                            gasit = true;
                            break;
                        }
                    }
                    if (gasit)
                    {
                        ClientArea clientArea = new ClientArea(txtNume.Text, txtPrenume.Text);
                        //  this.Hide();
                        clientArea.ShowDialog();
                    }
                    else
                    {
                        var option = MessageBox.Show("Nu existati in baza de date. Doriti sa va inregistrati?", "!!!",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (option == DialogResult.Yes)
                        {
                            Person.AddPerson(new Person(txtNume.Text, txtPrenume.Text));
                            MessageBox.Show("V-ati inregistrat!");
                            personList.Clear();
                            ReadPersonList();
                        }
                        else { }
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ReadPersonList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminArea adminArea = new AdminArea();
          //  this.Hide();
            adminArea.ShowDialog();
        }
    }
}
