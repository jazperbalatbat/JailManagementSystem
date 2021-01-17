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

namespace JailManagementSystem
{
    /// <summary>
    /// Interaction logic for inmatereports.xaml
    /// </summary>
    public partial class inmatereports : Window
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RVI30EH\SQLEXPRESS;Initial Catalog=jms;Integrated Security=True");
        public inmatereports()
        {
            InitializeComponent();
        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            date.Visibility = Visibility.Visible;
            search.Visibility = Visibility.Hidden;
        }

        private void ComboBoxItem_Selected_1(object sender, RoutedEventArgs e)
        {
            search.Visibility = Visibility.Visible;
            date.Visibility = Visibility.Hidden;
        }

      
        // get data in dataset
        private DataTable GetPrisoners()
        {
            
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from prisoner  where datein between '" + from.Text.ToString() + "' and'" + to.Text.ToString() + "'", con);
            SqlCommand cmd1 = new SqlCommand("update datefromTo set  fromData = '" + from.Text+ "', dateTo = '"+to.Text+"' ", con);
            SqlCommand command = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.SelectCommand =  cmd;
            da.SelectCommand = cmd1;
            da.Fill(dt);
            con.Close();
            return dt;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            inmateReportViewer.Reset();
            DataTable tb = GetPrisoners();
            ReportDataSource ds = new ReportDataSource("DataSet1", tb);
            inmateReportViewer.LocalReport.DataSources.Add(ds);
            inmateReportViewer.LocalReport.ReportEmbeddedResource = "JailManagementSystem.reports.inmatereport.rdlc";
            inmateReportViewer.LocalReport.Refresh();
            inmateReportViewer.RefreshReport();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            inmateReportViewer.Reset();
            DataTable tb = GetIndividualPrisoners();
            ReportDataSource ds = new ReportDataSource("DataSet1", tb);
            inmateReportViewer.LocalReport.DataSources.Add(ds);
            inmateReportViewer.LocalReport.DataSources.Add(new ReportDataSource ("DataSet2", tb));
            inmateReportViewer.LocalReport.ReportEmbeddedResource = "JailManagementSystem.reports.inmateIndividualReport.rdlc";
            inmateReportViewer.LocalReport.Refresh();
            inmateReportViewer.RefreshReport();
        }
        private DataTable GetIndividualPrisoners()
        {
          
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from prisoner inner join cases on cases.inmatenum = prisoner.id where lastname like '" + searchp.Text.ToString() + "%" + "' or firstname like '" + searchp.Text.ToString() + "%" + "' or middlename like '" + searchp.Text.ToString() + "%" + "' or address like '" + searchp.Text.ToString() + "%" + "'", con) ;
            SqlCommand command = new SqlCommand();
        
            cmd.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.SelectCommand = cmd;
            da.Fill(dt);
           
            return dt;
          


           

           

        }
     

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void WindowsFormsHost_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }
    }
}
