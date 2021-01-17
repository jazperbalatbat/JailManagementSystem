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
using JailManagementSystem.objects;

namespace JailManagementSystem
{
    /// <summary>
    /// Interaction logic for cellmain.xaml
    /// </summary>
    public partial class cellmain : Window
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RVI30EH\SQLEXPRESS;Initial Catalog=jms;Integrated Security=True");
        public cellmain()
        {
            InitializeComponent();
        }
        //LOAD DATAGRID VALUES
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from cell";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            datagrid_cell.ItemsSource = dt.DefaultView;
            con.Close();

            //con.Open();
            //SqlCommand cmds = con.CreateCommand();
            //DataTable dts = new DataTable();
            //cmds.CommandType = CommandType.Text;
            //cmds.CommandText = "select * from visitor where id = '" + id.Text.ToString() + "'";
            //cmds.ExecuteNonQuery();
            //SqlDataAdapter ds = new SqlDataAdapter(cmds);
            //ds.Fill(dts);
            //datagrid_cell.ItemsSource = dt.DefaultView;
            //con.Close();




        }
    
        //EDIT A CELL
        private void datagrid_cell_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            edit.Visibility = Visibility.Visible;
            datagrid_cell.Visibility = Visibility.Hidden;

            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                id.Text = row_selected["id"].ToString();
                cellnum.Text = row_selected["cellnum"].ToString();
                description.Text = row_selected["description"].ToString();
                num_inmates.Text = row_selected["num_inmates"].ToString();
                status.Text = row_selected["status"].ToString();
                status.Text = row_selected["status"].ToString();
                edit.Visibility = Visibility.Visible;
                datagrid_cell.Visibility = Visibility.Hidden;

            }
            else
                MessageBox.Show("please select an object");
        }

        //EDIT-CANCELBUTTON
        private void add_cancel_cell_Click(object sender, RoutedEventArgs e)
        {
            edit.Visibility = Visibility.Hidden;
            datagrid_cell.Visibility = Visibility.Visible;
            cell p = new cell();
            cellmain cm = new cellmain();
            cm.Show();
            loading l = new loading();
            l.Show();
            this.Close();
            
            

        }

        //SELECT ROW AND VISIBILITY OF DELETE BUTTON
        private void datagrid_cell_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
           
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void update_cell_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataGrid dataGrid = datagrid_cell;
                DataGridRow Row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
                DataGridCell RowAndColumn = (DataGridCell)dataGrid.Columns[0].GetCellContent(Row).Parent;
                ((TextBlock)RowAndColumn.Content).Text = id.Text;
                con.Open();

                SqlCommand command = con.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "update cell set cell='" + cellnum.Text.ToString() + "', description= '" + description.Text.ToString() + "', num_inmates = '" + num_inmates.Text.ToString() + "', status = '" + status.Text.ToString() + "' where id = '" + id.Text + "'";
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully Updated!");
                edit.Visibility = Visibility.Hidden;
                datagrid_cell.Visibility = Visibility.Visible;
                cellmain cm = new cellmain();
               cm.Show();
                loading l = new loading();
                l.Show();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Invalid Inputs");
            }

            cellmain CM = new cellmain();
            CM.Show();
            this.Close();

        }

        private void update_prisoner_Click(object sender, RoutedEventArgs e)
        {

        }

        private void addinmate_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
