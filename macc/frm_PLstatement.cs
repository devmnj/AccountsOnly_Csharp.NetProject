using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace macc
{
    

    public partial class frm_PLstatement : Form
    {
        string firstDate;
        public frm_PLstatement()
        {
            InitializeComponent();

        }

        private void frm_PLstatement_Load(object sender, EventArgs e)
        {
            try
            {
                OleDbDataAdapter tr_rs = new OleDbDataAdapter("select tr_date from transactions order by tr_date asc", Globals.con);
                DataSet tr_ds = new DataSet();
                tr_rs.Fill(tr_ds);
                DataView tr_dv = new DataView(tr_ds.Tables[0]);
                if (tr_dv.Count > 0)
                {
                    firstDate = string.Format("{0:MM/dd/yyyy}", tr_dv[0]["tr_date"]);
                    Console.Write(tr_dv[0]["tr_date"]);
                    dateTimePicker2.Value = DateTime.Parse(tr_dv[0]["tr_date"].ToString());
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Globals.F5Account();
            int rootid = 0;
            dataGridView1.Rows.Clear();
            double[] subtot = { 0.00, 0.00 };
            List<PLClass> PLList = new List<PLClass>();
            List<double> tot = new List<double>();
            int k = 0;
            int[] rows = { Globals.GetSubGroupCount(Globals.GetGroupID("EXPENSE")), Globals.GetSubGroupCount(Globals.GetGroupID("INCOME")) };
            if (rows[0] + rows[1] > 0) { dataGridView1.Rows.Add(rows[0] + rows[1]+1); }
            Globals.F5Account();
            foreach (DataRowView accs in Globals.AccountView)
            {
                rootid = 0;
                rootid = Globals.GetAccountGroupRoot(int.Parse(accs["acid"].ToString()));
                Console.WriteLine(int.Parse(accs["acid"].ToString()));
                Console.WriteLine(Globals.GetAccountName(int.Parse(accs["acid"].ToString())) + " | " + Globals.GetGroupName(rootid));
                tot = Globals.getGroupListBalance(dateTimePicker1.Value.ToShortDateString(), dateTimePicker2.Value.ToShortDateString(), int.Parse(accs["acid"].ToString()));
                if (Globals.GetGroupName(rootid).Trim().Length>0 &&  Globals.GetGroupName(rootid).Trim() == "EXPENSE")
                {
                    dataGridView1[0, k].Value = k + 1;
                    dataGridView1[1, k].Value = accs["acname"].ToString();
                    dataGridView1[2, k].Value = tot[0].ToString();
                    //PLList.Add(new PLClass(accs["acname"].ToString(), dram: tot[0].ToString()));
                    subtot[0] += tot[0]; k++;
                }
                else if (Globals.GetGroupName(rootid).Trim().Length > 0 && Globals.GetGroupName(rootid).Trim() == "INCOME")
                {
                    dataGridView1[0, k].Value = k + 1;
                    dataGridView1[1, k].Value = accs["acname"].ToString();
                    dataGridView1[3, k].Value = tot[1].ToString();
                    subtot[1] += tot[1]; k++;
                }
            }
            dataGridView1.Rows.Add(1);
            
            dataGridView1[1, k  ].Value = "Total ";
            dataGridView1[2, k  ].Value = subtot[0];
            dataGridView1[3, k  ].Value = subtot[1];
            dataGridView1.Rows[k].DefaultCellStyle.BackColor = Color.Honeydew; 
            dataGridView1.Rows.Add(1);
            
            
            //Profit and Loss check
            dataGridView1.Rows.Add(1);
            if (subtot[0] > subtot[1])
            {   //Loss
                dataGridView1[1, k + 1 + 1].Value = "Loss ";
                dataGridView1[2, k + 1 + 1].Value = subtot[0] - subtot[1];
                dataGridView1.Rows[k + 1 + 1].DefaultCellStyle.BackColor = Color.RosyBrown; 
            }
            else if(subtot[1]>subtot[0])
            {   //Profit
                dataGridView1[1, k + 1 + 1].Value = "Profit ";
                dataGridView1[2, k + 1 + 1].Value = subtot[1] - subtot[0];
                dataGridView1.Rows[k + 1 + 1].DefaultCellStyle.BackColor = Color.GreenYellow ; 
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    class PLClass
    {
        private string Part, Dramount, Cramount;
        public PLClass(string item, string dram) { Part = item; Dramount = dram; }
        public PLClass(string item, string cram, int x = 0) { Part = item; Cramount = cram; }
        public string Particulars
        {
            get { return this.Part; }
        }
        public string Dr
        {
            get
            {
                return this.Dramount;

            }
        }
        public string Cr
        {
            get
            {
                return this.Cramount;

            }
        }

    }
}
