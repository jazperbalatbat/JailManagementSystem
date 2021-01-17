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
    /// Interaction logic for cellstatusreport.xaml
    /// </summary>
    public partial class cellstatusreport : Window
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RVI30EH\SQLEXPRESS;Initial Catalog=jms;Integrated Security=True");
        public cellstatusreport()
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
            caseReportViewer.Reset();
            DataTable tb = GetCases();
            ReportDataSource ds = new ReportDataSource("DataSet1", tb);
            caseReportViewer.LocalReport.DataSources.Add(ds);
            caseReportViewer.LocalReport.ReportEmbeddedResource = "JailManagementSystem.reports.cellstatus.rdlc";
            caseReportViewer.LocalReport.Refresh();
            caseReportViewer.RefreshReport();
        }
        private DataTable GetCases()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from cell  ", con);
            SqlCommand command = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }
    }
}
