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
    public partial class menuPage : Form
    {
        public menuPage()
        {
            InitializeComponent();
        }

        OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/This PC/Three Bean Barista/loginDB.accdb");

        int maxOrderSpace = 0;
        private void menuPage_Load(object sender, EventArgs e)
        {
            remove1.Visible = false;
            remove2.Visible = false;
            remove3.Visible = false;
            remove4.Visible = false;
            remove5.Visible = false;
            remove6.Visible = false;
            remove7.Visible = false;
            remove8.Visible = false;
            remove9.Visible = false;
            remove10.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            OleDbDataAdapter da1 = new OleDbDataAdapter("select * from userDetail",connection);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);

            string id = "";
            int count = 0;

            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                if (ds1.Tables[0].Rows[i][4].ToString() == "true")
                {
                    id = ds1.Tables[0].Rows[i][0].ToString();
                }
            }
            
            OleDbDataAdapter da2 = new OleDbDataAdapter("select * from menu", connection);
            DataSet ds2= new DataSet();
            da2.Fill(ds2);

            for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
            {
                if (ds2.Tables[0].Rows[i][4].ToString() == "true")
                    count++;
            }

            int t = 0;
            string[] temp = new string[4]{"","","",""};
            for (int j = 0; j < ds2.Tables[0].Rows.Count; j++)
            {
                if (ds2.Tables[0].Rows[j][4].ToString() == "true")
                {
                    temp[t] = ds2.Tables[0].Rows[j][0].ToString();
                    t++;
                }

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = connection;
                cmd.CommandText = "update userDetail set mID1 = '" + temp[0] + "', mID2 = '" + temp[1] + "', mID3 = '" + temp[2] + "', mID4 = '" + temp[3] + "' where userID = '" + id + "'";
                cmd.ExecuteNonQuery();
            }
            
            connection.Close();

            orderPage op = new orderPage();
            op.ShowDialog();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = connection;
            cmd.CommandText = "update menu set flag ='false'";
            cmd.ExecuteNonQuery();
            connection.Close();
            this.Close();
        }

        private void btnItem1_Click(object sender, EventArgs e)
        {
            if (maxOrderSpace < 4 && remove1.Visible == false)
            {
                ++maxOrderSpace;
                remove1.Visible = true;
                btnItem1.Text = "Added";
                btnItem1.BackColor = Color.SandyBrown;
                rectangleShape1.BackColor = Color.SandyBrown;

                connection.Open();

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = connection;
                cmd.CommandText = "update menu set flag = 'true' where mID = '1'";
                cmd.ExecuteNonQuery();

                connection.Close();
            }

            if (maxOrderSpace == 4)
                MessageBox.Show("Max Capcity reached");
        }

        private void btnItem2_Click(object sender, EventArgs e)
        {
            if (maxOrderSpace < 4 && remove2.Visible == false)
            {
                ++maxOrderSpace;
                remove2.Visible = true;
                btnItem2.Text = "Added";
                btnItem2.BackColor = Color.SandyBrown;
                rectangleShape2.BackColor = Color.SandyBrown;

                connection.Open();

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = connection;
                cmd.CommandText = "update menu set flag = 'true' where mID = '2'";
                cmd.ExecuteNonQuery();
                
                 connection.Close();
            }

            if (maxOrderSpace == 4)
                MessageBox.Show("Max Capcity reached");
        }

        private void btnItem3_Click(object sender, EventArgs e)
        {
            if (maxOrderSpace < 4 && remove3.Visible == false)
            {
                ++maxOrderSpace;
                remove3.Visible = true;
                btnItem3.Text = "Added";
                btnItem3.BackColor = Color.SandyBrown;
                rectangleShape3.BackColor = Color.SandyBrown;

                connection.Open();

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = connection;
                cmd.CommandText = "update menu set flag = 'true' where mID = '3'";
                cmd.ExecuteNonQuery();

                connection.Close();
            }

            if (maxOrderSpace == 4)
                MessageBox.Show("Max Capcity reached");
        }

        private void btnItem4_Click(object sender, EventArgs e)
        {
            if (maxOrderSpace < 4 && remove4.Visible == false)
            {
                ++maxOrderSpace;
                remove4.Visible = true;
                btnItem4.Text = "Added";
                btnItem4.BackColor = Color.SandyBrown;
                rectangleShape4.BackColor = Color.SandyBrown;

                connection.Open();

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = connection;
                cmd.CommandText = "update menu set flag = 'true' where mID = '4'";
                cmd.ExecuteNonQuery();

                connection.Close();
            }

            if (maxOrderSpace == 4)
                MessageBox.Show("Max Capcity reached");
        }

        private void btnItem5_Click(object sender, EventArgs e)
        {
            if (maxOrderSpace < 4 && remove5.Visible == false)
            {
                ++maxOrderSpace;
                remove5.Visible = true;
                btnItem5.Text = "Added";
                btnItem5.BackColor = Color.SandyBrown;
                rectangleShape5.BackColor = Color.SandyBrown;

                connection.Open();

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = connection;
                cmd.CommandText = "update menu set flag = 'true' where mID = '5'";
                cmd.ExecuteNonQuery();

                connection.Close();
            }

            if (maxOrderSpace == 4)
                MessageBox.Show("Max Capcity reached");
        }

        private void btnItem6_Click(object sender, EventArgs e)
        {
            if (maxOrderSpace < 4 && remove6.Visible == false)
            {
                ++maxOrderSpace;
                remove6.Visible = true;
                btnItem6.Text = "Added";
                btnItem6.BackColor = Color.SandyBrown;
                rectangleShape6.BackColor = Color.SandyBrown;

                connection.Open();

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = connection;
                cmd.CommandText = "update menu set flag = 'true' where mID = '6'";
                cmd.ExecuteNonQuery();

                connection.Close();
            }

            if (maxOrderSpace == 4)
                MessageBox.Show("Max Capcity reached");
        }

        private void btnItem7_Click(object sender, EventArgs e)
        {
            if (maxOrderSpace < 4 && remove7.Visible == false)
            {
                ++maxOrderSpace;
                remove7.Visible = true;
                btnItem7.Text = "Added";
                btnItem7.BackColor = Color.SandyBrown;
                rectangleShape7.BackColor = Color.SandyBrown;

                connection.Open();

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = connection;
                cmd.CommandText = "update menu set flag = 'true' where mID = '7'";
                cmd.ExecuteNonQuery();

                connection.Close();
            }

            if (maxOrderSpace == 4)
                MessageBox.Show("Max Capcity reached");
        }

        private void btnItem8_Click(object sender, EventArgs e)
        {
            if (maxOrderSpace < 4 && remove8.Visible == false)
            {
                ++maxOrderSpace;
                remove8.Visible = true;
                btnItem8.Text = "Added";
                btnItem8.BackColor = Color.SandyBrown;
                rectangleShape8.BackColor = Color.SandyBrown;

                connection.Open();

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = connection;
                cmd.CommandText = "update menu set flag = 'true' where mID = '8'";
                cmd.ExecuteNonQuery();

                connection.Close();
            }

            if (maxOrderSpace == 4)
                MessageBox.Show("Max Capcity reached");
        }

        private void btnItem9_Click(object sender, EventArgs e)
        {
            if (maxOrderSpace < 4 && remove9.Visible == false)
            {
                ++maxOrderSpace;
                remove9.Visible = true;
                btnItem9.Text = "Added";
                btnItem9.BackColor = Color.SandyBrown;
                rectangleShape9.BackColor = Color.SandyBrown;

                connection.Open();

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = connection;
                cmd.CommandText = "update menu set flag = 'true' where mID = '9'";
                cmd.ExecuteNonQuery();

                connection.Close();
            }

            if (maxOrderSpace == 4)
                MessageBox.Show("Max Capcity reached");
        }

        private void btnItem10_Click(object sender, EventArgs e)
        {
            if (maxOrderSpace < 4 && remove10.Visible == false)
            {
                ++maxOrderSpace;
                remove10.Visible = true;
                btnItem10.Text = "Added";
                btnItem10.BackColor = Color.SandyBrown;
                rectangleShape10.BackColor = Color.SandyBrown;

                connection.Open();

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = connection;
                cmd.CommandText = "update menu set flag = 'true' where mID = '10'";
                cmd.ExecuteNonQuery();
                    
                connection.Close();
            }

            if(maxOrderSpace == 4)
                MessageBox.Show("Max Capcity reached");
        }

        private void remove1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            --maxOrderSpace;
            btnItem1.Text = "Add";
            btnItem1.BackColor = Color.White;
            rectangleShape1.BackColor = Color.White;
            remove1.Visible = false;

            connection.Open();

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = connection;
            cmd.CommandText = "update menu set flag = 'false' where mID = '1'";
            cmd.ExecuteNonQuery();

            connection.Close();
        }

        private void remove2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            --maxOrderSpace;
            btnItem2.Text = "Add";
            btnItem2.BackColor = Color.White;
            rectangleShape2.BackColor = Color.White;
            remove2.Visible = false;

            connection.Open();

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = connection;
            cmd.CommandText = "update menu set flag = 'false' where mID = '2'";
            cmd.ExecuteNonQuery();

            connection.Close();
        }

        private void remove3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            --maxOrderSpace;
            btnItem3.Text = "Add";
            btnItem3.BackColor = Color.White;
            rectangleShape3.BackColor = Color.White;
            remove3.Visible = false;

            connection.Open();

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = connection;
            cmd.CommandText = "update menu set flag = 'false' where mID = '3'";
            cmd.ExecuteNonQuery();

            connection.Close();
        }

        private void remove4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            --maxOrderSpace;
            btnItem4.Text = "Add";
            btnItem4.BackColor = Color.White;
            rectangleShape4.BackColor = Color.White;
            remove4.Visible = false;

            connection.Open();

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = connection;
            cmd.CommandText = "update menu set flag = 'false' where mID = '4'";
            cmd.ExecuteNonQuery();

            connection.Close();
        }

        private void remove5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            --maxOrderSpace;
            btnItem5.Text = "Add";
            btnItem5.BackColor = Color.White;
            rectangleShape5.BackColor = Color.White;
            remove5.Visible = false;

            connection.Open();

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = connection;
            cmd.CommandText = "update menu set flag = 'false' where mID = '5'";
            cmd.ExecuteNonQuery();

            connection.Close();
        }

        private void remove6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            --maxOrderSpace;
            btnItem6.Text = "Add";
            btnItem6.BackColor = Color.White;
            rectangleShape6.BackColor = Color.White;
            remove6.Visible = false;

            connection.Open();

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = connection;
            cmd.CommandText = "update menu set flag = 'false' where mID = '6'";
            cmd.ExecuteNonQuery();

            connection.Close();
        }

        private void remove7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            --maxOrderSpace;
            btnItem7.Text = "Add";
            btnItem7.BackColor = Color.White;
            rectangleShape7.BackColor = Color.White;
            remove7.Visible = false;

            connection.Open();

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = connection;
            cmd.CommandText = "update menu set flag = 'false' where mID = '7'";
            cmd.ExecuteNonQuery();

            connection.Close();
        }

        private void remove8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            --maxOrderSpace;
            btnItem8.Text = "Add";
            btnItem8.BackColor = Color.White;
            rectangleShape8.BackColor = Color.White;
            remove8.Visible = false;

            connection.Open();

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = connection;
            cmd.CommandText = "update menu set flag = 'false' where mID = '8'";
            cmd.ExecuteNonQuery();

            connection.Close();
        }

        private void remove9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            --maxOrderSpace;
            btnItem9.Text = "Add";
            btnItem9.BackColor = Color.White;
            rectangleShape9.BackColor = Color.White;
            remove9.Visible = false;

            connection.Open();

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = connection;
            cmd.CommandText = "update menu set flag = 'false' where mID = '9'";
            cmd.ExecuteNonQuery();

            connection.Close();
        }

        private void remove10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            --maxOrderSpace;
            btnItem10.Text = "Add";
            btnItem10.BackColor = Color.White;
            rectangleShape10.BackColor = Color.White;
            remove10.Visible = false;

            connection.Open();

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = connection;
            cmd.CommandText = "update menu set flag = 'false' where mID = '10'";
            cmd.ExecuteNonQuery();

            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = connection;
            cmd.CommandText = "update menu set flag ='false'";
            cmd.ExecuteNonQuery();
            this.Close();
            customCoffee cc = new customCoffee();
            cc.ShowDialog();
        }
    }
}
