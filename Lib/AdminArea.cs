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
    public partial class AdminArea : Form
    {
        public AdminArea()
        {
            InitializeComponent();
        }

        List<Book> bookList = new List<Book>();
        List<Person> clientList = new List<Person>();

        private void ReadBookList()
        {
            bookList = Book.LoadBooks();
        }

        private void ReadClientList()
        {
            clientList = Person.ReadPersonList();
        }

        private void ShowClientList()
        {
            listBox1.Items.Clear();
            foreach (Person person in clientList)
            {
                listBox1.Items.Add(person.Id + ". " + person.Nume + " " + person.Prenume);
            }
        }

        private void ShowBookList()
        {
            listBox1.Items.Clear();
            foreach (Book book in bookList)
            {
                listBox1.Items.Add(book.Id + ". " + book.Title);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnEdtCarte.Enabled = false;
            btnStergeClient.Enabled = true;
            btnStergeCarte.Enabled = false;
            ShowClientList();
            
        }

        private void AdminArea_Load(object sender, EventArgs e)
        {
            btnStergeCarte.Enabled = false;
            btnStergeClient.Enabled = false;
            btnEdtCarte.Enabled = false;
            ReadBookList();
            ReadClientList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            btnEdtCarte.Enabled = true;
            btnStergeCarte.Enabled = true;
            btnStergeClient.Enabled = false;
            ShowBookList();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            if (listBox1.SelectedIndex >= 0)
            {
                string select = listBox1.Items[listBox1.SelectedIndex].ToString();
                select = select.Substring(select.IndexOf(".")+2);
                int i = 0;
                foreach (var book in bookList)
                {
                    if (select == book.Title)
                    {
                        listBox2.Items.Add("Autor: " + bookList[i].Author);
                        listBox2.Items.Add("Editura: " + bookList[i].PublishingHouse);
                        break;
                    }
                    i++;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                string clientString = listBox1.Items[listBox1.SelectedIndex].ToString();
                clientString = clientString.Substring(0, clientString.IndexOf("."));
                int clientId = Convert.ToInt32(clientString);
                Console.WriteLine(clientId);
                foreach (var person in clientList)
                {
                    if (person.Id == clientId)
                    {
                        Console.WriteLine("gasit");
                        Person.DeleteClient(clientId);
                        listBox1.Items.Clear();
                        ReadClientList();
                        ShowClientList();
                        break;
                    }
                }
            }
            else MessageBox.Show("Selectati un cient mai intai!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                string bookString = listBox1.Items[listBox1.SelectedIndex].ToString();
                bookString = bookString.Substring(0, bookString.IndexOf("."));
                int bookId = Convert.ToInt32(bookString);
                foreach (var book in bookList)
                {
                    if (book.Id == bookId)
                    {
                        Book.DeleteBook(bookId);
                        listBox1.Items.Clear();
                        ReadBookList();
                        ShowBookList();
                        break;
                    }
                }
            }
            else MessageBox.Show("Selectati o carte mai intai!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                    if (comboBox1.Text.Count() == 0 || textBox1.Text.Count() == 0)
                        MessageBox.Show("Completati ambele campuri: \"Modificare pentru...\" si \"Modificarea\"");
                    else
                    {
                        string bookString = listBox1.Items[listBox1.SelectedIndex].ToString();
                        bookString = bookString.Substring(0, bookString.IndexOf("."));
                        int bookId = Convert.ToInt32(bookString);
                        foreach (var book in bookList)
                        {
                            if (book.Id == bookId)
                            {
                                Book.EditBook(comboBox1.Text, textBox1.Text, bookId);
                                listBox1.Items.Clear();
                                ReadBookList();
                                ShowBookList();
                                break;
                            }
                        }
                    }
            }
            else
            { MessageBox.Show("Selectati o carte mai intai"); }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            if (txtTitlu.Text.Count() == 0 || txtAutor.Text.Count() == 0 || txtEd.Text.Count() == 0)
            {
                MessageBox.Show("Completati campurile \"Titlu\", \"Autor\", \"Editura\"");
            }
            else
            {
                Book.AddBook(new Book(txtTitlu.Text, txtAutor.Text, txtEd.Text));
                ReadBookList();
                ShowBookList();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int count = searchBook.Text.Count();
            if(count==0)
            {
                MessageBox.Show("Completati campul \"Titlu\"");
            }
            else
           if( Book.SearchBook(searchBook.Text)!="")
            {
                foreach (Book book in bookList)
                {
                    if(book.Title==searchBook.Text)
                    {
                        listBox1.Items.Clear();
                        listBox2.Items.Clear();
                        listBox1.Items.Add(book.Id+ ". " +book.Title);
                        break;
                    }
                }
                
            }
            else
                MessageBox.Show("Cartea nu a fost gasita!");

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if(textBox2.Text.Count()==0) MessageBox.Show("Exemplu input: Nume Prenume");
            else
            if (Person.SearchPeople(textBox2.Text)!= "")
            {
                foreach (Person person in clientList)
                {
                    if (person.Nume+" "+person.Prenume == textBox2.Text)
                    {
                        listBox1.Items.Clear();
                        listBox2.Items.Clear();
                        listBox1.Items.Add(person.Id + ". " + person.Nume+" "+person.Prenume);
                        break;
                    }
                }
            }
            else
                MessageBox.Show("Clientul nu a fost gasita!");
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Neimplementat", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
