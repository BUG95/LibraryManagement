using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Lib
{
    public partial class ClientArea : Form
    {
        public ClientArea()
        {
            InitializeComponent();
        }
        public ClientArea(string nume, string prenume)
        {
            InitializeComponent();
            label3.Text = nume;
            label4.Text = prenume;
        }
        List<Book> bookList = new List<Book>();
        List<Person> personList = new List<Person>();
        public void ReadBookList()
        {
            bookList = Book.LoadBooks();
        }
        public void ReadPersonList()
        {
            personList = Person.ReadPersonList();
        }
        private void ShowBooks()
        {
            listBox1.Items.Clear();
            foreach (Book book in bookList)
            {
                listBox1.Items.Add("Titlu: " + book.Title);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ShowBooks();
        }

        private void ClientArea_Load(object sender, EventArgs e)
        {
            ReadBookList();
            ReadPersonList();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            if (listBox1.SelectedIndex >= 0)
            {
                string select = listBox1.Items[listBox1.SelectedIndex].ToString();
                select = select.Substring(7);
                int i = 0;
                foreach(var book in bookList)
                {
                    if (select==book.Title)
                    {
                        listBox2.Items.Add("Autor: " + bookList[i].Author);
                        listBox2.Items.Add("Editura: " + bookList[i].PublishingHouse);
                        break;
                    }
                    i++;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                int bookID = 0;
                int clientID = 0;
                try
                {
                    string book = listBox1.Items[listBox1.SelectedIndex].ToString();
                    book = book.Substring(7);
                    foreach (Book _book in bookList)
                        if (_book.Title == book)
                        {
                            bookID = _book.Id;
                            break;
                        }
                }
                catch (System.Exception exc) { MessageBox.Show(exc.Message); }
                foreach (Person client in personList)
                    if (label3.Text == client.Nume)
                        if (label4.Text == client.Prenume)
                        {
                            clientID = client.Id;
                            break;
                        }

                Book.Borrow(Book.GetBook(bookID), Person.GetPerson(clientID));
                listBox3.Items.Clear();
                ShowBorrowedBooks();
            }
            else MessageBox.Show("Selectati o carte!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Count() == 0)
                MessageBox.Show("Completati campul: \"Titlu\"");
            else
            {
                if (Book.SearchBook(textBox1.Text) != "")
                {
                    foreach (var book in bookList)
                    {
                        if (book.Title == textBox1.Text)
                        {
                            listBox1.Items.Clear();
                            listBox2.Items.Clear();
                            listBox1.Items.Add("Titlu: " + book.Title);
                            break;
                        }
                    }
                }
                else
                {
                    listBox1.Items.Clear();
                    listBox2.Items.Clear();
                    MessageBox.Show("Cartea nu a fost gasita!");
                }
            }
        }
        private void ShowBorrowedBooks()
        {
            listBox3.Items.Clear();
            List<string> borrowedBooks = new List<string>();
            int clientID = 0;
            int i = 0, stop=0;
            foreach (Person client in personList)
                if (label3.Text == client.Nume)
                    if (label4.Text == client.Prenume)
                    {
                        clientID = client.Id;
                        break;
                    }
            borrowedBooks = Book.ShowBorrowedBooks(Person.GetPerson(clientID));
            Console.WriteLine("borrowedBooks="+ borrowedBooks.Count());
            if (borrowedBooks.Count() == 0) MessageBox.Show("Nu aveti carti imprumutate!");
            else
            {
                foreach (Book book in bookList)
                {
                    for (i = 0; i < borrowedBooks.Count(); i++)
                    {
                        if (book.Id == Convert.ToInt32(borrowedBooks[i]))
                        {
                            listBox3.Items.Add("Titlu: " + book.Title);
                            stop++;
                            if (stop == borrowedBooks.Count()) break;
                        }
                    }
                }
            }

        }
        private void button4_Click(object sender, EventArgs e)
        {
            ShowBorrowedBooks();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox3.SelectedIndex >= 0)
            {
                string temp_title = listBox3.Items[listBox3.SelectedIndex].ToString();
                temp_title = temp_title.Substring(temp_title.IndexOf(" ") + 1);
                foreach(Book book in bookList)
                {
                    if(book.Title==temp_title)
                    {
                        foreach (Person person in personList)
                        {
                            if (person.Nume == label3.Text && person.Prenume == label4.Text)
                            {
                                Book.ReturnBook(book, person);
                                listBox3.Items.Clear();
                                ShowBorrowedBooks();
                                break;
                            }     
                        }
                        break;
                    }
                }
            }
            else MessageBox.Show("Nu ati selectat nici o carte!");
        }
    }
}
