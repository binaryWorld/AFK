using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace Artificial_meter
{



    public partial class Form1 : Form
    {
        static int formCount = 0;
         string filePath; // filePath by Excel or ASCII parser will be stored in this variable
        public  DataSet ds = new DataSet();
        OleDbDataAdapter adapter;
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
            

            MLR mlr = new MLR(ds);
            mlr.MdiParent = this;
            mlr.Text = "Workspace " + Convert.ToString(formCount);
            mlr.Show();
            formCount++;
            
        }

        private void helpContentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void excelFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filePath = openFile.FileName.ToString();
 
            }
            else
            {
                MessageBox.Show("Method is still not implemented", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            statusLabel.Text = "Loading data...";
            
        }

        // PARSER FUNCTIONS
        public void loadExcelFile()
        {
            string connectionString;

            if (filePath.EndsWith(".xlsx") || filePath.EndsWith("xlsm")){

            connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath +
            ";Extended Properties=\"Excel 12.0 Macro;HDR=YES;";
           
                OleDbConnection conn = new OleDbConnection(connectionString);
                string commandSelect = "select * from [WTData1$A1:D15]";
                adapter = new OleDbDataAdapter(commandSelect, conn);
                
            try
            {   
  
                conn.Open();
                ds.Clear();
                
                adapter.Fill(ds);
            }

            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("There was en error" + e.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
               conn.Close();
            }

           } // end if 


            else if (filePath.EndsWith(".xls")){

             connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath +
";Extended Properties=\"Excel 8.0;HDR=YES;";

                       OleDbConnection conn = new OleDbConnection(connectionString);
                string commandSelect = "select * from [WTdata$A1:D15]";
                adapter = new OleDbDataAdapter(commandSelect, conn);
                
            try
            {   
  
                conn.Open();
                ds.Clear();
                
                adapter.Fill(ds);
            }

            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("There was en error" + e.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
               conn.Close();
            }

            }

        }


       
    }



}
