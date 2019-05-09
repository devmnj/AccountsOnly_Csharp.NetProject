using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace macc
{
    public partial class AcReport2 : Form
    {
        string firstDate;
        AutoCompleteStringCollection autotext = new AutoCompleteStringCollection();
        bool flag;
        int ledid;
        public AcReport2()
        {
            InitializeComponent();
            SetupAutoText();
        }
 public AcReport2(int id)
        {
            InitializeComponent();
            SetupAutoText();
            Find(id);
          
        }
        public void SetupAutoText()
        {
            Globals.F5Account();
            autotext.Clear();
            foreach (DataRowView row in Globals.AccountView)
            {
                autotext.Add(row["acname"].ToString() + "|" + row["acid"].ToString());
            }
            txt_ledger.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_ledger.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_ledger.AutoCompleteCustomSource = autotext;
        }
        private void AcReport2_Load(object sender, EventArgs e)
        {
            SetHeaders();
            Globals.Positionform(this);

        }
        private void SetHeaders()
        {
            ColumnHeader headers = new ColumnHeader();
            listView1.View = View.Details;
            headers.Text = "";
            headers.Width = 0;
            listView1.Columns.Add(headers);
            headers = new ColumnHeader();
            listView1.View = View.Details;
            headers.Text = "Date";
            headers.Width = 80;
            listView1.Columns.Add(headers);
            headers = new ColumnHeader();
            headers.Text = "Particulars";
            headers.Width = 200;

            listView1.Columns.Add(headers);
            headers = new ColumnHeader();
            headers.Text = "Voucher";
            headers.Width = 130;

            listView1.Columns.Add(headers);
            headers = new ColumnHeader();
            headers.Text = "V.No";
            headers.Width = 90;
            listView1.Columns.Add(headers);
            headers = new ColumnHeader();
            headers.Text = "Dr ";
            headers.Width = 120;

            listView1.Columns.Add(headers);
            headers = new ColumnHeader();
            headers.Text = "Cr ";
            headers.Width = 120;

            listView1.Columns.Add(headers);
            headers = new ColumnHeader();
            headers.Text = "Note";
            headers.Width = 200;

            listView1.Columns.Add(headers);
            headers = new ColumnHeader();
            headers.Text = "";
            headers.Width = 0;


            listView1.Refresh();
        }
        private void txt_ledger_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Find();
            }
        }
        public void Find(int acid)
        {
             
            string drac=Globals.GetAccountName(acid);
            if (drac != "")
            {
                List<string> dts = Globals.GetTransPeriods(acid);
                
                 txt_ledger.Text=drac.ToUpper();
                dateTimePicker1.Value =DateTime.Parse( string.Format("{0:MM/dd/yy}", dts[0].ToString()));
                dateTimePicker2.Value = DateTime.Parse(string.Format("{0:MM/dd/yy}", dts[1].ToString()));
                try
                {

                    Find();
                }
                catch (Exception ms)
                {
                    MessageBox.Show((ms.Message.ToString()));
                }

            }
        }
        private void txt_ledger_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_ledger_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txt_ledger.Text.Trim() != null)
            {
                button1.Focus();
            }
        }
        public void Find()
        {
            string drac;
            if (txt_ledger.Text.Trim() != "")
            {
                listView1.Items.Clear();
                drac = txt_ledger.Text.ToString().ToUpper();
                if (drac.Contains("|"))
                {
                    string[] strArr = new string[5];
                    char[] splitchar = { '|' };
                    strArr = drac.Split(splitchar);
                    drac = strArr[0];
                }
                try
                {


                    ledid = Globals.GetAccountID(drac);
                    if (ledid > 0)
                    {

                        OleDbDataAdapter rs = new System.Data.OleDb.OleDbDataAdapter("select * from   transactions where  tr_date>=#" + dateTimePicker1.Value.ToShortDateString() + "#" +
                         " AND  tr_date<=#" + dateTimePicker2.Value.ToShortDateString() + "#  AND acID=" + ledid, Globals.con);
                        DataSet trnsDataSet = new DataSet();
                        rs.Fill(trnsDataSet, "transactions");
                        DataView trnsView = new DataView(trnsDataSet.Tables[0]);
                        Globals.AppEvents.NewEvent(new Events(DateTime.Now, "Account Report", drac, "Viewed"));
                        Globals.history.Subscribe(Globals.AppEvents);

                        double TDr = 0, TCr = 0;

                        ListViewItem tr_items = new ListViewItem();
                        double Curr_ODr = 0, Curr_OCr = 0;
                        List<double> DrCrBalance = Globals.GetOB(dateTimePicker1.Value, ledid);
                        //tr_items = new ListViewItem();
                        //tr_items.SubItems.Add("");
                        //tr_items.SubItems.Add("");
                        //tr_items.SubItems.Add("");
                        //tr_items.SubItems.Add("");

                        //tr_items.SubItems.Add("");
                        //tr_items.SubItems.Add("");
                        //tr_items.SubItems.Add("");
                        //listView1.Items.Add(tr_items);

                        tr_items = new ListViewItem();
                        tr_items.SubItems.Add("");
                        tr_items.SubItems.Add("Account" );
                        tr_items.SubItems.Add("Period" );
                        tr_items.SubItems.Add("");
                     
                        tr_items.SubItems.Add("");
                        tr_items.SubItems.Add("");
                        tr_items.SubItems.Add("");
                        tr_items.Font = new System.Drawing.Font(FontFamily.GenericSerif, 10, FontStyle.Bold);
                        tr_items.BackColor = Color.Aquamarine ;
                        listView1.Items.Add(tr_items);

                        tr_items = new ListViewItem();
                        tr_items.SubItems.Add("" );
                        tr_items.SubItems.Add(txt_ledger.Text.ToString());
                        tr_items.SubItems.Add(dateTimePicker1.Value.ToShortDateString() + " To " + dateTimePicker2.Value.ToShortDateString());
                        tr_items.SubItems.Add("");
                     
                        tr_items.SubItems.Add("");
                        tr_items.SubItems.Add("");
                        tr_items.SubItems.Add("");
                        tr_items.BackColor = Color.Aquamarine;
                        listView1.Items.Add(tr_items);


                        tr_items = new ListViewItem();
                        tr_items.SubItems.Add(" ");
                        tr_items.SubItems.Add("");
                        tr_items.SubItems.Add("");
                        tr_items.SubItems.Add("");

                        tr_items.SubItems.Add("");
                        tr_items.SubItems.Add("");
                        tr_items.SubItems.Add("");
                        listView1.Items.Add(tr_items);
 tr_items = new ListViewItem();

                        if (DrCrBalance[0] != 0)
                        {

                            tr_items = new ListViewItem();
                            tr_items.SubItems.Add("");
                            tr_items.SubItems.Add("");
                            tr_items.SubItems.Add("Opening Balance");
                            tr_items.SubItems.Add("");
                            TDr += DrCrBalance[0];
                            tr_items.SubItems.Add(string.Format("{0:0.00}", DrCrBalance[0]));
                            tr_items.SubItems.Add(string.Format("{0:0.00}", 0.00));
                            tr_items.SubItems.Add("Old balance");
                        }
                        if (DrCrBalance[1] != 0)
                        {
                            tr_items = new ListViewItem();
                            tr_items.SubItems.Add("");
                            tr_items.SubItems.Add("");
                            tr_items.SubItems.Add("Opening Balance");
                            tr_items.SubItems.Add("");
                            TCr += DrCrBalance[1];
                            tr_items.SubItems.Add(string.Format("{0:0.00}", 0.00));
                            tr_items.SubItems.Add(string.Format("{0:0.00}", DrCrBalance[1]));
                            tr_items.SubItems.Add("Old balance");
                        }

                        Curr_OCr = DrCrBalance[1];
                        Curr_ODr = DrCrBalance[0];

                        if (tr_items.SubItems.Count >1) listView1.Items.Add(tr_items);

                        string account_root = Globals.GetGroupName(Globals.GetAccountGroupRoot(ledid));


                        TDr = TCr = 0;
                        int id = 0;
                        if (trnsView.Count > 0)
                        {
                            foreach (DataRowView row in trnsView)
                            {


                                tr_items = new ListViewItem();
                                tr_items.SubItems.Add(string.Format("{0:MM/dd/yyyy}", row["tr_date"]));
                                tr_items.SubItems.Add(Globals.GetAccountName((int)row["linkd_tr_id"]).ToString());
                                tr_items.SubItems.Add(Globals.GetEntryName(int.Parse(row["eid"].ToString())));
                                tr_items.SubItems.Add(row["eno"].ToString());
                                tr_items.SubItems.Add(string.Format("{0:0.00}", row["dr_amount"]));
                                tr_items.SubItems.Add(string.Format("{0:0.00}", row["cr_amount"]));
                                TDr += double.Parse(row["dr_amount"].ToString());
                                TCr += double.Parse(row["cr_amount"].ToString());
                                tr_items.SubItems.Add(Globals.GetNarration(int.Parse(row["eid"].ToString()), int.Parse(row["eno"].ToString())));
                                listView1.Items.Add(tr_items);

                            }

                        }
                        ListViewItem footer = new ListViewItem();

                        footer.SubItems.Add("");

                        footer = new ListViewItem();
                      
                        footer.SubItems.Add("");
                        footer.SubItems.Add("Total");
                        footer.SubItems.Add("");
                        footer.SubItems.Add("");
                        footer.SubItems.Add(string.Format("{0:0.00}", Curr_ODr + TDr));
                        footer.SubItems.Add(string.Format("{0:0.00}", Curr_OCr + TCr));
                        footer.SubItems.Add("");
                        footer.Font = new System.Drawing.Font(FontFamily.GenericSansSerif,10, FontStyle.Bold);
                        listView1.Items.Add(footer);
                        footer = new ListViewItem();

                        footer.SubItems.Add("");
                        footer.SubItems.Add("Balance");
                        if (Curr_ODr + TDr > Curr_OCr + TCr)
                        {
                            footer.SubItems.Add("");
                            footer.SubItems.Add("");

                            footer.SubItems.Add(string.Format("{0:0.00}", (Curr_ODr + TDr) - (Curr_OCr + TCr)));
                            footer.SubItems.Add("");
                            footer.SubItems.Add("");
                            footer.SubItems.Add("");
                            footer.SubItems.Add("");
                        }
                        else if (Curr_ODr + TDr < Curr_OCr + TCr)
                        {
                            footer.SubItems.Add("");
                            footer.SubItems.Add("");
                            footer.SubItems.Add("");
                            footer.SubItems.Add(string.Format("{0:0.00}", string.Format("{0:0.00}", (Curr_OCr + TCr) - (Curr_ODr + TDr))));
                            footer.SubItems.Add("");
                            footer.SubItems.Add("");
                            footer.SubItems.Add("");

                        }
                        footer.Font = new System.Drawing.Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
                        
                        footer.BackColor = Color.Bisque;
                        listView1.Items.Add(footer);
                        listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

                    }
                }
                catch (Exception ms)
                {
                    MessageBox.Show((ms.Message.ToString()));
                }

            }
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label7_MouseMove(object sender, MouseEventArgs e)
        {
            if (flag == true)
            {

                this.Location = Cursor.Position;

            }
        }

        private void label7_MouseDown(object sender, MouseEventArgs e)
        {
            flag = true;
        }

        private void label7_MouseUp(object sender, MouseEventArgs e)
        {
            flag = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Find();
        }

        private void btn_excel_Click(object sender, EventArgs e)
        {
            ExportReportsEngine excel = new ExportReportsEngine();
            string[] excid = txt_ledger.Text.Split('|');
            if (excid.Length > 1)
            {
                excel.ExcelExport(excid[1] + ".xlsx", listView1);
            }

        }

        private void btn_pdf_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This  is a beata feature");
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                SendKeys.Send("{TAB}");
            }
        }
    }
}
