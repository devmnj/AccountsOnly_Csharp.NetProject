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
    public partial class frm_JEntry : Form
    {
        double TDr, TCr, Drcash, Crcash, cash;
        int Cracid, Dracid;
        public frm_JEntry()
        {
            InitializeComponent();
            Globals.F5Account();
            txt_rvno.Text = Globals.GenericF5SLNO("JE_info", "entryno");
            NormalState();

        }
        private void FindState()
        {
            btn_edit.Enabled = true;
            btn_save.Enabled = false;
            btn_delete.Enabled = true;
            btn_edit.Enabled = true;
            btn_print.Enabled = true;
        }
        private void NormalState()
        {
            btn_edit.Enabled = false;
            btn_save.Enabled = true;
            btn_delete.Enabled = false;
            btn_edit.Enabled = false;
            btn_print.Enabled = false;
        }
        private void frm_JEntry_Load(object sender, EventArgs e)
        {

        }
        private void GetTotal()
        {
            DataGridViewRowCollection rows = (DataGridViewRowCollection)dataGridView1.Rows;
            TDr = TCr = 0;
            foreach (DataGridViewRow row in rows)
            {
                if (row.Cells[2].Value != null)
                {
                    //Dr
                    double.TryParse(row.Cells[4].FormattedValue.ToString(), out cash);
                    TDr = TDr + cash;
                    //Cr
                    double.TryParse(row.Cells[2].Value.ToString(), out cash);
                    TCr = TCr + cash;
                }

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
                    txt_Dr.Text = string.Format("{0:0.00}", TDr);
                    txt_Cr.Text = string.Format("{0:0.00}", TCr);
                    lbl_amount.Text = string.Format("{0:0.00}", txt_Cr.Text); 
                }


                if (e.RowIndex != 0)
                {
                    if (dataGridView1.Rows[e.RowIndex - 1].Cells[1].FormattedValue.ToString() == "")
                    {

                        txt_narration.Focus();
                        lbl_amount.Text  = txt_Cr.Text ;
                    }
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

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            AutoCompleteStringCollection autotext = new AutoCompleteStringCollection();
            TextBox auto = e.Control as TextBox;
            if (dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].Index == 1 || dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].Index == 3)
            {

                AutoCompleteStringCollection autotxt = new AutoCompleteStringCollection();
                //DataTable tb;
                //string[] col = { "acname" };
                //tb=Globals.AccountView.ToTable(false, col); 
                foreach (DataRowView row in Globals.AccountView)
                {
                    autotext.Add(row["acname"].ToString() + " | " + row["acid"].ToString());
                }
               
                
                auto.AutoCompleteMode = AutoCompleteMode.Suggest;
                auto.AutoCompleteSource = AutoCompleteSource.CustomSource;
                auto.AutoCompleteCustomSource = autotext;
                //auto.AutoCompleteCustomSource = tb;
            }
            else
            {
                auto.AutoCompleteMode = AutoCompleteMode.None;
                auto.AutoCompleteSource = AutoCompleteSource.None;
                auto.AutoCompleteCustomSource = null;

            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            //save
            DataRow dr;
            int rcno;
            string acc;
            double.TryParse(txt_Cr.Text.ToString(), out TCr);
            double.TryParse(txt_Dr.Text.ToString(), out TDr);

            if (TDr == TCr && TCr != 0 && TDr != 0)
            {
                try
                {
                    Globals.F5JEIN();


                    int.TryParse(txt_rvno.Text.ToString(), out rcno);


                    Globals.cmdbuilder = new System.Data.OleDb.OleDbCommandBuilder(Globals.JEInfoAdapter);

                    dr = Globals.JEInfoDataSet.Tables[0].NewRow();
                    dr["entryno"] = rcno;
                    dr["jdate"] = DTP_rvdate.Value.ToShortDateString();
                    dr["dr"] = TDr;
                    dr["narration"] = txt_narration.Text.ToString();
                    dr["Cr"] = TCr;

                    Globals.JEInfoDataSet.Tables[0].Rows.Add(dr);
                    Globals.JEInfoAdapter.InsertCommand = Globals.cmdbuilder.GetInsertCommand();
                    int stat = Globals.JEInfoAdapter.Update(Globals.JEInfoDataSet.Tables[0]);
                    if (stat > 0)
                    {
                        Globals.F5JEPart();
                        Globals.cmdbuilder = new System.Data.OleDb.OleDbCommandBuilder(Globals.JEPartAdapter);
                        DataGridViewRowCollection rows = (DataGridViewRowCollection)dataGridView1.Rows;
                        dr = null;

                        foreach (DataGridViewRow row in rows)
                        {
                            Cracid = 0;
                            Dracid = 0;
                            acc = row.Cells[RECFRM.Index].FormattedValue.ToString();
                            if (acc.Contains("|"))
                            {
                                string[] strArr = new string[5];
                                char[] splitchar = { '|' };
                                strArr = acc.Split(splitchar);
                                acc = strArr[0];
                            }
                            Cracid = Globals.GetAccountID(acc);

                            acc = row.Cells[ToAccount.Index].FormattedValue.ToString();
                            if (acc.Contains("|"))
                            {
                                string[] strArr = new string[5];
                                char[] splitchar = { '|' };
                                strArr = acc.Split(splitchar);
                                acc = strArr[0];
                            }
                            Dracid = Globals.GetAccountID(acc);

                            if ((Cracid > 0 && Dracid > 0))
                            {

                                double.TryParse(row.Cells[CRAMOUNT.Index].FormattedValue.ToString(), out Crcash);
                                dr = Globals.JEPartDataSet.Tables[0].NewRow();
                                dr["entryno"] = rcno;
                                dr["crac"] = Cracid;
                                dr["cram"] = Crcash;
                                double.TryParse(row.Cells[Dramount.Index].FormattedValue.ToString(), out Drcash);
                                dr["dram"] = Drcash;
                                dr["drac"] = Dracid;
                                Globals.JEPartDataSet.Tables[0].Rows.Add(dr);
                                Globals.JEPartAdapter.InsertCommand = Globals.cmdbuilder.GetInsertCommand();
                                Globals.JEPartAdapter.Update(Globals.JEPartDataSet.Tables[0]);
                                Globals.TrFunctions.AddTransactions(DTP_rvdate.Value.ToShortDateString(), Cracid, Dracid, 102, eno: rcno, cr: Crcash);
                                Globals.TrFunctions.AddTransactions(DTP_rvdate.Value.ToShortDateString(), Dracid, Cracid, 102, eno: rcno, dr: cash);
                            }

                        }
                        Globals.AppEvents.NewEvent(new Events(DateTime.Now, "Journal Entry Posted", rcno.ToString(), "Save"));
                        Globals.history.Subscribe(Globals.AppEvents);
                        MessageBox.Show("Journal Entry Posted");
                        btn_clear_Click(sender, e);
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
        private void Find(int rcno)
        {
            Globals.F5JEIN();

            Globals.F5JEPart();
            Globals.JEInfoView.Sort = "entryno";
            int rid = Globals.JEInfoView.Find(rcno);
            if (rid != -1)
            {




                txt_narration.Text = Globals.JEInfoView[rid]["narration"].ToString();
                txt_rvno.Text = rcno.ToString();


                txt_Cr.Text = Globals.JEInfoView[rid]["Cr"].ToString();
                txt_Dr.Text = Globals.JEInfoView[rid]["Dr"].ToString();
                lbl_amount.Text = txt_Cr.Text;
                DTP_rvdate.Value = DateTime.Parse(Globals.JEInfoView[rid]["jdate"].ToString());
                int k = 0;
                Globals.JEPartView.Sort = "entryno";
                DataRowView[] rows = Globals.JEPartView.FindRows(rcno);
                foreach (DataRowView r in rows)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.CurrentCell = dataGridView1.Rows[k].Cells[SLNO.Index]; k++;
                    dataGridView1.CurrentRow.Cells[SLNO.Index].Value = dataGridView1.CurrentRow.Index + 1;
                    dataGridView1.CurrentRow.Cells[RECFRM.Index].Value = Globals.GetAccountName((int)r["crac"]);
                    dataGridView1.CurrentRow.Cells[CRAMOUNT.Index].Value = r["cram"];
                    dataGridView1.CurrentRow.Cells[ToAccount.Index].Value = Globals.GetAccountName((int)r["drac"]);
                    dataGridView1.CurrentRow.Cells[Dramount.Index].Value = r["dram"];
                    dataGridView1.CurrentRow.Cells[CRID.Index].Value = r["crac"];
                    dataGridView1.CurrentRow.Cells[DRID.Index].Value = r["Drac"].ToString();
                }


                Globals.AppEvents.NewEvent(new Events(DateTime.Now, "Journal Entry", rcno.ToString(), "Open"));
                Globals.history.Subscribe(Globals.AppEvents);
                FindState();
            }
            else
            {
                MessageBox.Show("Journal not found");

            }
        }
        private void btn_clear_Click(object sender, EventArgs e)
        {
            NormalState();
            txt_rvno.Clear();
            Globals.F5Account();
            txt_rvno.Text = Globals.GenericF5SLNO("je_info", "entryno");
            DTP_rvdate.Value = DateTime.Now;
            txt_narration.Clear();
            txt_Cr.Clear(); txt_Dr.Clear();
            dataGridView1.Rows.Clear();
            lbl_amount.Text = "";

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
            string acc = null;
            DialogResult res = new DialogResult();
            DataSet ds = new DataSet();
            OleDbDataAdapter ad;
            DataView dv = new DataView();
            DataRow dr;
            res = MessageBox.Show("Do you want to edit the Journal", "Edit Journal", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {

                try
                {
                    ad = new OleDbDataAdapter("select * from je_info where entryno=" + txt_rvno.Text, Globals.con);
                    ad.Fill(ds, "rv_info");
                    dv = new DataView(ds.Tables[0]);


                    int rcno;
                    int dracid = Globals.GetAccountID(acc);


                    int.TryParse(txt_rvno.Text.ToString(), out rcno);
                    double.TryParse(txt_Cr.Text.ToString(), out TCr);
                    double.TryParse(txt_Dr.Text.ToString(), out TDr);

                    if (TDr == TCr && TCr != 0 && TDr != 0)
                    {
                        dr = (DataRow)dv.Table.Rows[0];
                        dr.BeginEdit();
                        dr["entryno"] = rcno;
                        dr["jdate"] = DTP_rvdate.Value.ToShortDateString();
                        dr["dr"] = TDr; dr["cr"] = TCr;
                        dr["narration"] = txt_narration.Text.ToString();
                        dr.EndEdit();
                        Globals.cmdbuilder = new OleDbCommandBuilder(ad);
                        ad.UpdateCommand = Globals.cmdbuilder.GetUpdateCommand();
                        int stat = ad.Update(ds.Tables[0]);
                        if (stat > 0)
                        {

                            OleDbCommand cmd = new OleDbCommand("delete from je_part where entryno=" + txt_rvno.Text, Globals.con);
                            cmd.ExecuteScalar();
                            Globals.TrFunctions.DeleteTransactions(int.Parse(txt_rvno.Text.ToString()), 102);
                            //re-insert records
                            Globals.F5JEPart();
                            Globals.cmdbuilder = new System.Data.OleDb.OleDbCommandBuilder(Globals.JEPartAdapter);
                            DataGridViewRowCollection rows = (DataGridViewRowCollection)dataGridView1.Rows;
                            dr = null;
                            foreach (DataGridViewRow row in rows)
                            {
                                Cracid = 0;
                                acc = row.Cells[RECFRM.Index].FormattedValue.ToString();
                                if (acc.Contains("|"))
                                {
                                    string[] strArr = new string[5];
                                    char[] splitchar = { '|' };
                                    strArr = acc.Split(splitchar);
                                    acc = strArr[0];
                                }
                                Cracid = Globals.GetAccountID(acc);
                                Dracid = 0;

                                acc = row.Cells[ToAccount.Index].FormattedValue.ToString();
                                if (acc.Contains("|"))
                                {
                                    string[] strArr = new string[5];
                                    char[] splitchar = { '|' };
                                    strArr = acc.Split(splitchar);
                                    acc = strArr[0];
                                }
                                Dracid = Globals.GetAccountID(acc);




                                if (Cracid > 0 && Dracid > 0)
                                {

                                    double.TryParse(row.Cells[CRAMOUNT.Index].FormattedValue.ToString(), out Crcash);
                                    double.TryParse(row.Cells[Dramount.Index].FormattedValue.ToString(), out Drcash);
                                    dr = Globals.JEPartDataSet.Tables[0].NewRow();
                                    dr["entryno"] = rcno;
                                    dr["crac"] = Cracid;
                                    dr["cram"] = Crcash;
                                    dr["drac"] = Dracid;
                                    dr["dram"] = Drcash;
                                    Globals.JEPartDataSet.Tables[0].Rows.Add(dr);
                                    Globals.JEPartAdapter.InsertCommand = Globals.cmdbuilder.GetInsertCommand();
                                    Globals.JEPartAdapter.Update(Globals.JEPartDataSet.Tables[0]);
                                    Globals.TrFunctions.AddTransactions(DTP_rvdate.Value.ToShortDateString(), Cracid, Dracid, 102, eno: rcno, cr: Crcash);
                                    Globals.TrFunctions.AddTransactions(DTP_rvdate.Value.ToShortDateString(), Dracid, Cracid, 102, eno: rcno, dr: Drcash);

                                }
                            }
                            Globals.AppEvents.NewEvent(new Events(DateTime.Now, "Journal Entry", rcno.ToString(), "Edited"));
                            Globals.history.Subscribe(Globals.AppEvents); MessageBox.Show("Journal Edited");
                            btn_clear_Click(sender, e);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Enter Data Correctly");
                    }
                    //
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.Message.ToString());
                }
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DialogResult res = new DialogResult();
            res = MessageBox.Show("Do you want to delete the Journal[" + txt_rvno.Text + "]", "Edit Journal", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                Globals.F5JEIN();
                Globals.JEInfoView.Sort = "entryno";
                int rid = Globals.JEInfoView.Find(txt_rvno.Text);
                if (rid != -1)
                {
                    OleDbCommand cmd = new OleDbCommand("delete from  je_info where  entryno=" + txt_rvno.Text, Globals.con);
                    cmd.ExecuteScalar();
                    Globals.TrFunctions.DeleteTransactions(int.Parse(txt_rvno.Text.ToString()), 102);
                    MessageBox.Show("Journal Entry [" + txt_rvno.Text + "]" + " Deleted");
                    Globals.AppEvents.NewEvent(new Events(DateTime.Now, "Journal Entry", txt_rvno.Text.ToString(), "Deleted"));
                    Globals.history.Subscribe(Globals.AppEvents);

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Move First
            try
            {
                Globals.F5JEIN();
                if (Globals.JEInfoView.Count > 0)
                {
                    txt_findrcno.Text = Globals.JEInfoView[0]["entryno"].ToString();
                    btn_clear_Click(sender, e);
                    Find(int.Parse(txt_findrcno.Text.ToString()));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Move Last
            try
            {
                Globals.F5JEIN();
                if (Globals.JEInfoView.Count > 0)
                {
                    txt_findrcno.Text = Globals.JEInfoView[Globals.JEInfoView.Count - 1]["entryno"].ToString();
                    btn_clear_Click(sender, e);
                    Find(int.Parse(txt_findrcno.Text.ToString()));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Previous
            try
            {

                Globals.F5JEIN();
                if (Globals.JEInfoView.Count > 0)
                {
                    int inv = 0; int.TryParse(txt_findrcno.Text.ToString(), out inv);
                Recheck:
                    if (inv > 0)
                    {

                        inv--;
                        if (Globals.iseno(inv, Globals.DB_TABLES[1021]) == 1)
                        {
                            Globals.F5JEIN();
                            Globals.JEInfoView.Sort = "entryno";
                            int eno = Globals.JEInfoView.Find(inv);

                            if (eno != -1)
                            {
                                txt_findrcno.Text = Globals.JEInfoView[eno]["entryno"].ToString();
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
                        
                        button3_Click (sender, e);

                    }

                }
            }
            catch (Exception e1)
            {
                Console.WriteLine("Error:" + e1.Message.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Move Next
            try
            {

                Globals.F5JEIN();
                if (Globals.JEInfoView.Count > 0)
                {
                    int inv = 0; int.TryParse(txt_findrcno.Text.ToString(), out inv);
                Recheck:
                    if (inv > 0)
                    {

                        inv++;
                        if (Globals.iseno(inv, Globals.DB_TABLES[1021]) == 1)
                        {
                            Globals.F5JEIN();
                            Globals.JEInfoView.Sort = "entryno";
                            int eno = Globals.JEInfoView.Find(inv);

                            if (eno != -1)
                            {
                                txt_findrcno.Text = Globals.JEInfoView[eno]["entryno"].ToString();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
 this.Close();

        }
    }
}
