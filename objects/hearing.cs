using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace JailManagementSystem.objects
{
    class hearing
    {
        public int id { get; set; }
        public String inmatenum { get; set; }
        public String hearingdate { get; set; }
        public String hearingtime { get; set; }
        public String escort { get; set; }


        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RVI30EH\SQLEXPRESS;Initial Catalog=jms;Integrated Security=True");

        public hearing()
        {

        }

        public hearing (int id)
        {
            SqlDbConnection con = new SqlDbConnection();

            con.Adaptor("select * from hearing where id=" + id.ToString());
            DataTable dt = con.Fill();
            this.id = dt.Rows[0].Field<int>("id");
            this.inmatenum = dt.Rows[0].Field<String>("inmatenum");
            this.hearingdate = dt.Rows[0].Field<String>("hearingdate");
            this.hearingtime = dt.Rows[0].Field<String>("hearingtime");

            this.escort = dt.Rows[0].Field<String>("escort");
        }

         public void hearing_add()
        {
            string cmnd = "insert into hearing values('" + this.inmatenum + "','" + this.hearingdate + "','" + this.hearingtime + "', '"+this.escort+"')";
            con.Open();
            SqlCommand command = con.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = cmnd;
            command.ExecuteNonQuery();
            MessageBox.Show("Successfully inserted!");
            con.Close();

        }
    }
   
}
