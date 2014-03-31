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
    public partial class MLR : Form
    {
        private DataSet ds; 
        public MLR(DataSet dataSet)
        {
            InitializeComponent();
            ds = dataSet;
        }

        private void MLR_Load(object sender, EventArgs e)
        {
            if (ds != null)
            {
                dataGridView1.DataSource = ds;
            }
            else
            {
                MessageBox.Show("Error", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    }
}
