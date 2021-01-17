using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JailManagementSystem.objects
{
    class visitor_archive
    {
        public int id { get; set; }
        public String firstname { get; set; }
        public String lastname { get; set; }
        public String middlename { get; set; }
        public String address { get; set; }
        public String gender { get; set; }
        public String visit { get; set; }
        public String person_id { get; set; }
        public String face_id { get; set; }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RVI30EH\SQLEXPRESS;Initial Catalog=jms;Integrated Security=True");

        public visitor_archive()
        {

        }

        public visitor_archive(int id)
        {
            SqlDbConnection con = new SqlDbConnection();

            con.Adaptor("select * from visitor where id=" + id.ToString());
            DataTable dt = con.Fill();

            this.id = dt.Rows[0].Field<int>("id");
            this.firstname = dt.Rows[0].Field<String>("firstname");
            this.lastname = dt.Rows[0].Field<String>("lastname");
            this.middlename = dt.Rows[0].Field<String>("middlename");
            this.address = dt.Rows[0].Field<String>("address");
            this.gender = dt.Rows[0].Field<String>("gender");
            this.visit = dt.Rows[0].Field<String>("visit");
            this.person_id = dt.Rows[0].Field<String>("person_id");
            this.face_id = dt.Rows[0].Field<String>("face_id");
        }

        public void add()
        {

            //string cmnd = "insert into visitor_archive values('" + this.lastname + "',";
            //cmnd += "'" + this.firstname + "','" + this.middlename + "','" + this.address + "','" + this.gender + "','" + this.visit + "','" + this.firstname + "','" + this.lastname + "')";

            //con.Open();
            //SqlCommand command = con.CreateCommand();
            //command.CommandType = CommandType.Text;
            //command.CommandText = cmnd;
            //command.ExecuteNonQuery();
            //con.Close();

        }
    }
}
