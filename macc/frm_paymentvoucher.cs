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
    public partial class frm_paymentvoucher : Form
    {
        AutoCompleteStringCollection autotext = new AutoCompleteStringCollection();
        double disc = 0, cash, totalCash;
        int cracid;
        //
        string drac;
        double netamount, discp;
        public frm_paymentvoucher()
        {
            InitializeComponent();
            Globals.F5Account();

            txt_rvno.Text = Globals.GenericF5SLNO("pv_info", "entryno");
            AutoText();
        }
        private void FindState()
        {
            btn_edit.Enabled = true;
            btn_save.Enabled = false;
            btn_delete.Enabled = true;
            btn_edit.Enabled = true;
        }
        private void NormalState()
        {
            btn_edit.Enabled = false;
            btn_save.Enabled = true;
            btn_delete.Enabled = false;
            btn_edit.Enabled = false;
        }
        private void AutoText()
        {

            autotext.Clear();
            foreach (DataRowView row in Globals.AccountView)
            {
                autotext.Add(row["acname"].ToString() + " | " + row["acid"].ToString());
            }
            txt_acname.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_acname.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_acname.AutoCompleteCustomSource = autotext;
        }
        private void frm_paymentvoucher_Load(object sender, EventArgs e)
        {

        }

        private void txt_findrcno_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void GetTotal()
        {
            DataGridViewRowCollection rows = (DataGridViewRowCollection)dataGridView1.Rows;
            totalCash = 0;
            foreach (DataGridViewRow row in rows)
            {
                if (row.Cells[2].Value != null)
                {
                    double.TryParse(row.Cells[2].Value.ToString(), out cash);
                    totalCash = totalCash + cash;
                }

            }
        }
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox auto = e.Control as TextBox;
            if (dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].Index == 1)
            {

                AutoCompleteStringCollection autotxt = new AutoCompleteStringCollection();

                foreach (DataRowView row in Globals.AccountView)
                {
                    autotext.Add(row["acname"].ToString() + " | " + row["acid"].ToString());
                }
                auto.AutoCompleteMode = AutoCompleteMode.Suggest;
                auto.AutoCompleteSource = AutoCompleteSource.CustomSource;
                auto.AutoCompleteCustomSource = autotext;
            }
            else
            {
                auto.AutoCompleteMode = AutoCompleteMode.None;
                auto.AutoCompleteSource = AutoCompleteSource.None;
                auto.AutoCompleteCustomSource = null;

            }
        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.EndEdit();

            if (e.ColumnIndex != 0)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[1].FormattedValue.ToString().ToString() == "")
                {
                    GetTotal();
                    txt_totalCash.Text = string.Format("{0:0.00}", totalCash);

                    //disc_perc.Focus();
                    if (e.RowIndex != 0)
                    {
                        if (dataGridView1.Rows[e.RowIndex - 1].Cells[1].FormattedValue.ToString() == "")
                        {

                            disc_perc.Focus();
                        }
                    }
                }

                string n = dataGridView1.Rows[e.RowIndex].Cells[1].FormattedValue.ToString().ToString();
                if (n.Contains("|"))
                {
                    string[] strArr = new string[5];
                    char[] splitchar = { '|' };
                    strArr = n.Split(splitchar);
                    n = strArr[0];
                }
                int lid = Globals.GetAccountID(n);
                int inv = 0;
                int.TryParse(txt_rvno.Text.ToString(), out inv);
                //double pt = Globals.PreviousTransactionsToGrid(dataGridView2, "cr_amount as AmountPaid", inv, 101, lid);
                // txt_total_received.Text = string.Format("{0:0.00}", pt);
                txt_dr.TextAlign = HorizontalAlignment.Right;
                List<double> b = Globals.GetOB(DTP_rvdate.Value.AddDays(1), lid);

                if (b[1]>0) {
                    txt_dr.Text = string.Format("{0:0.00}", b[1]) + " Cr";
                    txt_dr.Visible = true;
                }
                else if(b[0]>0)
                {
                    txt_dr.Text = string.Format("{0:0.00}", b[0]) + " Dr";
                }
                else{

                    txt_dr.Visible = false;
                }
            }


        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                dataGridView1.EndEdit();

            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

        }

        private void disc_perc_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
            {
                disc = 0;
                double.TryParse(txt_totalCash.Text.ToString(), out totalCash);
                double.TryParse(disc_perc.Text.ToString(), out discp);
                if (discp > 0 && totalCash > 0)
                {
                    disc = totalCash * discp / 100;

                }
                txt_disc_amount.Text = string.Format("{0:0.00}", disc);
                GetNet();
            }
        }
        private void GetNet()
        {
            double net;

            net = totalCash - disc;

            txt_netamount.Text = string.Format("{0:0.00}", net);
        }

        private void txt_totalCash_TextChanged(object sender, EventArgs e)
        {
            GetNet();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void Find(int rcno)
        {
            Globals.F5PVIN();
            dataGridView1.totalCash = 0;
            Globals.F5PVPA();
            Globals.PVinfoView.Sort = "entryno";
            int rid = Globals.PVinfoView.Find(rcno);
            if (rid != -1)
            {


                txt_acname.Text = Globals.GetAccountName((int)Globals.PVinfoView[rid]["crac"]) + "|" + Globals.PVinfoView[rid]["crac"];
                txt_disc_amount.Text = Globals.PVinfoView[rid]["discount"].ToString();
                txt_narration.Text = Globals.PVinfoView[rid]["narration"].ToString();
                txt_rvno.Text = rcno.ToString();

                disc_perc.Text = Globals.PVinfoView[rid]["discp"].ToString();
                txt_totalCash.Text = Globals.PVinfoView[rid]["total"].ToString();
                DTP_rvdate.Value = DateTime.Parse(Globals.PVinfoView[rid]["pvdate"].ToString());
                int k = 0;
                Globals.PVPartView.Sort = "entryno";
                DataRowView[] rows = Globals.PVPartView.FindRows(rcno);
                foreach (DataRowView r in rows)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.CurrentCell = dataGridView1.Rows[k].Cells[SLNO.Index]; k++;
                    dataGridView1.CurrentRow.Cells[SLNO.Index].Value = dataGridView1.CurrentRow.Index + 1;
                    dataGridView1.CurrentRow.Cells[RECFRM.Index].Value = Globals.GetAccountName((int)r["drac"]);
                    dataGridView1.CurrentRow.Cells[CRID.Index].Value = r["drac"].ToString();
                    dataGridView1.CurrentRow.Cells[CASH1.Index].Value = r["amount"].ToString();

                }

                txt_netamount.Text = Globals.PVinfoView[rid]["netamount"].ToString();
                FindState();
                Globals.AppEvents.NewEvent(new Events(DateTime.Now, "Payment Voucher", rcno.ToString(), "Opened"));
                Globals.history.Subscribe(Globals.AppEvents);
            }
            else
            {
                MessageBox.Show("Payment Voucher not found");
            }
        }
        private void button_FIND_Click(object sender, EventArgs e)
        {
            if (txt_findrcno.Text.ToString() != "")
            {
                Find(int.Parse(txt_findrcno.Text.ToString()));
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {


            //}
            txt_rvno.Clear(); txt_acname.Clear();
            txt_dr.Text = "0.00";
            txt_dr.Visible = false;
            txt_disc_amount.Clear();
            txt_narration.Clear();
            txt_netamount.Clear();
            txt_dr.Clear();
            disc_perc.Clear();
            txt_totalCash.Clear();
            dataGridView1.Rows.Clear();
            Globals.F5Account();
            txt_rvno.Text = Globals.GenericF5SLNO("pv_info", "entryno");
            AutoText();
            NormalState();
        }



        private void btn_edit_Click(object sender, EventArgs e)
        {
            //EDIT
            DialogResult res = new DialogResult();
            DataSet ds = new DataSet();
            OleDbDataAdapter ad;
            DataView dv = new DataView();
            DataRow dr;
            res = MessageBox.Show("Do you want to edit the Payment", "Edit Payment", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {

                try
                {
                    ad = new OleDbDataAdapter("select * from pv_info where entryno=" + txt_rvno.Text, Globals.con);
                    ad.Fill(ds, "pv_info");
                    dv = new DataView(ds.Tables[0]);

                    drac = txt_acname.Text.ToString().ToUpper();
                    if (drac.Contains("|"))
                    {
                        string[] strArr = new string[5];
                        char[] splitchar = { '|' };
                        strArr = drac.Split(splitchar);
                        drac = strArr[0];
                    }
                    int rcno;
                    int dracid = Globals.GetAccountID(drac);
                    double.TryParse(txt_netamount.Text.ToString(), out netamount);
                    double.TryParse(txt_totalCash.Text.ToString(), out cash);
                    double.TryParse(disc_perc.Text.ToString(), out discp);
                    double.TryParse(txt_disc_amount.Text.ToString(), out disc);

                    int.TryParse(txt_rvno.Text.ToString(), out rcno);

                    if (txt_acname.Text != "" && txt_netamount.Text != "")
                    {
                        dr = (DataRow)dv.Table.Rows[0];
                        dr.BeginEdit();
                        dr["entryno"] = rcno;
                        dr["crac"] = dracid;
                        dr["pvdate"] = DTP_rvdate.Value;
                        dr["total"] = cash;
                        dr["narration"] = txt_narration.Text.ToString();
                        dr["discount"] = disc;
                        dr["netamount"] = netamount;
                        dr["discp"] = discp;
                        dr.EndEdit();
                        Globals.cmdbuilder = new OleDbCommandBuilder(ad);
                        ad.UpdateCommand = Globals.cmdbuilder.GetUpdateCommand();
                        int stat = ad.Update(ds.Tables[0]);
                        if (stat > 0)
                        {

                            Globals.DeleteTransactions(rcno, Globals.GetEntryID("PAYMENT VOUCHER"));
                            OleDbCommand cmd = new OleDbCommand("delete from pv_part where entryno=" + txt_rvno.Text, Globals.con);
                            cmd.ExecuteScalar();
                            //re-insert records
                            Globals.F5PVPA();
                            Globals.cmdbuilder = new System.Data.OleDb.OleDbCommandBuilder(Globals.PVPartAdapter);
                            DataGridViewRowCollection rows = (DataGridViewRowCollection)dataGridView1.Rows;
                            dr = null;
                            foreach (DataGridViewRow row in rows)
                            {
                                cracid = 0;
                                drac = row.Cells[RECFRM.Index].FormattedValue.ToString();
                                if (drac != null)
                                {
                                    if (drac.Contains("|"))
                                    {
                                        string[] strArr = new string[5];
                                        char[] splitchar = { '|' };
                                        strArr = drac.Split(splitchar);
                                        drac = strArr[0];
                                    }
                                    cracid = Globals.GetAccountID(drac);
                                    if (cracid > 0 && dracid > 0)
                                    {

                                        double.TryParse(row.Cells[CASH1.Index].FormattedValue.ToString(), out cash);
                                        dr = Globals.PVPartDataSet.Tables[0].NewRow();
                                        dr["entryno"] = rcno;
                                        dr["drac"] = cracid;
                                        dr["amount"] = cash;
                                        Globals.PVPartDataSet.Tables[0].Rows.Add(dr);
                                        Globals.PVPartAdapter.InsertCommand = Globals.cmdbuilder.GetInsertCommand();
                                        Globals.PVPartAdapter.Update(Globals.PVPartDataSet.Tables[0]);
                                        Globals.AddTransactions(DTP_rvdate.Value.ToShortDateString(), cracid, dracid, 101, eno: rcno, dr: cash);
                                        Globals.AddTransactions(DTP_rvdate.Value.ToShortDateString(), dracid, cracid, 101, eno: rcno, cr: cash);

                                    }
                                }
                            }
                            MessageBox.Show("Payment Edited");
                            Globals.AppEvents.NewEvent(new Events(DateTime.Now, "Payment Voucher", rcno.ToString(), "Edited"));
                            Globals.history.Subscribe(Globals.AppEvents);
                            btn_clear_Click(sender, e);
                        }
                    }
                    //
                }
                catch { }
            }
            else
            {

            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res = new DialogResult();
                res = MessageBox.Show("Do you want to delete the Payment[" + txt_rvno.Text + "]", "Edit Receipt", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    Globals.F5PVIN();
                    Globals.PVinfoView.Sort = "entryno";
                    int rid = Globals.PVinfoView.Find(txt_rvno.Text);
                    if (rid != -1)
                    {
                        OleDbCommand cmd = new OleDbCommand("delete from  pv_info where  entryno=" + txt_rvno.Text, Globals.con);
                        cmd.ExecuteScalar();

                        Globals.DeleteTransactions(int.Parse(txt_rvno.Text.ToString()), 101);
                        MessageBox.Show("Paymeny Voucher [" + txt_rvno.Text + "]" + " Deleted");
                        Globals.AppEvents.NewEvent(new Events(DateTime.Now, "Payment Voucher", txt_rvno.Text.ToString(), "Deleted"));
                        Globals.history.Subscribe(Globals.AppEvents);
                        MessageBox.Show("Entry deleted");
                        btn_clear_Click(sender, e);
                    }
                }
            }

            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString());
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void btn_save_Click(object sender, EventArgs e)
        {
            //save
            DataRow dr;
            int rcno;
            int dracid;
            if (txt_acname.Text != "" && txt_netamount.Text != "")
            {
                try
                {
                    Globals.F5PVIN();

                    drac = txt_acname.Text.ToString().ToUpper();
                    if (drac.Contains("|"))
                    {
                        string[] strArr = new string[5];
                        char[] splitchar = { '|' };
                        strArr = drac.Split(splitchar);
                        drac = strArr[0];
                    }

                    dracid = Globals.GetAccountID(drac);
                    double.TryParse(txt_netamount.Text.ToString(), out netamount);
                    double.TryParse(txt_totalCash.Text.ToString(), out cash);
                    int.TryParse(txt_rvno.Text.ToString(), out rcno);
                    double.TryParse(disc_perc.Text.ToString(), out discp);
                    double.TryParse(txt_disc_amount.Text.ToString(), out disc);

                    Globals.cmdbuilder = new System.Data.OleDb.OleDbCommandBuilder(Globals.PVinfoAdapter);
                    if (dracid > 0)
                    {
                        dr = Globals.PVinfoDataSet.Tables[0].NewRow();
                        dr["entryno"] = rcno;
                        dr["crac"] = dracid;
                        dr["pvdate"] = DTP_rvdate.Value.ToLongDateString();
                        dr["total"] = cash;
                        dr["narration"] = txt_narration.Text.ToString();
                        dr["discount"] = disc;
                        dr["netamount"] = netamount;
                        dr["discp"] = discp;
                        Globals.PVinfoDataSet.Tables[0].Rows.Add(dr);
                        Globals.PVinfoAdapter.InsertCommand = Globals.cmdbuilder.GetInsertCommand();
                        int stat = Globals.PVinfoAdapter.Update(Globals.PVinfoDataSet.Tables[0]);
                        if (stat > 0)
                        {
                            Globals.F5PVPA();
                            Globals.cmdbuilder = new System.Data.OleDb.OleDbCommandBuilder(Globals.PVPartAdapter);
                            DataGridViewRowCollection rows = (DataGridViewRowCollection)dataGridView1.Rows;
                            dr = null;

                            foreach (DataGridViewRow row in rows)
                            {
                                cracid = 0;
                                drac = row.Cells[RECFRM.Index].FormattedValue.ToString();
                                if (drac.Contains("|"))
                                {
                                    string[] strArr = new string[5];
                                    char[] splitchar = { '|' };
                                    strArr = drac.Split(splitchar);
                                    drac = strArr[0];
                                }
                                cracid = Globals.GetAccountID(drac);
                                if ((cracid > 0 && dracid > 0))
                                {

                                    double.TryParse(row.Cells[CASH1.Index].FormattedValue.ToString(), out cash);
                                    dr = Globals.PVPartDataSet.Tables[0].NewRow();
                                    dr["entryno"] = rcno;
                                    dr["drac"] = cracid;
                                    dr["amount"] = cash;
                                    Globals.PVPartDataSet.Tables[0].Rows.Add(dr);
                                    Globals.PVPartAdapter.InsertCommand = Globals.cmdbuilder.GetInsertCommand();
                                    Globals.PVPartAdapter.Update(Globals.PVPartDataSet.Tables[0]);
                                    Globals.AddTransactions(DTP_rvdate.Value.ToShortDateString(), cracid, dracid, 101, eno: rcno, dr: cash);
                                    Globals.AddTransactions(DTP_rvdate.Value.ToShortDateString(), dracid, cracid, 101, eno: rcno, cr: cash);
                                }

                            }
                            MessageBox.Show("Payment successfully entered");
                            Globals.AppEvents.NewEvent(new Events(DateTime.Now, "Payment Voucher", rcno.ToString(), "Saved"));
                            Globals.history.Subscribe(Globals.AppEvents);
                            btn_clear_Click(sender, e);
                        }
                    }
                }
                catch (ArgumentOutOfRangeException e2)
                {
                    MessageBox.Show(e2.Message.ToString());
                }
            }
            else
            {
                MessageBox.Show("Enter data corrently and try again !");
            }
        }

        private void txt_findrcno_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txt_findrcno_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                int no; int.TryParse(txt_findrcno.Text.ToString(), out no);
                if (no > 0)
                {
                    button_FIND_Click(sender, e);
                }
                else
                {
                    txt_findrcno.Text = "";
                }
            }
        }

        private void txt_findrcno_KeywwwDown(object sender, KeyEventArgs e)
        {

        }

        private void btn_delete_Click_1(object sender, EventArgs e)
        {

        }

        private void btn_print_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            //Move First
            try
            {
                Globals.F5PVIN();
                if (Globals.PVinfoView.Count > 0)
                {
                    txt_findrcno.Text = Globals.PVinfoView[0]["entryno"].ToString();
                    btn_clear_Click(sender, e);
                    Find(int.Parse(txt_findrcno.Text.ToString()));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message.ToString());
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //Move Last
            try
            {
                Globals.F5PVIN();
                if (Globals.PVinfoView.Count > 0)
                {
                    txt_findrcno.Text = Globals.PVinfoView[Globals.PVinfoView.Count - 1]["entryno"].ToString();
                    btn_clear_Click(sender, e);
                    Find(int.Parse(txt_findrcno.Text.ToString()));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message.ToString());
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //Previous
            try
            {

                Globals.F5PVIN();
                if (Globals.PVinfoView.Count > 0)
                {
                    int inv = 0; int.TryParse(txt_findrcno.Text.ToString(), out inv);
                Recheck:
                    if (inv > 0)
                    {

                        inv--;
                        if (Globals.iseno(inv, Globals.DB_TABLES[1011]) == 1)
                        {
                            Globals.F5PVIN();
                            Globals.PVinfoView.Sort = "entryno";
                            int eno = Globals.PVinfoView.Find(inv);

                            if (eno != -1)
                            {
                                txt_findrcno.Text = Globals.PVinfoView[eno]["entryno"].ToString();
                                btn_clear_Click(sender, e);
                                Find(int.Parse(txt_findrcno.Text.ToString()));
                                txt_findrcno.Text = txt_rvno.Text;
                            }
                            else
                            {
                                inv--;
                            }

                        }
                        else
                        {
                            MessageBox.Show("No more Vouchers found");
                        }

                    }
                    else
                    {

                        button14_Click(sender, e);

                    }

                }
            }
            catch (Exception e1)
            {
                Console.WriteLine("Error:" + e1.Message.ToString());
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //Move Next
            try
            {

                Globals.F5PVIN();
                if (Globals.PVinfoView.Count > 0)
                {
                    int inv = 0; int.TryParse(txt_findrcno.Text.ToString(), out inv);
                Recheck:
                    if (inv > 0)
                    {

                        inv++;
                        if (Globals.iseno(inv, Globals.DB_TABLES[1011]) == 1)
                        {
                            Globals.F5PVIN();
                            Globals.PVinfoView.Sort = "entryno";
                            int eno = Globals.PVinfoView.Find(inv);

                            if (eno != -1)
                            {
                                txt_findrcno.Text = Globals.PVinfoView[eno]["entryno"].ToString();
                                btn_clear_Click(sender, e);
                                Find(int.Parse(txt_findrcno.Text.ToString()));
                                txt_findrcno.Text = txt_rvno.Text;
                            }
                            else
                            {
                                inv--;
                            }

                        }
                        else
                        {
                            MessageBox.Show("No more Vouchers found");
                        }

                    }
                    else
                    {

                        MessageBox.Show("No more Vouchers found");

                    }

                }
            }
            catch (Exception e1)
            {
                Console.WriteLine("Error:" + e1.Message.ToString());
            }
        }

        private void txt_bal_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_acname_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_acname_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
