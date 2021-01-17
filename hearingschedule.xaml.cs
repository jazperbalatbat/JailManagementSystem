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
    /// Interaction logic for hearingschedule.xaml
    /// </summary>
    public partial class hearingschedule : Window
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RVI30EH\SQLEXPRESS;Initial Catalog=jms;Integrated Security=True");
        public hearingschedule()
        {
            InitializeComponent();
        }

        //LOAD DATAGRID VALUES
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select prisoner.id, prisoner.lastname, prisoner.firstname, prisoner.middlename ,hearing.escort, hearing.hearingdate, hearing.hearingtime from prisoner inner join hearing on prisoner.id = hearing.inmatenum";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            datagrid_hearing.ItemsSource = dt.DefaultView;
            con.Close();

        




        }

        //EDIT A PRISONER
        private void datagrid_hearing_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {





        }

        //SELECT ROW AND VISIBILITY OF DELETE BUTTON
        private void datagrid_hearing_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


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
            cmd.CommandText = "select prisoner.id, prisoner.lastname, prisoner.firstname, prisoner.middlename , hearing.hearingdate, hearing.hearingtime from prisoner inner join hearing on prisoner.id = hearing.inmatenum where lastname like '" + tb_prisoner.Text.ToString() + "%" + "' or firstname like '" + tb_prisoner.Text.ToString() + "%" + "' or middlename like '" + tb_prisoner.Text.ToString() + "%" + "' or escort like '" + tb_prisoner.Text.ToString() + "%" + "' ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            datagrid_hearing.ItemsSource = dt.DefaultView;
            con.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

