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
    /// Interaction logic for prisonerreports.xaml
    /// </summary>
    public partial class prisonerreports : Window
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RVI30EH\SQLEXPRESS;Initial Catalog=jms;Integrated Security=True");
        public prisonerreports()
        {
            InitializeComponent();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            date.Visibility = Visibility.Visible;
            select.Visibility = Visibility.Visible;
            search.Visibility = Visibility.Hidden;
        }

        private void ComboBoxItem_Selected_1(object sender, RoutedEventArgs e)
        {
            search.Visibility = Visibility.Visible;
            select.Visibility = Visibility.Visible;
            date.Visibility = Visibility.Hidden;
        }

        // get data in dataset
        private DataTable GetPrisoners()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from prisoner  where datein between '" + from.Text.ToString()+ "' and'" + to.Text.ToString() + "'";
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            inmateReportViewer.Reset();
            DataTable tb = GetPrisoners();
            DataTable tb1 = GetDate();
           
            ReportDataSource ds = new ReportDataSource("DataSet1", tb);
            //inmateReportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", tb2));
            inmateReportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", tb1));
            inmateReportViewer.Refresh();
            inmateReportViewer.LocalReport.DataSources.Add(ds);
            inmateReportViewer.LocalReport.ReportEmbeddedResource = "JailManagementSystem.reports.prisonerSummary.rdlc";
            inmateReportViewer.LocalReport.Refresh();
            inmateReportViewer.RefreshReport();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            inmateReportViewer.Reset();
            DataTable tb2 = GetIndividualPrisoners();
            ReportDataSource ds2 = new ReportDataSource("DataSet1", tb2);
            inmateReportViewer.LocalReport.DataSources.Add(ds2);
            inmateReportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", tb2));
            inmateReportViewer.LocalReport.ReportEmbeddedResource = "JailManagementSystem.reports.prisonerIndividual.rdlc";
            inmateReportViewer.LocalReport.Refresh();
            inmateReportViewer.RefreshReport();
        }
        private DataTable GetIndividualPrisoners()
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("select * from prisoner inner join cases on cases.inmatenum = prisoner.id where lastname like '" + searchp.Text.ToString() + "%" + "' or firstname like '" + searchp.Text.ToString() + "%" + "' or middlename like '" + searchp.Text.ToString() + "%" + "' or address like '" + searchp.Text.ToString() + "%" + "'", con);
            SqlCommand command = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }

        //private DataTable GetColumn()
        //{

        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("Select '" + select1.Text.ToString() + "' from prisoner");
        //    SqlCommand command = new SqlCommand();
        //    cmd.CommandType = CommandType.Text;
        //    DataTable dt = new DataTable();
        //    SqlDataAdapter da = new SqlDataAdapter(command);
        //    da.SelectCommand = cmd;
        //    da.Fill(dt);
        //    con.Close();
        //    return dt;
        //}

        private void WindowsFormsHost_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }


    }
}
