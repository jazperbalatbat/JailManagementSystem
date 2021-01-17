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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using JailManagementSystem.objects;

namespace JailManagementSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection cons = new SqlConnection(@"Data Source=DESKTOP-RVI30EH\SQLEXPRESS;Initial Catalog=jms;Integrated Security=True");


        public MainWindow()
        {
            InitializeComponent();
        }

        int rowscount = 0;

        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();


        private void login_Click(object sender, RoutedEventArgs e)
        {

            ////ADMIN LOGIN
            var db = new dashboard();
            //Warden warden = new Warden();
            //warden.setUsername(id_login.Text.ToString());
            //warden.setPassword(pass_login.Password);

            //string query = "select * from warden where username = '" + warden.username + "' and password = '" + warden.password + "'";
            //SqlCommand coms = new SqlCommand(query, cons);
            //SqlDbConnection con = new SqlDbConnection();

            //con.Adaptor(query);
            //DataTable dt = con.Fill();
            //if (dt.Rows.Count == 1)
            //{
            db.Show();
            //cons.Open();
            //SqlDataReader reads = coms.ExecuteReader();
            //while (reads.Read())
            //{

            //        warden.firstname = (reads["firstname"].ToString());
            //        warden.lastname = (reads["lastname"].ToString());
            //        warden.admin = (reads["admin"].ToString());
            //        warden.id = (reads["id"].ToString());
            //        db.main_lastname.Text = warden.lastname;
            //        db.main_firstname.Text = warden.firstname;
            //        db.main_id.Text = warden.id;
            //        db.main_position.Text = warden.admin;

            //}
            //reads.Close();
            //cons.Close();
            //    this.Close();
            //}
            ////ADMIN LOGIN

            //jailofficers jo = new jailofficers();
            //jo.setUsername(id_login.Text.ToString());
            //jo.setPassword(pass_login.Password);


            //string qry = "select * from jailofficer where username = '" + jo.username + "' and password = '" + jo.password + "'";

            //SqlCommand com = new SqlCommand(qry, cons);

            //audittrail audit = new audittrail();

            //audit.users = id_login.Text.ToString();
            //audit.activity = "login";
            //audit.dateOfActivity = DateTime.Now.ToString();
            //audit.timeOfActivity = DateTime.Now.ToString("G");
            //audit.add();
            //con.Adaptor(qry);
            //DataTable dts = con.Fill();

            //if (dts.Rows.Count == 1)
            //{
            //    db.Show();

            //    cons.Open();
            //    SqlDataReader read = com.ExecuteReader();
            //    while (read.Read())
            //    {
            //        jo.firstname = (read["firstname"].ToString());
            //        jo.lastname = (read["lastname"].ToString());
            //        jo.jo = (read["jo"].ToString());
            //        jo.id = (read["id"].ToString());
            //        db.main_lastname.Text = jo.lastname;
            //        db.main_firstname.Text = jo.firstname;
            //        db.main_id.Text = jo.id;
            //        db.main_position.Text = jo.jo;
            //        string p = (read["prisoner"].ToString());
            //        string v = (read["visitor"].ToString());
            //        string ce = (read["cell"].ToString());
            //        string ca = (read["casee"].ToString());
            //        string es = (read["escort"].ToString());
            //        string pr = (read["prisoner_report"].ToString());
            //        string vr = (read["visitor_report"].ToString());
            //        string cer = (read["cell_report"].ToString());
            //        string car = (read["case_report"].ToString());
            //        string br = (read["bail_report"].ToString());
            //        string hr = (read["hearing_report"].ToString());
            //        string jor = (read["jailofficer_report"].ToString());
            //        db.pos_iden = (read["jo"].ToString());



            //        if (db.pos_iden == "jailofficer")
            //        {
            //            db.util.IsEnabled = false;
            //            //db.jailofficer_b.IsEnabled = false;
            //            if (p == "0")
            //                db.prisoner_b.IsEnabled = false;
            //            if (v == "0")
            //                db.visitor_b.IsEnabled = false;
            //            if (ce == "0")
            //                db.cell_b.IsEnabled = false;
            //            if (ca == "0")
            //                db.case_b.IsEnabled = false;
            //            if (es == "0")
            //                db.escort_b.IsEnabled = false;

            //            if (pr == "0")
            //                db.prisoner.IsHitTestVisible = false;
            //            if (vr == "0")
            //                db.visitor.IsHitTestVisible = false;
            //            if (cer == "0")
            //                db.cell.IsHitTestVisible = false;
            //            if (car == "0")
            //                db.@case.IsHitTestVisible = false;

            //            if (br == "0")
            //                db.bail.IsHitTestVisible = false;
            //            if (hr == "0")
            //                db.hearing.IsHitTestVisible = false;

            //            if (jor == "0")
            //                db.officer.IsHitTestVisible = false;
            //        }

            //    }
            //    read.Close();


            //    string cmnd = "insert into joattendance_in values('" + DateTime.Now.ToString() +  "', '" + jo.lastname.ToString() + "',' " + jo.firstname.ToString() + "',";
            //    cmnd += "  '" + jo.id.ToString() + "')";
            //    SqlCommand commandss = cons.CreateCommand();
            //    commandss.CommandType = CommandType.Text;
            //    commandss.CommandText = cmnd;
            //    commandss.ExecuteNonQuery();
            //    cons.Close();
            //    this.Close();
            //}

            //if (dts.Rows.Count != 1 && dt.Rows.Count != 1)
            //{
            //    MessageBox.Show("invalid user id and password");
            //    rowscount++;
            //    if(rowscount == 3)
            //    {

            //        timer.Interval = 30000; // here time in milliseconds
            //        timer.Tick += timer_Tick;
            //        timer.Start();
            //        login.IsEnabled = false;


            //    }
            //}

        }

        void timer_Tick(object sender, System.EventArgs e)
        {
            login.IsEnabled = true;
            timer.Stop();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            register r = new register();
            r.Show();
        }
    }
}
