using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Windows;
using System.Text;

namespace JailManagementSystem
{
    public class SqlDbConnection
    {
        private SqlConnection con;
        public SqlCommand cmd;
        private SqlDataAdapter sda;
        private DataTable dt;

    public SqlDbConnection()
        {
            con = new SqlConnection(@"Data Source=DESKTOP-RVI30EH\SQLEXPRESS;Initial Catalog=jms;Integrated Security=True");
            con.Open();
        }

    public void Adaptor(string query)
        {
         sda = new SqlDataAdapter(query, con);
        }

        public DataTable Fill()
        {
            dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }


       // public DataTable ExQuery()
       // {
       //     sda = new SqlDataAdapter(cmd);
      //      dt = new DataTable();
       //     sda.Fill(dt);
      //      return dt;
      //  }


      public void ExNonQuery() // update insert delete
        {
            
          
        }

    }




    
}
