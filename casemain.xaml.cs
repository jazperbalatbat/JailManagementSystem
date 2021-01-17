using JailManagementSystem.objects;
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
    /// Interaction logic for casemain.xaml
    /// </summary>
    public partial class casemain : Window
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RVI30EH\SQLEXPRESS;Initial Catalog=jms;Integrated Security=True");
        //prisonermain pm = new prisonermain();


        public casemain()
        {
            InitializeComponent();
        }


        //LOAD DATAGRID VALUES
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from cases";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            datagrid_case.ItemsSource = dt.DefaultView;
            con.Close();
            
        }
        //EDIT A PRISONER
        private void datagrid_case_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            prisonermain pms = new prisonermain();
            pms.Show();
           pms.datagrid_prisoner.Visibility = Visibility.Hidden;
           pms.edit.Visibility = Visibility.Visible;
           pms.bail.Visibility = Visibility.Hidden;
           pms.hearing_schedule.Visibility = Visibility.Hidden;
           pms.cell_transfer.Visibility = Visibility.Hidden;
           pms.cell_registration.Visibility = Visibility.Hidden;
           pms.case_registration.Visibility = Visibility.Visible;
           pms.save_case.Visibility = Visibility.Hidden;
           pms.update_case.Visibility = Visibility.Visible;

            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                SqlConnection cons = new SqlConnection(@"Data Source=DESKTOP-RVI30EH\SQLEXPRESS;Initial Catalog=jms;Integrated Security=True");
                //pm.inmate_name.Text = row_selected["inmatename"].ToString();
               pms.inmatenum.Text = row_selected["inmatenum"].ToString();
               pms.casenum.Text = row_selected["casenum"].ToString();
               pms.offense1.Text = row_selected["offense"].ToString();
               pms.datefiled.Text = row_selected["datefiled"].ToString();
               pms.datesen.Text = row_selected["datesen"].ToString();
               pms.senstatus.Text = row_selected["senstatus"].ToString();
               pms.senreceive.Text = row_selected["senreceive"].ToString();
               pms.sendue.Text = row_selected["sendue"].ToString();
                string identifier = row_selected["inmatenum"].ToString();
                string query = "select * from prisoner where id = '" + identifier + "'";
                SqlCommand coms = new SqlCommand(query, cons);
                SqlDbConnection con = new SqlDbConnection();

                con.Adaptor(query);
                DataTable dt = con.Fill();
                
                cons.Open();
                //getting sql data from case registration prisoner to prisoner main
                SqlDataReader read = coms.ExecuteReader();
                while (read.Read())
                {
                   pms.id.Text = (read["id"].ToString());
                   pms.firstname.Text = (read["firstname"].ToString());
                   pms.lastname.Text = (read["lastname"].ToString());
                   pms.birthdate.Text = (read["birthdate"].ToString());
                   pms.middlename.Text = (read["middlename"].ToString());
                   pms.address.Text = (read["address"].ToString());
                   pms.age.Text = (read["age"].ToString());
                   pms.gender.Text = (read["gender"].ToString());
                   pms.weight.Text = (read["weight"].ToString());
                   pms.height.Text = (read["height"].ToString());
                   pms.citizenship.Text = (read["citizenship"].ToString());
                   pms.religion.Text = (read["religion"].ToString());
                   pms.datein.Text = (read["datein"].ToString());
                   pms.civilstatus.Text = (read["civilstatus"].ToString());
                   pms.jailstatus.Text = (read["jailstatus"].ToString());

                }
                read.Close();
                cons.Close();


            }


        }

        //SELECT ROW AND VISIBILITY OF DELETE BUTTON
        private void datagrid_case_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            prisonermain pms = new prisonermain();
            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                pms.id.Text = row_selected["id"].ToString();
            }
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //SEARCH PRISONER
        private void tb_prisoner_TextChanged(object sender, TextChangedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select prisoner.id, prisoner.lastname, prisoner.firstname, prisoner.middlename , cases.casenum, cases.offense, cases.datefiled, cases.datesen, cases.senstatus, cases.senreceive, cases.sendue from prisoner inner join cases on prisoner.id = cases.inmatenum where lastname like '" + tb_prisoner.Text.ToString() + "%" + "' or firstname like '" + tb_prisoner.Text.ToString() + "%" + "' or middlename like '" + tb_prisoner.Text.ToString() + "%" + "' or casenum like '" + tb_prisoner.Text.ToString() + "%" + "' ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            datagrid_case.ItemsSource = dt.DefaultView;
            con.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bailinfo bail = new bailinfo();
            bail.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            bailinfo bail = new bailinfo();
            bail.Show();
            
        }
    }
}
