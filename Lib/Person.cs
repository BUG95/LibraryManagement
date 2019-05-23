using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lib
{
    class Person
    {
        private string nume;
        private string prenume;
        private int id;
        public Person(string nume, string prenume, int id=0)
        {
            this.id = id;
            this.nume = nume;
            this.prenume = prenume;
        }
        public string Nume
        {

            get { return nume; }
            set { nume = value; }
        }
        public string Prenume
        {
            get { return prenume; }
            set { prenume = value; }
        }
        public int Id
        {

            get { return id; }
            set { id = value; }
        }
        public static List<Person> ReadPersonList()
        {
            List<Person> list = new List<Person>();
            using (SqlConnection connection = new SqlConnection(@"Data Source=ASUS;Initial Catalog=data;Integrated Security=True;Pooling=False"))
            using (SqlCommand cmd = new SqlCommand("select * from Clients", connection))
            {
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new Person(reader.GetString(reader.GetOrdinal("Nume")), reader.GetString(reader.GetOrdinal("Prenume")), reader.GetInt32(reader.GetOrdinal("Id"))));
                        }
                    }
                }
                connection.Close();
                return list;
            }
        }
        public static void AddPerson(Person person)
        {
            string connection1 = "Data Source=ASUS;Initial Catalog=data;Integrated Security=True;Pooling=False"; 
            string Query = "insert into Clients (Nume, Prenume) values('" + person.nume + "','" + person.prenume +  "');";
            SqlConnection connection2 = new SqlConnection(connection1);
            SqlCommand MyCommand2 = new SqlCommand(Query, connection2);
            SqlDataReader Reader;
            connection2.Open();
            Reader = MyCommand2.ExecuteReader(); 
            while (Reader.Read())
            {
            }
            connection2.Close();
        }
        public static void DeleteClient(int clientId)
        {
            try
            {
                string connection1 = "Data Source=ASUS;Initial Catalog=data;Integrated Security=True;Pooling=False";
                string Query = "delete from Clients where Id='" + clientId + "';";
                SqlConnection connection2 = new SqlConnection(connection1);
                SqlCommand MyCommand2 = new SqlCommand(Query, connection2);
                SqlDataReader Reader;
                connection2.Open();
                Reader = MyCommand2.ExecuteReader();
                connection2.Close();
            }
            catch (Exception)
            {
          
            }
        }
        public static Person GetPerson(int ID)
        {
            List<Person> clientList = new List<Person>();
            clientList = ReadPersonList();
            Person p=clientList[0]; //
            using (SqlConnection connection = new SqlConnection(@"Data Source=ASUS;Initial Catalog=data;Integrated Security=True;Pooling=False"))
            using (SqlCommand cmd = new SqlCommand("select Id from Clients", connection))
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
                                foreach (Person client in clientList)
                                    if (client.Id == ID)
                                    {
                                        p = client;
                                        return p;
                                    }
                            }
                        }
                    }
                    
                }
                connection.Close();
            }
            return p;
        }
        public static string SearchPeople(string nume_prenume)
        {
            try
            {
                string nume = nume_prenume.Substring(0, nume_prenume.IndexOf(" "));
                string prenume = nume_prenume.Substring(nume_prenume.IndexOf(" ") + 1);
                using (SqlConnection connection = new SqlConnection(@"Data Source=ASUS;Initial Catalog=data;Integrated Security=True;Pooling=False"))

                using (SqlCommand cmd = new SqlCommand("select Nume, Prenume from Clients", connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                if (reader.GetString(reader.GetOrdinal("Nume")) == nume
                                    && reader.GetString(reader.GetOrdinal("Prenume")) == prenume)
                                {
                                    string np = nume + " " + prenume;
                                    return np;
                                }
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (System.Exception) {  }
            return "";
        }
    }
}
