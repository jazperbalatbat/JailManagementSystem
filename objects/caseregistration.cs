using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JailManagementSystem.objects
{


    class caseregistration
    {
        public int id { get; set; }
        public String inmatename { get; set; }
        public String inmatenum { get; set; }
        public String casenum { get; set; }
        public String offense { get; set; }
        public String datefiled { get; set; }
        public String datesen { get; set; }
        public String senstatus { get; set; }
        public String senreceive { get; set; }
        public String sendue { get; set; }
      

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RVI30EH\SQLEXPRESS;Initial Catalog=jms;Integrated Security=True");

        public caseregistration()
        {

        }
     
        public caseregistration (int id)
        {
            SqlDbConnection con = new SqlDbConnection();

            con.Adaptor("select * from cases where id=" + id.ToString());
            DataTable dt = con.Fill();
            this.id = dt.Rows[0].Field<int>("id");
            this.inmatename = dt.Rows[0].Field<String>("inmatename");
            this.inmatenum = dt.Rows[0].Field<String>("inmatenum");
            this.casenum = dt.Rows[0].Field<String>("case number");
            this.offense = dt.Rows[0].Field<String>("offense");
            this.datefiled = dt.Rows[0].Field<String>("datefiled");
            this.datesen = dt.Rows[0].Field<String>("date sentence");
            this.senstatus = dt.Rows[0].Field<String>("sentence status");
            this.senreceive = dt.Rows[0].Field<String>("sentence receive");
            this.sendue = dt.Rows[0].Field<String>("sentence due");
           

        }
        public void case_add()
        {
            string cmnd = "insert into cases values('" + this.inmatename+ "','" + this.inmatenum+ "', '" + this.casenum + "',";
            cmnd += "'" + this.offense + "','" + this.datefiled + "','" + this.datesen + "','" + this.senstatus + "','" + this.senreceive + "','" + this.sendue + "')";
            con.Open();
            SqlCommand command = con.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = cmnd;
            command.ExecuteNonQuery();
            con.Close();
        }


    }
}
