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
using JailManagementSystem.objects;
namespace JailManagementSystem
{
    /// <summary>
    /// Interaction logic for prisonerFM.xaml
    /// </summary>
    public partial class prisonerFM : Window
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RVI30EH\SQLEXPRESS;Initial Catalog=jms;Integrated Security=True");

        public prisonerFM()
        {
            InitializeComponent();

        }

        public ICommand NewTabCommand { get; }

        private void fmprisoner_b_add_Click(object sender, RoutedEventArgs e)
        {

            prisoner prisoner = new prisoner();
            prisoner.firstname = firstname.Text.ToString();
            prisoner.middlename = middlename.Text.ToString();
            prisoner.lastname = lastname.Text.ToString();
            prisoner.address = address.Text.ToString();
            prisoner.age = age.Text.ToString();
            prisoner.gender = gender.Text.ToString();
            prisoner.birthdate = birthdate.DisplayDate.ToString("yyyy-MM-dd");
            prisoner.height = height.Text.ToString();
            prisoner.weight = weight.Text.ToString();
            prisoner.citizenship = citizenship.Text.ToString();
            prisoner.religion = religion.Text.ToString();
            prisoner.datein = datein.DisplayDate.ToString("yyyy-MM-dd");
            prisoner.civilstatus = civilstatus.Text.ToString();
            prisoner.jailstatus = jailstatus.Text.ToString();
            prisoner.add();
            this.Close();
            prisonermain pm = new prisonermain();
            //pm.Close();
            pm.Show();
            loading l = new loading();
            l.Show();
            MessageBox.Show("Successfully inserted!");
            


        }

        private void fmprisoner_b_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            prisonermain pm = new prisonermain();

            loading l = new loading();
            l.Show();
            pm.Show();
        }

        //close this panel
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
