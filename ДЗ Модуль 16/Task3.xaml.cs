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
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;

namespace ДЗ_Модуль_16
{
    /// <summary>
    /// Логика взаимодействия для Task3.xaml
    /// </summary>
    public partial class Task3 : Page
    {
        DataRowView row;
        SqlDataAdapter adapter = DBManager.DBadapter;
        DataTable table = new DataTable();



        
        public Task3()
        {
            InitializeComponent(); 
            
            
            DBManager.Prepairing(table);
            myDataGrid.DataContext = table.DefaultView;
        }

        

        private void deletePerson_Click(object sender, RoutedEventArgs e)
        {
            row = (DataRowView)myDataGrid.SelectedItem;
            row.Delete();
            adapter.Update(table);
        }

        private void showGoods_Click(object sender, RoutedEventArgs e)
        {

            row = (DataRowView)myDataGrid.SelectedItem;
            DataRow dataRow = row.Row;
            Person selectedPerson = new Person();

            selectedPerson.Email = dataRow["Email"].ToString();

            GoodsList goodsList = new GoodsList(selectedPerson.Email);
            goodsList.Show();
        }

        private void myDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (row == null) return;
            row.EndEdit();
            
        }

        private void myDataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            row = (DataRowView)myDataGrid.SelectedItem;
            row.BeginEdit();
            adapter.Update(table);
        }

        private void ShowAddInterface_Click(object sender, RoutedEventArgs e)
        {
            ShowAddInterface.Visibility = Visibility.Hidden;

            firsNameBox.Visibility = Visibility.Visible;
            lastNameBox.Visibility = Visibility.Visible;
            midNameBox.Visibility = Visibility.Visible;
            emailBox.Visibility = Visibility.Visible;
            phoneBox.Visibility = Visibility.Visible;
            firstNameBlock.Visibility = Visibility.Visible;
            lastNameBlock.Visibility = Visibility.Visible;
            midNameBlock.Visibility = Visibility.Visible;
            emailBlock.Visibility = Visibility.Visible;
            phoneBlock.Visibility = Visibility.Visible;
            Save.Visibility = Visibility.Visible;

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            DataRow row = table.NewRow();

            row["firstName"] = firsNameBox.Text;
            row["lastName"] = lastNameBox.Text;
            row["middleName"] = midNameBox.Text;
            row["email"] = emailBox.Text;
            row["phone"] = phoneBox.Text;

            table.Rows.Add(row);
            adapter.Update(table);

            firsNameBox.Visibility = Visibility.Hidden;
            lastNameBox.Visibility = Visibility.Hidden;
            midNameBox.Visibility = Visibility.Hidden;
            emailBox.Visibility = Visibility.Hidden;
            phoneBox.Visibility = Visibility.Hidden;

            firstNameBlock.Visibility = Visibility.Hidden;
            lastNameBlock.Visibility = Visibility.Hidden;
            midNameBlock.Visibility = Visibility.Hidden;
            emailBlock.Visibility = Visibility.Hidden;
            phoneBlock.Visibility = Visibility.Hidden;
            Save.Visibility = Visibility.Hidden;

            firsNameBox.Text = null;
            lastNameBox.Text = null;
            midNameBox.Text = null;
            emailBox.Text = null;
            phoneBox.Text = null;

            ShowAddInterface.Visibility = Visibility.Visible;
        }

        private void firsNameBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!string.IsNullOrEmpty(firsNameBox.Text) && 
                !string.IsNullOrEmpty(lastNameBox.Text) && 
                !string.IsNullOrEmpty(midNameBox.Text) &&
                !string.IsNullOrEmpty(emailBox.Text) &&
                    !string.IsNullOrEmpty(phoneBox.Text))
            {
                Save.IsEnabled = true;
            }
        }
    }
}
