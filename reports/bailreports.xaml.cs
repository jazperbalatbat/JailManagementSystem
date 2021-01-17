using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace JailManagementSystem.reports
{
    /// <summary>
    /// Interaction logic for bailreports.xaml
    /// </summary>
    public partial class bailreports : Window
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RVI30EH\SQLEXPRESS;Initial Catalog=jms;Integrated Security=True");
        public bailreports()
        {
            InitializeComponent();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void WindowsFormsHost_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           bailReportViewer.Reset();
            DataTable tb = Getbail();
            DataTable tb1 = GetDate();
            ReportDataSource ds = new ReportDataSource("DataSet1", tb);
            bailReportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", tb1));
            bailReportViewer.LocalReport.DataSources.Add(ds);
            bailReportViewer.LocalReport.ReportEmbeddedResource = "JailManagementSystem.reports.bailedreports.rdlc";
            bailReportViewer.LocalReport.Refresh();
            bailReportViewer.RefreshReport();




        }
        private DataTable Getbail()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from bail where datebailed between '" + from.Text.ToString() + "' and'" + to.Text.ToString() + "'";
            cmd.CommandText += "update datefromTo set fromDate = '" + from + "', toDate = '" + to + "' where id = 1 ";


            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        private DataTable GetDate()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText += "select * from datefromTo where id = 1";

            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;

        }



    }
}
