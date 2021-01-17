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
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace JailManagementSystem
{
    /// <summary>
    /// Interaction logic for register.xaml
    /// </summary>
    public partial class register : Window
    {
        public register()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RVI30EH\SQLEXPRESS;Initial Catalog=jms;Integrated Security=True");

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string query = "select * from jailofficer where lastname = '" + lastname.Text.ToString() + "'";
            SqlCommand coms = new SqlCommand(query, con);
            SqlDbConnection cons = new SqlDbConnection();
            cons.Adaptor(query);
            DataTable dt = cons.Fill();

            con.Open();
            SqlDataReader reads = coms.ExecuteReader();
            while (reads.Read())
            {

                string fn = (reads["firstname"].ToString());
                string ln = (reads["lastname"].ToString());
                string mn = (reads["middlename"].ToString());
                string p = (reads["position"].ToString());

                if (firstname.Text != fn && lastname.Text != ln && middlename.Text != mn && position.Text != p)
                {
                    if (position.Text != "" && lastname.Text != "" && firstname.Text != ""  && address0.Text != "" && address1.Text != "" && birthdate.Text != "" 
                        && age.Text != "" && username.Text != "" && password.Password != "")
                        {
                            MD5 md5Hash = MD5.Create();
                            // Create a new instance of the MD5CryptoServiceProvider object.
                            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();

                            // Convert the input string to a byte array and compute the hash.
                            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(password.Password));

                            // Create a new Stringbuilder to collect the bytes
                            // and create a string.
                            StringBuilder sBuilder = new StringBuilder();

                            // Loop through each byte of the hashed data 
                            // and format each one as a hexadecimal string.
                            for (int i = 0; i < data.Length; i++)
                            {
                                sBuilder.Append(data[i].ToString("x2"));
                            }

                            string address = address0.Text.ToString() + " " + address1.Text.ToString();
                            string cmnd = "insert into jailofficer values('" + position.Text.ToString() + "', '" + lastname.Text.ToString() + "', '" + firstname.Text.ToString() + "',' " + middlename.Text.ToString() + "',";
                            cmnd += "  '" + address.ToString() + "','" + birthdate.Text.ToString() + "','" + age.Text.ToString() +  "','" + username.Text.ToString() + "','" + password.Password.ToString() + "','" + "" + "','" + "" + "','" + "" + "','" + "" + "')";

                            con.Open();
                            SqlCommand command = con.CreateCommand();
                            command.CommandType = CommandType.Text;
                            command.CommandText = cmnd;
                            command.ExecuteNonQuery();
                            con.Close();
                            this.Close();
                        position.Text = "";
                        lastname.Text = "";
                        firstname.Text = "";
                        middlename.Text = "";
                        address0.Text = "";
                        address1.Text = "";
                        birthdate.Text = "";
                        age.Text = "";
                        username.Text = "";
                        password.Password = "";
                        xpassword.Password = "";
                        registers.IsEnabled = false;
                        MessageBox.Show("Congratulations, You have an Account!");
                        }

                        else
                        {
                            MessageBox.Show("INVALID INPUTS!");
                        }

        }
                else
                {
                    MessageBox.Show("THIS VISITOR IS ALREADY IN THE DATABASE");
                    position.Text = "";
                    lastname.Text = "";
                    firstname.Text = "";
                    middlename.Text = "";
                    address0.Text = "";
                    address1.Text = "";
                    birthdate.Text = "";
                    age.Text = "";
                    username.Text = "";
                    password.Password = "";
                    xpassword.Password = "";
                    registers.IsEnabled = false;
                }
                        
                }
    reads.Close();
                con.Close();
                

        }

            private void Button_Click_2(object sender, RoutedEventArgs e)
            {
                this.Close();
            }

            private void Button_Click_3(object sender, RoutedEventArgs e)
            {
                if (xpassword.Password != password.Password)
                {
                    xpassword.Password = "";
                    password.Password = "";
                    MessageBox.Show("Your password doesn't match!");
                }
            else
            {
                MessageBox.Show("Password Confirmed! :)");
                registers.IsEnabled = true;
            }
            }

        private void birthdate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DateTime start = birthdate.SelectedDate.Value.Date;
                TimeSpan difference = start.Subtract(DateTime.Now);
                string x = difference.ToString("%d");
                long y = Convert.ToInt64(x);
                long z = y / 365;
                if (z <= 18)
                {
                    MessageBox.Show("Your age should be legal to proceed! sorry!");
                    birthdate.Text = "";
                }
                else
                    age.Text = z.ToString();
            }

            catch
            {

            }
            
        }
    }
}

