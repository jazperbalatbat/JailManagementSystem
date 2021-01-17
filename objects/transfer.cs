using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace JailManagementSystem.objects
{
    class transfer
    {
        public int id { get; set; }
        public String cell { get; set; }
        public String reason { get; set; }
        public String lastname { get; set; }
        public String firstname { get; set; }
        public String inmatenum { get; set; }


        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RVI30EH\SQLEXPRESS;Initial Catalog=jms;Integrated Security=True");

        public transfer()
        {

        }
        public transfer (int id)
        {
            SqlDbConnection con = new SqlDbConnection();

            con.Adaptor("select * from celltransfer where id=" + id.ToString());
            DataTable dt = con.Fill();

            this.id = dt.Rows[0].Field<int>("id");
            this.cell = dt.Rows[0].Field<String>("cell");
            this.reason = dt.Rows[0].Field<String>("reason");
            this.lastname = dt.Rows[0].Field<String>("lastname");
           
            this.firstname = dt.Rows[0].Field<String>("firstname");
            this.inmatenum = dt.Rows[0].Field<String>("inmatenum");
        

        }
        public void celltrans_add()
        {
            con.Open();
            
            string cmnd = "insert into celltransfer values('" + this.cell+ "', '"+ this.reason + "', '" + this.lastname + "','" + this.firstname + "','" +this.inmatenum+"')";
         
            SqlCommand command = con.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = cmnd;
            command.ExecuteNonQuery();
            con.Close();
        }
        public void celltrans_update()
        {

        }

    }
}
