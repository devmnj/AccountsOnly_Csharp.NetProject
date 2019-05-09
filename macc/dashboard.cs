using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Threading;


namespace macc
{
    public partial class dashboard : Form
    {
        DataTable dashTable = new System.Data.DataTable("dashtable");

        public dashboard()
        {
            InitializeComponent(); 
            dashTable.Columns.Add("dvalue", typeof(string));
            dataGridView1.DataSource = dashTable;

        }

        public void BackWorker()
        {
            double bal = 0; string str = null;
            try
            {
                
                dashTable.Rows.Clear();
                Globals.F5DashBoardSettings();
                foreach (DataRowView r in Globals.dashboardSettings_View)
                {
                    str = Globals.GetAccountName(int.Parse(r["acid"].ToString()));

                    if (str == null)
                    {
                        str = Globals.GetGroupName(int.Parse(r["acid"].ToString()));
                        bal = Globals.GetGroupOB(int.Parse(r["acid"].ToString()));
                        //dataGridView1.Rows.Add(str);

                    }
                    else
                    {

                        bal = Globals.GetOB(DateTime.Now.Date, int.Parse(r["acid"].ToString()), 1);

                        // string stam = String.Format("{{0:0.00}", bal).ToString();
                        //dataGridView1.Rows.Add(bal.ToString());
                        //dataGridView1.Rows.Add(bal.ToString());
                    }
                    dashTable.Rows.Add(str);
                    dashTable.Rows.Add(bal);
                }
                //dataGridView1.DataSource = dashTable;
                dataGridView1.Rows[0].Selected = false;
            }
            catch (OleDbException exc)
            {
                MessageBox.Show(exc.Message.ToString());
            }
        }
        private void dashboard_Load(object sender, EventArgs e)
        {
           //  backgroundWorker1.RunWorkerAsync();
           BackWorker();       
            
        }


        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        //private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    if (backgroundWorker1.CancellationPending == true)
        //    {
        //        e.Cancel = true;
        //    }
        //    else
        //    {
        //        BackWorker();
        //        backgroundWorker1.ReportProgress(90);
                
        //    }
        //}

        //private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        //{
        //    toolStripProgressBar1.Value = e.ProgressPercentage;
        //}

        //private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    //if (e.Cancelled || e.Error == null)
        //    //{
                
        //    //}
        //    //else
        //    //{
        //        //dataGridView1.Rows[0].Selected = false;            
        //    //}
        //}

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //  backgroundWorker1.CancelAsync();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
          //  backgroundWorker1.RunWorkerAsync();
            BackWorker();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    
    }
}
