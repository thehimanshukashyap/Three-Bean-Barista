using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Three_Bean_Barista
{
    public partial class orderSuccessPage2 : Form
    {
        public orderSuccessPage2()
        {
            InitializeComponent();
        }

        OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/This PC/Three Bean Barista/loginDB.accdb");

        private void orderSuccessPage2_Load(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "select * from customCoffee";
            cmd.Connection = connection;
            OleDbDataReader dr = cmd.ExecuteReader();

            dr.Read();
            lblBeans.Text = dr.GetString(1);
            lblRoast.Text = dr.GetString(2);
            lblGrind.Text = dr.GetString(3);
            lblMethod.Text = dr.GetString(3);
            lblGrandTotal.Text = Convert.ToString(6 + (6*18/100)) + '$';
            connection.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Feedbackcs fb = new Feedbackcs();
            fb.ShowDialog();

            connection.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "delete from customCoffee where id = '1'";
            cmd.Connection = connection;
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
