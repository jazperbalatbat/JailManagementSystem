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
    /// Interaction logic for addescort.xaml
    /// </summary>
    public partial class addescort : Window
    {
        escortClass es = new escortClass();

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RVI30EH\SQLEXPRESS;Initial Catalog=jms;Integrated Security=True");
        public addescort()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            con.Open();
            SqlCommand cmds = con.CreateCommand();
            cmds.CommandType = CommandType.Text;
            cmds.CommandText = "select prisoner.id,prisoner.lastname,prisoner.firstname,prisoner.middlename, hearing.hearingdate, hearing.hearingtime from prisoner inner join hearing on prisoner.id = hearing.inmatenum";
            cmds.ExecuteNonQuery();
            DataTable dts = new DataTable();
            SqlDataAdapter das = new SqlDataAdapter(cmds);
            das.Fill(dts);
            datagrid_escort.ItemsSource = dts.DefaultView;
            con.Close();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            this.Close();
            escort es = new escort();
            loading l = new loading();
            l.Show();
            es.Show();
          
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
              
               es.lastname = lastname.Text.ToString();
               es.firstname = firstname.Text.ToString();
               es.position = position.Text.ToString();
               es.escort = p_id.Text.ToString();
                if (lastname.Text.ToString() != "" && firstname.Text.ToString() != "" && position.Text.ToString() !=  "" && p_id.Text.ToString() != "")
                {
                es.add();
                    MessageBox.Show("Succesfully inserted!");
                    this.Close();
                    escort escort = new escort();
                    escort.Show();
                    loading l = new loading();
                    l.Show();

                }
                else
                    MessageBox.Show("INVALID INPUTS!");
            
        }
        private void datagrid_escort_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
                p_hearingdate.Text = row_selected["hearingdate"].ToString();
                p_hearingtime.Text = row_selected["hearingtime"].ToString();
            }
        }
    }
}
