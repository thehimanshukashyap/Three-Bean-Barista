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
    public partial class Feedbackcs : Form
    {
        public Feedbackcs()
        {
            InitializeComponent();
        }

        OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/This PC/Three Bean Barista/loginDB.accdb");
        int qRating;
        int sRating;
        int pickVar = 0;

        
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from userDetail", connection);
            DataSet ds = new DataSet();
            da.Fill(ds);

            
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i][4].ToString() == "true")
                {
                    pickVar = i;
                    break;
                }
            }

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = connection;
            cmd.CommandText = "update userDetail set feedbackQuality = " + qRating + " , feedbackService = " + sRating + " where userName = '" + ds.Tables[0].Rows[pickVar][1].ToString() + "'";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Feedback successfully stored");

            OleDbCommand cmd1 = new OleDbCommand();
            cmd1.Connection = connection;
            cmd1.CommandText = "update menu set flag ='false'";
            cmd1.ExecuteNonQuery();

            int num = Application.OpenForms.Count;
            for (int i = 1; i < num; i++)
            {
                if (Application.OpenForms[i].Name != "loginPage" && Application.OpenForms[i].Name != "homePage")
                {
                    Application.OpenForms[i].Close();
                }
            }

            this.Close();
            connection.Close();
        }

        private void qRate1_Click(object sender, EventArgs e)
        {
            qRate1.BackgroundImageLayout = ImageLayout.Stretch;
            qRate2.BackgroundImageLayout = ImageLayout.Tile;
            qRate3.BackgroundImageLayout = ImageLayout.Tile;
            qRate4.BackgroundImageLayout = ImageLayout.Tile;
            qRate5.BackgroundImageLayout = ImageLayout.Tile;
            qRating = 1;
        }

        private void qRate2_Click(object sender, EventArgs e)
        {
            qRate1.BackgroundImageLayout = ImageLayout.Stretch;
            qRate2.BackgroundImageLayout = ImageLayout.Stretch;
            qRate3.BackgroundImageLayout = ImageLayout.Tile;
            qRate4.BackgroundImageLayout = ImageLayout.Tile;
            qRate5.BackgroundImageLayout = ImageLayout.Tile;
            qRating = 2;
        }

        private void qRate3_Click(object sender, EventArgs e)
        {
            qRate1.BackgroundImageLayout = ImageLayout.Stretch;
            qRate2.BackgroundImageLayout = ImageLayout.Stretch;
            qRate3.BackgroundImageLayout = ImageLayout.Stretch;
            qRate4.BackgroundImageLayout = ImageLayout.Tile;
            qRate5.BackgroundImageLayout = ImageLayout.Tile;
            qRating = 3;
            
        }

        private void qRate4_Click(object sender, EventArgs e)
        {
            qRate1.BackgroundImageLayout = ImageLayout.Stretch;
            qRate2.BackgroundImageLayout = ImageLayout.Stretch;
            qRate3.BackgroundImageLayout = ImageLayout.Stretch;
            qRate4.BackgroundImageLayout = ImageLayout.Stretch;
            qRate5.BackgroundImageLayout = ImageLayout.Tile;
            qRating = 4;
        }

        private void qRate5_Click(object sender, EventArgs e)
        {
            qRate1.BackgroundImageLayout = ImageLayout.Stretch;
            qRate2.BackgroundImageLayout = ImageLayout.Stretch;
            qRate3.BackgroundImageLayout = ImageLayout.Stretch;
            qRate4.BackgroundImageLayout = ImageLayout.Stretch;
            qRate5.BackgroundImageLayout = ImageLayout.Stretch;
            qRating = 5;
        }

        private void sRate1_Click(object sender, EventArgs e)
        {
            sRate1.BackgroundImageLayout = ImageLayout.Stretch;
            sRate2.BackgroundImageLayout = ImageLayout.Tile;
            sRate3.BackgroundImageLayout = ImageLayout.Tile;
            sRate4.BackgroundImageLayout = ImageLayout.Tile;
            sRate5.BackgroundImageLayout = ImageLayout.Tile;
            sRating = 1;
        }

        private void sRate2_Click(object sender, EventArgs e)
        {
            sRate1.BackgroundImageLayout = ImageLayout.Stretch;
            sRate2.BackgroundImageLayout = ImageLayout.Stretch;
            sRate3.BackgroundImageLayout = ImageLayout.Tile;
            sRate4.BackgroundImageLayout = ImageLayout.Tile;
            sRate5.BackgroundImageLayout = ImageLayout.Tile;
            sRating = 2;   
        }

        private void sRate3_Click(object sender, EventArgs e)
        {
            sRate1.BackgroundImageLayout = ImageLayout.Stretch;
            sRate2.BackgroundImageLayout = ImageLayout.Stretch;
            sRate3.BackgroundImageLayout = ImageLayout.Stretch;
            sRate4.BackgroundImageLayout = ImageLayout.Tile;
            sRate5.BackgroundImageLayout = ImageLayout.Tile;
            sRating = 3;
        }

        private void sRate4_Click(object sender, EventArgs e)
        {
            sRate1.BackgroundImageLayout = ImageLayout.Stretch;
            sRate2.BackgroundImageLayout = ImageLayout.Stretch;
            sRate3.BackgroundImageLayout = ImageLayout.Stretch;
            sRate4.BackgroundImageLayout = ImageLayout.Stretch;
            sRate5.BackgroundImageLayout = ImageLayout.Tile;
            sRating = 4;
        }

        private void sRate5_Click(object sender, EventArgs e)
        {
            sRate1.BackgroundImageLayout = ImageLayout.Stretch;
            sRate2.BackgroundImageLayout = ImageLayout.Stretch;
            sRate3.BackgroundImageLayout = ImageLayout.Stretch;
            sRate4.BackgroundImageLayout = ImageLayout.Stretch;
            sRate5.BackgroundImageLayout = ImageLayout.Stretch;
            sRating = 5;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            
        }

        private void Feedbackcs_Load(object sender, EventArgs e)
        {

        }


    }
}
