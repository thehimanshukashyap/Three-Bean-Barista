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
    public partial class customCoffee : Form
    {
        public customCoffee()
        {
            InitializeComponent();
        }

        OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/This PC/Three Bean Barista/loginDB.accdb");
        string coffeeBeans = "";
        string roastType = "";
        string grindType = "";

        private void rbtnArabica_Click(object sender, EventArgs e)
        {
            rbtnArabica.BackgroundImageLayout = ImageLayout.Stretch;
            rbtnRobusta.BackgroundImageLayout = ImageLayout.Tile;
            rbtnLiberica.BackgroundImageLayout = ImageLayout.Tile;
            coffeeBeans = "Arabica";
        }

        private void rbtnRobusta_Click(object sender, EventArgs e)
        {
            rbtnArabica.BackgroundImageLayout = ImageLayout.Tile;
            rbtnRobusta.BackgroundImageLayout = ImageLayout.Stretch;
            rbtnLiberica.BackgroundImageLayout = ImageLayout.Tile;
            coffeeBeans = "Robusta";
        }

        private void rbtnLiberica_Click(object sender, EventArgs e)
        {
            rbtnArabica.BackgroundImageLayout = ImageLayout.Tile;
            rbtnRobusta.BackgroundImageLayout = ImageLayout.Tile;
            rbtnLiberica.BackgroundImageLayout = ImageLayout.Stretch;
            coffeeBeans = "Liberica";
        }

        private void rbtnLight_Click(object sender, EventArgs e)
        {
            rbtnLight.BackgroundImageLayout = ImageLayout.Stretch;
            rbtnMediumR.BackgroundImageLayout = ImageLayout.Tile;
            rbtnDark.BackgroundImageLayout = ImageLayout.Tile;
            roastType = "Light";
        }

        private void rbtnMediumR_Click(object sender, EventArgs e)
        {
            rbtnLight.BackgroundImageLayout = ImageLayout.Tile;
            rbtnMediumR.BackgroundImageLayout = ImageLayout.Stretch;
            rbtnDark.BackgroundImageLayout = ImageLayout.Tile;
            roastType = "Medium";
        }

        private void rbtnDark_Click(object sender, EventArgs e)
        {
            rbtnLight.BackgroundImageLayout = ImageLayout.Tile;
            rbtnMediumR.BackgroundImageLayout = ImageLayout.Tile;
            rbtnDark.BackgroundImageLayout = ImageLayout.Stretch;
            roastType = "Dark";
        }

        private void rbtnFine_Click(object sender, EventArgs e)
        {
            rbtnFine.BackgroundImageLayout = ImageLayout.Stretch;
            rbtnMediumG.BackgroundImageLayout = ImageLayout.Tile;
            rbtnCoarse.BackgroundImageLayout = ImageLayout.Tile;
            grindType = "Fine";
        }

        private void rbtnMediumG_Click(object sender, EventArgs e)
        {
            rbtnFine.BackgroundImageLayout = ImageLayout.Tile;
            rbtnMediumG.BackgroundImageLayout = ImageLayout.Stretch;
            rbtnCoarse.BackgroundImageLayout = ImageLayout.Tile;
            grindType = "Medium";
        }

        private void rbtnCoarse_Click(object sender, EventArgs e)
        {
            rbtnFine.BackgroundImageLayout = ImageLayout.Tile;
            rbtnMediumG.BackgroundImageLayout = ImageLayout.Tile;
            rbtnCoarse.BackgroundImageLayout = ImageLayout.Stretch;
            grindType = "Coarse";
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = connection;
            cmd.CommandText = "insert into customCoffee values('1','"+coffeeBeans+"','"+roastType+"','"+grindType+"','"+bMethod+"')";
            cmd.ExecuteNonQuery();
            //MessageBox.Show("Order Successfully accepted.");
            connection.Close();
            orderSuccessPage2 osp = new orderSuccessPage2();
            osp.ShowDialog();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void customCoffee_Load(object sender, EventArgs e)
        {

        }

        string bMethod = "";

        private void cmbxBMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbxBMethod.SelectedItem.ToString() == "Chemex") 
            {
                bMethodImage.BackgroundImage = Image.FromFile("D:/This PC/UI Design/TBB UI/Components/Chemex.jpg");
                bMethodImage.BackgroundImageLayout = ImageLayout.Stretch;
                bMethod  = "Chemex";
            }
            if (cmbxBMethod.SelectedItem.ToString() == "V60")
            {
                bMethodImage.BackgroundImage = Image.FromFile("D:/This PC/UI Design/TBB UI/Components/V60.jpg");
                bMethodImage.BackgroundImageLayout = ImageLayout.Stretch;
                bMethod = "V60";
            }
            if (cmbxBMethod.SelectedItem.ToString() == "Aero Press")
            {
                bMethodImage.BackgroundImage = Image.FromFile("D:/This PC/UI Design/TBB UI/Components/Aeropress.jpg");
                bMethodImage.BackgroundImageLayout = ImageLayout.Stretch;
                bMethod = "Aero Press";
            }
            if (cmbxBMethod.SelectedItem.ToString() == "French Press")
            {
                bMethodImage.BackgroundImage = Image.FromFile("D:/This PC/UI Design/TBB UI/Components/frenchPress.png");
                bMethodImage.BackgroundImageLayout = ImageLayout.Stretch;
                bMethod = "French Press";
            }

            lblPrice.Text = Convert.ToString(6 + (6 * 18 / 100)) + '$';
        }
    }
}
