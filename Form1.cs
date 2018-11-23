using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe_2._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnJ1_Click(object sender, EventArgs e)
        {
            J1vsCPU j1vscpu = new J1vsCPU();
            j1vscpu.Show();
            this.Hide();
        }

        private void btnJ2_Click(object sender, EventArgs e)
        {
            J1vsJ2 j1vsj2 = new J1vsJ2();
            j1vsj2.Show();
            this.Hide();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
