﻿using System;
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
    /// Interaction logic for cellinfo.xaml
    /// </summary>
    public partial class cellinfo : Window
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RVI30EH\SQLEXPRESS;Initial Catalog=jms;Integrated Security=True");
        public cellinfo()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            con.Open();
            SqlCommand comm = con.CreateCommand();
            DataTable tb = new DataTable();
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select prisoner.id, prisoner.firstname, prisoner.middlename, prisoner.lastname, celltransfer.cell, celltransfer.reason from prisoner inner join celltransfer on prisoner.id = celltransfer.id ";
            comm.ExecuteNonQuery();
            SqlDataAdapter adapt = new SqlDataAdapter(comm);
            adapt.Fill(tb);
            datagrid_cellinfo.ItemsSource = tb.DefaultView;
            con.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void datagrid_cellinfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void datagrid_cell_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
         


            
        }
    }
}
