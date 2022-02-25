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
    public partial class inputMhs : Form
    {
        db konn = new db();
        private MySqlCommand cmd;
        

        public inputMhs()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

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
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox3.Text.Trim() == "" || comboBox1.Text.Trim() == "" )
            {
                MessageBox.Show("Pastikan semua terisi");
            }
            else
            {
                MySqlConnection conn = konn.GetConn();
                cmd = new MySqlCommand("insert into ms_mhs values('" + textBox1.Text + "','" + textBox3.Text + "','" + comboBox1.Text + "')", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil masuk");

            }
        }
        void Kondisireset()
        {
            textBox1.Text = "";
            comboBox1.Text = "";
            textBox3.Text = "";
           
        }
        void kodemahasiswaotomatis()
        {
            long prodi;
            string urutan;
            MySqlDataReader rd;
            MySqlConnection conn = konn.GetConn();
            conn.Open();
            cmd = new MySqlCommand("select npm from ms_mhs where npm in(select max(npm) from ms_mhs) order by npm desc", conn);
            rd = cmd.ExecuteReader();
            rd.Read();
            if (rd.HasRows)
            {
                prodi = Convert.ToInt64(rd[0].ToString().Substring(rd["npm"].ToString().Length - 3, 3)) + 1;
                string joinstr = "000" + prodi;
                urutan = "120" + joinstr.Substring(joinstr.Length - 3, 3);

            }
            else
            {
                urutan = "120001";
            }
            rd.Close();
            textBox1.Text = urutan;
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Kondisireset();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("hanya bisa diisi angka");
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            string karakter = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ., ";
            if (karakter.IndexOf(e.KeyChar) < 0)
            {
                MessageBox.Show("Hanya Bisa Dimasuki Huruf");
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void inputMhs_Load(object sender, EventArgs e)
        {
            kodemahasiswaotomatis();
            munculprogramstudi();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            munculprogramstudi();
        }
    }
}
