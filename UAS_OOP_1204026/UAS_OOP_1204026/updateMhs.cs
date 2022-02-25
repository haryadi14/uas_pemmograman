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
    public partial class updateMhs : Form
    {
        db konn = new db();
        private MySqlCommand cmd;
        Decimal rupiah;
        private DataSet ds;
        private MySqlDataAdapter da;
        private MySqlDataReader rd;
        public updateMhs()
        {
            InitializeComponent();
        }
        void munculprogramstudi()
        {
            MySqlDataReader rd;
            MySqlConnection conn = konn.GetConn();
            conn.Open();

            cmd = new MySqlCommand("select * from ms_prodi", conn);
            cmd.CommandType = CommandType.Text;
            rd = cmd.ExecuteReader();

            while (rd.Read())
            {

                comboBox1.Items.Add(rd[0].ToString());

            }
            rd.Close();
            conn.Close();

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
                textBox3.Text = rd[1].ToString();
                comboBox1.Text = rd[2].ToString();


            }
        }
        void kondisiawal()
        {
            textBox1.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox3.Text.Trim() == "" || comboBox1.Text.Trim() == "")
            {
                MessageBox.Show("Pastikan semua terisi");
            }
            else
            {
                MySqlConnection conn = konn.GetConn();

                cmd = new MySqlCommand("Update ms_mhs set nama_mhs='" + textBox3.Text + "',kode_prodi='" + comboBox1.Text + "' where npm='" + textBox1.Text + "'", conn);
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
            if (textBox1.Text.Trim() == "" || textBox3.Text.Trim() == "" || comboBox1.Text.Trim() == "")
            {
                MessageBox.Show("Pastikan semua terisi");
            }
            else
            {
                if (MessageBox.Show("APAKAH YAKIN AKAN MENGHAPUS DATA INI :" + textBox3.Text + "??", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MySqlConnection conn = konn.GetConn();

                    cmd = new MySqlCommand("DELETE from ms_mhs where npm='" + textBox1.Text + "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil di Hapus");
                    kondisiawal();

                }
            }
    }

        private void updateMhs_Load(object sender, EventArgs e)
        {
            munculprogramstudi();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mahasiswa();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
