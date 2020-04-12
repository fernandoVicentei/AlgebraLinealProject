using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALGEBRA_LINEAL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Paint(object sender, PaintEventArgs e)
        {
         

        }
       // eventos de click
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            //button1.BackColor = Color.Red;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            //button1.BackColor = Color.Pink;
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            //button1.BackColor = Color.Purple;
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
           
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.Blue;           
            
        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                button1.BackColor = Color.Aqua;
            }
        }

        private void aLGEBRALINEALToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mULTIPLICACIONDEMATRICESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Oparaciones opera = new Oparaciones();
            opera.Show();
        }

        private void iNVERSADEUNAMATRIZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            INVERSA iNVERSA = new INVERSA();
            iNVERSA.Show();
        }

        private void dETERMINANTEDEUNAMATRIZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DETERMINANTE deter = new DETERMINANTE();
            deter.Show();
        }

        private void sALIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void rESOLUCIONDESISTEMASDEECUACIONESLINEALESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ECUACIONESLINEALES ecua = new ECUACIONESLINEALES();
            ecua.Show();
        }

        private void sUMAYRESTADEMATRICESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Oparaciones operas = new Oparaciones();
            operas.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }
    }
}
