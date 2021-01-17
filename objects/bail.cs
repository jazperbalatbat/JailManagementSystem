using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JailManagementSystem
{
    class bail
    {
        public int id { get; set; }
        public String inmatenum { get; set; }
        public String inmatename { get; set; }
        public String offense { get; set; }
        public String cases { get; set; }
        public String datebailed { get; set; }
        public String bond { get; set; }
        public String court { get; set; }
        public String approved { get; set; }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RVI30EH\SQLEXPRESS;Initial Catalog=jms;Integrated Security=True");

        public bail()
        {

        }

        public bail(int id)
        {
            SqlDbConnection con = new SqlDbConnection();

            con.Adaptor("select * from bail where id=" + id.ToString());
            DataTable dt = con.Fill();
            this.id = dt.Rows[0].Field<int>("id");
            this.inmatename = dt.Rows[0].Field<String>("inmatename");
            this.inmatenum = dt.Rows[0].Field<String>("inmatenumber");
            this.offense = dt.Rows[0].Field<String>("offense");
            this.cases = dt.Rows[0].Field<String>("cases");
            this.datebailed = dt.Rows[0].Field<String>("datebailed");
            this.bond = dt.Rows[0].Field<String>("bond");
            this.court = dt.Rows[0].Field<String>("court");
            this.approved = dt.Rows[0].Field<String>("approved");
          

        }
        public void bail_add()
        {


            string cmnd = "insert into bail values('" +this.inmatename + "','" + this.inmatenum + "','" + this.offense + "','" + this.cases + "','" + this.datebailed + "','" + this.bond + "','" + this.court + "','" + this.approved + "')";


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
