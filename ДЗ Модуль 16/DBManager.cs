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
    internal class DBManager
    {
        public static SqlDataAdapter DBadapter = new SqlDataAdapter();
        
        
        public static SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder()
        {
            DataSource = @"(localdb)\MSSQLLocalDB",
            InitialCatalog = @"TestSQLLocalDB",
            IntegratedSecurity = true,
            Pooling = true
        };
        public static void Prepairing(DataTable table)
        {
            SqlConnection connection = new SqlConnection(builder.ConnectionString);
            
            
            #region SELECT
            string selectExp = "SELECT * FROM Persons Order By Persons.Id";

            DBadapter.SelectCommand = new SqlCommand(selectExp, connection);
            #endregion
            #region INSERT
            string insertExp = "INSERT INTO Persons (lastname, firstName, middleName, email, phone) VALUES (@lastname, @firstName, @middleName, @email, @phone); SET @Id = @@IDENTITY";

            DBadapter.InsertCommand = new SqlCommand(insertExp, connection);
            DBadapter.InsertCommand.Parameters.Add("@id", SqlDbType.Int, 4, "id").Direction = ParameterDirection.Output;
            DBadapter.InsertCommand.Parameters.Add("@lastName", SqlDbType.NVarChar, 50, "lastName");
            DBadapter.InsertCommand.Parameters.Add("@firstName", SqlDbType.NVarChar, 50, "firstName");
            DBadapter.InsertCommand.Parameters.Add("@middleName", SqlDbType.NVarChar, 50, "middleName");
            DBadapter.InsertCommand.Parameters.Add("@email", SqlDbType.NVarChar, 50, "email");
            DBadapter.InsertCommand.Parameters.Add("@phone", SqlDbType.NVarChar, 50, "phone");
            #endregion
            #region UPDATE
            string updateExp = "UPDATE Persons SET lastName = @lastName, firstName = @firstName, middleName = @middleName, email = @email, phone = @phone WHERE id = @id";

            DBadapter.UpdateCommand = new SqlCommand(updateExp, connection);
            DBadapter.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 4, "id").SourceVersion = DataRowVersion.Original;
            DBadapter.UpdateCommand.Parameters.Add("@lastName", SqlDbType.NVarChar, 50, "lastName");
            DBadapter.UpdateCommand.Parameters.Add("@firstName", SqlDbType.NVarChar, 50, "firstName");
            DBadapter.UpdateCommand.Parameters.Add("@middleName", SqlDbType.NVarChar, 50, "middleName");
            DBadapter.UpdateCommand.Parameters.Add("@email", SqlDbType.NVarChar, 50, "email");
            DBadapter.UpdateCommand.Parameters.Add("@phone", SqlDbType.NVarChar, 50, "phone");
            #endregion
            #region DELETE
            string deleteExp = "DELETE FROM Persons WHERE Id = @Id";

            DBadapter.DeleteCommand = new SqlCommand(@deleteExp, connection);
            DBadapter.DeleteCommand.Parameters.Add("@Id", SqlDbType.Int, 4, "Id");
            #endregion
            DBadapter.Fill(table);
        }

    }
     
}
