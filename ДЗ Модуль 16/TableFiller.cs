using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ДЗ_Модуль_16
{
    internal class TableFiller
    {
        

        static SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder()
        {
            DataSource = @"(localdb)\MSSQLLocalDB",
            InitialCatalog = @"TestSQLLocalDB",
            IntegratedSecurity = true,
            Pooling = true
        };

        public static void CreateOrdersTable()
        {
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                var comm = "CREATE TABLE Orders (Id INT NOT NULL  IDENTITY, email NVARCHAR (50) NOT NULL , goodCode NVARCHAR (50) NOT NULL , goodName NVARCHAR (50) NOT NULL )";
                SqlCommand command = new SqlCommand(comm, connection);
                command.ExecuteNonQuery();
            }
        }

        public static void CreatePersonsTable()
        {

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                var comm = "CREATE TABLE Persons (Id INT NOT NULL  IDENTITY, firstName NVARCHAR (50) NOT NULL , lastName NVARCHAR (50) NOT NULL , middleName NVARCHAR (50) NOT NULL , email NVARCHAR (50) NOT NULL , phone NVARCHAR (50))";
                SqlCommand command = new SqlCommand(comm, connection);
                command.ExecuteNonQuery();

            }
        }
        /// <summary>
        /// Заполнение таблиц
        /// </summary>
        /// <param name="sender">Передай экземпляр класса, для которого будем заполнять таблицу</param>
        public static void GoFill(object sender)
        {
            if (sender.GetType() == typeof(Person))
            {
                List<Person> list = Person.GetList();

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    string exp = "INSERT INTO Persons (firstName, lastName, middleName, email, phone) VALUES (@firstName, @lastName, @middleName, @email, @phone);";
                    SqlCommand command = new SqlCommand(exp, connection);
                    connection.Open();

                    foreach (Person filler in list)
                    {
                        
                        SqlParameter firstNameParam = new SqlParameter("@firstName", filler.FirstName);
                        SqlParameter lastNameParam = new SqlParameter("@lastName", filler.LastName);
                        SqlParameter middleNameParam = new SqlParameter("@middleName", filler.MiddleName);
                        SqlParameter emailParam = new SqlParameter("@email", filler.Email);
                        SqlParameter phoneParam = new SqlParameter("@phone", filler.Phone);


                        command.Parameters.Add(firstNameParam);
                        command.Parameters.Add(lastNameParam);
                        command.Parameters.Add(middleNameParam);
                        command.Parameters.Add(emailParam);
                        command.Parameters.Add(phoneParam);

                        command.ExecuteNonQuery();
                        command.Parameters.Clear();


                    }


                }
            }
            if (sender.GetType() == typeof(Order))
            {
                List<Order> list = Order.GetList();

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    string exp = "INSERT INTO Orders (email, goodCode, goodName) VALUES (@email, @goodCode, @goodName);";
                    SqlCommand command = new SqlCommand(exp, connection);
                    connection.Open();

                    foreach(Order filler in list)
                    {
                        SqlParameter emailParam = new SqlParameter("@email", filler.email);
                        SqlParameter goodCodeParam = new SqlParameter("@goodCode", filler.goodCode);
                        SqlParameter goodNameParam = new SqlParameter("@goodName", filler.goodName);

                        command.Parameters.Add(emailParam);
                        command.Parameters.Add(goodCodeParam);
                        command.Parameters.Add(goodNameParam);

                        command.ExecuteNonQuery();
                        command.Parameters.Clear();
                    }
                }
            }
        }
        public static List<string> GetEmails()
        {
            List<string> emails = new List<string>();
            string exp = @"SELECT email FROM Persons";


            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(exp, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    emails.Add(reader.GetString(0));
                }
            }
            
            
                return emails;
        }
    }


}
