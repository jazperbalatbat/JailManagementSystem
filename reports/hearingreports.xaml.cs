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
    /// Interaction logic for hearingreports.xaml
    /// </summary>
    public partial class hearingreports : Window
    {

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RVI30EH\SQLEXPRESS;Initial Catalog=jms;Integrated Security=True");
        public hearingreports()
        {
            InitializeComponent();
        }

        private void WindowsFormsHost_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            hearingReportViewer.Reset();
            DataTable tb = GetHearing();
            DataTable tb1= GetDate();
            ReportDataSource ds = new ReportDataSource("DataSet1", tb);
            hearingReportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", tb1));
            hearingReportViewer.LocalReport.DataSources.Add(ds);
            hearingReportViewer.LocalReport.ReportEmbeddedResource = "JailManagementSystem.reports.hearingReport.rdlc";
            hearingReportViewer.LocalReport.Refresh();
            hearingReportViewer.RefreshReport();

        }
        private DataTable GetHearing()
        {

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from hearing  where hearingdate between '" + from.Text.ToString() + "' and'" + to.Text.ToString() + "'";
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
