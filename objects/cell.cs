using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace JailManagementSystem.objects
{
    class cell
    {
        public int id { get; set; }
        public String cellnum { get; set; }
        public String description { get; set; }
        public int num_inmates { get; set; }
        public String status { get; set; }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RVI30EH\SQLEXPRESS;Initial Catalog=jms;Integrated Security=True");

        public cell()
        {

        }
        public cell(int id)
        {
            SqlDbConnection con = new SqlDbConnection();

            con.Adaptor("select * from cell where id=" + id.ToString());
            DataTable dt = con.Fill();

            this.id = dt.Rows[0].Field<int>("id");
            this.cellnum = dt.Rows[0].Field<String>("cellnum");
            this.description = dt.Rows[0].Field<String>("description");
            this.num_inmates = dt.Rows[0].Field<int>("num_inmates");
            this.status = dt.Rows[0].Field<String>("status");


        }
        public void cell_add()
        {
            //string cmnd = "insert into cell values ('" + this.cellnum + "', '" + this.de + "')";
            //con.Open();
            //SqlCommand command = con.CreateCommand();
            //command.CommandType = CommandType.Text;
            //command.CommandText = cmnd;
            //command.ExecuteNonQuery();
            //con.Close();
        }
        public void cell_update()
        {

        }

    }
}
