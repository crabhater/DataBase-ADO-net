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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Security;

namespace ДЗ_Модуль_16
{
    /// <summary>
    /// Логика взаимодействия для Task1.xaml
    /// </summary>
    public partial class Task1 : Page
    {
        public Task1()
        {
            InitializeComponent();
        }
        
        private void OleDBState_Initialized(object sender, EventArgs e)
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Ренат\\Desktop\\Database1.accdb";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.OpenAsync();
                OleDBState.Text = $"Состояние:{connection.State.ToString()} \n Строка подключения: {connection.ConnectionString}";
            }
        }

        private void MSSQLState_Initialized(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder()
            {
                DataSource = @"(localdb)\MSSQLLocalDB",
                InitialCatalog = @"TestSQLLocalDB",
                IntegratedSecurity = true,
                Pooling = true
            };

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.OpenAsync();

                MSSQLState.Text = $"Состояние:{connection.State.ToString()} \n Строка подключения: {connection.ConnectionString}";

            }
        }
    }
}
