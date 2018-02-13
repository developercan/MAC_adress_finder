using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace MAC_adresss
{
    class Database
    {
        SqlCommand comm;
        SqlConnection conn;
        SqlDataAdapter Da = new SqlDataAdapter();
        DataTable Dt = new DataTable();
        string name, model, mac, commandtext;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string Model
        {
            get
            {
                return model;
            }
            set
            {
                model = value;
            }
        }
        public string MAC
        {
            get
            {
                return mac;
            }
            set
            {
                mac = value;
            }
        }
        public string CommandText
        {
            get
            {
                return commandtext;
            }
            set
            {
                commandtext = value;
            }
        }

        public Database()
        {
            conn = new SqlConnection();
            comm = new SqlCommand();
            conn.ConnectionString = "Data Source=DESKTOP-V56QKFA\\SQLEXPRESS;Initial Catalog=mac-adress;Integrated Security=True";
            comm.Connection = conn;
            conn.Open();
        }

        public void SetMAC()
        {
            try
            {
                comm.CommandText = CommandText;
                comm.Parameters.AddWithValue("@ad", Name);
                comm.Parameters.AddWithValue("@marka", Model);
                comm.Parameters.AddWithValue("@Mac", MAC);
                comm.ExecuteNonQuery();
                MessageBox.Show("MAC kaydı başarılı", "MAC Kaydı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Hata" + Ex.Message, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataGridView GetData(DataGridView datagrid)
        {
            comm.CommandText = CommandText;
            Da.SelectCommand = comm;
            Da.Fill(Dt);
            datagrid.DataSource = Dt;
            return datagrid;
        }
    }
}
