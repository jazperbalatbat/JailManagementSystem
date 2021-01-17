using System;
using System.Collections.Generic;
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
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;
using MaterialDesignThemes.Wpf;
using JailManagementSystem.objects;
using JailManagementSystem.visitor;
using JailManagementSystem.reports;
using JailManagementSystem.utilities;
using System.IO;
using Microsoft.Win32;
using MsgBox;
namespace JailManagementSystem
{
    /// <summary>
    /// Interaction logic for dashboard.xaml
    /// </summary>
    public partial class dashboard : Window
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RVI30EH\SQLEXPRESS;Initial Catalog=jms;Integrated Security=True");
        public string pos_iden = "";
        public dashboard()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //con.Open();
            //SqlCommand cmd = con.CreateCommand();
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "select id, position, lastname, firstname, middlename, prisoner, visitor, cell, casee, escort, prisoner_report, visitor_report, cell_report, case_report, hearing_report, bail_report, jailofficer_report from jailofficer";
            //cmd.ExecuteNonQuery();
            //DataTable dt = new DataTable();
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //da.Fill(dt);
            //datagrid_jailofficer.ItemsSource = dt.DefaultView;
            //con.Close();

        }
        //SIGNOUT
        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            audittrail audit = new audittrail();
            audit.users = mw.id_login.Text.ToString();
            audit.activity = "logout";
            audit.dateOfActivity = DateTime.Now.ToString();
            audit.timeOfActivity = DateTime.Now.ToString("G");
            audit.add();
            mw.id_login.Text = "";
            mw.pass_login.Password = "";
            mw.Show();
            if(main_position.Text == "jailofficer")
            {
                con.Open();
                string cmnd = "insert into joattendance_out values('" + DateTime.Now.ToString() + "', '" + main_lastname.Text.ToString() + "',' " + main_firstname.Text.ToString() + "',";
                cmnd += "  '" + main_id.Text.ToString() + "')";
                SqlCommand commandss = con.CreateCommand();
                commandss.CommandType = CommandType.Text;
                commandss.CommandText = cmnd;
                commandss.ExecuteNonQuery();
                con.Close();
                this.Close();
            }

            if(main_position.Text == "admin")
            {
                this.Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            prisonermain pm = new prisonermain();
            pm.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            visitormain vm = new visitormain();
            vm.Show();
        }

        //PRISONER INFORMATION PANEL
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            b_prisoner.Visibility = Visibility.Visible;
            warden.Visibility = Visibility.Hidden;
            reports.Visibility = Visibility.Hidden;
            utilities.Visibility = Visibility.Hidden;
            jailofficer.Visibility = Visibility.Hidden;
            b_cell_monitoring.Visibility = Visibility.Collapsed;
            transaction_list.Visibility = Visibility.Collapsed;
            b_hearing_schedule.Visibility = Visibility.Collapsed;
            b_visitor_log.Visibility = Visibility.Collapsed;
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            b_prisoner.Visibility = Visibility.Hidden;
            utilities.Visibility = Visibility.Hidden;
        }
        //PRISONER INFORMATION PANEL

        //REPORTS PANEL
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            b_prisoner.Visibility = Visibility.Hidden;
            reports.Visibility = Visibility.Visible;
            warden.Visibility = Visibility.Hidden;
            utilities.Visibility = Visibility.Hidden;
            jailofficer.Visibility = Visibility.Hidden;
            b_cell_monitoring.Visibility = Visibility.Collapsed;
            transaction_list.Visibility = Visibility.Collapsed;
            b_hearing_schedule.Visibility = Visibility.Collapsed;
            b_visitor_log.Visibility = Visibility.Collapsed;
        }

        //close this panel
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //WARDEN INFORMATION PANEL
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            warden.Visibility = Visibility.Hidden;
        }

        private void admin_proceed_Click(object sender, RoutedEventArgs e)
        {
            if (username.Text != "" && password.Password != "" && a_lastname.Text != "" && a_firstname.Text != "")
            {
                if (username.Text.Length >= 8 && password.Password.Length >= 8)
                    admin_approval.Visibility = Visibility.Visible;

                else
                    MessageBox.Show("Username and Password Should have the minimum of 8!!!");
            }
                

            else
                MessageBox.Show("PLEASE COMPLETE THE INPUT!");
        }

        private void escort_Click(object sender, RoutedEventArgs e)
        {
            escort escort = new escort();
            escort.Show();
        }

        //WARDEN VISIBILITY
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            warden.Visibility = Visibility.Visible;
            b_prisoner.Visibility = Visibility.Hidden;
            reports.Visibility = Visibility.Hidden;
            utilities.Visibility = Visibility.Hidden;
            jailofficer.Visibility = Visibility.Hidden;
            b_cell_monitoring.Visibility = Visibility.Collapsed;
            b_hearing_schedule.Visibility = Visibility.Collapsed;
            b_visitor_log.Visibility = Visibility.Collapsed;
        }

        //JAIL OFFICER GRANT
        private void datagrid_jailofficer_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            edit_jailofficer.Visibility = Visibility.Visible;
            datagrid_jailofficer.Visibility = Visibility.Hidden;

            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;

            if (row_selected != null)
            {
                id.Text = row_selected["id"].ToString();
                position.Text = row_selected["position"].ToString();
                lastname.Text = row_selected["lastname"].ToString();
                firstname.Text = row_selected["firstname"].ToString();
                middlename.Text = row_selected["middlename"].ToString();

                //prisoner information
                if(row_selected["prisoner"].ToString() == "1")
                {
                    access_prisoner.IsChecked = true;
                }
                if (row_selected["visitor"].ToString() == "1")
                {
                    access_visitor.IsChecked = true;
                }
                if (row_selected["cell"].ToString() == "1")
                {
                    access_cell.IsChecked = true;
                }
                if (row_selected["casee"].ToString() == "1")
                {
                    access_case.IsChecked = true;
                }
                if (row_selected["escort"].ToString() == "1")
                {
                    access_escort.IsChecked = true;
                }
                //prisoner information

                //reports
                if (row_selected["prisoner_report"].ToString() == "1")
                {
                    access_prisonerreport.IsChecked = true;
                }
                if (row_selected["visitor_report"].ToString() == "1")
                {
                    access_visitorreport.IsChecked = true;
                }
                if (row_selected["cell_report"].ToString() == "1")
                {
                    access_cellreport.IsChecked = true;
                }
                if (row_selected["case_report"].ToString() == "1")
                {
                    access_casereport.IsChecked = true;
                }
                if (row_selected["hearing_report"].ToString() == "1")
                {
                    access_hearing_report.IsChecked = true;
                }
                if (row_selected["bail_report"].ToString() == "1")
                {
                    access_bail_report.IsChecked = true;
                }
                if (row_selected["jailofficer_report"].ToString() == "1")
                {
                    access_jailofficerreport.IsChecked = true;
                }
                //reports

                edit_jailofficer.Visibility = Visibility.Visible;
                datagrid_jailofficer.Visibility = Visibility.Hidden;

                
            }
            else
                MessageBox.Show("please select an object");
        }

        //JAILOFFICER PANEL
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            jailofficer.Visibility = Visibility.Visible;
            b_prisoner.Visibility = Visibility.Hidden;
            warden.Visibility = Visibility.Hidden;
            reports.Visibility = Visibility.Hidden;
            utilities.Visibility = Visibility.Hidden;
            b_cell_monitoring.Visibility = Visibility.Collapsed;
            b_hearing_schedule.Visibility = Visibility.Collapsed;
            b_visitor_log.Visibility = Visibility.Collapsed;
            transaction_list.Visibility = Visibility.Collapsed;
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            jailofficer.Visibility = Visibility.Hidden;
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            edit_jailofficer.Visibility = Visibility.Hidden;
            datagrid_jailofficer.Visibility = Visibility.Visible;
        }

        private void grant_access_Click(object sender, RoutedEventArgs e)
        {
            string access = "";
            jailofficers jo = new jailofficers();
            jo.id = id.Text;
            jo.position = position.Text.ToString();
            jo.lastname = lastname.Text.ToString();
            jo.firstname = firstname.Text.ToString();
            jo.middlename = middlename.Text.ToString();

            if (access_prisoner.IsChecked == true)
            {
                jo.prisoner = 1;
                access += "Prisoner ";
            }
            else
                jo.prisoner = 0;

            if (access_visitor.IsChecked == true)
            {
                jo.visitor = 1;
                access += "Visitor ";
            }
            else
                jo.visitor = 0;

            if (access_cell.IsChecked == true)
            {
                jo.cell = 1;
                access += "Cell ";
            }
            else
                jo.cell = 0;

            if (access_case.IsChecked == true)
            {
                jo.casee = 1;
                access += "Case ";
            }
            else
                jo.casee = 0;

            if (access_escort.IsChecked == true)
            {
                jo.escort = 1;
                access += "Escort ";
            }
            else
                jo.escort = 0;

            if (access_prisonerreport.IsChecked == true)
            {
                jo.prisoner_report = 1;
                access += "PrisonerReports ";
            }
            else
                jo.prisoner_report = 0;

            if (access_visitorreport.IsChecked == true)
            {
                jo.visitor_report = 1;
                access += "VisitorReports ";
            }
            else
                jo.visitor_report = 0;

            if (access_cellreport.IsChecked == true)
            {
                jo.cell_report = 1;
                access += "CellReports ";
            }
            else
                jo.cell_report = 0;

            if (access_casereport.IsChecked == true)
            {
                jo.case_report = 1;
                access += "CaseReports ";
            }
            else
                jo.case_report = 0;
            if (access_hearing_report.IsChecked == true)
            {
                jo.hearing_report = 1;
                access += "HearingReports ";
            }
            else
                jo.hearing_report = 0;
            if (access_bail_report.IsChecked == true)
            {
                jo.bail_report = 1;
                access += "BailReports ";
            }
            else
                jo.bail_report = 0;

            if (access_jailofficerreport.IsChecked == true)
            {
                jo.jailofficer_report = 1;
                access += "JailOfficerReports ";
            }
            else
                jo.jailofficer_report = 0;

            jo.add();
            edit_jailofficer.Visibility = Visibility.Hidden;
            if (access != "")
                MessageBox.Show(jo.firstname + " has now access to: " + access + "!!!");

            else
                MessageBox.Show(jo.firstname +" has no access to anything");

            dashboard db = new dashboard();
            this.Close();

            loading ld = new loading();
            ld.Show();
            db.Show();

                datagrid_jailofficer.Visibility = Visibility.Visible;

            jo.refreshCB();

        }

        //button for utilities
        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            transaction_list.Visibility = Visibility.Collapsed;
            b_prisoner.Visibility = Visibility.Hidden;
            reports.Visibility = Visibility.Hidden;
            warden.Visibility = Visibility.Hidden;
            utilities.Visibility = Visibility.Visible;
            jailofficer.Visibility = Visibility.Hidden;
            b_hearing_schedule.Visibility = Visibility.Collapsed;
            b_visitor_log.Visibility = Visibility.Collapsed;
            transaction_list.Visibility = Visibility.Collapsed;
        }

        private void Cell_Click(object sender, RoutedEventArgs e)
        {
            cellmain cm = new cellmain();
            cm.Show();
           
        }

        private void case_Click(object sender, RoutedEventArgs e)
        {
            casemain casem = new casemain();
            casem.Show();
         
        }

        private void audittrail_CheckedChanged(object sender, RoutedEventArgs e)
        {
            audit au = new audit();
            au.Show();
         
        }


      
        private void prisoner_CheckedChanged(object sender, RoutedEventArgs e)
        {
            prisonerreports pr = new prisonerreports();
            pr.Show();


        }
        private void Backup_CheckedChanged(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.ShowDialog();
            try
            {
                string path = "";
                string path2 = "";
                FileStream fs = File.OpenWrite("dirinfo.txt");
                StreamWriter sfr = new StreamWriter(fs);
                string subpath = @"c:\users\Coleen Salonga\Desktop\JailManagementSystem\JailManagementSystem\Database1.mdf";
                string subpath2 = @"C:\Users\Coleen Salonga\Desktop\JailManagementSystem\JailManagementSystem\Database1_log.ldf";
                string sh = Directory.GetDirectoryRoot("dirinfo.txt");
                path = sh + subpath;
                path2 = sh + subpath2;

                File.Copy(path, "Database1.mdf", true);
                File.Copy(path2, "Database1_log.ldf", true);
                MessageBox.Show("Successfuly Created Database Back Up");
                con.Open();
                SqlCommand command1 = con.CreateCommand();
                command1.CommandType = CommandType.Text;
                string database = (@"Data Source=DESKTOP-O4VH1PA\SQLEXPRESS;Initial Catalog=jms;Integrated Security=True");
                command1 = new SqlCommand("backup database test to disk='" + path + "\\" + database + DateTime.Now.ToString("ddMMMyyyy") + ".Bak'", con);
                command1.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Backup of database is Done successfully");

            }
            catch
            {

            }

        }
      

     

        private void archive_CheckedChanged(object sender, RoutedEventArgs e)
        { 
            archive archive = new archive();
            archive.Show();
        }

        private void visitor_CheckedChanged(object sender, RoutedEventArgs e)
        {

            visitorReports vr = new visitorReports();
            vr.Show();
        }

        private void cases_CheckedChanged(object sender, RoutedEventArgs e)
        {

            casesreports cr = new casesreports();
            cr.Show();
        }
        private void cell_CheckedChanged(object sender, RoutedEventArgs e)
        {
            cellstatusreport cell = new cellstatusreport();
            cell.Show();
        }


        private void bail_CheckedChanged(object sender, RoutedEventArgs e)
        {
            bailreports bail = new bailreports();
            bail.Show();
        }
        private void hearing_CheckedChanged(object sender, RoutedEventArgs e)
        {
            hearingreports hr = new hearingreports();
            hr.Show();
        }
        private void officer_CheckedChanged(object sender, RoutedEventArgs e)
        {
            officerreport or = new officerreport();
            or.Show();
        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            //con.Open();
            //string cmnd = "insert into jailofficer values('" + this.datevisit + "', '" + this.timein + "', '" + this.timeout + "',' " + this.lastname + "',";
            //cmnd += "  '" + this.firstname + "','" + this.middlename + "','" + this.address + "','" + this.gender + "','" + this.visit + "','" + this.firstname + "','" + this.lastname + "')";

            //con.Open();
            //SqlCommand command = con.CreateCommand();
            //command.CommandType = CommandType.Text;
            //command.CommandText = cmnd;
            //command.ExecuteNonQuery();
            //con.Close();
            prisonerupdate pu = new prisonerupdate();
            pu.Show();
        }

        private void jail_officer_b_fm_Click(object sender, RoutedEventArgs e)
        {

        }

        private void judges_b_Click(object sender, RoutedEventArgs e)
        {

        }

        #region TRANSACTION CELL MONITORING START
        private void Button_Click_14(object sender, RoutedEventArgs e)
        {
            transaction_list.Visibility = Visibility.Visible;

        }

        private void cell_monitoring_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You can monitor cell availability here and many more!!");
            b_cell_monitoring.Visibility = Visibility.Visible;
            transaction_list.Visibility = Visibility.Collapsed;
            b_prisoner.Visibility = Visibility.Collapsed;
            utilities.Visibility = Visibility.Collapsed;
            reports.Visibility = Visibility.Collapsed;
            b_hearing_schedule.Visibility = Visibility.Collapsed;
            b_visitor_log.Visibility = Visibility.Collapsed;
        }

        private void cell1_Click(object sender, RoutedEventArgs e)
        {
            cell_name.Text = "3RD DEGREE HIGH RISK CELL";
            cell_name.Foreground = new SolidColorBrush(Colors.Red);
            cell1.IsEnabled = false;
            cell2.IsEnabled = true;
            cell3.IsEnabled = true;
            cell4.IsEnabled = true;
            cell5.IsEnabled = true;
            cell_level.Visibility = Visibility.Visible;
            datagrid_cellviewer.Visibility = Visibility.Collapsed;

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select id, inmatenum, lastname, firstname, reason from celltransfer where cell = 'CELL 1' or cell = 'CELL1'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            datagrid_cellviewer.ItemsSource = dt.DefaultView;
            con.Close();

            string query = "select * from cell where cellnum = 'CELL1'";
            SqlCommand coms = new SqlCommand(query, con);
            SqlDbConnection cons = new SqlDbConnection();

            cons.Adaptor(query);
            DataTable dts = cons.Fill();
            if (dts.Rows.Count == 1)
            {
                con.Open();
                SqlDataReader reads = coms.ExecuteReader();
                while (reads.Read())
                {
                    no_inmates_cell.Text = (reads["num_inmates"].ToString());
                }
                reads.Close();
                con.Close();
            }
        }

        private void cell2_Click_1(object sender, RoutedEventArgs e)
        {
            cell_name.Text = "2ND DEGREE HIGH RISK CELL";
            cell_name.Foreground = new SolidColorBrush(Colors.Blue);
            cell1.IsEnabled = true;
            cell2.IsEnabled = false;
            cell3.IsEnabled = true;
            cell4.IsEnabled = true;
            cell5.IsEnabled = true;
            cell_level.Visibility = Visibility.Visible;
            datagrid_cellviewer.Visibility = Visibility.Collapsed;

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select id, inmatenum, lastname, firstname, reason from celltransfer where cell = 'CELL 2' or cell = 'CELL2'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            datagrid_cellviewer.ItemsSource = dt.DefaultView;
            con.Close();

            string query = "select * from cell where cellnum = 'CELL2'";
            SqlCommand coms = new SqlCommand(query, con);
            SqlDbConnection cons = new SqlDbConnection();

            cons.Adaptor(query);
            DataTable dts = cons.Fill();
            if (dts.Rows.Count == 1)
            {
                con.Open();
                SqlDataReader reads = coms.ExecuteReader();
                while (reads.Read())
                {
                    no_inmates_cell.Text = (reads["num_inmates"].ToString());
                }
                reads.Close();
                con.Close();
            }
        }

        private void cell3_Click(object sender, RoutedEventArgs e)
        {
            cell_name.Text = "1ST DEGREE HIGH RISK CELL";
            cell_name.Foreground = new SolidColorBrush(Colors.Orange);
            cell1.IsEnabled = true;
            cell2.IsEnabled = true;
            cell3.IsEnabled = false;
            cell4.IsEnabled = true;
            cell5.IsEnabled = true;
            cell_level.Visibility = Visibility.Visible;
            datagrid_cellviewer.Visibility = Visibility.Collapsed;

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select id, inmatenum, lastname, firstname, reason from celltransfer where cell = 'CELL 3' or cell = 'CELL3'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            datagrid_cellviewer.ItemsSource = dt.DefaultView;
            con.Close();
            string query = "select * from cell where cellnum = 'CELL3'";
            SqlCommand coms = new SqlCommand(query, con);
            SqlDbConnection cons = new SqlDbConnection();

            cons.Adaptor(query);
            DataTable dts = cons.Fill();
            if (dts.Rows.Count == 1)
            {
                con.Open();
                SqlDataReader reads = coms.ExecuteReader();
                while (reads.Read())
                {
                    no_inmates_cell.Text = (reads["num_inmates"].ToString());
                }
                reads.Close();
                con.Close();
            }

        }

        private void cell4_Click(object sender, RoutedEventArgs e)
        {
            cell_name.Text = "AVERAGE RISK CELL";
            cell_name.Foreground = new SolidColorBrush(Colors.Green);
            cell1.IsEnabled = true;
            cell2.IsEnabled = true;
            cell3.IsEnabled = true;
            cell4.IsEnabled = false;
            cell5.IsEnabled = true;
            cell_level.Visibility = Visibility.Visible;
            datagrid_cellviewer.Visibility = Visibility.Collapsed;

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select id, inmatenum, lastname, firstname, reason from celltransfer where cell = 'CELL 4' or cell = 'CELL4'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            datagrid_cellviewer.ItemsSource = dt.DefaultView;
            con.Close();

            string query = "select * from cell where cellnum = 'CELL4'";
            SqlCommand coms = new SqlCommand(query, con);
            SqlDbConnection cons = new SqlDbConnection();

            cons.Adaptor(query);
            DataTable dts = cons.Fill();
            if (dts.Rows.Count == 1)
            {
                con.Open();
                SqlDataReader reads = coms.ExecuteReader();
                while (reads.Read())
                {
                    no_inmates_cell.Text = (reads["num_inmates"].ToString());
                }
                reads.Close();
                con.Close();
            }
        }

        private void cell5_Click(object sender, RoutedEventArgs e)
        {
            cell_name.Text = "LOW RISK CELL";
            cell_name.Foreground = new SolidColorBrush(Colors.Yellow);
            cell1.IsEnabled = true;
            cell2.IsEnabled = true;
            cell3.IsEnabled = true;
            cell4.IsEnabled = true;
            cell5.IsEnabled = false;
            cell_level.Visibility = Visibility.Visible;
            datagrid_cellviewer.Visibility = Visibility.Collapsed;

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select id, inmatenum, lastname, firstname, reason from celltransfer where cell = 'CELL 5' or cell = 'CELL5'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            datagrid_cellviewer.ItemsSource = dt.DefaultView;
            con.Close();

            string query = "select * from cell where cellnum = 'CELL5'";
            SqlCommand coms = new SqlCommand(query, con);
            SqlDbConnection cons = new SqlDbConnection();

            cons.Adaptor(query);
            DataTable dts = cons.Fill();
            if (dts.Rows.Count == 1)
            {
                con.Open();
                SqlDataReader reads = coms.ExecuteReader();
                while (reads.Read())
                {
                    no_inmates_cell.Text = (reads["num_inmates"].ToString());
                }
                reads.Close();
                con.Close();
            }
        }

        private void Button_Click_15(object sender, RoutedEventArgs e)
        {
            datagrid_cellviewer.Visibility = Visibility.Visible;
        }

        private void Button_Click_16(object sender, RoutedEventArgs e)
        {
            b_cell_monitoring.Visibility = Visibility.Collapsed;
        }
        #endregion

        #region TRANSACTION HEARING SCHEDULE
        private void hearing_schedule_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You can set hearing schedule here and many more!");
            b_hearing_schedule.Visibility = Visibility.Visible;
            jailofficer.Visibility = Visibility.Collapsed;
            b_prisoner.Visibility = Visibility.Hidden;
            warden.Visibility = Visibility.Hidden;
            reports.Visibility = Visibility.Hidden;
            utilities.Visibility = Visibility.Hidden;
            b_cell_monitoring.Visibility = Visibility.Collapsed;
            transaction_list.Visibility = Visibility.Collapsed;

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from attorney order by id desc";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            datagrid_hs_attorney.ItemsSource = dt.DefaultView;
            con.Close();

            con.Open();
            SqlCommand cmds = con.CreateCommand();
            cmds.CommandType = CommandType.Text;
            cmds.CommandText = "select * from prisoner order by id desc";
            cmds.ExecuteNonQuery();
            DataTable dts = new DataTable();
            SqlDataAdapter das = new SqlDataAdapter(cmds);
            das.Fill(dts);
            datagrid_hs_inmate.ItemsSource = dts.DefaultView;
            con.Close();

            con.Open();
            SqlCommand cmdss = con.CreateCommand();
            cmdss.CommandType = CommandType.Text;
            cmdss.CommandText = "select * from judge order by id desc";
            cmdss.ExecuteNonQuery();
            DataTable dtss = new DataTable();
            SqlDataAdapter dass = new SqlDataAdapter(cmdss);
            dass.Fill(dtss);
            datagrid_hs_judge.ItemsSource = dtss.DefaultView;
            con.Close();

            con.Open();
            SqlCommand cmdsss = con.CreateCommand();
            cmdsss.CommandType = CommandType.Text;
            cmdsss.CommandText = "select * from court order by id desc";
            cmdsss.ExecuteNonQuery();
            DataTable dtsss = new DataTable();
            SqlDataAdapter dasss = new SqlDataAdapter(cmdsss);
            dasss.Fill(dtsss);
            datagrid_hs_court.ItemsSource = dtsss.DefaultView;
            con.Close();

            con.Open();
            SqlCommand cmdssss = con.CreateCommand();
            cmdssss.CommandType = CommandType.Text;
            cmdssss.CommandText = "select * from escort order by id desc";
            cmdssss.ExecuteNonQuery();
            DataTable dtssss = new DataTable();
            SqlDataAdapter dassss = new SqlDataAdapter(cmdssss);
            dassss.Fill(dtssss);
            datagrid_hs_escort.ItemsSource = dtssss.DefaultView;
            con.Close();

            con.Open();
            SqlCommand cmdsssss = con.CreateCommand();
            cmdsssss.CommandType = CommandType.Text;
            cmdsssss.CommandText = "select * from hearing order by id desc";
            cmdsssss.ExecuteNonQuery();
            DataTable dtsssss = new DataTable();
            SqlDataAdapter dasssss = new SqlDataAdapter(cmdsssss);
            dasssss.Fill(dtsssss);
            view_hs.ItemsSource = dtsssss.DefaultView;
            con.Close();
        }

        private void Button_Click_17(object sender, RoutedEventArgs e)
        {
            b_hearing_schedule.Visibility = Visibility.Collapsed;
        }

        private void Button_Click_18(object sender, RoutedEventArgs e)
        {
            var x = hs_date.SelectedDate;
            var y = hs_time.SelectedTime;
            if (x >= DateTime.Now && y > DateTime.Now)
            {
                MessageBox.Show(y.ToString());
            }
            else
                MessageBox.Show("Invalid Inputs!");

        }

        private void search_hs_attorney_TextChanged(object sender, TextChangedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from attorney where lastname like '" + search_hs_attorney.Text.ToString() + "%" + "' or firstname like '" + search_hs_attorney.Text.ToString() + "%" + "' or middlename like '" + search_hs_attorney.Text.ToString() + "%" + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            datagrid_hs_attorney.ItemsSource = dt.DefaultView;
            con.Close();
        }

        private void datagrid_hs_attorney_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                hs_attorneyid.Text = row_selected["id"].ToString();
                hs_attorneylname.Text = row_selected["lastname"].ToString();
                hs_attorneyfname.Text = row_selected["firstname"].ToString();
                MessageBox.Show("You have selected Atty." + hs_attorneylname.Text + ", " + hs_attorneyfname.Text + "!");
            }
            else
                MessageBox.Show("please select an Attorney");
        }

        private void search_hs_inmate_SelectionChanged(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from prisoner where lastname like '" + search_hs_inmate.Text.ToString() + "%" + "' or firstname like '" + search_hs_inmate.Text.ToString() + "%" + "' or middlename like '" + search_hs_inmate.Text.ToString() + "%" + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            datagrid_hs_inmate.ItemsSource = dt.DefaultView;
            con.Close();
        }

        private void datagrid_hs_inmate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                hs_inmateid.Text = row_selected["id"].ToString();
                hs_inmatelname.Text = row_selected["lastname"].ToString();
                hs_inmatefname.Text = row_selected["firstname"].ToString();
                MessageBox.Show("You have selected inmate " + hs_inmatelname.Text + ", " + hs_inmatefname.Text + "!");
            }
            else
                MessageBox.Show("please select an inmate");
        }

        private void search_hs_judge_SelectionChanged(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from judge where lastname like '" + search_hs_judge.Text.ToString() + "%" + "' or firstname like '" + search_hs_judge.Text.ToString() + "%" + "' or middlename like '" + search_hs_judge.Text.ToString() + "%" + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            datagrid_hs_judge.ItemsSource = dt.DefaultView;
            con.Close();
        }

        private void datagrid_hs_judge_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                hs_judgeid.Text = row_selected["id"].ToString();
                hs_judgelname.Text = row_selected["lastname"].ToString();
                hs_judgefname.Text = row_selected["firstname"].ToString();
                hs_judgecourtid.Text = row_selected["court_id"].ToString();
                MessageBox.Show("You have selected Judge " + hs_judgelname.Text + ", " + hs_judgefname.Text + "!");

                string query = "select * from court where id = '" + hs_judgecourtid.Text + "'";
                SqlCommand coms = new SqlCommand(query, con);
                SqlDbConnection cons = new SqlDbConnection();

                cons.Adaptor(query);
                DataTable dt = cons.Fill();
                if (dt.Rows.Count == 1)
                {
                    con.Open();
                    SqlDataReader reads = coms.ExecuteReader();
                    while (reads.Read())
                    {

                        hs_hearing_court.Text = (reads["branch"].ToString());
                        hs_hearing_courtid.Text = (reads["id"].ToString());
                        MessageBox.Show(hs_hearing_court.Text);

                    }
                    reads.Close();
                    con.Close();
                }
            }
            else
                MessageBox.Show("please select a Judge");
        }

        private void search_hs_court_SelectionChanged(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from court where branch like '" + "%" + search_hs_court.Text.ToString() + "%" + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            datagrid_hs_court.ItemsSource = dt.DefaultView;
            con.Close();
        }

        private void search_hs_escort_SelectionChanged(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from escort where lastname like '" + search_hs_escort.Text.ToString() + "%" + "' or firstname like '" + search_hs_escort.Text.ToString() + "%" + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            datagrid_hs_escort.ItemsSource = dt.DefaultView;
            con.Close();
        }

        private void datagrid_hs_escort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                hs_escortid.Text = row_selected["id"].ToString();
                hs_escortlname.Text = row_selected["lastname"].ToString();
                hs_escortfname.Text = row_selected["firstname"].ToString();
                hs_escortpos.Text = row_selected["position"].ToString();
                MessageBox.Show("You have selected " + hs_escortpos.Text + " " + hs_escortlname.Text + ", " + hs_escortfname.Text + "!");
            }
            else
                MessageBox.Show("please select an Escort");
        }

        private void Button_Click_19(object sender, RoutedEventArgs e)
        {//set schedule to
            if(hs_date.Text != "" && hs_time.Text != "" && hs_inmateid.Text != "" && hs_attorneyid.Text != "" && hs_judgeid.Text != "" && hs_hearing_courtid.Text != "" && hs_escortid.Text != "")
            {
                string x = "";
                if(hs_date.SelectedDate > DateTime.Now)
                {
                    x = "on going";
                }
                if (hs_date.SelectedDate < DateTime.Now)
                {
                    x = "done";
                }

                string cmnd = "insert into hearing values('" + hs_inmateid.Text + "',";
                cmnd += "'" + hs_attorneyid.Text + "','" + hs_judgeid.Text + "','" + hs_hearing_courtid.Text + "','" + hs_date.Text + "','" + hs_time.Text + "','" + x + "')";


                con.Open();
                SqlCommand command = con.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = cmnd;
                command.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("HEARING SCHEDULE HAS BEEN SET!");
            }
            else
                MessageBox.Show("huhu");
        }

        private void Button_Click_20(object sender, RoutedEventArgs e)
        {
            b_hearing_schedule.Visibility = Visibility.Collapsed;
        }

        private void Button_Click_21(object sender, RoutedEventArgs e)
        {
            set_hs.Visibility = Visibility.Visible;
            view_hs.Visibility = Visibility.Collapsed;
        }

        private void Button_Click_22(object sender, RoutedEventArgs e)
        {
            b_hearing_schedule.Visibility = Visibility.Collapsed;
        }

        #endregion

        #region TRANSACTION VISITOR LOG
        private void visitor_log_Click(object sender, RoutedEventArgs e)
        {
            b_visitor_log.Visibility = Visibility.Visible;
            b_hearing_schedule.Visibility = Visibility.Collapsed;
            jailofficer.Visibility = Visibility.Collapsed;
            b_prisoner.Visibility = Visibility.Hidden;
            warden.Visibility = Visibility.Hidden;
            reports.Visibility = Visibility.Hidden;
            utilities.Visibility = Visibility.Hidden;
            b_cell_monitoring.Visibility = Visibility.Collapsed;
            transaction_list.Visibility = Visibility.Collapsed;

            con.Open();
            SqlCommand cmds = con.CreateCommand();
            cmds.CommandType = CommandType.Text;
            cmds.CommandText = "select * from visitor order by id desc";
            cmds.ExecuteNonQuery();
            DataTable dts = new DataTable();
            SqlDataAdapter das = new SqlDataAdapter(cmds);
            das.Fill(dts);
            vl_datagrid_visitor.ItemsSource = dts.DefaultView;
            con.Close();
        }

        private void vl_searchlist_SelectionChanged(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from visitor where lastname like '" + vl_searchlist.Text.ToString() + "%" + "' or firstname like '" + vl_searchlist.Text.ToString() + "%" + "' or middlename like '" + vl_searchlist.Text.ToString() + "%" + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            vl_datagrid_visitor.ItemsSource = dt.DefaultView;
            con.Close();
        }

        private void vl_datagrid_visitor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                vl_id.Text = row_selected["id"].ToString();
                string lastname = row_selected["lastname"].ToString();
                string firstname = row_selected["firstname"].ToString();
                MessageBox.Show("You have selected " + lastname + ", " + firstname + "!");
                vl_fname.Text = firstname;
                vl_lname.Text = lastname + ",";
                vl.Visibility = Visibility.Collapsed;
                vl_log.Visibility = Visibility.Visible;

                vl_timein.Text = "";
                vl_idpresented.Text = "";
                vl_idpresenteds.Text = "";
                vl_refnum.Text = "";
            }
            else
                MessageBox.Show("please select a Visitor");
        }


        private void savelog_Click(object sender, RoutedEventArgs e)
        {
            if (vl_timein.SelectedTime > DateTime.Now)
            {
                    if (vl_idpresented.Text != "")
                    {

                    if(vl_others.IsVisible)
                    {
                        if (vl_idpresenteds.Text != "")
                        {
                            con.Open();
                            SqlCommand command = con.CreateCommand();
                            command.CommandType = CommandType.Text;
                            command.CommandText = "update visitor set datevisit='" + DateTime.Now.ToString() + "', timein = '" + vl_timein.Text.ToString() + "', referencenumber = '" + vl_refnum.Text.ToString() + "', idpresented = '" + vl_idpresenteds.Text.ToString() + "' where id = '" + vl_id.Text + "'";
                            command.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Visitor has been logged in!");
                            
                            vl_log.Visibility = Visibility.Collapsed;
                            vl.Visibility = Visibility.Visible;
                        }

                        else
                            MessageBox.Show("INVALID ID REPRESENTED INPUT");
                    }

                    else
                    {
                        con.Open();
                        SqlCommand command = con.CreateCommand();
                        command.CommandType = CommandType.Text;
                        command.CommandText = "update visitor set datevisit='" + DateTime.Now.ToString() + "', timein = '" + vl_timein.Text.ToString() + "', referencenumber = '" + vl_refnum.Text.ToString() + "', idpresented = '" + vl_idpresented.Text.ToString() + "' where id = '" + vl_id.Text + "'";
                        command.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Visitor has been logged in!");

                        vl_log.Visibility = Visibility.Collapsed;
                        vl.Visibility = Visibility.Visible;
                    }

                    }
                    else
                        MessageBox.Show("INVALID ID REPRESENTED INPUT");
            }
            else
                MessageBox.Show("INVALID TIME IN INPUT");
        }
        private void Button_Click_24(object sender, RoutedEventArgs e)
        {
            vl_others.Visibility = Visibility.Collapsed;
        }

        private void vl_othersid_Click(object sender, RoutedEventArgs e)
        {
            vl_others.Visibility = Visibility.Visible;
        }

        private void vl_idpresented_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Button_Click_25(object sender, RoutedEventArgs e)
        {
            vl_log.Visibility = Visibility.Collapsed;
            vl.Visibility = Visibility.Visible;
        }

        private void Button_Click_23(object sender, RoutedEventArgs e)
        {
            b_visitor_log.Visibility = Visibility.Collapsed;
        }
        #endregion

        #region FILE MAINTENANCE ATTORNEY
        private void attorney_b_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmds = con.CreateCommand();
            cmds.CommandType = CommandType.Text;
            cmds.CommandText = "select * from attorney order by id desc";
            cmds.ExecuteNonQuery();
            DataTable dts = new DataTable();
            SqlDataAdapter das = new SqlDataAdapter(cmds);
            das.Fill(dts);
            datagrid_attorney.ItemsSource = dts.DefaultView;
            con.Close();
            b_attorney.Visibility = Visibility.Visible;
        }

        private void search_attorney_SelectionChanged(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from attorney where lastname like '" + search_attorney.Text.ToString() + "%" + "' or firstname like '" + search_attorney.Text.ToString() + "%" + "' or middlename like '" + search_attorney.Text.ToString() + "%" + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            datagrid_attorney.ItemsSource = dt.DefaultView;
            con.Close();
        }

        private void datagrid_attorney_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            a_main.Visibility = Visibility.Collapsed;
            a_update.Visibility = Visibility.Visible;

            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                atty_id.Text = row_selected["id"].ToString();
                atty_contact_nos.Text = row_selected["contact_no"].ToString();
                atty_lastnames.Text = row_selected["lastname"].ToString();
                atty_firstnames.Text = row_selected["firstname"].ToString();
                atty_middlenames.Text = row_selected["middlename"].ToString();
                atty_address0s.Text = row_selected["address"].ToString();
                atty_genders.Text = row_selected["gender"].ToString();
                atty_birthdates.Text = row_selected["birthdate"].ToString();

            }
        }

        private void datagrid_attorney_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                atty_id.Text = row_selected["id"].ToString();
                delete_attorney.Visibility = Visibility.Visible;
            }

        }

        private void add_attorney_Click(object sender, RoutedEventArgs e)
        {
            a_main.Visibility = Visibility.Collapsed;
            a_add.Visibility = Visibility.Visible;
        }

        private void delete_attorney_Click(object sender, RoutedEventArgs e)
        {
            DataGrid dataGrid = datagrid_attorney;
            DataGridRow Row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
            DataGridCell RowAndColumn = (DataGridCell)dataGrid.Columns[0].GetCellContent(Row).Parent;
            ((TextBlock)RowAndColumn.Content).Text = atty_id.Text;

            con.Open();
                SqlCommand command = con.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "delete from attorney where id = '" + atty_id.Text.ToString() + "'";
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully Deleted!");
            
            
        }

        private void Button_Click_26(object sender, RoutedEventArgs e)
        {
            if(atty_firstname.Text != "" && atty_lastname.Text != "" && atty_middlename.Text != "" && atty_gender.Text != "" && atty_birthdate.Text != "" && atty_address0.Text != "" && atty_address1.Text != "")
            {
                string address = atty_address0.Text + " " + atty_address1.Text;
                string cmnd = "insert into attorney values('" + atty_firstname.Text.ToString() + "', '" + atty_middlename.Text.ToString() + "', '" + atty_lastname.Text.ToString() + "',' " + atty_gender.Text.ToString() + "',";
                cmnd += "  '" + atty_birthdate.Text.ToString() + "','" + address.ToString() + "','" + atty_contact_no.Text.ToString() + "')";

                con.Open();
                SqlCommand command = con.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = cmnd;
                command.ExecuteNonQuery();
                con.Close();
                a_add.Visibility = Visibility.Collapsed;
                a_main.Visibility = Visibility.Visible;
                MessageBox.Show("You have added a new Attorney");
            }

            else
            {
                MessageBox.Show("INVALID INPUTS");
            }
            
        }

        private void Button_Click_27(object sender, RoutedEventArgs e)
        {
            a_add.Visibility = Visibility.Collapsed;
        }

        private void Button_Click_28(object sender, RoutedEventArgs e)
        {
            if (atty_firstnames.Text != "" && atty_lastnames.Text != "" && atty_middlenames.Text != "" && atty_genders.Text != "" && atty_birthdates.Text != "" && atty_address0s.Text != "" && atty_address1s.Text != "")
            {
                con.Open();
                SqlCommand command = con.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "update attorney set firstname = '" + atty_firstnames.Text.ToString() + "',  lastname='" + atty_lastnames.Text.ToString() + "', birthdate= '" + atty_birthdates.Text.ToString() + "', middlename = '" + atty_middlenames.Text.ToString() + "', address = '" + atty_address0s.Text.ToString() + " " + atty_address1s.Text.ToString() + "', gender = '" + atty_genders.Text.ToString() + "' where id = '" + atty_id.Text + "'";
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully Updated!");
                a_update.Visibility = Visibility.Collapsed;
                a_main.Visibility = Visibility.Visible;
            }
            else
                MessageBox.Show("INVALID INPUTS");
        }

        private void Button_Click_29(object sender, RoutedEventArgs e)
        {
            a_update.Visibility = Visibility.Collapsed;
            a_main.Visibility = Visibility.Visible;
        }

        private void Button_Click_30(object sender, RoutedEventArgs e)
        {
            b_attorney.Visibility = Visibility.Collapsed;
        }
        #endregion

        #region FILE MAINTENANCE TRIAL COURTS
        private void trial_courts_b_Click(object sender, RoutedEventArgs e)
        {
            b_court.Visibility = Visibility.Visible;
            con.Open();
            SqlCommand cmds = con.CreateCommand();
            cmds.CommandType = CommandType.Text;
            cmds.CommandText = "select * from court order by id desc";
            cmds.ExecuteNonQuery();
            DataTable dts = new DataTable();
            SqlDataAdapter das = new SqlDataAdapter(cmds);
            das.Fill(dts);
            datagrid_court.ItemsSource = dts.DefaultView;
            con.Close();
        }

        private void search_court_SelectionChanged(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from court where branch like '" + "%" + search_court.Text + "%" + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            datagrid_court.ItemsSource = dt.DefaultView;
            con.Close();
        }

        private void datagrid_court_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                tc_id.Text = row_selected["id"].ToString();
                delete_court.Visibility = Visibility.Visible;
            }
        }

        private void datagrid_court_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                tc_id.Text = row_selected["id"].ToString();
                court_branch.Text = row_selected["branch"].ToString();
                tc_main.Visibility = Visibility.Collapsed;
                tc_add.Visibility = Visibility.Visible;
                tc_b_update.Visibility = Visibility.Visible;
                tc_add_update.Text = "EDIT BRANCH NAME: ";
            }

            else
            {
                MessageBox.Show("PLEASE SELECT AN OBJECT");
            }
        }

        private void Button_Click_31(object sender, RoutedEventArgs e)
        {
            court_branch.Text = "";
            tc_add.Visibility = Visibility.Collapsed;
            tc_b_add.Visibility = Visibility.Collapsed;
            tc_b_update.Visibility = Visibility.Collapsed;
            tc_add_update.Text = "";
            tc_main.Visibility = Visibility.Visible;
        }

        private void add_court_Click(object sender, RoutedEventArgs e)
        {
            court_branch.Text = "";
            tc_add.Visibility = Visibility.Visible;
            tc_b_add.Visibility = Visibility.Visible;
            tc_b_update.Visibility = Visibility.Collapsed;
            tc_add_update.Text = "ADD NEW TRIAL COURT: ";
            tc_main.Visibility = Visibility.Collapsed;
        }

        private void Button_Click_32(object sender, RoutedEventArgs e)
        {
            b_court.Visibility = Visibility.Collapsed;
        }

        private void delete_court_Click(object sender, RoutedEventArgs e)
        {
            DataGrid dataGrid = datagrid_court;
            DataGridRow Row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
            DataGridCell RowAndColumn = (DataGridCell)dataGrid.Columns[0].GetCellContent(Row).Parent;
            ((TextBlock)RowAndColumn.Content).Text = tc_id.Text;

            con.Open();
            SqlCommand command = con.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "delete from court where id = '" + tc_id.Text.ToString() + "'";
            command.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Deleted!");
        }

        private void tc_b_add_Click(object sender, RoutedEventArgs e)
        {
            if ( court_branch.Text != "")
            {
                string cmnd = "insert into court values('" + court_branch.Text.ToString() + "', '" + 1 + "')";

                con.Open();
                SqlCommand command = con.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = cmnd;
                command.ExecuteNonQuery();
                con.Close();
                court_branch.Text = "";
                tc_add.Visibility = Visibility.Collapsed;
                tc_b_add.Visibility = Visibility.Collapsed;
                tc_b_update.Visibility = Visibility.Collapsed;
                tc_add_update.Text = "";
                tc_main.Visibility = Visibility.Visible;
                MessageBox.Show("You have added a new Trial Court!");
            }

            else
            {
                MessageBox.Show("INVALID INPUTS");
            }
        }

        private void tc_b_update_Click(object sender, RoutedEventArgs e)
        {
            if (court_branch.Text != "")
            {
                con.Open();
                SqlCommand command = con.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "update court set branch = '" + court_branch.Text.ToString() + "',  available='" + 1 + "' where id = '" + tc_id.Text + "'";
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully Updated!");
                court_branch.Text = "";
                tc_add.Visibility = Visibility.Collapsed;
                tc_b_add.Visibility = Visibility.Collapsed;
                tc_b_update.Visibility = Visibility.Collapsed;
                tc_add_update.Text = "";
                tc_main.Visibility = Visibility.Visible;
            }
            else
                MessageBox.Show("INVALID INPUTS");
        }
        #endregion

        //CHECKBOXES OF ACCESSIBILITY OF THE JAIL OFFICERS //

        /**private void fmprisoner_Click(object sender, RoutedEventArgs e)
        {
            prisonerFM fmp = new prisonerFM();
            fmp.Show();
        }

        private void search_prisoner_Click(object sender, RoutedEventArgs e)
        {
            prisoner prisoner = new prisoner();
            prisoner.searchdb = search_db_prison.Text.ToString();
            prisoner.dgv_prisoner = dgv_prisoner.ItemsSource;
            prisoner.search();
            con.Close();
        } 

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {



        }**/
    }



}
