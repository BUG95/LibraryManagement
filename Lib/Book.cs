using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Lib
{
    class Book
    {
        private int id;
        private string title;
        private string author;
        private string publishingHouse;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        public string PublishingHouse
        {
            get { return publishingHouse; }
            set { publishingHouse = value; }
        }
        public Book(string _title, string _author, string _publishingHouse, int _id=0)
        {
            id = _id;
            title = _title;
            author = _author;
            publishingHouse = _publishingHouse;
        }

        public static void AddBook(Book book)
        {
            string connection1 = "Data Source=ASUS;Initial Catalog=data;Integrated Security=True;Pooling=False";
            string Query = "insert into Books (Titlu, Autor, Editura) values('" + book.Title + "','" + book.Author + "','" + book.PublishingHouse + "');";
            SqlConnection connection2 = new SqlConnection(connection1);
            SqlCommand command = new SqlCommand(Query, connection2);
            SqlDataReader Reader;
            connection2.Open();
            Reader = command.ExecuteReader();
            while (Reader.Read())
            {
            }
            connection2.Close();
        }

        public static void EditBook(string option,string bookEdit,int bookId)
        {
            try
            {
                string Query=null;
                string connection1 = "Data Source=ASUS;Initial Catalog=data;Integrated Security=True;Pooling=False";
                if (option == "Titlu")
                {
                    Query = "update Books set Titlu='" + bookEdit + "' where Id= '" + bookId + "';";
                }
                else
                    if (option == "Autor")
                {
                    Query = "update Books set Autor='" + bookEdit + "' where Id= '" + bookId + "';";
                }
                else
                    if (option == "Editura")
                {
                    Query = "update Books set Editura='" + bookEdit + "' where Id= '" + bookId + "';";
                }
                else return;
                SqlConnection connection2 = new SqlConnection(connection1);
                SqlCommand command = new SqlCommand(Query, connection2);
                SqlDataReader Reader;
                connection2.Open();
                Reader = command.ExecuteReader();
                connection2.Close();
            }
            catch (Exception)
            {
            }
        }

        public static void DeleteBook(int bookId)
        {
            try
            {
                string connection1 = "Data Source=ASUS;Initial Catalog=data;Integrated Security=True;Pooling=False";
                string Query = "delete from Books where Id='" + bookId + "';";
                SqlConnection connection2 = new SqlConnection(connection1);
                SqlCommand MyCommand2 = new SqlCommand(Query, connection2);
                SqlDataReader Reader;
                connection2.Open();
                Reader = MyCommand2.ExecuteReader();
                connection2.Close();
            }
            catch (System.Exception)
            {

            }
        }
        public static Book GetBook(int ID)
        {
            List<Book> bookList = new List<Book>();
            bookList = LoadBooks();
            Book b = bookList[0]; //
            using (SqlConnection connection = new SqlConnection(@"Data Source=ASUS;Initial Catalog=data;Integrated Security=True;Pooling=False"))
            using (SqlCommand cmd = new SqlCommand("select Id from Books", connection))
            {
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (reader.GetInt32(reader.GetOrdinal("Id")) == ID)
                            {
                                foreach (Book book in bookList)
                                    if (book.Id == ID)
                                    {
                                        b = book;
                                        return b;
                                    }
                            }
                        }
                    }

                }
                connection.Close();
            }
            return b;
        }
        public static bool ExistentBook(Book book, Person person)
        {
            string connection1 = "Data Source=ASUS;Initial Catalog=data;Integrated Security=True;Pooling=False";
            string Query = "SELECT ClientID, BookID FROM Borrows";
            SqlConnection connection2 = new SqlConnection(connection1);
            SqlCommand command = new SqlCommand(Query, connection2);
            SqlDataReader reader;
            connection2.Open();
            reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (reader.GetInt32(reader.GetOrdinal("ClientId")) == person.Id)
                    {
                        if (reader.GetInt32(reader.GetOrdinal("BookId")) == book.id)
                        {
                            connection2.Close();
                            return true;
                        }
                            
                    }
                }
            }
            return false;
        }
        public static int LookAfterBorrows(Person person)
        {
            int noOfBorr = 0;
            string connection1 = "Data Source=ASUS;Initial Catalog=data;Integrated Security=True;Pooling=False";
            string Query = "SELECT ClientID, NoOfBorr FROM Borrows";
            SqlConnection connection2 = new SqlConnection(connection1);
            SqlCommand command = new SqlCommand(Query, connection2);
            SqlDataReader reader;
            connection2.Open();
            reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (reader.GetInt32(reader.GetOrdinal("ClientID")) == person.Id)
                    {
                        noOfBorr += reader.GetInt32(reader.GetOrdinal("NoOfBorr"));
                    }
                }
            }
            connection2.Close();
            return noOfBorr;
        }
        public static bool IsSameBook(Book book, Person person)
        {
            string connection1 = "Data Source=ASUS;Initial Catalog=data;Integrated Security=True;Pooling=False";
            string Query = "SELECT ClientID, BookID FROM Borrows";
            SqlConnection connection2 = new SqlConnection(connection1);
            SqlCommand command = new SqlCommand(Query, connection2);
            SqlDataReader reader;
            connection2.Open();
            reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (reader.GetInt32(reader.GetOrdinal("ClientID")) == person.Id)
                        if (reader.GetInt32(reader.GetOrdinal("BookID")) == book.Id)
                            return true;
                }
            }
            connection2.Close();
            return false;
        }
            public static void Borrow(Book book, Person person)
        {
            int noOfBorr = 0;
            noOfBorr = LookAfterBorrows(person);
            bool update = ExistentBook(book, person);
            Console.WriteLine(noOfBorr + " carti imprumutate");
            if (noOfBorr == 3)
            {
                MessageBox.Show("Aveti deja 3 carti imprumutate!");
                return;
            }
            else
            if (update)
            {
                string connection1 = "Data Source=ASUS;Initial Catalog=data;Integrated Security=True;Pooling=False";
                string Query = "UPDATE Borrows SET NoOfBorr = '" + (noOfBorr + 1) + "' WHERE ClientID = '" + person.Id + "' AND BookID = '" + book.Id+"'";
                SqlConnection connection2 = new SqlConnection(connection1);
                SqlCommand command = new SqlCommand(Query, connection2);
                SqlDataReader reader;
                connection2.Open();
                reader = command.ExecuteReader();
                connection2.Close();
                MessageBox.Show("Ati imprumutat inca o carte cu titlul " + book.title);
            }
            else
            {
                string connection1 = "Data Source=ASUS;Initial Catalog=data;Integrated Security=True;Pooling=False";
                string Query = "insert into Borrows (ClientID,BookID,NoOfBorr) values('" + person.Id + "','" + book.Id + "','" + 1 + "');";
                SqlConnection connection2 = new SqlConnection(connection1);
                SqlCommand command = new SqlCommand(Query, connection2);
                SqlDataReader reader;
                connection2.Open();
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (reader.GetInt32(reader.GetOrdinal("ClientId")) == person.Id)
                        {
                            noOfBorr += reader.GetInt32(reader.GetOrdinal("NoOfBorr"));
                        }
                    }
                }
                connection2.Close();
                MessageBox.Show("Ati imprumutat cartea cu titlul " + book.title);
            }
        }
      
        public static List<Book> LoadBooks()
        {
            List<Book> list = new List<Book>();
            using (SqlConnection connection = new SqlConnection(@"Data Source=ASUS;Initial Catalog=data;Integrated Security=True;Pooling=False"))
            using (SqlCommand cmd = new SqlCommand("select * from Books", connection))
            {
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new Book(reader.GetString(reader.GetOrdinal("Titlu")), reader.GetString(reader.GetOrdinal("Autor")), reader.GetString(reader.GetOrdinal("Editura")), reader.GetInt32(reader.GetOrdinal("Id"))));
                        }
                    }
                }
                connection.Close();
            }
            return list;
        }
        public static string SearchBook(string title)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=ASUS;Initial Catalog=data;Integrated Security=True;Pooling=False"))

            using (SqlCommand cmd = new SqlCommand("select Titlu from Books", connection))
            {
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if(reader.GetString(reader.GetOrdinal("Titlu"))==title)
                            {
                                return title;
                            }
                        }
                    }
                }
                connection.Close();
            }
            return "";
        }
        public static List<string> ShowBorrowedBooks(Person client)
        {
            int i = 1;
            List<string> borrowedBookList = new List<string>();
            using (SqlConnection connection = new SqlConnection(@"Data Source=ASUS;Initial Catalog=data;Integrated Security=True;Pooling=False"))
            using (SqlCommand cmd = new SqlCommand("select BookID, NoOfBorr from Borrows WHERE ClientID="+client.Id, connection))
            {
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {

                        while (reader.Read())
                        {
                         string item = (reader.GetInt32(reader.GetOrdinal("BookID"))).ToString();
                         int nr = reader.GetInt32(reader.GetOrdinal("NoOfBorr"));
                        if (nr == 1)
                        {
                            borrowedBookList.Add(item);
                        }
                        if (nr==2)
                        {
                            borrowedBookList.Add(item);
                            borrowedBookList.Add(item);
                        }
                        if (nr == 3)
                        {
                            MessageBox.Show("Am adaugat " + 3);
                            borrowedBookList.Add(item);
                            borrowedBookList.Add(item);
                            borrowedBookList.Add(item);
                        }
                    }
                }
                connection.Close();
            }
            return borrowedBookList;
        }

        public static void ReturnBook(Book book, Person person)
        {
            int noOfBorr = 0;
            bool update = false;
            string connection1 = "Data Source=ASUS;Initial Catalog=data;Integrated Security=True;Pooling=False";
            string Query = "Select NoOfBorr FROM Borrows WHERE ClientID = '" + person.Id + "' AND BookID = '" + book.Id+"';";
            SqlConnection conn = new SqlConnection(connection1);
            SqlCommand comm = new SqlCommand(Query, conn);
            SqlDataReader Reader;
            conn.Open();
            Reader = comm.ExecuteReader();
            while(Reader.Read())
            {
                noOfBorr = Reader.GetInt32(Reader.GetOrdinal("NoOfBorr"));
                Console.WriteLine("NoooofB= " + noOfBorr);
                break;
            }
            conn.Close();
            Query = "UPDATE Borrows SET NoOfBorr = '" + (noOfBorr - 1) + "' WHERE ClientID = '" + person.Id + "' AND BookID = '" + book.Id + "'";
            SqlConnection connection2 = new SqlConnection(connection1);
            SqlCommand command = new SqlCommand(Query, connection2);
            SqlDataReader reader;
            connection2.Open();
            reader = command.ExecuteReader();
            connection2.Close();
            MessageBox.Show("Ati returnat cartea cu titlul " + book.title);
            update = IsSameBook(book,person);
            if (noOfBorr == 1)
                if (update)
            {
                Query = "DELETE FROM Borrows WHERE ClientID = '" + person.Id + "' AND BookID = '" + book.Id + "';";
                comm = new SqlCommand(Query, conn);
                conn.Open();
                Reader = comm.ExecuteReader();
                conn.Close();
            }
            

        }
    }
}
