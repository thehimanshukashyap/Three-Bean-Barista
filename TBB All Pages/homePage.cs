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
    public partial class homePage : Form
    {
        public homePage()
        {
            InitializeComponent();
        }

        OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/This PC/Three Bean Barista/loginDB.accdb");

        private void homePage_Load(object sender, EventArgs e)
        {
            connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from userDetail",connection);
            DataSet ds = new DataSet();
            da.Fill(ds);

            //the notification rectangle is invisible and when the user clicks the items the notification icon must appear.
            notification.Visible = false;
            lblAddedToCart.Visible = false;
            btnNotiClose.Visible = false;
            btnNotiClose.Enabled = false;
            rectangleShape1.Visible = false;
            btnOrder.Visible = false;
            remove1.Visible = false;
            remove2.Visible = false;
            remove3.Visible = false;
            remove4.Visible = false;

            int pickVar = 0;
            //to print the name of the person that has successfully logged in.
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i][4].ToString() == "true")
                {
                    lblName.Text = ds.Tables[0].Rows[i][1].ToString();
                    pickVar = i;
                    break;
                }
            }

            OleDbDataAdapter da1 = new OleDbDataAdapter("select * from personalisedProfile", connection);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);

            //to print the personalised items that the profile has stored in the database.
            string foreignKey = ds.Tables[0].Rows[pickVar][5].ToString();

            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                if (foreignKey == ds1.Tables[0].Rows[i][0].ToString())
                {
                    //according to the personalisedProfile table in the database
                    lblItem1.Text = ds1.Tables[0].Rows[i][1].ToString();
                    lblItem2.Text = ds1.Tables[0].Rows[i][2].ToString();
                    lblItem3.Text = ds1.Tables[0].Rows[i][3].ToString();
                    lblItem4.Text = ds1.Tables[0].Rows[i][4].ToString();
                    lblPrice1.Text = ds1.Tables[0].Rows[i][5].ToString();
                    lblPrice2.Text = ds1.Tables[0].Rows[i][6].ToString();
                    lblPrice3.Text = ds1.Tables[0].Rows[i][7].ToString();
                    lblPrice4.Text = ds1.Tables[0].Rows[i][8].ToString();

                    //For the first icon
                    if (lblItem1.Text == "Espresso Shot")
                    {
                        icon1.BackgroundImage = Image.FromFile("D:/This PC/Three Bean Barista/components/aerialView3.png");
                        icon1.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else if (lblItem1.Text == "Latte")
                    {
                        icon1.BackgroundImage = Image.FromFile("D:/This PC/Three Bean Barista/components/aerialView4.png");
                        icon1.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else if (lblItem1.Text == "Americano")
                    {
                        icon1.BackgroundImage = Image.FromFile("D:/This PC/Three Bean Barista/components/aerialView5.png");
                        icon1.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else if (lblItem1.Text == "Cappuccinno")
                    {
                        icon1.BackgroundImage = Image.FromFile("D:/This PC/Three Bean Barista/components/aerialView6.png");
                        icon1.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else if (lblItem1.Text == "Mocha")
                    {
                        icon1.BackgroundImage = Image.FromFile("D:/This PC/Three Bean Barista/components/aerialView7.png");
                        icon1.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else if(lblItem1.Text == "White Mocha")
                    {
                        icon1.BackgroundImage = Image.FromFile("D:/This PC/Three Bean Barista/components/aerialView8.png");
                        icon1.BackgroundImageLayout = ImageLayout.Stretch;
                    }

                    else if (lblItem1.Text == "Oolong Tea")
                    {
                        icon1.BackgroundImage = Image.FromFile("D:/This PC/Three Bean Barista/components/aerialView9.png");
                        icon1.BackgroundImageLayout = ImageLayout.Stretch;
                    }

                    else if (lblItem1.Text == "Chamomile Tea")
                    {
                        icon1.BackgroundImage = Image.FromFile("D:/This PC/Three Bean Barista/components/aerialView10.png");
                        icon1.BackgroundImageLayout = ImageLayout.Stretch;
                    }

                    else if (lblItem1.Text == "Muffins")
                    {
                        icon1.BackgroundImage = Image.FromFile("D:/This PC/Three Bean Barista/components/muffins.jpg");
                        icon1.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else if (lblItem1.Text == "Cinnamon Roll")
                    {
                        icon1.BackgroundImage = Image.FromFile("D:/This PC/Three Bean Barista/components/CinnamonRoll.jpg");
                        icon1.BackgroundImageLayout = ImageLayout.Stretch;
                    }

                    //  for the second icon
                    if (lblItem2.Text == "Espresso")
                    {
                        icon2.BackgroundImage = Image.FromFile("D:/This PC/Three Bean Barista/components/aerialView3.png");
                        icon2.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else if (lblItem2.Text == "Latte")
                    {
                        icon2.BackgroundImage = Image.FromFile("D:/This PC/Three Bean Barista/components/aerialView4.png");
                        icon2.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else if (lblItem2.Text == "Americano")
                    {
                        icon2.BackgroundImage = Image.FromFile("D:/This PC/Three Bean Barista/components/aerialView5.png");
                        icon2.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else if (lblItem2.Text == "Cappuccinno")
                    {
                        icon2.BackgroundImage = Image.FromFile("D:/This PC/Three Bean Barista/components/aerialView6.png");
                        icon2.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else if (lblItem2.Text == "Mocha")
                    {
                        icon2.BackgroundImage = Image.FromFile("D:/This PC/Three Bean Barista/components/aerialView7.png");
                        icon2.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else if (lblItem2.Text == "White Mocha")
                    {
                        icon2.BackgroundImage = Image.FromFile("D:/This PC/Three Bean Barista/components/aerialView8.png");
                        icon2.BackgroundImageLayout = ImageLayout.Stretch;
                    }

                    else if (lblItem2.Text == "Oolong Tea")
                    {
                        icon2.BackgroundImage = Image.FromFile("D:/This PC/Three Bean Barista/components/aerialView9.png");
                        icon2.BackgroundImageLayout = ImageLayout.Stretch;
                    }

                    else if (lblItem2.Text == "Chamomile Tea")
                    {
                        icon2.BackgroundImage = Image.FromFile("D:/This PC/Three Bean Barista/components/aerialView10.png");
                        icon2.BackgroundImageLayout = ImageLayout.Stretch;
                    }

                    else if (lblItem2.Text == "Muffins")
                    {
                        icon2.BackgroundImage = Image.FromFile("D:/This PC/Three Bean Barista/components/muffins.jpg");
                        icon2.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else if (lblItem2.Text == "Cinnamon Roll")
                    {
                        icon2.BackgroundImage = Image.FromFile("D:/This PC/Three Bean Barista/components/CinnamonRoll.jpg");
                        icon2.BackgroundImageLayout = ImageLayout.Stretch;
                    }

                    // for the third icon
                    if (lblItem3.Text == "Espresso Shot")
                    {
                        icon3.BackgroundImage = Image.FromFile("D:/This PC/Three Bean Barista/components/aerialView3.png");
                        icon3.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else if (lblItem3.Text == "Latte")
                    {
                        icon3.BackgroundImage = Image.FromFile("D:/This PC/Three Bean Barista/components/aerialView4.png");
                        icon3.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else if (lblItem3.Text == "Americano")
                    {
                        icon3.BackgroundImage = Image.FromFile("D:/This PC/Three Bean Barista/components/aerialView5.png");
                        icon3.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else if (lblItem3.Text == "Cappuccinno")
                    {
                        icon3.BackgroundImage = Image.FromFile("D:/This PC/Three Bean Barista/components/aerialView6.png");
                        icon3.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else if (lblItem3.Text == "Mocha")
                    {
                        icon3.BackgroundImage = Image.FromFile("D:/This PC/Three Bean Barista/components/aerialView7.png");
                        icon3.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else if (lblItem1.Text == "White Mocha")
                    {
                        icon3.BackgroundImage = Image.FromFile("D:/This PC/Three Bean Barista/components/aerialView8.png");
                        icon3.BackgroundImageLayout = ImageLayout.Stretch;
                    }

                    else if (lblItem3.Text == "Oolong Tea")
                    {
                        icon3.BackgroundImage = Image.FromFile("D:/This PC/Three Bean Barista/components/aerialView9.png");
                        icon3.BackgroundImageLayout = ImageLayout.Stretch;
                    }

                    else if (lblItem3.Text == "Chamomile Tea")
                    {
                        icon3.BackgroundImage = Image.FromFile("D:/This PC/Three Bean Barista/components/aerialView10.png");
                        icon3.BackgroundImageLayout = ImageLayout.Stretch;
                    }

                    else if (lblItem3.Text == "Muffins")
                    {
                        icon3.BackgroundImage = Image.FromFile("D:/This PC/Three Bean Barista/components/muffins.jpg");
                        icon3.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else if (lblItem3.Text == "Cinnamon Roll")
                    {
                        icon3.BackgroundImage = Image.FromFile("D:/This PC/Three Bean Barista/components/CinnamonRoll.jpg");
                        icon3.BackgroundImageLayout = ImageLayout.Stretch;
                    }

                    //for the fourth icon

                    if (lblItem4.Text == "Espresso Shot")
                    {
                        icon4.BackgroundImage = Image.FromFile("D:/This PC/Three Bean Barista/components/aerialView3.png");
                        icon4.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else if (lblItem4.Text == "Latte")
                    {
                        icon4.BackgroundImage = Image.FromFile("D:/This PC/Three Bean Barista/components/aerialView4.png");
                        icon4.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else if (lblItem4.Text == "Americano")
                    {
                        icon4.BackgroundImage = Image.FromFile("D:/This PC/Three Bean Barista/components/aerialView5.png");
                        icon4.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else if (lblItem4.Text == "Cappuccinno")
                    {
                        icon4.BackgroundImage = Image.FromFile("D:/This PC/Three Bean Barista/components/aerialView6.png");
                        icon4.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else if (lblItem4.Text == "Mocha")
                    {
                        icon4.BackgroundImage = Image.FromFile("D:/This PC/Three Bean Barista/components/aerialView7.png");
                        icon4.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else if (lblItem1.Text == "White Mocha")
                    {
                        icon4.BackgroundImage = Image.FromFile("D:/This PC/Three Bean Barista/components/aerialView8.png");
                        icon4.BackgroundImageLayout = ImageLayout.Stretch;
                    }

                    else if (lblItem4.Text == "Oolong Tea")
                    {
                        icon4.BackgroundImage = Image.FromFile("D:/This PC/Three Bean Barista/components/aerialView9.png");
                        icon4.BackgroundImageLayout = ImageLayout.Stretch;
                    }

                    else if (lblItem4.Text == "Chamomile Tea")
                    {
                        icon4.BackgroundImage = Image.FromFile("D:/This PC/Three Bean Barista/components/aerialView10.png");
                        icon4.BackgroundImageLayout = ImageLayout.Stretch;
                    }

                    else if (lblItem4.Text == "Muffins")
                    {
                        icon4.BackgroundImage = Image.FromFile("D:/This PC/Three Bean Barista/components/muffins.jpg");
                        icon4.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else if (lblItem4.Text == "Cinnamon Roll")
                    {
                        icon4.BackgroundImage = Image.FromFile("D:/This PC/Three Bean Barista/components/CinnamonRoll.jpg");
                        icon4.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                }
            }
            
            connection.Close();
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from userDetail", connection);
            DataSet ds = new DataSet();
            da.Fill(ds);

            //when the user signs out the value of userFlag must be false.
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = connection;
            cmd.CommandText = "update userDetail set userFlag = 'false', mID1 = '', mID2 = '', mID3 = '', mID4 = '', grandTotal = ''";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "delete from customCoffee where id = '1'";
            cmd.ExecuteNonQuery();
            connection.Close();
            this.Close();
        }

        //Here all the icons when clicked, the items must be added to the cart and the menu button must be hidden.
        //The item which is clicked the menu flag must turn to true.
        int[] count = new int[4]{0,0,0,0};
        int cnt = 0;
        private void icon1_Click(object sender, EventArgs e)
        {
            if (count[0] == 0)
            {
                remove1.Visible = true;
                ++count[0];
                ++cnt;
                if (cnt <= 4)
                {
                    notification.Visible = true;
                    lblAddedToCart.Visible = true;
                    btnNotiClose.Visible = true;
                    btnNotiClose.Enabled = true;
                    btnMenu.Visible = false;
                    rectangleShape1.Visible = true;
                    btnOrder.Visible = true;

                    connection.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "update menu set flag = 'true' where item = '"+lblItem1.Text+"'";
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                if (cnt == 4)
                    MessageBox.Show("Max Capacity Reached.");
            }
        }

        private void icon2_Click(object sender, EventArgs e)
        {
            if (count[1] == 0)
            {
                remove2.Visible = true;
                ++count[1];
                cnt++;
                if (cnt <= 4)
                {
                    notification.Visible = true;
                    lblAddedToCart.Visible = true;
                    btnNotiClose.Visible = true;
                    btnNotiClose.Enabled = true;
                    btnMenu.Visible = false;
                    rectangleShape1.Visible = true;
                    btnOrder.Visible = true;

                    connection.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "update menu set flag = 'true' where item = '" + lblItem2.Text + "'";
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                if(cnt == 4)
                    MessageBox.Show("Max Capacity Reached");
            }
        }

        private void icon3_Click(object sender, EventArgs e)
        {
            if (count[2] == 0)
            {
                remove3.Visible = true;
                ++count[2];
                ++cnt;
                if (cnt <= 4)
                {
                    notification.Visible = true;
                    lblAddedToCart.Visible = true;
                    btnNotiClose.Visible = true;
                    btnNotiClose.Enabled = true;
                    btnMenu.Visible = false;
                    rectangleShape1.Visible = true;
                    btnOrder.Visible = true;

                    connection.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "update menu set flag = 'true' where item = '" + lblItem3.Text + "'";
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                if(cnt == 4)
                    MessageBox.Show("Max Capacity Reached.");
            }
        }

        private void icon4_Click(object sender, EventArgs e)
        {
            if (count[3] == 0)
            {
                remove4.Visible = true;
                ++count[3];
                ++cnt;
                if (cnt <= 4)
                {
                    notification.Visible = true;
                    lblAddedToCart.Visible = true;
                    btnNotiClose.Visible = true;
                    btnNotiClose.Enabled = true;
                    btnMenu.Visible = false;
                    rectangleShape1.Visible = true;
                    btnOrder.Visible = true;

                    connection.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "update menu set flag = 'true' where item = '" + lblItem4.Text + "'";
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                if (cnt == 4)
                     MessageBox.Show("Max Capacity Reached");
            }
        }

        private void btnNotiClose_Click(object sender, EventArgs e)
        {
            notification.Visible = false;
            lblAddedToCart.Visible = false;
            btnNotiClose.Visible = false;
            btnNotiClose.Enabled = false;
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            menuPage mp = new menuPage();
            mp.ShowDialog();
        }

        private void btnFeedback_Click(object sender, EventArgs e)
        {
            Feedbackcs fb = new Feedbackcs();
            fb.ShowDialog();
        }

        private void btnAboutUs_Click(object sender, EventArgs e)
        {
            aboutUs au = new aboutUs();
            au.ShowDialog();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            orderPage op = new orderPage();
            op.ShowDialog();
        }


        //when the remove link label is linked the items must be removed from the cart and the count must reduced.
        private void remove1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            --count[0];
            --cnt;
            remove1.Visible = false;
            notification.Visible = false;
            btnNotiClose.Visible = false;
            lblAddedToCart.Visible = false;

            connection.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = connection;
            cmd.CommandText = "update menu set flag = 'false' where name = '" + lblItem1.Text + "'";
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        private void remove2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            --count[1];
            --cnt;
            remove2.Visible = false;
            notification.Visible = false;
            btnNotiClose.Visible = false;
            lblAddedToCart.Visible = false;

            connection.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = connection;
            cmd.CommandText = "update menu set flag = 'false' where name = '" + lblItem2.Text + "'";
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        private void remove3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            --count[2];
            --cnt;
            remove3.Visible = false;
            notification.Visible = false;
            btnNotiClose.Visible = false;
            lblAddedToCart.Visible = false;

            connection.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = connection;
            cmd.CommandText = "update menu set flag = 'false' where name = '" + lblItem3.Text + "'";
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        private void remove4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            --count[3];
            --cnt;
            remove4.Visible = false;
            notification.Visible = false;
            btnNotiClose.Visible = false;
            lblAddedToCart.Visible = false;

            connection.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = connection;
            cmd.CommandText = "update menu set flag = 'false' where item = '" + lblItem4.Text + "'";
            cmd.ExecuteNonQuery();
            connection.Close();
        }        
    }
}
