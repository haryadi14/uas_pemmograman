using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UAS_OOP_1204026
{
    public partial class daftar_ulang : Form
    {
        public daftar_ulang()
        {
            InitializeComponent();
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
    }
}
