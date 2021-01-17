using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using JailManagementSystem.Properties;

namespace JailManagementSystem.objects
{
    class visitors
    {
        public int id { get; set; }
        public String relation { get; set; }
        public String firstname { get; set; }
        public String lastname { get; set; }
        public String middlename { get; set; }
        public String address { get; set; }
        public String gender { get; set; }
        public String visit { get; set; }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RVI30EH\SQLEXPRESS;Initial Catalog=jms;Integrated Security=True");

        public visitors()
        {

        }

        public visitors(int id)
        {
            SqlDbConnection con = new SqlDbConnection();

            con.Adaptor("select * from visitor where id=" + id.ToString());
            DataTable dt = con.Fill();

            this.id = dt.Rows[0].Field<int>("id");
            this.relation = dt.Rows[0].Field<String>("relation");
            this.firstname = dt.Rows[0].Field<String>("firstname");
            this.lastname = dt.Rows[0].Field<String>("lastname");
            this.middlename = dt.Rows[0].Field<String>("middlename");
            this.address = dt.Rows[0].Field<String>("address");
            this.gender = dt.Rows[0].Field<String>("gender");
            this.visit = dt.Rows[0].Field<String>("visit");
        }

        public void add()
        {

            string cmnd = "insert into visitor values('" + this.lastname + "', '" + this.firstname + "', '" + this.middlename+ "',' " + this.address + "',";
            cmnd += "  '" + this.gender + "','" + this.visit + "','" + this.relation + "','" + "" + "','" + "" + "','" + "" + "','" + "" + "')";

            con.Open();
            SqlCommand command = con.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = cmnd;
            command.ExecuteNonQuery();
            con.Close();
           
        }
    }
}
