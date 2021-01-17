using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace JailManagementSystem.objects
{
    class jailofficers
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RVI30EH\SQLEXPRESS;Initial Catalog=jms;Integrated Security=True");

        public string id { get; set; }
        public string jo { get; set; }
        public String username { get; set; }
        public String password { get; set; }
        public String position { get; set; }
        public String firstname { get; set; }
        public String firstnames { get; set; }
        public String lastname { get; set; }
        public String middlename { get; set; }
        public int prisoner { get; set; }
        public int visitor { get; set; }
        public int cell { get; set; }
        public int casee { get; set; }
        public int escort { get; set; }
        public int prisoner_report { get; set; }
        public int visitor_report { get; set; }
        public int case_report { get; set; }
        public int hearing_report { get; set; }
        public int bail_report { get; set; }
        public int cell_report { get; set; }
        public int jailofficer_report { get; set; }

        public jailofficers()
        {

        }

        public jailofficers(int id)
        {
            SqlDbConnection con = new SqlDbConnection();

            con.Adaptor("select * from jailofficer where id=" + id.ToString());
            DataTable dt = con.Fill();

            this.id = dt.Rows[0].Field<string>("id");
            this.username = dt.Rows[0].Field<String>("username");
            this.password = dt.Rows[0].Field<String>("password");
            this.position = dt.Rows[0].Field<String>("position");
            this.firstname = dt.Rows[0].Field<String>("firstname");
            this.lastname = dt.Rows[0].Field<String>("lastname");
            this.middlename = dt.Rows[0].Field<String>("middlename");
            this.prisoner = dt.Rows[0].Field<int>("prisoner");
            this.visitor = dt.Rows[0].Field<int>("visitor");
            this.casee = dt.Rows[0].Field<int>("casee");
            this.cell = dt.Rows[0].Field<int>("cell");
            this.escort = dt.Rows[0].Field<int>("escort");
            this.prisoner_report = dt.Rows[0].Field<int>("prisoner_report");
            this.visitor_report = dt.Rows[0].Field<int>("visitor_report");
            this.case_report = dt.Rows[0].Field<int>("case_report");
            this.cell_report = dt.Rows[0].Field<int>("cell_report");
            this.hearing_report = dt.Rows[0].Field<int>("hearing_report");
            this.bail_report = dt.Rows[0].Field<int>("bail_report");
            this.jailofficer_report = dt.Rows[0].Field<int>("jailofficer_report");
        }

        public void add()
        {
            string cmnd = "update jailofficer set lastname='" + this.lastname + "', firstname= '" + this.firstname + "', middlename = '" + this.middlename + "', prisoner = '" + this.prisoner + 
                "', visitor = '" + this.visitor + "', casee = '" + this.casee +
                "', cell = '" + this.cell + "', escort = '" + this.escort +
                "', prisoner_report = '" + this.prisoner_report + "', visitor_report = '" + this.visitor_report + "', case_report = '" + this.case_report + 
                "', cell_report = '" + this.cell_report + "', jailofficer_report = '" + this.jailofficer_report + "', hearing_report = '" + this.hearing_report + "', bail_report = '" + this.bail_report +
                 "', position = '" + this.position + "' where id = '" + this.id + "'";

            con.Open();
            SqlCommand command = con.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = cmnd;
            command.ExecuteNonQuery();
            con.Close();

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

        public void refreshCB()
        {
            dashboard db = new dashboard();
            db.access_prisoner.IsChecked = false;
            db.access_visitor.IsChecked = false;
            db.access_cell.IsChecked = false;
            db.access_case.IsChecked = false;
            db.access_escort.IsChecked = false;
            db.access_prisonerreport.IsChecked = false;
            db.access_visitorreport.IsChecked = false;
            db.access_cellreport.IsChecked = false;
            db.access_casereport.IsChecked = false;
            db.access_jailofficerreport.IsChecked = false;
        }
    }
}
