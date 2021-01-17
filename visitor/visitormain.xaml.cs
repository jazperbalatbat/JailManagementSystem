using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using JailManagementSystem.visitor;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;
using JailManagementSystem.objects;

namespace JailManagementSystem.visitor
{
    /// <summary>
    /// Interaction logic for visitormain.xaml
    /// </summary>
    public partial class visitormain : Window
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RVI30EH\SQLEXPRESS;Initial Catalog=jms;Integrated Security=True");

        public visitormain()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from visitor";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            datagrid_visitor.ItemsSource = dt.DefaultView;
            con.Close();

            con.Open();
            SqlCommand cmds = con.CreateCommand();
            cmds.CommandType = CommandType.Text;
            cmds.CommandText = "select * from prisoner";
            cmds.ExecuteNonQuery();
            DataTable dts = new DataTable();
            SqlDataAdapter das = new SqlDataAdapter(cmds);
            das.Fill(dts);
            datagrid_visitors.ItemsSource = dts.DefaultView;
            con.Close();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            prisonerfacerecog pfr = new prisonerfacerecog();
            pfr.Show();
            pfr.type = "visitor";
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                id.Text = row_selected["id"].ToString();
                delete_visitor.Visibility = Visibility.Visible;
            }
        }

        //delete visitor
        private void delete_visitor_Click(object sender, RoutedEventArgs e)
        {
            DataGrid dataGrid = datagrid_visitor;
            DataGridRow Row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
            DataGridCell RowAndColumn = (DataGridCell)dataGrid.Columns[0].GetCellContent(Row).Parent;
            ((TextBlock)RowAndColumn.Content).Text = id.Text;
            con.Open();

            SqlCommand command = con.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "delete from visitor where id = '" + id.Text + "'";
            command.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Deleted!");
            edit_visitor.Visibility = Visibility.Hidden;
            datagrid_visitor.Visibility = Visibility.Visible;

            //visitor_archive v = new visitor_archive();

            //v.lastname = lastname.Text.ToString();
            //v.firstname = firstname.Text.ToString();
            //v.middlename = middlename.Text.ToString();
            //v.address = address0.Text.ToString() + " " + address1.Text.ToString();
            //v.gender = gender.Text.ToString();
            //v.add();



            this.Close();
            visitormain pm = new visitormain();
            loading l = new loading();
            l.Show();
            pm.Show();

        }

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;



            if (row_selected != null)
            {
                id.Text = row_selected["id"].ToString();
                relation.Text = row_selected["relation"].ToString();
                lastname.Text = row_selected["lastname"].ToString();
                firstname.Text = row_selected["firstname"].ToString();
                middlename.Text = row_selected["middlename"].ToString();
                address0.Text = row_selected["address"].ToString();
                gender.Text = row_selected["gender"].ToString();
                relation.Text = row_selected["relation"].ToString();
                string inmate = row_selected["inmate"].ToString();

                string query = "select * from prisoner where id = '" + inmate + "'";
                SqlCommand coms = new SqlCommand(query, con);
                SqlDbConnection cons = new SqlDbConnection();

                cons.Adaptor(query);
                DataTable dt = cons.Fill();
                if (dt.Rows.Count == 1)
                {
                    con.Open();
                    SqlDataReader reads = coms.ExecuteReader();
                    while (reads.Read())
                    {

                        vp_firstname.Text = (reads["firstname"].ToString());
                        vp_lastname.Text = (reads["lastname"].ToString());
                        vp_middlename.Text = (reads["middlename"].ToString());
                        vp_id.Text = (reads["id"].ToString());

                    }
                    reads.Close();
                    con.Close();

                    edit_visitor.Visibility = Visibility.Visible;
                    datagrid_visitor.Visibility = Visibility.Hidden;
                }
                else
                    MessageBox.Show("please select an object");
            }


        }

        private void tb_visitor_TextChanged(object sender, TextChangedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from visitor where lastname like '" + tb_visitor.Text.ToString() + "%" + "' or firstname like '" + tb_visitor.Text.ToString() + "%" + "' or middlename like '" + tb_visitor.Text.ToString() + "%" + "' or address like '" + tb_visitor.Text.ToString() + "%" + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            datagrid_visitor.ItemsSource = dt.DefaultView;
            con.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            datagrid_visitor.Visibility = Visibility.Visible;
            edit_visitor.Visibility = Visibility.Hidden;
        }

        private void datagrid_visitors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            vp_id.Visibility = Visibility.Visible;
            vp_lastname.Visibility = Visibility.Visible;
            vp_firstname.Visibility = Visibility.Visible;
            vp_middlename.Visibility = Visibility.Visible;

            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                vp_id.Text = row_selected["id"].ToString();
                vp_lastname.Text = row_selected["lastname"].ToString();
                vp_firstname.Text = row_selected["firstname"].ToString();
                vp_middlename.Text = row_selected["middlename"].ToString();
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            visitoradd va = new visitoradd();
            va.Show();
        }

        private void update_visitor_Click(object sender, RoutedEventArgs e)
        {
            DataGrid dataGrid = datagrid_visitor;
            DataGridRow Row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
            DataGridCell RowAndColumn = (DataGridCell)dataGrid.Columns[0].GetCellContent(Row).Parent;
            ((TextBlock)RowAndColumn.Content).Text = id.Text;
            con.Open();
            SqlCommand command = con.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "update visitor set inmate = '" + vp_id.Text.ToString() + "',  lastname='" + lastname.Text.ToString() + "', firstname= '" + firstname.Text.ToString() + "', middlename = '" + middlename.Text.ToString() + "', address = '" + address0.Text.ToString() + "', gender = '" + gender.Text.ToString() + "' where id = '" + id.Text + "'";
            command.ExecuteNonQuery();
            con.Close();
            this.Close();
            loading l = new loading();
            l.Show();
            visitormain vm = new visitormain();
            vm.Show();
            MessageBox.Show("Successfully Updated!");
            edit_visitor.Visibility = Visibility.Hidden;
            datagrid_visitor.Visibility = Visibility.Visible;
        }
    }
}