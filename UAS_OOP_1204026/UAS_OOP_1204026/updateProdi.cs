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
    public partial class updateProdi : Form
    {
        db konn = new db();
        private MySqlCommand cmd;
        Decimal rupiah;
        private DataSet ds;
        private MySqlDataAdapter da;
        private MySqlDataReader rd;
        public updateProdi()
        {
            InitializeComponent();
        }
        void prodi()
        {

            MySqlDataReader rd;
            MySqlConnection conn = konn.GetConn();
            conn.Open();

            cmd = new MySqlCommand("select * from ms_prodi where kode_prodi='" + textBox1.Text + "'", conn);
            cmd.CommandType = CommandType.Text;
            rd = cmd.ExecuteReader();
            rd.Read();

            if (rd.HasRows)


            {
                textBox1.Text = rd[0].ToString();
                textBox2.Text = rd[1].ToString();
                textBox3.Text = rd[2].ToString();
                textBox4.Text = rd[3].ToString();


            }
        }
        void mahasiswa()
        {

            MySqlDataReader rd;
            MySqlConnection conn = konn.GetConn();
            conn.Open();

            cmd = new MySqlCommand("select * from ms_mhs where npm='" + textBox1.Text + "'", conn);
            cmd.CommandType = CommandType.Text;
            rd = cmd.ExecuteReader();
            rd.Read();

            if (rd.HasRows)


            {
                textBox1.Text = rd[0].ToString();
                textBox2.Text = rd[1].ToString();
                textBox3.Text = rd[2].ToString();

                prodi();

            }
        }
        void kondisiawal()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "")
            {
                MessageBox.Show("Pastikan semua terisi");
            }
            else
            {
                MySqlConnection conn = konn.GetConn();

                cmd = new MySqlCommand("Update ms_prodi set nama_prodi='" + textBox1.Text + "',singkatan='" + textBox2.Text + "',biaya_kuliah='" + textBox3.Text + "'  where kode_prodi='" + textBox4.Text + "'", conn);
                //cmd1 = new MySqlCommand("Update stokin set namabarang='" + textBox2.Text + "',pemasok='" + comboBox3.Text + "',hargabeli='" + textBox5.Text + "',jumlahbarang='" + textBox3.Text + "',level_barang='" + comboBox1.Text + "',satuan='" + comboBox2.Text + "',tanggal='" + DateTime.Now.ToString("yyyy-MM-dd") + "' where idbarang='" + textBox1.Text + "'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                //cmd1.ExecuteNonQuery();
                MessageBox.Show("Data berhasil di Ganti");
                kondisiawal();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "")
            {
                MessageBox.Show("Pastikan semua terisi");
            }
            else
            {
                if (MessageBox.Show("APAKAH YAKIN AKAN MENGHAPUS DATA INI :" + textBox1.Text + "??", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MySqlConnection conn = konn.GetConn();

                    cmd = new MySqlCommand("DELETE from ms_prodi where kode_prodi='" + textBox1.Text + "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil di Hapus");
                    kondisiawal();

                }
            }
        }

        private void updateProdi_Load(object sender, EventArgs e)
        {
            prodi();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            prodi();

        }
    }
}
