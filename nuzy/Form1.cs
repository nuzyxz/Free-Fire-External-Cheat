using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace nuzy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            aim1.Show();
            visual1.Hide();
            settings1.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            aim1.Hide();
            visual1.Show();
            settings1.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            aim1.Hide();
            visual1.Hide();
            settings1.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            aim1.BringToFront();
        }
        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SetAllBorderColorDefault()
        {
            aimCB.CustomBorderColor = Color.FromArgb(18,18,18);
            visualCB.CustomBorderColor = Color.FromArgb(18, 18, 18);
            configCB.CustomBorderColor = Color.FromArgb(18, 18, 18);
        }

        private void visualCB_Click(object sender, EventArgs e)
        {
            visual1.BringToFront(); 
            SetAllBorderColorDefault();
            visualCB.CustomBorderColor = Color.FromArgb(3, 187, 133);
        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {
            aim1.BringToFront();
            SetAllBorderColorDefault();
            aimCB.CustomBorderColor = Color.FromArgb(3, 187, 133);
        }

        private void configCB_Click(object sender, EventArgs e)
        {
            settings1.BringToFront();
            SetAllBorderColorDefault();
            configCB.CustomBorderColor = Color.FromArgb(3, 187, 133);
        }

        private void aim1_Load(object sender, EventArgs e)
        {

        }
    }
}
