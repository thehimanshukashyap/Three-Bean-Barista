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
    public partial class loginPage : Form
    {
        public loginPage()
        {
            InitializeComponent();
        }

        string[] profile = new string[4];

        OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/This PC/Three Bean Barista/loginDB.accdb");
        bool flag = false;

        private void lblForgotPwd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // When clicked the recovery username and phone no. is visible and the other basic login labels and textboxes are hidden.
             
            lblRecoverUser.Visible = true;
            lblRecoverPhone.Visible = true;
            txtPhoneNo.Visible = true;
            txtRecoverUser.Visible = true;
            btnUser.Visible = true;
            lblUserName.Visible = false;
            lblPhoneNo.Visible = false;
            lblPassword.Visible = false;
            txtUserName.Visible = false;
            txtUserName.Enabled = false;
            txtPassword.Visible = false;
            txtPassword.Enabled = false;
            lblForgotPwd.Visible = false;
        }

        private void loginPage_Load(object sender, EventArgs e)
        {
            // When the page is loaded, the recovery username and phone are hidden.

            lblRecoverUser.Visible = false;
            lblRecoverPhone.Visible = false;
            txtRecoverUser.Visible = false;
            btnUser.Visible = false;

            txtSignPassword.Enabled = false;
            txtSignPassword.Text = "";
            txtSignReEnter.Enabled = false;
            txtSignReEnter.Text = "";
            txtSignPhone.Enabled = false;
            txtSignPhone.Text = "";
            btnLogin.Visible = false;
            btnSignup.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {          
            // while closing the application the userFlag column in the database must be turned to false becuase it shows that no user is logged in.
            connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from userDetail",connection);
            DataSet ds = new DataSet();
            da.Fill(ds);

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = connection;
            cmd.CommandText = "update userDetail set userFlag = 'false'";
            cmd.ExecuteNonQuery();

            connection.Close();
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from userDetail", connection);
            DataSet ds = new DataSet();
            da.Fill(ds);

            //When the User is in login mode the labels and textboxes of normal Login are visible and when not the recovery user name and phone no. are visible.
            // The basic login is turned on.
            if (lblUserName.Visible == true && lblPassword.Visible == true && lblPhoneNo.Visible == true)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (txtUserName.Text == ds.Tables[0].Rows[i][1].ToString() && txtPassword.Text == ds.Tables[0].Rows[i][2].ToString() && txtPhoneNo.Text == ds.Tables[0].Rows[i][3].ToString())
                    {
                        flag = true;
                        //here the flag determines that the user has logged in successfully
                        
                        OleDbCommand cmd = new OleDbCommand();
                        cmd.Connection = connection;
                        cmd.CommandText = "update userDetail set userFlag = 'true' where userID = '" + ds.Tables[0].Rows[i][0].ToString()+"'";
                        cmd.ExecuteNonQuery();
                        // after loggin in the user in the database must be logged in so the userFlag is set to true for the logged person.
                    }
                }
            }

            // if the recovery mode of login is turned on.
            if(txtRecoverUser.Visible == true && txtPhoneNo.Visible == true)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (txtRecoverUser.Text == ds.Tables[0].Rows[i][1].ToString() && txtPhoneNo.Text == ds.Tables[0].Rows[i][3].ToString())
                    {
                        flag = true;

                        OleDbCommand cmd = new OleDbCommand();
                        cmd.Connection = connection;
                        cmd.CommandText = "update userDetail set userFlag = 'true' where userID = '" + ds.Tables[0].Rows[i][0].ToString()+"'";
                        cmd.ExecuteNonQuery();
                        // Same as normal login but for the recovered user.
                    }
                }
            }

            // If the user is successfully logged in.
            if (flag == true)
            {
                MessageBox.Show("Login.Successfull");
                // After successfully logging in the Home page must be loaded.
                homePage hp = new homePage();
                hp.ShowDialog();
            }
            else
                MessageBox.Show("Invalid.User");    //Invalid user condition.

            flag = false;

            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void rbtnLogin_Click(object sender, EventArgs e)
        {
            //When the user clicks on the login radio button then the contents of login must appear and the sign uo contents must be enabled or invisible.
            btnLogin.Visible = true;
            rbtnLogin.BackColor = Color.Black;
            rbtnSignup.BackColor = Color.Gray;
            btnLogin.BackColor = Color.SaddleBrown;
            btnSignup.BackColor = Color.Black;
            txtSignUser.Enabled = false;
            txtSignUser.Text = "";
            txtSignPassword.Enabled = false;
            txtSignPassword.Text = "";
            txtSignReEnter.Enabled = false;
            txtSignReEnter.Text = "";
            txtSignPhone.Enabled = false;
            txtSignPhone.Text = "";
            txtUserName.Enabled = true;
            txtUserName.Text = "";
            txtPassword.Enabled = true;
            txtPassword.Text = "";
            txtPhoneNo.Enabled = true;
            txtPhoneNo.Text = "";
        }

        private void rbtnSignup_Click(object sender, EventArgs e)
        {
            //It is similarly to the login radio button, in this sign up contents are visible and login contents are hidden.
            btnSignup.Visible = true;
            btnSignup.BackColor = Color.SaddleBrown;
            rbtnSignup.BackColor = Color.Black;
            btnLogin.BackColor = Color.Gray;
            rbtnLogin.BackColor = Color.Gray;
            txtUserName.Enabled = false;
            txtUserName.Text = "";
            txtPassword.Enabled = false;
            txtPassword.Text = "";
            txtPhoneNo.Enabled = false;
            txtPhoneNo.Text = "";
            txtSignUser.Enabled = true;
            txtSignUser.Text = "";
            txtSignPassword.Enabled = true;
            txtSignPassword.Text = "";
            txtSignReEnter.Enabled = true;
            txtSignReEnter.Text = "";
            txtSignPhone.Enabled = true;
            txtSignPhone.Text = "";
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            //Here the new user is automatically stored in the database for furthur logins.
            connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from userDetail",connection);
            DataSet ds = new DataSet();
            da.Fill(ds);

            int count = ds.Tables[0].Rows.Count + 1;
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = connection;

            if (txtSignPassword.Text == txtSignReEnter.Text)
            {
                cmd.CommandText = "insert into userDetail (userID,userName,userPassword,userPhone,userFlag,pID) values('" + count + "','" + txtSignUser.Text + "','" + txtSignPassword.Text + "','" + txtSignPhone.Text + "','true','2')";
                cmd.ExecuteNonQuery();

                MessageBox.Show("Sign up.Successfull");
                // After successfully logging in the Home page must be loaded.
                homePage hp = new homePage();
                hp.ShowDialog();
            }
            connection.Close();
        }
    }
}
