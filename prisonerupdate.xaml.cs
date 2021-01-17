using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
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
    /// Interaction logic for prisonerupdate.xaml
    /// </summary>
    public partial class prisonerupdate : Window
    {
        public prisonerupdate()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RVI30EH\SQLEXPRESS;Initial Catalog=jms;Integrated Security=True");

        private void Button_Click(object sender, RoutedEventArgs e)
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
            
            con.Open();
            string cmnd = "insert into jailofficer values('" + "jailofficer" + "', '" + username.Text.ToString() + "', '" + sBuilder.ToString() + "',' " + position.Text.ToString() + "',";
            cmnd += "  '" + lastname.Text.ToString() + "','" + firstname.Text.ToString() + "','" + middlename.Text.ToString() + "','" + "0" + "','" + "0" + "','" + "0" + "','" + "0" + "','" + "0" + "','" + "0" + "','" + "0" + "','" + "0" + "','" + "0" + "','" + "0" + "','" + "0" + "','" + "0" + "')";
            SqlCommand command = con.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = cmnd;
            command.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("SUCCESSFULLY ADDED!!");
            this.Close();
            dashboard db = new dashboard();
            db.jailofficer.Visibility = Visibility.Collapsed;
            db.jailofficer.Visibility = Visibility.Visible;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
