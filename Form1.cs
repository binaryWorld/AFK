using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Artificial_meter
{

    public partial class Form1 : Form
    {
        static int formCount = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            statusLabel.Text = "Ready";
        }

        protected void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to quit", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                System.Windows.Forms.Application.Exit();
            }
            // else pass or implement later
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            MLR mlr = new MLR();
            mlr.MdiParent = this;
            mlr.Text = "Workspace " + Convert.ToString(formCount);
            mlr.Show();
            formCount++;
            
        }

       
    }
}
