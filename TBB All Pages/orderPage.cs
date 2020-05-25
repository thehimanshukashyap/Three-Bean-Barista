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
    public partial class orderPage : Form
    {
        public orderPage()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        double p1, p2, p3, p4;
        decimal p = 0, grandTotal;
        void setp()
        {
            //first p1
            if (lblItem1.Text == "Espresso Shot" || lblItem1.Text == "Americano" || lblItem1.Text == "Mocha")
            {
                p1 = 12.99;
            }
            else if (lblItem1.Text == "Latte" || lblItem1.Text == "Cappuccinno" || lblItem1.Text == "White Mocha")
            {
                p1 = 14.99;
            }

            else if (lblItem1.Text == "Muffins" || lblItem1.Text == "Cinnamon Roll")
            {
                p1 = 5.99;
            }

            else if (lblItem1.Text == "Oolong Tea" || lblItem1.Text == "Chamomile Tea")
            {
                p1 = 9.99;
            }

            //secondly p2;
            if (lblItem2.Text == "Espresso Shot" || lblItem2.Text == "Americano" || lblItem2.Text == "Mocha")
            {
                p2 = 12.99;
            }
            else if (lblItem2.Text == "Latte" || lblItem2.Text == "Cappuccinno" || lblItem2.Text == "White Mocha")
            {
                p2 = 14.99;
            }

            else if (lblItem2.Text == "Muffins" || lblItem2.Text == "Cinnamon Roll")
            {
                p2 = 5.99;
            }

            else if (lblItem2.Text == "Oolong Tea" || lblItem2.Text == "Chamomile Tea")
            {
                p2 = 9.99;
            }

            //thridly p3
            if (lblItem3.Text == "Espresso Shot" || lblItem3.Text == "Americano" || lblItem3.Text == "Mocha")
            {
                p3 = 12.99;
            }
            else if (lblItem3.Text == "Latte" || lblItem3.Text == "Cappuccinno" || lblItem3.Text == "White Mocha")
            {
                p3 = 14.99;
            }

            else if (lblItem3.Text == "Muffins" || lblItem3.Text == "Cinnamon Roll")
            {
                p3 = 5.99;
            }

            else if (lblItem3.Text == "Oolong Tea" || lblItem3.Text == "Chamomile Tea")
            {
                p3 = 9.99;
            }

            //fourthly p4;
            if (lblItem4.Text == "Espresso Shot" || lblItem4.Text == "Americano" || lblItem4.Text == "Mocha")
            {
                p4 = 12.99;
            }
            else if (lblItem4.Text == "Latte" || lblItem4.Text == "Cappuccinno" || lblItem4.Text == "White Mocha")
            {
                p4 = 14.99;
            }

            else if (lblItem4.Text == "Muffins" || lblItem4.Text == "Cinnamon Roll")
            {
                p4 = 5.99;
            }

            else if (lblItem4.Text == "Oolong Tea" || lblItem4.Text == "Chamomile Tea")
            {
                p4 = 9.99;
            }
        }

        void setTotal()
        {
            lblTotal.Text = Convert.ToString(p1 + p2 + p3 + p4) + '$';
            p = (decimal)((p1 + p2 + p3 + p4) * 18 / 100);
            lblTax.Text = Convert.ToString(Math.Round(p, 2)) + '$';
            grandTotal = Math.Round((decimal)(p1 + p2 + p3 + p4) + p, 2);
            lblGrandTotal.Text = Convert.ToString(grandTotal) + '$';
        }

        OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/This PC/Three Bean Barista/loginDB.accdb");
        int[] quantity = new int[4]{1,1,1,1};
        private void orderPage_Load(object sender, EventArgs e)
        {
            item1.Visible = false;
            lblItem1.Visible = false;
            btnQtySub1.Visible = false;
            btnQtyAdd1.Visible = false;
            lblQty1.Visible = false;
            lblPrice1.Visible = false;
            lineShape1.Visible = false;

            item2.Visible = false;
            lblItem2.Visible = false;
            btnQtySub2.Visible = false;
            btnQtyAdd2.Visible = false;
            lblQty2.Visible = false;
            lblPrice2.Visible = false;
            lineShape2.Visible = false;

            item3.Visible = false;
            lblItem3.Visible = false;
            btnQtySub3.Visible = false;
            btnQtyAdd3.Visible = false;
            lblQty3.Visible = false;
            lblPrice3.Visible = false;
            lineShape3.Visible = false;

            item4.Visible = false;
            lblItem4.Visible = false;
            btnQtySub4.Visible = false;
            btnQtyAdd4.Visible = false;
            lblQty4.Visible = false;
            lblPrice4.Visible = false;
            lineShape4.Visible = false;

            for (int i = 1; i <= 12; i++)
            {
                if (i < 10)
                {
                    string month = "0" + i.ToString();
                    cmbxMonth.Items.Add(month);
                }

                else
                    cmbxMonth.Items.Add(i.ToString());
            }

            for (int i = 2017; i <= 2025; i++)
            {
                cmbxYear.Items.Add(i.ToString());
            }

            cover.Visible = false;
            rbtnCard.Visible = true;
            rbtnCash.Visible = true;
            rbtnCustomCard.Visible = false;
            rbtnCustomCash.Visible = false;
            confirmationBox.Visible = false;
            lblConfirmation.Visible = false;
            btnYes.Visible = false;
            btnNo.Visible = false;
            
            connection.Open();
            OleDbDataAdapter da1 = new OleDbDataAdapter("select * from userDetail",connection);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            
            OleDbDataAdapter da2 = new OleDbDataAdapter("select * from menu",connection);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);

            OleDbCommand cmd;

            int index = 0;
            int count = 0;

            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                if ("true" == ds1.Tables[0].Rows[i][4].ToString())
                {
                    index = i;
                }
            }

            for (int i = 0; i < 10; i++)
            {
                if (ds2.Tables[0].Rows[i][4].ToString() == "true")
                    count++;
            }
           
            if (count == 1) 
            {
                item1.Visible = true;
                lblItem1.Visible = true;
                btnQtySub1.Visible = true;
                lblQty1.Visible = true;
                btnQtyAdd1.Visible = true;
                lblPrice1.Visible = true;
                lineShape1.Visible = true;

                cmd = new OleDbCommand();
                cmd.Connection = connection;
                cmd.CommandText = "select * from menu where flag = 'true'";

                string filePath = "";
                string item = "";
                string price = "";
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    item = dr.GetString(1);
                    price = dr.GetString(2);
                    filePath = dr.GetString(3);
                }

                item1.BackgroundImage = Image.FromFile(filePath);
                item1.BackgroundImageLayout = ImageLayout.Stretch;
                lblPrice1.Text = price;
                lblItem1.Text = item;
            }

            if (count == 2)
            {
                item1.Visible = true;
                lblItem1.Visible = true;
                btnQtySub1.Visible = true;
                lblQty1.Visible = true;
                btnQtyAdd1.Visible = true;
                lblPrice1.Visible = true;
                lineShape1.Visible = true;

                item2.Visible = true;
                lblItem2.Visible = true;
                btnQtySub2.Visible = true;
                lblQty2.Visible = true;
                btnQtyAdd2.Visible = true;
                lblPrice2.Visible = true;
                lineShape3.Visible = true;

                cmd = new OleDbCommand();
                cmd.Connection = connection;
                cmd.CommandText = "select * from menu where flag = 'true'";
                OleDbDataReader dr = cmd.ExecuteReader();

                string[] filePath = new string[2];
                string[] item = new string[2];
                string[] price = new string[2];
                int i = 0;

                while (dr.Read())
                {
                    item[i] = dr.GetString(1);
                    price[i] = dr.GetString(2);
                    filePath[i] = dr.GetString(3);
                    i++;
                }

                item1.BackgroundImage = Image.FromFile(filePath[0]);
                item1.BackgroundImageLayout = ImageLayout.Stretch;
                lblPrice1.Text = price[0];
                lblItem1.Text = item[0];

                item2.BackgroundImage = Image.FromFile(filePath[1]);
                item2.BackgroundImageLayout = ImageLayout.Stretch;
                lblPrice2.Text = price[1];
                lblItem2.Text = item[1];
            }

            if (count == 3)
            {
                item1.Visible = true;
                lblItem1.Visible = true;
                btnQtySub1.Visible = true;
                lblQty1.Visible = true;
                btnQtyAdd1.Visible = true;
                lblPrice1.Visible = true;
                lineShape1.Visible = true;

                item2.Visible = true;
                lblItem2.Visible = true;
                btnQtySub2.Visible = true;
                lblQty2.Visible = true;
                btnQtyAdd2.Visible = true;
                lblPrice2.Visible = true;
                lineShape3.Visible = true;

                item3.Visible = true;
                lblItem3.Visible = true;
                btnQtySub3.Visible = true;
                lblQty3.Visible = true;
                btnQtyAdd3.Visible = true;
                lblPrice3.Visible = true;
                lineShape2.Visible = true;

                cmd = new OleDbCommand();
                cmd.Connection = connection;
                cmd.CommandText = "select * from menu where flag = 'true'";
                OleDbDataReader dr = cmd.ExecuteReader();

                string[] filePath = new string[3];
                string[] item = new string[3];
                string[] price = new string[3];
                int i = 0;

                while (dr.Read())
                {
                    item[i] = dr.GetString(1);
                    price[i] = dr.GetString(2);
                    filePath[i] = dr.GetString(3);
                    i++;
                }

                item1.BackgroundImage = Image.FromFile(filePath[0]);
                item1.BackgroundImageLayout = ImageLayout.Stretch;
                lblPrice1.Text = price[0];
                lblItem1.Text = item[0];

                item2.BackgroundImage = Image.FromFile(filePath[1]);
                item2.BackgroundImageLayout = ImageLayout.Stretch;
                lblPrice2.Text = price[1];
                lblItem2.Text = item[1];

                item3.BackgroundImage = Image.FromFile(filePath[2]);
                item3.BackgroundImageLayout = ImageLayout.Stretch;
                lblPrice3.Text = price[2];
                lblItem3.Text = item[2];
            }

            if (count == 4)
            {
                item1.Visible = true;
                lblItem1.Visible = true;
                btnQtySub1.Visible = true;
                lblQty1.Visible = true;
                btnQtyAdd1.Visible = true;
                lblPrice1.Visible = true;
                lineShape1.Visible = true;

                item2.Visible = true;
                lblItem2.Visible = true;
                btnQtySub2.Visible = true;
                lblQty2.Visible = true;
                btnQtyAdd2.Visible = true;
                lblPrice2.Visible = true;
                lineShape3.Visible = true;

                item3.Visible = true;
                lblItem3.Visible = true;
                btnQtySub3.Visible = true;
                lblQty3.Visible = true;
                btnQtyAdd3.Visible = true;
                lblPrice3.Visible = true;
                lineShape2.Visible = true;

                item4.Visible = true;
                lblItem4.Visible = true;
                btnQtySub4.Visible = true;
                lblQty4.Visible = true;
                btnQtyAdd4.Visible = true;
                lblPrice4.Visible = true;
                lineShape4.Visible = true;

                cmd = new OleDbCommand();
                cmd.Connection = connection;
                cmd.CommandText = "select * from menu where flag = 'true'";
                OleDbDataReader dr = cmd.ExecuteReader();

                string[] filePath = new string[4];
                string[] item = new string[4];
                string[] price = new string[4];
                int i = 0;

                while (dr.Read())
                {
                    item[i] = dr.GetString(1);
                    price[i] = dr.GetString(2);
                    filePath[i] = dr.GetString(3);
                    i++;
                }

                item1.BackgroundImage = Image.FromFile(filePath[0]);
                item1.BackgroundImageLayout = ImageLayout.Stretch;
                lblPrice1.Text = price[0];
                lblItem1.Text = item[0];

                item2.BackgroundImage = Image.FromFile(filePath[1]);
                item2.BackgroundImageLayout = ImageLayout.Stretch;
                lblPrice2.Text = price[1];
                lblItem2.Text = item[1];

                item3.BackgroundImage = Image.FromFile(filePath[2]);
                item3.BackgroundImageLayout = ImageLayout.Stretch;
                lblPrice3.Text = price[2];
                lblItem3.Text = item[2];

                item4.BackgroundImage = Image.FromFile(filePath[3]);
                item4.BackgroundImageLayout = ImageLayout.Stretch;
                lblPrice4.Text = price[3];
                lblItem4.Text = item[3];
             
            }

            connection.Close();

            setp();
            setTotal();
        }

        private void txtCardNo1_TextChanged(object sender, EventArgs e)
        {
            if (txtCardNo1.TextLength == 4)
                txtCardNo2.Focus();
        }

        private void txtCardNo2_TextChanged(object sender, EventArgs e)
        {
            if (txtCardNo2.TextLength == 4)
                txtCardNo3.Focus();
        }

        private void txtCardNo3_TextChanged(object sender, EventArgs e)
        {
            if (txtCardNo3.TextLength == 4)
                txtCardNo4.Focus();
        }

        private void rbtnCard_Click(object sender, EventArgs e)
        {
            rbtnCard.Visible = false;
            rbtnCustomCard.Visible = true;
            rbtnCash.Visible = true;
            rbtnCustomCash.Visible = false;
            txtCardNo1.Enabled = true;
            txtCardNo2.Enabled = true;
            txtCardNo3.Enabled = true;
            txtCardNo4.Enabled = true;
            cmbxMonth.Enabled = true;
            cmbxYear.Enabled = true;
        }

        private void rbtnCash_Click(object sender, EventArgs e)
        {
            rbtnCard.Visible = true;
            rbtnCustomCard.Visible = false;
            rbtnCash.Visible = false;
            rbtnCustomCash.Visible = true;
            txtCardNo1.Enabled = false;
            txtCardNo2.Enabled = false;
            txtCardNo3.Enabled = false;
            txtCardNo4.Enabled = false;
            txtCVV.Text = "";
            cmbxMonth.SelectedIndex = -1;
            cmbxYear.SelectedIndex = -1;
            txtCardNo1.Text = "";
            txtCardNo2.Text = "";
            txtCardNo3.Text = "";
            txtCardNo4.Text = "";   
        }

        private void lblCancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            confirmationBox.Visible = true;
            cover.Visible = true;
            lblConfirmation.Visible = true;
            btnYes.Visible = true;
            btnNo.Visible = true;
            rbtnCash.Visible = false;
            rbtnCustomCash.Visible = false;
            rbtnCard.Visible = false;
            rbtnCustomCard.Visible = false;
            lblCard.Visible = false;
            lblCash.Visible = false;
            cmbxMonth.Visible = false;
            cmbxYear.Visible = false;
            btnPay.Visible = false;
            txtCVV.Visible = false;
            orderContainer.BorderColor = Color.Gray;
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            int num = Application.OpenForms.Count;
            for (int i = 1; i < num; i++)
            {
                if (Application.OpenForms[i].Name != "loginPage" && Application.OpenForms[i].Name != "homePage")
                {
                    Application.OpenForms[i].Close();
                }
            }
            
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            confirmationBox.Visible = false;
            cover.Visible = false;
            lblConfirmation.Visible = false;
            btnYes.Visible = false;
            btnNo.Visible = false;
            rbtnCash.Visible = true;
            rbtnCustomCash.Visible = true;
            rbtnCard.Visible = true;
            rbtnCustomCard.Visible = true;
            lblCard.Visible = true;
            cmbxMonth.Visible = true;
            cmbxYear.Visible = true;
            lblCash.Visible = true;
            txtCVV.Visible = true;
            btnPay.Visible = true;
            orderContainer.BorderColor = Color.SandyBrown;
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            connection.Open();

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = connection;
            cmd.CommandText = "update userDetail set grandTotal = '"+lblGrandTotal.Text+"' where userFlag = 'true'";
            cmd.ExecuteNonQuery();

            OleDbDataAdapter da = new OleDbDataAdapter("select * from menu",connection);
            DataSet ds = new DataSet();
            da.Fill(ds);

            OleDbDataAdapter da1 = new OleDbDataAdapter("select * from userDetail", connection);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);

            string pID = "";
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                if (ds1.Tables[0].Rows[i][4].ToString() == "true")
                    pID = ds1.Tables[0].Rows[i][5].ToString();
            }

            int count = 0;
            for (int i = 0; i < 10; i++)
            {
                if (ds.Tables[0].Rows[i][4].ToString() == "true")
                    count++;
            }

            int j = 0;
            string[] price = new string[4];
            for (int i = 0; i < 10; i++)
            {
                if (ds.Tables[0].Rows[i][4].ToString() == "true")
                {
                    price[j++] = ds.Tables[0].Rows[i][2].ToString();
                }
            }

            if (count == 1)
            {
                cmd.CommandText = "update orderSuccess set item = '" + lblItem1.Text + "', qty = '" + lblQty1.Text + "', price ='" +price[0] + "' where id = '1'";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "update orderSuccess set item = ' ', qty = ' ', price = ' ' where id = '2'";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "update orderSuccess set item = ' ', qty = ' ', price = ' ' where id = '3'";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "update orderSuccess set item = ' ', qty = ' ', price = ' ' where id = '4'";
                cmd.ExecuteNonQuery();

                cmd.Connection = connection;
                cmd.CommandText = "update personalisedProfile set item1 = '" + lblItem1.Text + "', item2 = 'Muffins', item3 = 'Chamomile Tea', item4 = 'Cinnamon Roll', price1 = '" + lblPrice1.Text + "', price2 = '5.99$', price3 = '9.99$',price4 = '5.99$' where pID = '" + pID + "'";
                cmd.ExecuteNonQuery();
            }

            if (count == 2)
            {
                cmd.CommandText = "update orderSuccess set item = '" + lblItem1.Text + "', qty = '" + lblQty1.Text + "', price ='" + price[0] + "' where id = '1'";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "update orderSuccess set item = '" + lblItem2.Text + "', qty = '" + lblQty2.Text + "', price ='" + price[1] + "' where id = '2'";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "update orderSuccess set item = ' ', qty = ' ', price = ' ' where id = '3'";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "update orderSuccess set item = ' ', qty = ' ', price = ' ' where id = '4'";
                cmd.ExecuteNonQuery();

                cmd.Connection = connection;
                cmd.CommandText = "update personalisedProfile set item1 = '" + lblItem1.Text + "', item2 = '" + lblItem2.Text + "', item3 = 'Oolong Tea', item4 = 'Muffins', price1 = '" + lblPrice1.Text + "', price2 = '" + lblPrice2.Text + "', price3 = '9.99$',price4 = '5.99$' where pID = '" + pID + "'";
                cmd.ExecuteNonQuery();
            }
            
            if (count == 3)
            {
                cmd.CommandText = "update orderSuccess set item = '" + lblItem1.Text + "', qty = '" + lblQty1.Text + "', price ='" + price[0] + "' where id = '1'";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "update orderSuccess set item = '" + lblItem2.Text + "', qty = '" + lblQty2.Text + "', price ='" + price[1] + "' where id = '2'";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "update orderSuccess set item = '" + lblItem3.Text + "', qty = '" + lblQty3.Text + "', price = '" + price[2] + "' where id = '3'";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "update orderSuccess set item = ' ', qty = ' ', price = ' ' where id = '4'";
                cmd.ExecuteNonQuery();

                cmd.Connection = connection;
                cmd.CommandText = "update personalisedProfile set item1 = '" + lblItem1.Text + "', item2 = '" + lblItem2.Text + "', item3 = '" + lblItem3.Text + "', item4 = 'Chamomile Tea', price1 = '" + lblPrice1.Text + "', price2 = '" + lblPrice2.Text + "', price3 = '" + lblPrice3.Text + "',price4 = '9.99$' where pID = '" + pID + "'";
                cmd.ExecuteNonQuery();
            }

            if (count == 4)
            {
                cmd.CommandText = "update orderSuccess set item = '" + lblItem1.Text + "', qty = '" + lblQty1.Text + "', price ='" + price[0] + "' where id = '1'";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "update orderSuccess set item = '" + lblItem2.Text + "', qty = '" + lblQty2.Text + "', price ='" + price[1] + "' where id = '2'";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "update orderSuccess set item = '" + lblItem3.Text + "', qty = '" + lblQty3.Text + "', price = '" + price[2] + "' where id = '3'";
                cmd.ExecuteNonQuery();

                cmd.Connection = connection;
                cmd.CommandText = "update orderSuccess set item = '" + lblItem4.Text + "', qty = '" + lblQty4.Text + "', price = '" + price[3] + "' where id = '4'";
                cmd.ExecuteNonQuery();
            }
            connection.Close();
            orderSuccessPage osp = new orderSuccessPage();
            osp.ShowDialog();
        }
        
        private void btnQtySub1_Click(object sender, EventArgs e)
        {
            if(quantity[0] > 1)
            {
                --quantity[0];
                lblQty1.Text = quantity[0].ToString();

                if (lblItem1.Text == "Espresso Shot" || lblItem1.Text == "Americano" || lblItem1.Text == "Mocha")
                {
                    lblPrice1.Text = Convert.ToString(12.99 * quantity[0]) + '$';
                    p1 = 12.99 * quantity[0];
                }
                else if (lblItem1.Text == "Latte" || lblItem1.Text == "Cappuccinno" || lblItem1.Text == "White Mocha")
                {
                    lblPrice1.Text = Convert.ToString(14.99 * quantity[0]) + '$';
                    p1 = 14.99 * quantity[0];
                }

                else if (lblItem1.Text == "Muffins" || lblItem1.Text == "Cinnamon Roll")
                {
                    lblPrice1.Text = Convert.ToString(5.99 * quantity[0]) + '$';
                    p1 = 5.99 * quantity[0];
                }

                else if (lblItem1.Text == "Oolong Tea" || lblItem1.Text == "Chamomile Tea")
                {
                    lblPrice1.Text = Convert.ToString(9.99 * quantity[0]) + '$';
                    p1 = 9.99 * quantity[0];
                }

                setTotal();
            }
        }

        private void btnQtyAdd1_Click(object sender, EventArgs e)
        {
            ++quantity[0];
            lblQty1.Text = quantity[0].ToString();
            if (lblItem1.Text == "Espresso Shot" || lblItem1.Text == "Americano" || lblItem1.Text == "Mocha")
            {
                lblPrice1.Text = Convert.ToString(12.99 * quantity[0]) + '$';
                p1 = 12.99 * quantity[0];
            }
            else if (lblItem1.Text == "Latte" || lblItem1.Text == "Cappuccinno" || lblItem1.Text == "White Mocha")
            {
                lblPrice1.Text = Convert.ToString(14.99 * quantity[0]) + '$';
                p1 = 14.99 * quantity[0];
            }

            else if (lblItem1.Text == "Muffins" || lblItem1.Text == "Cinnamon Roll")
            {
                lblPrice1.Text = Convert.ToString(5.99 * quantity[0]) + '$';
                p1 = 5.99 * quantity[0];
            }

            else if (lblItem1.Text == "Oolong Tea" || lblItem1.Text == "Chamomile Tea")
            {
                lblPrice1.Text = Convert.ToString(9.99 * quantity[0]) + '$';
                p1 = 9.99 * quantity[0];
            }

            setTotal();
        }

        private void btnQtySub2_Click(object sender, EventArgs e)
        {
            if (quantity[1] > 1)
            {
                --quantity[1];
                lblQty2.Text = quantity[1].ToString();
                if (lblItem2.Text == "Espresso Shot" || lblItem2.Text == "Americano" || lblItem2.Text == "Mocha")
                {
                    lblPrice2.Text = Convert.ToString(12.99 * quantity[1]) + '$';
                    p2 = 12.99 * quantity[1];
                }
                else if (lblItem2.Text == "Latte" || lblItem2.Text == "Cappuccinno" || lblItem2.Text == "White Mocha")
                {
                    lblPrice2.Text = Convert.ToString(14.99 * quantity[1]) + '$';
                    p2 = 14.99 * quantity[1];
                }

                else if (lblItem2.Text == "Muffins" || lblItem2.Text == "Cinnamon Roll")
                {
                    lblPrice2.Text = Convert.ToString(5.99 * quantity[1]) + '$';
                    p2 = 5.99 * quantity[1];
                }

                else if (lblItem2.Text == "Oolong Tea" || lblItem2.Text == "Chamomile Tea")
                {
                    lblPrice2.Text = Convert.ToString(9.99 * quantity[1]) + '$';
                    p2 = 9.99 * quantity[1];
                }

                setTotal();
            }
        }

        private void btnQtyAdd2_Click(object sender, EventArgs e)
        {
            ++quantity[1];
            lblQty2.Text = quantity[1].ToString();

            if (lblItem2.Text == "Espresso Shot" || lblItem2.Text == "Americano" || lblItem2.Text == "Mocha")
            {
                lblPrice2.Text = Convert.ToString(12.99 * quantity[1]) + '$';
                p2 = 12.99 * quantity[1];
            }
            else if (lblItem2.Text == "Latte" || lblItem2.Text == "Cappuccinno" || lblItem2.Text == "White Mocha")
            {
                lblPrice2.Text = Convert.ToString(14.99 * quantity[1]) + '$';
                p2 = 14.99 * quantity[1];
            }

            else if (lblItem2.Text == "Muffins" || lblItem2.Text == "Cinnamon Roll")
            {
                lblPrice2.Text = Convert.ToString(5.99 * quantity[1]) + '$';
                p2 = 5.99 * quantity[1];
            }

            else if (lblItem2.Text == "Oolong Tea" || lblItem2.Text == "Chamomile Tea")
            {
                lblPrice2.Text = Convert.ToString(9.99 * quantity[1]) + '$';
                p2 = 9.99 * quantity[1];
            }

            setTotal();
        }

        private void btnQtySub3_Click(object sender, EventArgs e)
        {
            if (quantity[2] > 1)
            {
                --quantity[2];
                lblQty3.Text = quantity[2].ToString();

                if (lblItem3.Text == "Espresso Shot" || lblItem3.Text == "Americano" || lblItem3.Text == "Mocha")
                {
                    lblPrice3.Text = Convert.ToString(12.99 * quantity[2]) + '$';
                    p3 = 12.99 * quantity[2];
                }
                else if (lblItem3.Text == "Latte" || lblItem3.Text == "Cappuccinno" || lblItem3.Text == "White Mocha")
                {
                    lblPrice3.Text = Convert.ToString(14.99 * quantity[2]) + '$';
                    p3 = 14.99 * quantity[2];
                }

                else if (lblItem3.Text == "Muffins" || lblItem3.Text == "Cinnamon Roll")
                {
                    lblPrice3.Text = Convert.ToString(5.99 * quantity[2]) + '$';
                    p3 = 5.99 * quantity[2];
                }

                else if (lblItem3.Text == "Oolong Tea" || lblItem3.Text == "Chamomile Tea")
                {
                    lblPrice3.Text = Convert.ToString(9.99 * quantity[2]) + '$';
                    p3 = 9.99 * quantity[2];
                }
            }

            setTotal();
        }

        private void btnQtyAdd3_Click(object sender, EventArgs e)
        {
            ++quantity[2];
            lblQty3.Text = quantity[2].ToString();

            if (lblItem3.Text == "Espresso Shot" || lblItem3.Text == "Americano" || lblItem3.Text == "Mocha")
            {
                lblPrice3.Text = Convert.ToString(12.99 * quantity[2]) + '$';
                p3 = 12.99 * quantity[2];
            }
            else if (lblItem3.Text == "Latte" || lblItem3.Text == "Cappuccinno" || lblItem3.Text == "White Mocha")
            {
                lblPrice3.Text = Convert.ToString(14.99 * quantity[2]) + '$';
                p3 = 14.99 * quantity[2];
            }

            else if (lblItem3.Text == "Muffins" || lblItem3.Text == "Cinnamon Roll")
            {
                lblPrice3.Text = Convert.ToString(5.99 * quantity[2]) + '$';
                p3 = 5.99 * quantity[2];
            }

            else if (lblItem3.Text == "Oolong Tea" || lblItem3.Text == "Chamomile Tea")
            {
                lblPrice3.Text = Convert.ToString(9.99 * quantity[2]) + '$';
                p3 = 9.99 * quantity[2];
            }

            setTotal();
        }

        private void btnQtySub4_Click(object sender, EventArgs e)
        {
            if (quantity[3] > 1)
            {
                --quantity[3];
                lblQty4.Text = quantity[3].ToString();

                if (lblItem4.Text == "Espresso Shot" || lblItem4.Text == "Americano" || lblItem4.Text == "Mocha")
                {
                    lblPrice4.Text = Convert.ToString(12.99 * quantity[3]) + '$';
                    p4 = 12.99 * quantity[3];
                }
                else if (lblItem4.Text == "Latte" || lblItem4.Text == "Cappuccinno" || lblItem4.Text == "White Mocha")
                {
                    lblPrice4.Text = Convert.ToString(14.99 * quantity[3]) + '$';
                    p4 = 14.99 * quantity[3];
                }

                else if (lblItem4.Text == "Muffins" || lblItem4.Text == "Cinnamon Roll")
                {
                    lblPrice4.Text = Convert.ToString(5.99 * quantity[3]) + '$';
                    p4 = 5.99 * quantity[3];
                }

                else if (lblItem4.Text == "Oolong Tea" || lblItem4.Text == "Chamomile Tea")
                {
                    lblPrice4.Text = Convert.ToString(9.99 * quantity[3]) + '$';
                    p4 = 9.99 * quantity[3];
                }

                setTotal();
            }
        }

        private void btnQtyAdd4_Click(object sender, EventArgs e)
        {
            quantity[3]++;
            lblQty4.Text = quantity[3].ToString();

            if (lblItem4.Text == "Espresso Shot" || lblItem4.Text == "Americano" || lblItem4.Text == "Mocha")
            {
                lblPrice4.Text = Convert.ToString(12.99 * quantity[3]) + '$';
                p4 = 12.99 * quantity[3];
            }
            else if (lblItem4.Text == "Latte" || lblItem4.Text == "Cappuccinno" || lblItem4.Text == "White Mocha")
            {
                lblPrice4.Text = Convert.ToString(14.99 * quantity[3]) + '$';
                p4 = 14.99 * quantity[3];
            }

            else if (lblItem4.Text == "Muffins" || lblItem4.Text == "Cinnamon Roll")
            {
                lblPrice4.Text = Convert.ToString(5.99 * quantity[3]) + '$';
                p4 = 5.99 * quantity[3];
            }

            else if (lblItem4.Text == "Oolong Tea" || lblItem4.Text == "Chamomile Tea")
            {
                lblPrice4.Text = Convert.ToString(9.99 * quantity[3]) + '$';
                p4 = 9.99 * quantity[3];
            }

            setTotal();
        }
    }
}
