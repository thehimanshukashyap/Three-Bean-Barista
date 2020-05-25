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
    public partial class orderSuccessPage : Form
    {
        public orderSuccessPage()
        {
            InitializeComponent();
        }

        OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/This PC/Three Bean Barista/loginDB.accdb");

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void orderSuccessPage_Load(object sender, EventArgs e)
        {
            connection.Open();

            OleDbDataAdapter da = new OleDbDataAdapter("select * from orderSuccess", connection);
            DataSet ds = new DataSet();
            da.Fill(ds);

            string[] item = new string[4];
            string[] price = new string[4];
            string[] qty = new string[4];

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                int j = 0;

                item[i] = ds.Tables[0].Rows[i][++j].ToString();
                qty[i] = ds.Tables[0].Rows[i][++j].ToString();
                price[i] = ds.Tables[0].Rows[i][++j].ToString();
            }

            if (ds.Tables[0].Rows[0][1].ToString() != " " && ds.Tables[0].Rows[1][1].ToString() == " " && ds.Tables[0].Rows[2][1].ToString()== " " && ds.Tables[0].Rows[3][1].ToString() == " ")
            {
                lblItem1.Text = item[0];
                lblPrice1.Text = price[0];
                lblQty1.Text = qty[0];
                
                lblItem2.Visible = false;
                lblPrice2.Visible = false;
                lblQty2.Visible = false;

                lblItem3.Visible = false;
                lblPrice3.Visible = false;
                lblQty3.Visible = false;

                lblItem4.Visible = false;
                lblPrice4.Visible = false;
                lblQty4.Visible = false;
                 
            }

            if (ds.Tables[0].Rows[0][1].ToString() != " " && ds.Tables[0].Rows[1][1].ToString() != " " && ds.Tables[0].Rows[2][1].ToString() == " " && ds.Tables[0].Rows[3][1].ToString() == " ")
            {
                lblItem1.Text = item[0];
                lblPrice1.Text = price[0];
                lblQty1.Text = qty[0];

                lblItem2.Text = item[1];
                lblPrice2.Text = price[1];
                lblQty2.Text = qty[1];

                lblItem3.Visible = false;
                lblPrice3.Visible = false;
                lblQty3.Visible = false;

                lblItem4.Visible = false;
                lblPrice4.Visible = false;
                lblQty4.Visible = false;
                
            }

            if (ds.Tables[0].Rows[0][1].ToString() != " " && ds.Tables[0].Rows[1][1].ToString() != " " && ds.Tables[0].Rows[2][1].ToString() != " " && ds.Tables[0].Rows[3][1].ToString() == " ")
            {
                lblItem1.Text = item[0];
                lblPrice1.Text = price[0];
                lblQty1.Text = qty[0];

                lblItem2.Text = item[1];
                lblPrice2.Text = price[1];
                lblQty2.Text = qty[1];

                lblItem3.Text = item[2];
                lblPrice3.Text = price[2];
                lblQty3.Text = qty[2];
                
                lblItem4.Visible = false;
                lblPrice4.Visible = false;
                lblQty4.Visible = false;
            }

            if (ds.Tables[0].Rows[0][1].ToString() != " " && ds.Tables[0].Rows[1][1].ToString() != " " && ds.Tables[0].Rows[2][1].ToString() != " " && ds.Tables[0].Rows[3][1].ToString() != " ")
            {
                lblItem1.Text = item[0];
                lblPrice1.Text = price[0];
                lblQty1.Text = qty[0];

                lblItem2.Text = item[1];
                lblPrice2.Text = price[1];
                lblQty2.Text = qty[1];

                lblItem3.Text = item[2];
                lblPrice3.Text = price[2];
                lblQty3.Text = qty[2];

                lblItem4.Text = item[3];
                lblPrice4.Text = price[3];
                lblQty4.Text = qty[3];
            }

            OleDbDataAdapter da2 = new OleDbDataAdapter("select * from userDetail where userFlag = 'true'", connection);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            lblGrandTotal.Text = ds2.Tables[0].Rows[0][12].ToString();
            connection.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Feedbackcs fb = new Feedbackcs();
            fb.ShowDialog();
        }
    }
}
