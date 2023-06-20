using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace ДЗ_Модуль_16
{
    /// <summary>
    /// Логика взаимодействия для GoodsList.xaml
    /// </summary>
    public partial class GoodsList : Window
    {
        public string personEmail;
        public GoodsList(string Email)
        {
            this.personEmail = Email;
            
            InitializeComponent();
            Prepairing();
            
        }


        static SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder()
        {
            DataSource = @"(localdb)\MSSQLLocalDB",
            InitialCatalog = @"TestSQLLocalDB",
            IntegratedSecurity = true,
            Pooling = true
        };

        public void Prepairing()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            

            string selectExp = "SELECT * FROM Orders WHERE email = @Email Order By Orders.Id";
            using (SqlConnection connection = new SqlConnection(DBManager.builder.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(selectExp, connection))
                {
                    command.Parameters.AddWithValue("@Email", personEmail);
                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                }
            }

            myDataGrid.DataContext = table;
            
        }
    }
}
