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
    /// Interaction logic for visitorReports.xaml
    /// </summary>
    public partial class visitorReports : Window
    {
        public visitorReports()
        {
            InitializeComponent();
        }


        // get data in dataset
        private DataTable GetVisitors()
        {
            SqlConnection cons = new SqlConnection(@"Data Source=DESKTOP-RVI30EH\SQLEXPRESS;Initial Catalog=jms;Integrated Security=True");
            cons.Open();
            SqlCommand cmd = new SqlCommand("select * from visitor  where datevisit between '" + from.Text.ToString() + "' and'" + to.Text.ToString() + "'", cons);
            SqlCommand command = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.SelectCommand = cmd;
            da.Fill(dt);
            cons.Close();
            return dt;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            visitorReportViewer.Reset();
            DataTable tb = GetVisitors();
            DataTable tb1 = GetDate();

            ReportDataSource ds = new ReportDataSource("DataSet1", tb);
            visitorReportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", tb1));
            visitorReportViewer.LocalReport.DataSources.Add(ds);
            visitorReportViewer.LocalReport.ReportEmbeddedResource = "JailManagementSystem.reports.visitorReports.rdlc";
            visitorReportViewer.LocalReport.Refresh();
            visitorReportViewer.RefreshReport();
        }
        

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void WindowsFormsHost_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }
        private DataTable GetDate()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RVI30EH\SQLEXPRESS;Initial Catalog=jms;Integrated Security=True");
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
