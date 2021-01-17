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
using JailManagementSystem.objects;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;

namespace JailManagementSystem.visitor
{
    /// <summary>
    /// Interaction logic for visitoradd.xaml
    /// </summary>
    public partial class visitoradd : Window
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RVI30EH\SQLEXPRESS;Initial Catalog=jms;Integrated Security=True");

        public visitoradd()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
            visitormain pm = new visitormain();
            loading l = new loading();
            l.Show();
            pm.Show();

        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            con.Open();
            SqlCommand cmds = con.CreateCommand();
            cmds.CommandType = CommandType.Text;
            cmds.CommandText = "select id, lastname, firstname, middlename from prisoner";
            cmds.ExecuteNonQuery();
            DataTable dts = new DataTable();
            SqlDataAdapter das = new SqlDataAdapter(cmds);
            das.Fill(dts);
            datagrid_visitors.ItemsSource = dts.DefaultView;
            con.Close();

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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            visitors visitors = new visitors();
            visitors.lastname = lastname.Text.ToString();
            visitors.firstname = firstname.Text.ToString();
            visitors.middlename = middlename.Text.ToString();
            visitors.address = address0.Text.ToString() + " " + address1.Text.ToString();
            visitors.gender = gender.Text.ToString();
            visitors.visit = vp_id.Text.ToString();
            visitors.relation = relation.Text.ToString();
            if (lastname.Text.ToString() != "" && firstname.Text.ToString() != "" && middlename.Text.ToString() != "" && address0.Text.ToString() != "" && gender.Text.ToString() != "" && vp_id.Text.ToString() != "" && relation.Text.ToString() != "" && address1.Text.ToString() != "")
            {
                string query = "select * from visitor where lastname = '" + lastname.Text.ToString() +  "'";
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

                        string fn = (reads["firstname"].ToString());
                        string ln = (reads["lastname"].ToString());
                        string mn = (reads["middlename"].ToString());

                        if (firstname.Text != fn && lastname.Text != ln && middlename.Text != mn)
                        {
                            visitors.add();
                            MessageBox.Show("You have Added a new Visitor!");
                            this.Close();
                            visitormain pm = new visitormain();

                            pm.Show();
                            loading l = new loading();
                            l.Show();
                        }
                        else
                            MessageBox.Show("THIS VISITOR IS ALREADY IN THE DATABASE");
                    }
                    reads.Close();
                    con.Close();
                    

                }
                else
                    MessageBox.Show("INVALID INPUTS!");
            }
        }
    }
}
