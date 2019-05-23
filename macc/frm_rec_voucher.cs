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
    public partial class frm_rec_voucher : Form,KeyBehaviour
    {
        AutoCompleteStringCollection autotext = new AutoCompleteStringCollection();
        double disc = 0, cash, totalCash;
        int cracid;
        //
        string drac;
        double netamount, discp;
        public frm_rec_voucher()
        {
            InitializeComponent();
            Globals.F5Account();
            NormalState();
            txt_rvno.Text = Globals.GenericF5SLNO("rv_info", "entryno");
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

        private void Form1_Load(object sender, EventArgs e)
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
            //dataGridView1.EndEdit();

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
                else
                {
                    string n = dataGridView1.Rows[e.RowIndex].Cells[1].FormattedValue.ToString().ToString();
                    if (n.Contains("|"))
                    {
                        string[] strArr = new string[5];
                        char[] splitchar = { '|' };
                        strArr = n.Split(splitchar);
                        n = strArr[0];
                    }

                    int lid = Globals.GetAccountID(n);



                    List<double> b = Globals.GetOB(DTP_rvdate.Value.AddDays(1), lid);
                    if (b[0] > 0)

                    {
                        txt_cr.Visible = true;
                        txt_cr.Text = string.Format("{0:0.00}", b[0]) + " Cr";
                    }
                    else if (b[1] > 0)
                    {
                        txt_cr.Visible = true;
                        txt_cr.Text = string.Format("{0:0.00}", b[1]) + " Dr";
                    }

                    else
                    {
                        {

                            txt_cr.Visible=false  ;
                        }

                    }
                }
            }
            //else
            //{
            //    disc_perc.Focus();
            //}

        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                dataGridView1.EndEdit();
                if (dataGridView1.CurrentCell.Value==null )
                {
                    disc_perc.Focus();
                }



            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

        }

        private void txt_acname_TextChanged(object sender, EventArgs e)
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
            Globals.F5RVIN();
            dataGridView1.totalCash = 0;
            Globals.F5RVPA();
            Globals.RVInfoView.Sort = "entryno";
            int rid = Globals.RVInfoView.Find(rcno);
            if (rid != -1)
            {


                txt_acname.Text = Globals.GetAccountName((int)Globals.RVInfoView[rid]["drac"]) + "|" + Globals.RVInfoView[rid]["drac"];
                txt_disc_amount.Text = Globals.RVInfoView[rid]["discount"].ToString();
                txt_narration.Text = Globals.RVInfoView[rid]["narration"].ToString();
                txt_rvno.Text = rcno.ToString();

                disc_perc.Text = Globals.RVInfoView[rid]["discp"].ToString();
                txt_totalCash.Text = Globals.RVInfoView[rid]["totalcash"].ToString();
                DTP_rvdate.Value = DateTime.Parse(Globals.RVInfoView[rid]["vdate"].ToString());
                int k = 0;
                Globals.RVPartView.Sort = "entryno";
                DataRowView[] rows = Globals.RVPartView.FindRows(rcno);
                foreach (DataRowView r in rows)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.CurrentCell = dataGridView1.Rows[k].Cells[SLNO.Index]; k++;
                    dataGridView1.CurrentRow.Cells[SLNO.Index].Value = dataGridView1.CurrentRow.Index + 1;
                    dataGridView1.CurrentRow.Cells[RECFRM.Index].Value = Globals.GetAccountName((int)r["crac"]);
                    dataGridView1.CurrentRow.Cells[CRID.Index].Value = r["crac"].ToString();
                    dataGridView1.CurrentRow.Cells[CASH1.Index].Value = r["amount"].ToString();

                }

                txt_netamount.Text = Globals.RVInfoView[rid]["netamount"].ToString();
                Globals.AppEvents.NewEvent(new Events(DateTime.Now, "Recept Voucher", rcno.ToString(), "Open"));
                Globals.history.Subscribe(Globals.AppEvents);
                FindState();
            }
            else
            {
                MessageBox.Show("Voucher not found");
                //Globals.AppEvents.NewEvent(new Events(DateTime.Now, "Receipt Voucher", rcno.ToString(), "Tried to Open"));
                //Globals.history.Subscribe(Globals.AppEvents); 
            }
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
                    Globals.F5RVIN();

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

                    Globals.cmdbuilder = new System.Data.OleDb.OleDbCommandBuilder(Globals.RVInfoAdapter);
                    if (dracid > 0)
                    {
                        dr = Globals.RVInfoDataSet.Tables[0].NewRow();
                        dr["entryno"] = rcno;
                        dr["drac"] = dracid;
                        dr["vdate"] = DTP_rvdate.Value.ToShortDateString();
                        dr["totalcash"] = cash;
                        dr["narration"] = txt_narration.Text.ToString();
                        dr["discount"] = disc;
                        dr["netamount"] = netamount;
                        dr["discp"] = discp;
                        Globals.RVInfoDataSet.Tables[0].Rows.Add(dr);
                        Globals.RVInfoAdapter.InsertCommand = Globals.cmdbuilder.GetInsertCommand();
                        int stat = Globals.RVInfoAdapter.Update(Globals.RVInfoDataSet.Tables[0]);
                        if (stat > 0)
                        {
                            Globals.F5RVPA();
                            Globals.cmdbuilder = new System.Data.OleDb.OleDbCommandBuilder(Globals.RVPartAdapter);
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
                                    dr = Globals.RVPartDataSet.Tables[0].NewRow();
                                    dr["entryno"] = rcno;
                                    dr["crac"] = cracid;
                                    dr["amount"] = cash;
                                    Globals.RVPartDataSet.Tables[0].Rows.Add(dr);
                                    Globals.RVPartAdapter.InsertCommand = Globals.cmdbuilder.GetInsertCommand();
                                    Globals.RVPartAdapter.Update(Globals.RVPartDataSet.Tables[0]);
                                    Globals.TrFunctions.AddTransactions(DTP_rvdate.Value.ToShortDateString(), cracid, dracid, eno: rcno, cr: cash);
                                    Globals.TrFunctions.AddTransactions(DTP_rvdate.Value.ToShortDateString(), dracid, cracid, eno: rcno, dr: cash);
                                }

                            }
                            Globals.AppEvents.NewEvent(new Events(DateTime.Now, "Recept Voucher", rcno.ToString(), "Save"));
                            Globals.history.Subscribe(Globals.AppEvents);
                            MessageBox.Show("Receipt successfully entered");
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

        private void btn_clear_Click(object sender, EventArgs e)
        {

            txt_rvno.Text=null; txt_acname.Text=null;
            txt_disc_amount.Text=null;
            txt_narration.Text=null;
            txt_netamount.Text=null;
            txt_cr.Text = null;
            txt_cr.Visible = false;
            disc_perc.Text=null;
            txt_totalCash.Text = null;
            txt_netamount.Text = null;
            txt_findrcno.Text = null;
            dataGridView1.Rows.Clear();
            //Globals.F5Account();
            txt_rvno.Text = Globals.GenericF5SLNO("rv_info", "entryno");
            AutoText();
            NormalState();
        }

        private void button_FIND_Click(object sender, EventArgs e)
        {
            if (txt_findrcno.Text.ToString() != "")
            {
                Find(int.Parse(txt_findrcno.Text.ToString()));
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            //EDIT
            DialogResult res = new DialogResult();
            DataSet ds = new DataSet();
            OleDbDataAdapter ad;
            DataView dv = new DataView();
            DataRow dr;
            res = MessageBox.Show("Do you want to edit the Receipt", "Edit Receipt", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {

                try
                {
                    ad = new OleDbDataAdapter("select * from rv_info where entryno=" + txt_rvno.Text, Globals.con);
                    ad.Fill(ds, "rv_info");
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
                        dr["drac"] = dracid;
                        dr["vdate"] = DTP_rvdate.Value.ToShortDateString();
                        dr["totalcash"] = cash;
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
                            Globals.TrFunctions.DeleteTransactions(rcno, 100);
                            OleDbCommand cmd = new OleDbCommand("delete from rv_part where entryno=" + txt_rvno.Text, Globals.con);
                            cmd.ExecuteScalar();
                            //re-insert records
                            Globals.F5RVPA();
                            Globals.cmdbuilder = new System.Data.OleDb.OleDbCommandBuilder(Globals.RVPartAdapter);
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
                                if (cracid > 0 && dracid > 0)
                                {

                                    double.TryParse(row.Cells[CASH1.Index].FormattedValue.ToString(), out cash);
                                    dr = Globals.RVPartDataSet.Tables[0].NewRow();
                                    dr["entryno"] = rcno;
                                    dr["crac"] = cracid;
                                    dr["amount"] = cash;
                                    Globals.RVPartDataSet.Tables[0].Rows.Add(dr);
                                    Globals.RVPartAdapter.InsertCommand = Globals.cmdbuilder.GetInsertCommand();
                                    Globals.RVPartAdapter.Update(Globals.RVPartDataSet.Tables[0]);
                                    Globals.TrFunctions.AddTransactions(DTP_rvdate.Value.ToShortDateString(), cracid, dracid, eno: rcno, cr: cash);
                                    Globals.TrFunctions.AddTransactions(DTP_rvdate.Value.ToShortDateString(), dracid, cracid, eno: rcno, dr: cash);

                                }
                            }
                            Globals.AppEvents.NewEvent(new Events(DateTime.Now, "Recept Voucher", rcno.ToString(), "Edited"));
                            Globals.history.Subscribe(Globals.AppEvents); MessageBox.Show("Receipt Edited");
                            btn_clear_Click(sender, e);
                        }
                    }
                    //
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.Message.ToString());
                }
            }
            else
            {

            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DialogResult res = new DialogResult();
            res = MessageBox.Show("Do you want to delete the Receipt[" + txt_rvno.Text + "]", "Edit Receipt", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                Globals.F5RVIN();
                Globals.RVInfoView.Sort = "entryno";
                int rid = Globals.RVInfoView.Find(txt_rvno.Text);
                if (rid != -1)
                {
                    OleDbCommand cmd = new OleDbCommand("delete from  rv_info where  entryno=" + txt_rvno.Text, Globals.con);
                    cmd.ExecuteScalar();
                    Globals.TrFunctions.DeleteTransactions(int.Parse(txt_rvno.Text.ToString()), 100);
                    MessageBox.Show("Receipt [" + txt_rvno.Text + "]" + " Deleted");
                    Globals.AppEvents.NewEvent(new Events(DateTime.Now, "Recept Voucher", txt_rvno.Text.ToString(), "Deleted"));
                    Globals.history.Subscribe(Globals.AppEvents);
                    MessageBox.Show("Entry deleted");
                    btn_clear_Click(sender, e);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txt_findrcno_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txt_findrcno_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_findrcno_KeyPress(object sender, KeyPressEventArgs e)
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

        private void disc_perc_TextChanged(object sender, EventArgs e)
        {

        }

        private void DTP_rvdate_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Move Last
            try
            {
                Globals.F5RVIN ();
                if (Globals.RVInfoView.Count > 0)
                {
                    txt_findrcno.Text = Globals.RVInfoView[Globals.RVInfoView.Count - 1]["entryno"].ToString();
                    btn_clear_Click(sender, e);
                    Find(int.Parse(txt_findrcno.Text.ToString()));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Move First
            try
            {
                Globals.F5RVIN();
                if (Globals.RVInfoView.Count > 0)
                {
                    txt_findrcno.Text = Globals.RVInfoView[0]["entryno"].ToString();
                    btn_clear_Click(sender, e);
                    Find(int.Parse(txt_findrcno.Text.ToString()));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Move Next
            try
            {

                Globals.F5RVIN();
                if (Globals.RVInfoView.Count > 0)
                {
                    int inv = 0; int.TryParse(txt_findrcno.Text.ToString(), out inv);
                    Recheck:
                    if (inv > 0)
                    {

                        inv++;
                        if (Globals.iseno(inv, Globals.DB_TABLES[1011]) == 1)
                        {
                            Globals.F5RVIN();
                            Globals.RVInfoView.Sort = "entryno";
                            int eno = Globals.RVInfoView.Find(inv);

                            if (eno != -1)
                            {
                                txt_findrcno.Text = Globals.RVInfoView[eno]["entryno"].ToString();
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

        private void button2_Click(object sender, EventArgs e)
        {
            //Previous
            try
            {

                Globals.F5RVIN();
                if (Globals.RVInfoView.Count > 0)
                {
                    int inv = 0; int.TryParse(txt_findrcno.Text.ToString(), out inv);
                    Recheck:
                    if (inv > 0)
                    {

                        inv--;
                        if (Globals.iseno(inv, Globals.DB_TABLES[1011]) == 1)
                        {
                            Globals.F5RVIN();
                            Globals.RVInfoView.Sort = "entryno";
                            int eno = Globals.RVInfoView.Find(inv);

                            if (eno != -1)
                            {
                                txt_findrcno.Text = Globals.RVInfoView[eno]["entryno"].ToString();
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

                        button3_Click(sender, e);

                    }

                }
            }
            catch (Exception e1)
            {
                Console.WriteLine("Error:" + e1.Message.ToString());
            }
        }

        private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
           // MessageBox.Show("validation completed");
        }

        private void dataGridView1_Leave(object sender, EventArgs e)
        {
          
           // MessageBox.Show("has Left");
        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_acname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridView1.Focus();
            }
        }
    }
}
