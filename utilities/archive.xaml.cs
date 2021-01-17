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
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;
using JailManagementSystem.objects;
using Microsoft.Win32;
using System.IO;
using System.Threading;

namespace JailManagementSystem
{
    /// <summary>
    /// Interaction logic for archive.xaml
    /// </summary>
    public partial class archive : Window
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RVI30EH\SQLEXPRESS;Initial Catalog=jms;Integrated Security=True");


        public archive()
        {
            InitializeComponent();
        }


        prisonermain p = new prisonermain();
      
        prisonermain pm = new prisonermain();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from archive_prisoner";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            datagrid_archive.ItemsSource = dt.DefaultView;
            con.Close();
        }

        private void datagrid_archive_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            if (row_selected != null)
            {

                p.id.Text = row_selected["id"].ToString();
                restore.Visibility = Visibility.Visible;
               
            }

        }

        private void datagrid_archive_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
          

            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;



            if (row_selected != null)
            {
               p.id.Text = row_selected["id"].ToString();
               p.lastname.Text = row_selected["lastname"].ToString();
               p.firstname.Text = row_selected["firstname"].ToString();
               p.middlename.Text = row_selected["middlename"].ToString();
               p.address.Text = row_selected["address"].ToString();
               p.age.Text = row_selected["age"].ToString();
               p.gender.Text = row_selected["gender"].ToString();
               p.birthdate.Text = row_selected["birthdate"].ToString();
               p.height.Text = row_selected["height"].ToString();
               p.weight.Text = row_selected["weight"].ToString();
               p.citizenship.Text = row_selected["citizenship"].ToString();
               p.religion.Text = row_selected["religion"].ToString();
               p.datein.Text = row_selected["datein"].ToString();
               p.civilstatus.Text = row_selected["civilstatus"].ToString();
               p.jailstatus.Text = row_selected["jailstatus"].ToString();

              

            }
            else
                MessageBox.Show("please select an object");
        }




        private void restore_Click(object sender, RoutedEventArgs e)
        {


                string ident = p.id.Text;
                DataGrid dataGrid = datagrid_archive;
                DataGridRow Row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
                DataGridCell RowAndColumn = (DataGridCell)dataGrid.Columns[0].GetCellContent(Row).Parent;
                ((TextBlock)RowAndColumn.Content).Text = ident;
                con.Open();

                SqlCommand command = con.CreateCommand();
                command.CommandType = CommandType.Text;
                restore res = new restore();
                res.firstname = p.firstname.Text.ToString();
            res.middlename = p.middlename.Text.ToString();
            res.lastname = p.lastname.Text.ToString();
            res.address = p.address.Text.ToString();
            res.age = p.age.Text.ToString();
            res.gender = p.gender.Text.ToString();
            res.birthdate = p.birthdate.DisplayDate.ToString("yyyy-MM-dd");
            res.height = p.height.Text.ToString();
            res.weight = p.weight.Text.ToString();
            res.citizenship = p.citizenship.Text.ToString();
            res.religion = p.religion.Text.ToString();
            res.datein = p.datein.DisplayDate.ToString("yyyy-MM-dd");
            res.civilstatus = p.civilstatus.Text.ToString();
            res.jailstatus = p.jailstatus.Text.ToString();

            res.add();

            command.CommandText = "delete from archive_prisoner where id = '" + ident + "'";
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully Deleted!");

                this.Close();

                pm.Show();
                loading l = new loading();
                l.Show();

          
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
