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
using System.Globalization;

namespace UAS_OOP_1204026
{
    public partial class daftar_ulang : Form
    {
        db konn = new db();
        private MySqlCommand cmd;
        Decimal rupiah;
        private DataSet ds;
        private MySqlDataAdapter da;
        private MySqlDataReader rd;
        double number1 = 0;
        double result = 0;
        public daftar_ulang()
        {
            InitializeComponent();
        }
        void kondisiawal()
        {
            label17.Text = "0";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;

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
        void prodi()
        {

            MySqlDataReader rd;
            MySqlConnection conn = konn.GetConn();
            conn.Open();

            cmd = new MySqlCommand("select * from ms_prodi where kode_prodi='" + textBox3.Text + "'", conn);
            cmd.CommandType = CommandType.Text;
            rd = cmd.ExecuteReader();
            rd.Read();

            if (rd.HasRows)


            {

                label17.Text = rd[3].ToString();


            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("hanya bisa diisi angka");
            }
        }
        void bagilimapuluh()
        {
            textBox5.Text = (Double.Parse(label17.Text) * 0.5).ToString();
            textBox6.Text = (Double.Parse(label17.Text) - Double.Parse(textBox5.Text)).ToString();
        }
        void bagidualima()
        {
            textBox5.Text = (Double.Parse(label17.Text) * 0.25).ToString();
            textBox6.Text = (Double.Parse(label17.Text) - Double.Parse(textBox5.Text)).ToString();
        }
        void bagisepuluh()
        {
            textBox5.Text = (Double.Parse(label17.Text) * 0.1).ToString();
            textBox6.Text = (Double.Parse(label17.Text) - Double.Parse(textBox5.Text)).ToString();

        }
        void separator()
        {


            if (!string.IsNullOrEmpty(textBox5.Text))
            {

                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                int valueBefore = Int32.Parse(textBox5.Text, System.Globalization.NumberStyles.AllowThousands);
                textBox5.Text = String.Format(culture, "{0:N0}", valueBefore);
                textBox5.Select(textBox5.Text.Length, 0);
            }

        }
        private void textox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btncari_Click(object sender, EventArgs e)
        {
            mahasiswa();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox6.Text.Trim() == "")
            {
                MessageBox.Show("Pastikan semua terisi");
            }
            else
            {
                string npm = textBox1.Text.Trim();
                double totalbiaya = double.Parse(textBox6.Text, NumberStyles.Currency);

                string grade = string.Empty;
                if (radioButton1.Checked)
                {
                    grade = "A";
                }
                else if (radioButton2.Checked)
                {
                    grade = "B";
                }
                else if (radioButton3.Checked)
                {
                    grade = "C";
                }
                MySqlConnection conn = konn.GetConn();
                cmd = new MySqlCommand("INSERT INTO tr_daftar_ulang (npm, grade, total_biaya) VALUES(@NPM, @Grade, @Total_Biaya)");
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@NPM", npm);
                cmd.Parameters.AddWithValue("@Grade", grade);
                cmd.Parameters.AddWithValue("@Total_Biaya", totalbiaya);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Transaksi Daftar Ulang Berhasil Ditambah");
                kondisiawal();

            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            bagilimapuluh();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            bagidualima();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            bagisepuluh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        void datadaftarulangmahasiswa()
        {
            MySqlConnection conn = konn.GetConn();
            conn.Open();
            cmd = new MySqlCommand("SELECT * FROM tr_daftar_ulang;", conn);
            ds = new DataSet();
            da = new MySqlDataAdapter(cmd);

            da.Fill(ds, "tr_daftar_ulang");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "tr_daftar_ulang";
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Refresh();
        }
        private void daftar_ulang_Load(object sender, EventArgs e)
        {
            datadaftarulangmahasiswa();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("APAKAH YAKIN AKAN MENGHAPUS DATA INI :", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MySqlConnection conn = konn.GetConn();

                cmd = new MySqlCommand("DELETE from tr_daftar_ulang where total_biaya'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil di Hapus");
                kondisiawal();

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("TRANSAKSI dihapus?", "APAKAH DATA INGIN DIHAPUS", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string id = dataGridView1.Rows[e.RowIndex].Cells["total_biaya"].FormattedValue.ToString();
                MySqlConnection conn = konn.GetConn();
                conn.Open();
                MySqlCommand com = new MySqlCommand("Delete from tr_daftar_ulang where total_biaya='" + id + "'", conn);
                com.ExecuteNonQuery();
                MessageBox.Show("DATA TRANSAKSI BERHASIL DIHAPUS");
                conn.Close();
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            MySqlConnection conn = konn.GetConn();
            MySqlCommand com = new MySqlCommand(" Select * from tr_daftar_ulang", conn);
            MySqlDataAdapter d = new MySqlDataAdapter(com);
            DataTable dt = new DataTable();
            d.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
         
            
        
            
    
    
}
