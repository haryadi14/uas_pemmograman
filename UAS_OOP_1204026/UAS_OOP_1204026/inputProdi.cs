using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace UAS_OOP_1204026
{
    
    public partial class inputProdi : Form
    {
        db konn = new db();
        private MySqlCommand cmd;
        Decimal rupiah;
        private DataSet ds;
        private MySqlDataAdapter da;
        private MySqlDataReader rd;

        public inputProdi()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        void kodeotomatis()
        {
            long prodi;
            string urutan;
            MySqlDataReader rd;
            MySqlConnection conn = konn.GetConn();
            conn.Open();
            cmd = new MySqlCommand("select kode_prodi from ms_prodi where kode_prodi in(select max(kode_prodi) from ms_prodi) order by kode_prodi desc", conn);
            rd = cmd.ExecuteReader();
            rd.Read();
            if (rd.HasRows)
            {
                prodi = Convert.ToInt64(rd[0].ToString().Substring(rd["kode_prodi"].ToString().Length - 3, 3)) + 1;
                string joinstr = "000" + prodi;
                urutan = "PRD" + joinstr.Substring(joinstr.Length - 3, 3);

            }
            else
            {
                urutan = "PRD001";
            }
            rd.Close();
            textBox1.Text = urutan;
            conn.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "")
            {
                MessageBox.Show("Pastikan semua terisi");
            }
            else
            {
                db database = new db();
                MySqlConnection conn = database.GetConn();
                cmd = new MySqlCommand("insert into ms_prodi values('" + textBox1.ToString() + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')", conn);
                conn.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Data berhasil ditambah");
                
            }
        }
        void Kondisireset()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";


        }
        private void button2_Click(object sender, EventArgs e)
        {
            Kondisireset();
        }

        private void textBox4_KeyUp(object sender, KeyEventArgs e)
        {
          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void inputProdi_Load(object sender, EventArgs e)
        {
            kodeotomatis();

        }
    }
}
