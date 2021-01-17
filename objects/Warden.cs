using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace JailManagementSystem.objects
{

    class Warden
    {
        public string id { get; set; }
        public string admin { get; set; }
        public String newusername { get; set; }
        public String newpassword { get; set; }
        public String username { get; set; }
        public String firstname { get; set; }
        public String lastname { get; set; }
        public String password { get; set; }
        SqlConnection cons = new SqlConnection(@"Data Source=DESKTOP-RVI30EH\SQLEXPRESS;Initial Catalog=jms;Integrated Security=True");

        public Warden()
        {

        }

        public Warden(int id)
        {

            SqlDbConnection con = new SqlDbConnection();

            con.Adaptor("select * from warden where id=" + id.ToString());
            DataTable dt = con.Fill();

            this.id = dt.Rows[0].Field<string>("id");
            this.username = dt.Rows[0].Field<String>("username");
            this.firstname = dt.Rows[0].Field<String>("firstname");
            this.lastname = dt.Rows[0].Field<String>("lastname");
            this.password = dt.Rows[0].Field<String>("password");
        }

        public Warden(String username)
        {

            SqlDbConnection con = new SqlDbConnection();
            cons.Open();
            con.Adaptor("select * from warden where username='" + username.Replace("'", "") + "'");
            DataTable dt = con.Fill();
            this.username = dt.Rows[0].Field<String>("username");
            cons.Close();
        }

        public void setUsername(String username)
        {
            this.username = username.Replace("'", "");
        }

        public void setPassword(String password)
        {
            this.password = getMd5Hash(password);
        }

        private string getMd5Hash(string input)
        {
            MD5 md5Hash = MD5.Create();
            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        public void save()
        {
            string cmnd = "insert into warden values('" + this.username + "', '" + this.lastname + "', '" + this.firstname + "', '" + this.password + "')";
            cons.Open();
            SqlCommand command = cons.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = cmnd;
            command.ExecuteNonQuery();
            cons.Close();
        }

        public void update()
        {
            string cmnd = "update warden set lastname='" + this.lastname + "', firstname= '" + this.firstname + "', username = '" + this.username + "', password = '" + this.password + "' where username = '" + this.newusername + "'";
            cons.Open();
            SqlCommand command = cons.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = cmnd;
            command.ExecuteNonQuery();
            cons.Close();
        }
    }
}
