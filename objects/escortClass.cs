using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JailManagementSystem.objects
{
    class escortClass
    {
        public int id { get; set; }
        public String escort { get; set; }
        public String firstname { get; set; }
        public String lastname { get; set; }
        public String position { get; set; }
      
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RVI30EH\SQLEXPRESS;Initial Catalog=jms;Integrated Security=True");

        public escortClass()
        {

        }

        public escortClass(int id)
        {
            SqlDbConnection con = new SqlDbConnection();
            con.Adaptor("select * from escort where id=" + id.ToString());
            DataTable dt = con.Fill();
            this.id = dt.Rows[0].Field<int>("id");
            this.escort = dt.Rows[0].Field<String>("escort");
            this.firstname = dt.Rows[0].Field<String>("firstname");
            this.lastname = dt.Rows[0].Field<String>("lastname");
            this.position = dt.Rows[0].Field<String>("position");
           

        }
        public void add()
        {

            string cmnd = "insert into escort values('" + this.escort + "','" + this.lastname + "','" + this.firstname + "','" + this.position + "')";
            con.Open();
            SqlCommand command = con.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = cmnd;
            command.ExecuteNonQuery();
            con.Close();

        }
    }



}
