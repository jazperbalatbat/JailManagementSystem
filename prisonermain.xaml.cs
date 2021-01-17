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
using JailManagementSystem.objects;
using Microsoft.Win32;
using System.IO;
using System.Threading;
using System.Windows.Controls.Primitives;

namespace JailManagementSystem
{
    /// <summary>
    /// Interaction logic for prisonermain.xaml
    /// </summary>
    public partial class prisonermain : Window
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RVI30EH\SQLEXPRESS;Initial Catalog=jms;Integrated Security=True");

        public prisonermain()
        {
            InitializeComponent();
        }

        //LOAD DATAGRID VALUES
        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from prisoner";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            datagrid_prisoner.ItemsSource = dt.DefaultView;
            con.Close();

            con.Open();
            SqlCommand command1 = con.CreateCommand();
            DataTable table = new DataTable();
            command1.CommandType = CommandType.Text;
            command1.CommandText = "Select id, lastname, firstname, position from jailofficer";
            command1.ExecuteNonQuery();
            SqlDataAdapter dataA = new SqlDataAdapter(command1);
            dataA.Fill(table);
            datagrid_escort.ItemsSource = table.DefaultView;
            con.Close();

        }

        //EDIT A PRISONER
        private void datagrid_prisoner_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            edit.Visibility = Visibility.Visible;
            datagrid_prisoner.Visibility = Visibility.Hidden;

            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                id.Text = row_selected["id"].ToString();
                lastname.Text = row_selected["lastname"].ToString();
                firstname.Text = row_selected["firstname"].ToString();
                middlename.Text = row_selected["middlename"].ToString();
                address.Text = row_selected["address"].ToString();
                age.Text = row_selected["age"].ToString();
                gender.Text = row_selected["gender"].ToString();
                birthdate.Text = row_selected["birthdate"].ToString();
                height.Text = row_selected["height"].ToString();
                weight.Text = row_selected["weight"].ToString();
                citizenship.Text = row_selected["citizenship"].ToString();
                religion.Text = row_selected["religion"].ToString();
                datein.Text = row_selected["datein"].ToString();
                civilstatus.Text = row_selected["civilstatus"].ToString();
                jailstatus.Text = row_selected["jailstatus"].ToString();

                edit.Visibility = Visibility.Visible;
                datagrid_prisoner.Visibility = Visibility.Hidden;

            }
            else
                MessageBox.Show("please select an object");

            con.Open();
            SqlCommand commands2 = con.CreateCommand();
            DataTable tables1 = new DataTable();
            commands2.CommandType = CommandType.Text;
            commands2.CommandText = "Select * from bail where inmatenum = '" + id.Text + "'";
            commands2.ExecuteNonQuery();
            SqlDataAdapter datasA1 = new SqlDataAdapter(commands2);
            datasA1.Fill(tables1);
            datagrid_bail.ItemsSource = tables1.DefaultView;
            con.Close();


            con.Open();
            SqlCommand commands1 = con.CreateCommand();
            DataTable tables = new DataTable();
            commands1.CommandType = CommandType.Text;
            commands1.CommandText = "select * from cases where inmatenum = '" + id.Text + "'";
            commands1.ExecuteNonQuery();
            SqlDataAdapter datasA = new SqlDataAdapter(commands1);
            datasA.Fill(tables);
            datagrid_case.ItemsSource = tables.DefaultView;
            con.Close();

            con.Open();
            SqlCommand cmds = con.CreateCommand();
            DataTable dts = new DataTable();
            cmds.CommandType = CommandType.Text;
            cmds.CommandText = "select * from visitor where visit = '" + id.Text.ToString() + "'";
            cmds.ExecuteNonQuery();
            SqlDataAdapter ds = new SqlDataAdapter(cmds);
            ds.Fill(dts);
            datagrid_visitors.ItemsSource = dts.DefaultView;
            con.Close();

            con.Open();
            SqlCommand comm = con.CreateCommand();
            DataTable dts1 = new DataTable();
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select * from celltransfer where inmatenum = '"+ id.Text.ToString()+ "' ";
            comm.ExecuteNonQuery();
            SqlDataAdapter ds1 = new SqlDataAdapter(comm);
            ds1.Fill(dts1);
            datagrid_cell.ItemsSource = dts1.DefaultView;
            con.Close();
        }

        //EDIT A PRISONER
        private void datagrid_case_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            edit.Visibility = Visibility.Visible;
            datagrid_prisoner.Visibility = Visibility.Hidden;

            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                id.Text = row_selected["id"].ToString();
                casenum.Text = row_selected["casenum"].ToString();
                offense1.Text = row_selected["offense"].ToString();

        

      
               

            }

            else
                MessageBox.Show("please select an object");

        }
        private void datagrid_case_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }



        //CAMERA FACIAL RECOGNITION BUTTON
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            prisonerfacerecog pfr = new prisonerfacerecog();
            pfr.Show();
            pfr.type = "prisoner";
        }

        //SEARCH PRISONER
        private void tb_prisoner_TextChanged(object sender, TextChangedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from prisoner where lastname like '" + tb_prisoner.Text.ToString() + "%" + "' or firstname like '" + tb_prisoner.Text.ToString() + "%" + "' or middlename like '" + tb_prisoner.Text.ToString() + "%" + "' or address like '" + tb_prisoner.Text.ToString() + "%" + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            datagrid_prisoner.ItemsSource = dt.DefaultView;
            con.Close();
        }

        //EDIT-CANCELBUTTON
        private void add_cancel_prisoner_Click(object sender, RoutedEventArgs e)
        {
            edit.Visibility = Visibility.Hidden;
            datagrid_prisoner.Visibility = Visibility.Visible;
            prisoner p = new prisoner();
            p.refreshTB_prisoner();
            this.Close();
            prisonermain pm = new prisonermain();
            pm.Show();

            loading l = new loading();
            l.Show();

        }

        //ADD PRISONER
        private void fmprisoner_Click(object sender, RoutedEventArgs e)
        {
            prisonerFM fmp = new prisonerFM();
            fmp.Show();
            prisoner p = new prisoner();
            p.refreshTB_prisoner();
        }

        //UPDATE PRISONER
        private void update_prisoner_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataGrid dataGrid = datagrid_prisoner;
                DataGridRow Row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
                DataGridCell RowAndColumn = (DataGridCell)dataGrid.Columns[0].GetCellContent(Row).Parent;
                ((TextBlock)RowAndColumn.Content).Text = id.Text;
                con.Open();

                SqlCommand command = con.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "update prisoner set lastname='" + lastname.Text.ToString() + "', firstname= '" + firstname.Text.ToString() + "', middlename = '" + middlename.Text.ToString() + "', address = '" + address.Text.ToString() + "', age = '" + age.Text.ToString() + "', gender = '" + gender.Text.ToString() + "', birthdate = '" + birthdate.DisplayDate.ToString("yyyy-MM-dd") + "', height = '" + height.Text.ToString() + "', weight = '" + weight.Text.ToString() + "', citizenship= '" + citizenship.Text.ToString() + "', religion= '" + religion.Text.ToString() + "', datein= '" + datein.Text.ToString() + "', civilstatus = '" + civilstatus.Text.ToString() + "', jailstatus = '" + jailstatus.Text.ToString() + "' where id = '" + id.Text + "'";
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully Updated!");
                edit.Visibility = Visibility.Hidden;
                datagrid_prisoner.Visibility = Visibility.Visible;

                MainWindow d = new MainWindow();
                audittrail au = new audittrail();
                string user = d.id_login.Text.ToString();
                au.users = user;
                au.activity = "update prisoner information";
                au.dateOfActivity = DateTime.Now.ToString();
                au.timeOfActivity = DateTime.Now.ToString("G");
                au.add();

                this.Close();
                prisonermain pm = new prisonermain();
                pm.Show();
                loading l = new loading();
                l.Show();
            }
            catch
            {
                MessageBox.Show("Invalid Inputs");
            }
        }

        //SELECT ROW AND VISIBILITY OF DELETE BUTTON
        private void datagrid_prisoner_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            if(row_selected != null)
            {
                id.Text = row_selected["id"].ToString();
                delete_prisoner.Visibility = Visibility.Visible;
            }
           
        }

        //DELETE BUTTON
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            DataGrid dataGrid = datagrid_prisoner;
            DataGridRow Row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
            DataGridCell RowAndColumn = (DataGridCell)dataGrid.Columns[0].GetCellContent(Row).Parent;
            ((TextBlock)RowAndColumn.Content).Text = id.Text;
            con.Open();

            SqlCommand command = con.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "delete from prisoner where id = '" + id.Text + "'";
            command.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Deleted!");
            edit.Visibility = Visibility.Hidden;
            datagrid_prisoner.Visibility = Visibility.Visible;

            //audittrail
            //dashboard d = new dashboard();
            //audittrail au = new audittrail();
            //au.users = d.username.Text.ToString();
            //au.activity = "deleted  prisoner information";
            //au.dateOfActivity = DateTime.Now.ToString();
            //au.timeOfActivity = DateTime.Now.ToString("G");
            //au.add(); 

            parchive ar = new parchive();
            ar.firstname = firstname.Text.ToString();
            ar.middlename = middlename.Text.ToString();
            ar.lastname = lastname.Text.ToString();
            ar.address = address.Text.ToString();
            ar.age = age.Text.ToString();
            ar.gender = gender.Text.ToString();
            ar.birthdate = birthdate.DisplayDate.ToString("yyyy-MM-dd");
            ar.height = height.Text.ToString();
            ar.weight = weight.Text.ToString();
            ar.citizenship = citizenship.Text.ToString();
            ar.religion = religion.Text.ToString();
            ar.datein = datein.DisplayDate.ToString("yyyy-MM-dd");
            ar.civilstatus = civilstatus.Text.ToString();
            ar.jailstatus = jailstatus.Text.ToString();

            ar.add();
           
            this.Close();
            prisonermain pm = new prisonermain();
            pm.Show();
            loading l = new loading();
            l.Show();
        }

        //BAIL BUTTON
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
                bail.Visibility = Visibility.Visible;
               
                hearing_schedule.Visibility = Visibility.Hidden;
                cell_transfer.Visibility = Visibility.Hidden;
                case_registration.Visibility = Visibility.Hidden;
                cell_registration.Visibility = Visibility.Hidden;
           
          
        }
        private void save_bail_Click(object sender, RoutedEventArgs e)
        {  
          
            
            bail bail = new bail();

            string identifier = id.Text;
            string[] name = new string[2] { lastname.Text, firstname.Text };
            foreach (var names in name)
            {
                string val = name[0];
                string val1 = name[1];
                bail.inmatename = val1 + " " + val;
            }
            bail.inmatenum = identifier;
            bail.offense = offense1.Text.ToString();
            bail.cases = cbb.Text.ToString();
            bail.datebailed = datebailed.DisplayDate.ToString("yyyy-MM-dd");
            bail.bond = bond.Text.ToString();
            bail.court = court.Text.ToString();
            bail.approved = approved.Text.ToString();
            con.Open();

            SqlCommand command = con.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "update prisoner set jailstatus = 'realeased' where id = '"+id.Text+"'";
            command.ExecuteNonQuery();
            con.Close();
            bail.bail_add();
            this.Close();

            bailinfo bi = new bailinfo();
            bi.Show();
            this.Close();
        }

        //close this panel
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //hearing schedule
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            bail.Visibility = Visibility.Hidden;
            cell_transfer.Visibility = Visibility.Hidden;
            hearing_schedule.Visibility = Visibility.Visible;
            case_registration.Visibility = Visibility.Hidden;
            cell_registration.Visibility = Visibility.Hidden;
        }

        private void add_hearing_Click(object sender, RoutedEventArgs e )
        {
            hearing h = new hearing();
            h.inmatenum = id.Text;
            h.hearingdate = hearingdate.DisplayDate.ToString("yyyy-MM-dd");
            h.hearingtime = hearingtime.SelectedTime.ToString();

          
            h.escort = escort_id.Text.ToString();
            h.hearing_add();
            hearingschedule hs = new hearingschedule();
            hs.Show();
            this.Close();
        }
        private void datagrid_escort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            escort_id.Visibility = Visibility.Visible;
            escort_lastname.Visibility = Visibility.Visible;
            escort_firstname.Visibility = Visibility.Visible;
            escort_position.Visibility = Visibility.Visible;

            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            if (row_selected != null)
            {
               escort_id.Text = row_selected["id"].ToString();
               escort_lastname.Text = row_selected["lastname"].ToString();
               escort_firstname.Text = row_selected["firstname"].ToString();
               escort_position.Text = row_selected["position"].ToString();
            }
        }
        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
          

        }
   

        //cell transfer
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            cell_transfer.Visibility = Visibility.Visible;
            bail.Visibility = Visibility.Hidden;
            hearing_schedule.Visibility = Visibility.Hidden;
            case_registration.Visibility = Visibility.Hidden;
            cell_registration.Visibility = Visibility.Hidden;
        }

        private void save_celltransfer_Click(object sender, RoutedEventArgs e)
        {
           
            con.Open();
            SqlCommand command = con.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "update celltransfer set cell='" + cell.Text.ToString() + "', reason= '" + reason.Text.ToString() + "' where id = '" + id.Text + "'";
            if(cell.Text.ToString()!= "" && reason.Text.ToString() != "")
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Successfully Transferred!");
                cellinfo ci = new cellinfo();
                ci.Show();
                con.Close();
                cell info = new cell();
                int count = info.num_inmates;


                con.Open();
                SqlCommand command1 = con.CreateCommand();
                command1.CommandType = CommandType.Text;
                command1.CommandText = "update cell set num_inmates = num_inmates + 1 where cellnum = '" + cell.Text + "'";
                command1.ExecuteNonQuery();
                con.Close(); 

                con.Open();
                SqlCommand comm = con.CreateCommand();
                comm.CommandType = CommandType.Text;
                comm.CommandText = "update cell set num_inmates= num_inmates - 1 where cellnum = '" + cell.Text + "'";
                comm.ExecuteNonQuery();
             
                con.Close();


              
               
              

            }
            //audittrail
            //dashboard d = new dashboard();
            //audittrail au = new audittrail();
            //au.users = d.username.Text.ToString();
            //au.activity = "transfered a prisoner";
            //au.dateOfActivity = DateTime.Now.ToString();
            //au.timeOfActivity = DateTime.Now.ToString("G");
            //au.add();
        }
        //case registration
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            case_registration.Visibility = Visibility.Visible;
            cell_transfer.Visibility = Visibility.Hidden;
            bail.Visibility = Visibility.Hidden;
            hearing_schedule.Visibility = Visibility.Hidden;
            cell_registration.Visibility = Visibility.Hidden;
            update_case.Visibility = Visibility.Hidden;
        }
        private void savecase_Click (object sender, RoutedEventArgs e)
        {
            caseregistration cases = new caseregistration();
            string identifier = id.Text;
            string[] name = new string[2] { lastname.Text, firstname.Text };
            foreach (var names in name)
            {
                string val = name[0];
                string val1 = name[1];
                cases.inmatename = val1 + " " + val;
            }
                cases.inmatenum = identifier;
                cases.casenum = casenum.Text.ToString();
                cases.offense = offense1.Text.ToString();
                cases.datefiled = datefiled.DisplayDate.ToString("yyyy-MM-dd");
                cases.datesen = datesen.DisplayDate.ToString("yyyy-MM-dd");
                cases.senstatus = senstatus.Text.ToString();
                cases.senreceive = senreceive.Text.ToString();
                cases.sendue = sendue.Text.ToString();
                cases.case_add();
            //audittrail
            //dashboard d = new dashboard();
            //audittrail au = new audittrail();
            //au.users = d.username.Text.ToString();
            //au.activity = "added a case to a prisoner";
            //au.dateOfActivity = DateTime.Now.ToString();
            //au.timeOfActivity = DateTime.Now.ToString("G");
            //au.add();
            //this.Close();
            bail1.Visibility = Visibility.Visible;

            //casemain casem = new casemain();
            //    casem.Show();
                this.Close();
            
        }
       


        private void close_photoviewer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void open_photoviewer_Click(object sender, RoutedEventArgs e)
        {
            mp_id.Text = id.Text;
            mp_name.Text = lastname.Text + ", " + firstname.Text + " " + middlename.Text;

            con.Open();
            DataSet ds = new DataSet();

            SqlDataAdapter sqa = new SqlDataAdapter("select name from mugshots where prisoner_id='"+mp_id.Text+"'", con);
            sqa.Fill(ds);

            con.Close();
            foreach (DataRow dataRow in ds.Tables[0].Rows)
            {
                ListBoxItem lbItem = new ListBoxItem();
                lbItem.Content = dataRow[0].ToString();
                lbpics.Items.Add(lbItem);
               
            }
            lbpics.SelectedIndex = 0;
        }


        //open picture
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.ShowDialog();

            try
            {
                FileStream fs = new FileStream(dlg.FileName, FileMode.Open,
                FileAccess.Read);
                byte[] data = new byte[fs.Length];
                fs.Read(data, 0, System.Convert.ToInt32(fs.Length));
                fs.Close();
                con.Open();
                SqlCommand sc = new SqlCommand("insert into mugshots(data, name, prisoner_id) values(@d, @n, @i)", con);

                sc.Parameters.AddWithValue("@d", data);
                sc.Parameters.AddWithValue("@n", mp_name.Text);
                sc.Parameters.AddWithValue("@i", mp_id.Text);
                sc.ExecuteNonQuery();
                con.Close();
                ImageSourceConverter imgs = new ImageSourceConverter();
                picturebox.SetValue(Image.SourceProperty, imgs.
                ConvertFromString(dlg.FileName.ToString()));
                MessageBox.Show("New Mugshot Pictures is Saved!");

                //audittrail
                //    dashboard d = new dashboard();
                //    audittrail au = new audittrail();
                //    au.users = d.username.Text.ToString();
                //    au.activity = "added a  mugshot to a prisoner";
                //    au.dateOfActivity = DateTime.Now.ToString();
                //    au.timeOfActivity = DateTime.Now.ToString("G");
                //    au.add();
            }


            catch
            {
            }
        }

        private void lbpics_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem lb = (lbpics.SelectedItem as ListBoxItem);
            con.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter sqa = new SqlDataAdapter
            ("Select data from mugshots where name='" + lb.Content.ToString() + "'", con);
            sqa.Fill(ds);
            con.Close();

            byte[] data = (byte[])ds.Tables[0].Rows[0][0];

            var image = new BitmapImage();
            using (var mem = new MemoryStream(data))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            picturebox.Source = image;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            visitor.visitormain vm = new visitor.visitormain();
            vm.Show();
            
        }

        private void datagrid_visitors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void datagrid_cellinfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            bail.Visibility = Visibility.Hidden;
            hearing_schedule.Visibility = Visibility.Hidden;
            cell_transfer.Visibility = Visibility.Hidden;
            case_registration.Visibility = Visibility.Hidden;
            cell_registration.Visibility = Visibility.Visible;
            fname.Text = firstname.Text;
            lname.Text = lastname.Text;
        }
        private void Button_Click_10(object sender, RoutedEventArgs e)
        {

            
            string identifier = id.Text;
            transfer t = new transfer();
            cell info = new cell();
            int count = info.num_inmates;
            t.cell = cell1.Text.ToString();
            t.firstname = fname.Text.ToString();
            t.lastname= lname.Text.ToString();
           
                   
                    con.Open();
                    SqlCommand command = con.CreateCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "update cell set num_inmates =  num_inmates + 1 where cellnum = '"+ cell1.Text +"'";
                    command.ExecuteNonQuery();
                    MessageBox.Show("Updated");
                    con.Close();
                    t.inmatenum = identifier;
                
                    t.celltrans_add();
                    this.Close();   
            


        }

        private void datagrid_cell_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void updatecase_Click(object sender, RoutedEventArgs e)
        {
                casemain cm = new casemain();

                con.Open();
                SqlCommand command = con.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "update cases set casenum = '" + casenum.Text.ToString()+"', offense= '" + offenses.Text.ToString() + "' , datefiled = '" + datefiled.DisplayDate.ToString("yyyy-MM-dd") + "', datesen = '" + datesen.DisplayDate.ToString("yyyy-MM-dd") + "', senstatus = '" + senstatus.Text.ToString() + "', senreceive= '" + senreceive.Text.ToString() + "', sendue= '" + sendue.Text.ToString() + "'  where id = '" + id.Text + "'";
                command.ExecuteNonQuery();
                MessageBox.Show("Successfully Updated!!");

                cm.Show();
                con.Close();
            
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void datagrid_bail_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bail.Visibility = Visibility.Visible;
            hearing_schedule.Visibility = Visibility.Collapsed;
            cell_transfer.Visibility = Visibility.Collapsed;
            cell_registration.Visibility = Visibility.Collapsed;
            case_registration.Visibility = Visibility.Collapsed;

            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                string cases = row_selected["cases"].ToString();
                string offense = row_selected["offense"].ToString();
                cbb.Text = cases.ToString();
                offenses.Text = offense.ToString();

            }


        }

        

        private void lbpicss_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem lbs = (lbpicss.SelectedItem as ListBoxItem);
            con.Open();
            DataSet dss = new DataSet();
            SqlDataAdapter sqas = new SqlDataAdapter
            ("Select data from documents where name='" + lbs.Content.ToString() + "'", con);
            sqas.Fill(dss);
            con.Close();

            byte[] datas = (byte[])dss.Tables[0].Rows[0][0];

            var image = new BitmapImage();
            using (var mem = new MemoryStream(datas))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            pictureboxs.Source = image;
        }

        private void open_documentviewer_Click(object sender, RoutedEventArgs e)
        {
            mp_ids.Text = id.Text;
            mp_names.Text = lastname.Text + ", " + firstname.Text + " " + middlename.Text;

            con.Open();
            DataSet dss = new DataSet();

            SqlDataAdapter sqas = new SqlDataAdapter("select name from documents where prisoner_id='" + mp_ids.Text + "'", con);
            sqas.Fill(dss);

            con.Close();
            foreach (DataRow dataRow in dss.Tables[0].Rows)
            {
                ListBoxItem lbItem = new ListBoxItem();
                lbItem.Content = dataRow[0].ToString();
                lbpicss.Items.Add(lbItem);

            }
            lbpicss.SelectedIndex = 0;
        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlgs = new Microsoft.Win32.OpenFileDialog();
            dlgs.ShowDialog();

            try
            {
                FileStream fss = new FileStream(dlgs.FileName, FileMode.Open,
                FileAccess.Read);
                byte[] datas = new byte[fss.Length];
                fss.Read(datas, 0, System.Convert.ToInt32(fss.Length));
                fss.Close();
                con.Open();
                SqlCommand scs = new SqlCommand("insert into documents(data, name, prisoner_id) values(@d, @n, @i)", con);

                scs.Parameters.AddWithValue("@d", datas);
                scs.Parameters.AddWithValue("@n", mp_names.Text);
                scs.Parameters.AddWithValue("@i", mp_ids.Text);
                scs.ExecuteNonQuery();
                con.Close();
                ImageSourceConverter imgss = new ImageSourceConverter();
                pictureboxs.SetValue(Image.SourceProperty, imgss.
                ConvertFromString(dlgs.FileName.ToString()));
                MessageBox.Show("New Document Picture was Saved!");
            }
            catch
            {
            }
        }
    }
    
}
