﻿using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void totToolStripMenuItem_Click(object sender, EventArgs e)
        {
            daftar_ulang frmdaftar_ulang = new daftar_ulang();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void mahasiswaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inputMhs frminputMhs = new inputMhs();

        }

        private void prodiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inputProdi frminputProdi = new inputProdi();
        }

        private void mahasiswaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            viewMhs frmviewMhs = new viewMhs();
        }

        private void prodiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            viewProdi frmviewProdi = new viewProdi();
        }

        private void mahasiswaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            updateMhs frmupdateMhs = new updateMhs();
        }

        private void prodiToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            updateProdi frmupdateProdi = new updateProdi();
        }
    }
    
}