using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace JailManagementSystem
{
    /// <summary>
    /// Interaction logic for escort.xaml
    /// </summary>
    public partial class escort : Window
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RVI30EH\SQLEXPRESS;Initial Catalog=jms;Integrated Security=True");
        prisonermain pm = new prisonermain();
        public escort()
        {
            InitializeComponent();
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand comm = con.CreateCommand();
            DataTable tb = new DataTable();
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select * from escort";
            comm.ExecuteNonQuery();
            SqlDataAdapter adapt = new SqlDataAdapter(comm);
            adapt.Fill(tb);
            datagrid_escort.ItemsSource = tb.DefaultView;
            con.Close();

            con.Open();
            SqlCommand cmds = con.CreateCommand();
            cmds.CommandType = CommandType.Text;
            cmds.CommandText = "select prisoner.id,prisoner.lastname,prisoner.firstname,prisoner.middlename, hearing.hearingdate, hearing.hearingtime from prisoner inner join hearing on prisoner.id = hearing.inmatenum";
            cmds.ExecuteNonQuery();
            DataTable tb1 = new DataTable();
            SqlDataAdapter das = new SqlDataAdapter(cmds);
            das.Fill(tb1);
            datagrid_escorts.ItemsSource = tb1.DefaultView;
            con.Close();
        }

        //SEARCH PRISONER
        private void tb_escort_TextChanged(object sender, TextChangedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from escort where lastname like '" + tb_escort.Text.ToString() + "%" + "' or firstname like '" + tb_escort.Text.ToString() + "%" + "' or position like '" + tb_escort.Text.ToString() + "%" + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            datagrid_escort.ItemsSource = dt.DefaultView;
            con.Close();
        }
        private void datagrid_escort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        
            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                id.Text = row_selected["id"].ToString();
                
            }

            delete_escort.Visibility = Visibility.Visible;
        }

        private void datagrid_escort_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            edit.Visibility = Visibility.Visible;
            datagrid_escort.Visibility = Visibility.Hidden;
            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                id.Text = row_selected["id"].ToString();
                lastname.Text = row_selected["lastname"].ToString();
                firstname.Text = row_selected["firstname"].ToString();
                position.Text = row_selected["position"].ToString();
                edit.Visibility = Visibility.Visible;
               

            }
            else
                MessageBox.Show("please select an object");
        }

        private void addescort_Click(object sender, RoutedEventArgs e)
        {

            addescort add = new addescort();
            add.Show();
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
                escort cm = new escort();
                con.Open();
                SqlCommand command = con.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "update escort set firstname = '" + firstname.Text.ToString() + "', lastname = '" + lastname.Text.ToString() + "', position = '" + position.Text.ToString() + "' , escort = '" + p_id.Text.ToString() + "' where id = '" + id.Text + "'";
                command.ExecuteNonQuery();
                MessageBox.Show("Successfully Updated!!");
                con.Close();
        }

        private void datagrid_escorts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            p_id.Visibility = Visibility.Visible;
            p_lastname.Visibility = Visibility.Visible;
            p_firstname.Visibility = Visibility.Visible;
            p_middlename.Visibility = Visibility.Visible;
            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            if (row_selected != null)
            {
              
                p_id.Text = row_selected["id"].ToString();
                p_lastname.Text = row_selected["lastname"].ToString();
                p_firstname.Text = row_selected["firstname"].ToString();
                p_middlename.Text = row_selected["middlename"].ToString();
                p_hearingdate.Text = row_selected["hearingadate"].ToString();
                p_hearingtime.Text = row_selected["hearingtime"].ToString();
            }
          
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DataGrid dataGrid = datagrid_escort;
            DataGridRow Row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
            DataGridCell RowAndColumn = (DataGridCell)dataGrid.Columns[0].GetCellContent(Row).Parent;
            ((TextBlock)RowAndColumn.Content).Text = id.Text;
            con.Open();

            SqlCommand command = con.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "delete from escort where id = '" + id.Text + "'";
            command.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Deleted!");
            edit.Visibility = Visibility.Hidden;
            datagrid_escort.Visibility = Visibility.Visible;
            this.Close();
            escort es = new escort();
            loading l = new loading();
            l.Show();
            es.Show();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            escort main = new escort();
            main.Show();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            hearingschedule hs = new hearingschedule();
            hs.Show();
        }
    }
}
