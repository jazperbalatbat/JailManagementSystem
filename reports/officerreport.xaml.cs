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
    /// Interaction logic for officerreport.xaml
    /// </summary>
    public partial class officerreport : Window
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RVI30EH\SQLEXPRESS;Initial Catalog=jms;Integrated Security=True");
        public officerreport()
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
            officerReportViewer.Reset();
            DataTable tb = GetOfficer();
            DataTable tb1 = GetDate();
            ReportDataSource ds = new ReportDataSource("DataSet1", tb);
            officerReportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", tb1));
            officerReportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet3", tb));
            officerReportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet4", tb));
            officerReportViewer.LocalReport.DataSources.Add(ds);
            officerReportViewer.LocalReport.ReportEmbeddedResource = "JailManagementSystem.reports.officerreport.rdlc";
            officerReportViewer.LocalReport.Refresh();
            officerReportViewer.RefreshReport();
        }
        private DataTable GetOfficer()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select jailofficer.id, jailofficer.firstname, jailofficer.lastname, jailofficer.middlename, jailofficer.position, jailofficer.password,jailofficer.username,joattendance_in.datetimein, joattendance_out.datetimeout from jailofficer inner join joattendance_in on jailofficer.id = joattendance_in.jo_id inner join joattendance_out on joattendance_in.jo_id = joattendance_out.jo_id where datetimein between '" + from.Text.ToString() + "' and'" + to.Text.ToString() + "'";
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
