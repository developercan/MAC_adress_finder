using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MAC_adresss
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }//DESKTOP-V56QKFA\SQLEXPRESS

        void GetData()
        {
            Database db = new Database();
            db.CommandText = "select ad,marka,mac from mac_adress";
            db.GetData(DgvGetData);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //Check every Textbox null or empty
          foreach (Control objectX in this.Controls)
            {
                if (objectX is TextBox)
                {
                    if (!string.IsNullOrEmpty(objectX.Text) || !string.IsNullOrWhiteSpace(objectX.Text))
                    {
                        Database db = new Database();
                        db.Name = TxtName.Text;
                        db.Model = TxtModel.Text;
                        db.MAC = TxtMAC.Text;
                        db.CommandText="insert into mac_adress(ad,marka,mac) values(@ad,@marka,@mac)";
                        db.SetMAC();
                        GetData();
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Boş değer girilemez","Hata!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        break;
                    }
                }
            }

           
        }
    }
}
