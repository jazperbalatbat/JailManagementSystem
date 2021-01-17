using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JailManagementSystem.objects
{
    class audittrail
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RVI30EH\SQLEXPRESS;Initial Catalog=jms;Integrated Security=True");
        public int id { get; set; }
        public String users { get; set; }
        public String activity { get; set; }
        public String dateOfActivity { get; set; }
        public String timeOfActivity { get; set; }

        public audittrail()
        {

        }

        public audittrail(int id)
            {

                SqlDbConnection con = new SqlDbConnection();
                con.Adaptor("select * from audit where id=" + id.ToString());
                DataTable dt = con.Fill();
                this.id = dt.Rows[0].Field<int>("id");
                this.users = dt.Rows[0].Field<String>("users");
                this.activity= dt.Rows[0].Field<String>("activity");
                this.dateOfActivity = dt.Rows[0].Field<String>("dateOfActivity");
                this.timeOfActivity = dt.Rows[0].Field<String>("timeOfActivity");


            }
            public void add()
            {
            string cmnd = "insert into audit values ('" + this.users+ "', '" + this.activity + "', '"+this.dateOfActivity+"','"+this.timeOfActivity+"')";
            con.Open();
            SqlCommand command = con.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = cmnd;
            command.ExecuteNonQuery();
            con.Close();
        }

        }

    
    
}
