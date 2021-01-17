using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JailManagementSystem.objects
{
    class restore
    {

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RVI30EH\SQLEXPRESS;Initial Catalog=jms;Integrated Security=True");
        public int id { get; set; }
        public String firstname { get; set; }
        public String lastname { get; set; }
        public String middlename { get; set; }
        public String address { get; set; }
        public String age { get; set; }
        public String gender { get; set; }
        public String birthdate { get; set; }
        public String height { get; set; }
        public String weight { get; set; }
        public String citizenship { get; set; }
        public String religion { get; set; }
        public String datein { get; set; }
        public String civilstatus { get; set; }
        public String jailstatus { get; set; }
        public String person_id { get; set; }
        public String face_id { get; set; }
        public String searchdb { get; set; }

        public restore()
        {

        }

        public restore(int id)
        {
            SqlDbConnection con = new SqlDbConnection();

            con.Adaptor("select * from archive_prisoner where id=" + id.ToString());


            DataTable dt = con.Fill();

            this.id = dt.Rows[0].Field<int>("id");
            this.firstname = dt.Rows[0].Field<String>("firstname");
            this.lastname = dt.Rows[0].Field<String>("lastname");
            this.middlename = dt.Rows[0].Field<String>("middlename");
            this.address = dt.Rows[0].Field<String>("address");
            this.age = dt.Rows[0].Field<String>("age");
            this.gender = dt.Rows[0].Field<String>("gender");
            this.birthdate = dt.Rows[0].Field<String>("birthdate");
            this.height = dt.Rows[0].Field<String>("height");
            this.weight = dt.Rows[0].Field<String>("weight");
            this.citizenship = dt.Rows[0].Field<String>("citizenship");
            this.religion = dt.Rows[0].Field<String>("religion");
            this.datein = dt.Rows[0].Field<String>("datein");
            this.civilstatus = dt.Rows[0].Field<String>("civilstatus");
            this.jailstatus = dt.Rows[0].Field<String>("jailstatus");
            this.person_id = dt.Rows[0].Field<String>("person_id");
            this.face_id = dt.Rows[0].Field<String>("face_id");
            this.searchdb = dt.Rows[0].Field<String>("searchdb");
        }


        public void add()
        {
            string cmnd = "insert into prisoner values('" + this.lastname + "',";
            cmnd += "'" + this.firstname + "','" + this.middlename + "','" + this.address + "','" + this.age + "','" + this.gender + "','" + this.birthdate + "','" + this.height + "','" + this.weight + "','" + this.citizenship + "'" +
                ",'" + this.religion + "','" + this.datein + "','" + this.civilstatus + "','" + this.jailstatus + "','" + this.firstname + "','" + this.lastname + "')";
            con.Open();
            SqlCommand command = con.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = cmnd;

            command.ExecuteNonQuery();
            con.Close();
        }
    }
}
