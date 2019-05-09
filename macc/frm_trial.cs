using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace macc
{
    public partial class frm_trial : Form
    {
        string firstDate = null;
        public frm_trial()
        {
            InitializeComponent();
            SetHeaders();
        }
        private void frm_trial_Load(object sender, EventArgs e)
        {
            try
            {
                OleDbDataAdapter tr_rs = new OleDbDataAdapter("select tr_date from transactions order by tr_date asc", Globals.con);
                DataSet tr_ds = new DataSet();
                tr_rs.Fill(tr_ds);
                DataView tr_dv = new DataView(tr_ds.Tables[0]);
                firstDate = string.Format("{0:MM/dd/yy}", tr_dv[0]["tr_date"]);
                dateTimePicker2.Value = DateTime.Parse(tr_dv[0]["tr_date"].ToString());
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void SetHeaders()
        {
            listView1.Columns.Clear();
            ColumnHeader headers = new ColumnHeader();
            listView1.View = View.Details;
            headers.Text = " ";
            headers.Width = 1;
            listView1.Columns.Add(headers);
            headers = new ColumnHeader();
            headers.Text = "#";
            headers.Width = 30;
            listView1.Columns.Add(headers);

            headers = new ColumnHeader();
            headers.Text = "Account";
            headers.Width = 300;
            listView1.Columns.Add(headers);
            headers = new ColumnHeader();
            headers.Text = "Dr ";
            headers.Width = 180;

            listView1.Columns.Add(headers);
            headers = new ColumnHeader();
            headers.Text = "Cr ";
            headers.Width = 180;


            listView1.Columns.Add(headers);
            headers = new ColumnHeader();
            headers.Text = "";
            headers.Width = 0;


            listView1.Refresh();
        }


        private void button1_Click(object sender, EventArgs e)
        {



            double[] tot = { 0, 0, 0, 0 };

            listView1.Clear(); SetHeaders();
            Globals.F5Account();
            ListViewItem tr_items = new ListViewItem(); int i = 1;
            int kkk = 1;
            foreach (DataRowView r in Globals.AccountView)
            {
                List<double> DrCrBalance = Globals.getGroupListBalance(dateTimePicker1.Value.ToShortDateString(), dateTimePicker2.Value.ToShortDateString(), int.Parse(r["acid"].ToString()));
                tr_items = new ListViewItem();

                tr_items.SubItems.Add(kkk.ToString());
                tr_items.SubItems.Add(Globals.GetAccountName(int.Parse(r["acid"].ToString())));
                tr_items.SubItems.Add(DrCrBalance[0].ToString());
                tr_items.SubItems.Add(DrCrBalance[1].ToString());
                tot[2] = tot[2] + DrCrBalance[0];
                tot[3] = tot[3] + DrCrBalance[1];
                tr_items.SubItems.Add("");

                listView1.Items.Add(tr_items);


                kkk++;
            }
            tr_items = new ListViewItem();
            tr_items.SubItems.Add(kkk.ToString());
            tr_items.SubItems.Add("Opening Balnce");
            List<double> opb = Globals.OpeningAccountBalance();
            if (opb[1] > opb[0])
            {
                tr_items.SubItems.Add((opb[1] - opb[0]).ToString());
                tr_items.SubItems.Add("0.00");
                tr_items.SubItems.Add("");
                tr_items.SubItems.Add("");
                tot[2] = tot[2] + (opb[1] - opb[0]);
            }
            else if (opb[0] > opb[1])
            {
                tr_items.SubItems.Add("0.00");
                tr_items.SubItems.Add((opb[0] - opb[1]).ToString());
                tr_items.SubItems.Add("");
                tr_items.SubItems.Add("");
                tot[3] = tot[3] + (opb[0] - opb[1]);
            }


            listView1.Items.Add(tr_items);

            ListViewItem footer = new ListViewItem();
            footer.BackColor = Color.Bisque;
            footer.SubItems.Add(" ");
            footer.SubItems.Add("Total");
            footer.SubItems.Add(string.Format("{0:0.00}", tot[2]));
            footer.SubItems.Add(string.Format("{0:0.00}", tot[3]));
            tr_items.SubItems.Add("");
            tr_items.SubItems.Add("");
            footer.Font = new Font(footer.Font, FontStyle.Bold);

            listView1.Items.Add(footer);


        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_excel_Click(object sender, EventArgs e)
        {
            ExportReportsEngine EXCEL = new ExportReportsEngine();
            EXCEL.ExcelExport("trialBalance.xlsx", listView1);
        }
    }
}
