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
    public partial class account_frm : Form
    {
        string[] strArr = new string[5];
        string acname, gdescription;
        int group;
        string[] takegid = new string[1];
        AutoCompleteStringCollection autotext = new AutoCompleteStringCollection();
        public account_frm()
        {
            InitializeComponent();
            Globals.F5Account();
            Autotext();
            GroupsToList();
        }
        private void FindButtonstate()
        {
            button4.Enabled = false;
            button5.Enabled = true;
            button2.Enabled = true;

        }
        private void NormalButtonstate()
        {
            button4.Enabled = true;
            button5.Enabled = false;
            button2.Enabled = false;
        }
        private void Autotext()
        {
            autotext.Clear();
            foreach (DataRowView row in Globals.AccountView)
            {
                autotext.Add(row["acname"].ToString() + " | " + row["acid"].ToString());
            }
            txt_name.Text = "";
            txt_name.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_name.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_name.AutoCompleteCustomSource = autotext;
        }

        private void GroupsToList()
        {
            Globals.F5Group();
            lst_groups.DataSource = null;
            lst_groups.Sorted = true;
            lst_groups.Items.Clear();
            lst_groups.Items.Add(" ");
            lst_groups.DataSource = Globals.GroupDataSet.Tables[0];
            lst_groups.DisplayMember = "gname";
            lst_groups.ValueMember = "gid";

        }

        private void account_frm_Load(object sender, EventArgs e)
        {
            System.Drawing.Size p = new Size(485, 275);
            this.Size = p;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //clear
            Globals.F5Account();
             Autotext();
             
            
            GroupsToList();
            textBox2.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            
            txt_note.Text = "";

            NormalButtonstate();
            txt_name.Focus();
            strArr[0] = "";
            strArr[1] = "";
            checkBox1.Checked = false;
            txt_street.Text = "";
            txt_place.Text = "";
            txt_city.Text = "";
            txt_pin.Text = "";
            txt_state.Text = "";
            txt_district.Text = "";
            txt_mob.Text = "";
            txt_phone.Text = "";
            txt_res.Text = "";
            txt_email.Text = "";
            txt_gst.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Save 17/April/18
            DataRow dr;
            Globals.F5Group();
            acname = txt_name.Text.ToString().Trim().ToUpper();
            string gpstr = lst_groups.Text.ToString().ToUpper();
            if (gpstr.Trim().Length < 1)
            {
                group = 0;
            }
            else
            {
                group = Globals.GetGroupID(gpstr);
            }

            gdescription = txt_note.Text.ToString();
            if (group != null)
            {
                try
                {
                    //OleDbCommand cmd = new OleDbCommand("insert into acgroup(gname,parent,[note]) values('" + gname +  "','" + gparent +  "','" + gdescription + "'" + ")", Globals.con);
                    //cmd.ExecuteScalar();
                    double obdr = 0;
                    double.TryParse(textBox1.Text.ToString(), out obdr);
                    double obcr = 0;
                    double.TryParse(textBox1.Text.ToString(), out obcr);
                    Globals.F5Account();
                    dr = Globals.AccountDataSet.Tables[0].NewRow();
                    dr["acname"] = acname;
                    dr["group"] = group;
                    dr["note"] = gdescription;
                    if (checkBox1.Checked == true)
                    {
                        dr["extended"] = true;
                    }
                    else
                    {
                        dr["extended"] = false;
                    }

                    Globals.cmdbuilder = new System.Data.OleDb.OleDbCommandBuilder(Globals.AccountAdapter);
                    Globals.cmdbuilder.QuotePrefix = "[";
                    Globals.cmdbuilder.QuoteSuffix = "]";
                    Globals.AccountDataSet.Tables[0].Rows.Add(dr);
                    Globals.AccountAdapter.InsertCommand = Globals.cmdbuilder.GetInsertCommand();
                    int stat = Globals.AccountAdapter.Update(Globals.AccountDataSet.Tables[0]);
                    if (stat > 0)
                    {
                        if (obdr > 0) Globals.AddTransactions(dateTimePicker1.Value.ToShortDateString(), Globals.GetAccountID(acname), Globals.GetAccountID(acname), 0, 0, dr: obdr);
                        if (obcr > 0) Globals.AddTransactions(dateTimePicker1.Value.ToShortDateString(), Globals.GetAccountID(acname), Globals.GetAccountID(acname), 0, 0, 0, obcr);
                        if (checkBox1.Checked == true)
                        {
                            Globals.F5Account_Particular();
                            dr = null;
                            dr = Globals.Account_PartDataSet.Tables[0].NewRow();
                            dr["street"] = txt_street.Text.ToString().ToUpper();
                            dr["place"] = txt_place.Text.ToString().ToUpper();
                            dr["city"] = txt_city.Text.ToString().ToUpper();
                            dr["district"] = txt_district.Text.ToString().ToUpper();
                            dr["state"] = txt_state.Text.ToString().ToUpper();
                            dr["gst"] = txt_gst.Text.ToString().ToUpper();
                            dr["dlno"] = "@";
                            dr["email"] = txt_email.Text.ToString().ToUpper();
                            dr["phone"] = txt_res.Text.ToString().ToUpper();
                            dr["mobile"] = txt_mob.Text.ToString().ToUpper();
                            dr["landline"] = txt_phone.Text.ToString().ToUpper();
                            dr["acid"] = Globals.GetAccountID(txt_name.Text.ToString());
                            dr["pin"] = txt_pin.Text.ToString().ToUpper();
                            OleDbCommandBuilder cmd = new OleDbCommandBuilder(Globals.Account_PartAdapter);
                            //Globals.cmdbuilder.QuotePrefix = "[";
                            //Globals.cmdbuilder.QuoteSuffix = "]";
                            Globals.Account_PartDataSet.Tables[0].Rows.Add(dr);
                            Globals.Account_PartAdapter.InsertCommand = cmd.GetInsertCommand();
                            int sta = Globals.Account_PartAdapter.Update(Globals.Account_PartDataSet.Tables[0]);
                        }



                        MessageBox.Show("Account Information saved");
                        button1_Click(sender, e);
                    }
                }

                catch (Exception e1)
                {
                    Console.WriteLine("Error:" + e1.ToString());

                    MessageBox.Show("DataBase operation interrupted");
                }
            }
            else
            {
                MessageBox.Show("Something missing");
            }
        }

        private void txt_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && button4.Enabled == true)
            {
                if (txt_name.Text.Contains("|"))
                {
                    string str = null;
                    Globals.F5Account();
                    int count = 0;
                    str = txt_name.Text.ToString();
                    char[] splitchar = { '|' };
                    strArr = str.Split(splitchar);
                    Globals.AccountView.Sort = "acid";
                    

                    //  txt_gid.Text = strArr[1];
                    List<string> list = new List<string>();
                    int stat = Globals.AccountView.Find(strArr[1]);
                    if (stat >= 0)
                        
                    {
                    
                        
                        this.FindButtonstate();

                        txt_note.Text = Globals.AccountView[stat]["note"].ToString();
                        int takeparent = int.Parse(Globals.AccountView[stat]["group"].ToString());
                        list = Globals.OBToList(int.Parse(strArr[1]));
                        textBox1.Text = list[0];
                        dateTimePicker1.Value = DateTime.Parse(list[1]);
                        if (takeparent > 0)
                        {
                            lst_groups.Text = Globals.GetGroupName(takeparent);


                        }
                        else
                        {
                            lst_groups.Text = " ";
                        }
                        checkBox1.Checked = false;

                        if ((bool)Globals.AccountView[stat]["extended"] == true)
                        {
                            checkBox1.Checked = true;
                            System.Drawing.Size p = new Size(485, 503);
                            this.Size = p;
                            Globals.F5Account_Particular();
                            Globals.Account_PartView.Sort = "acid";
                            int s = Globals.Account_PartView.Find(strArr[1]);
                            if (s >= 0)
                            {
                                txt_street.Text = Globals.Account_PartView[s]["street"].ToString();
                                txt_place.Text = Globals.Account_PartView[s]["place"].ToString();
                                txt_city.Text = Globals.Account_PartView[s]["city"].ToString();
                                txt_state.Text = Globals.Account_PartView[s]["state"].ToString();
                                txt_district.Text = Globals.Account_PartView[s]["district"].ToString();
                                txt_gst.Text = Globals.Account_PartView[s]["gst"].ToString();
                                txt_pin.Text = Globals.Account_PartView[s]["pin"].ToString();
                                txt_phone.Text = Globals.Account_PartView[s]["phone"].ToString();
                                txt_mob.Text = Globals.Account_PartView[s]["mobile"].ToString();
                                txt_res.Text = Globals.Account_PartView[s]["landline"].ToString();
                                txt_email.Text = Globals.Account_PartView[s]["email"].ToString();

                            }
                        }
                         

                        lst_groups.Focus();

                    }



                }

            }
        }

        private void txt_name_Enter(object sender, EventArgs e)
        {
            if (button4.Enabled == false)
            {
                txt_name.Text = strArr[0];
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Edit
            DataRow dr;
            DialogResult result = new System.Windows.Forms.DialogResult();
            int key = int.Parse(strArr[1].ToString());
            if (key > 0)
            {
                result = MessageBox.Show("Do you want Edit this Account", "Edit Accounts", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        Globals.F5Account();
                        Globals.AccountView.Sort = "acid";
                        DataRowView[] drv = Globals.AccountView.FindRows(strArr[1]);
                        double obdr = 0;
                        double.TryParse(textBox1.Text.ToString(), out obdr);
                        double obcr = 0;
                        double.TryParse(textBox1.Text.ToString(), out obcr);
                        dr = drv[0].Row;
                        dr.BeginEdit();
                        if (txt_name.Text.Contains("|"))
                        {
                            dr["acname"] = strArr[0].Trim();
                        }
                        else
                        {
                            dr["acname"] = txt_name.Text.Trim().ToUpper();
                        }

                        string takeparent = lst_groups.Text.ToString();
                        dr["group"] = Globals.GetGroupID(takeparent);
                        dr["note"] = txt_note.Text.Trim().ToUpper();
                        if (checkBox1.Checked == true)
                        {
                            dr["extended"] = true;
                        }
                        else
                        {
                            dr["extended"] = false;
                        }
                        dr.EndEdit();
                        int id;
                        string[] actxt = txt_name.Text.Split('|');
                        if (actxt.Length > 1)
                        {
                            int.TryParse(actxt[1].ToString().Trim(), out id);
                        }
                        else
                        {
                            id = Globals.GetAccountID(txt_name.Text.ToString());
                        }

                        OleDbCommand delAddress = new OleDbCommand("delete from account_part where acid=" + id + "", Globals.con);
                        delAddress.ExecuteNonQuery();
                        Globals.cmdbuilder = new OleDbCommandBuilder(Globals.AccountAdapter);
                        Globals.cmdbuilder.QuotePrefix = "[";
                        Globals.cmdbuilder.QuoteSuffix = "]";
                        Globals.AccountAdapter.UpdateCommand = Globals.cmdbuilder.GetUpdateCommand();
                        int stat = Globals.AccountAdapter.Update(Globals.AccountDataSet.Tables[0]);
                        Globals.DeleteTransactions(int.Parse(dr["acid"].ToString()), "0");

                        if (obdr > 0) Globals.AddTransactions(dateTimePicker1.Value.ToShortDateString(), Globals.GetAccountID(acname), Globals.GetAccountID(acname), 0, 0, dr: obdr);
                        if (obcr > 0) Globals.AddTransactions(dateTimePicker1.Value.ToShortDateString(), Globals.GetAccountID(acname), Globals.GetAccountID(acname), 0, 0, 0, obcr);

                        if (checkBox1.Checked == true)
                        {

                            Globals.F5Account_Particular();
                            dr = null;
                            dr = Globals.Account_PartDataSet.Tables[0].NewRow();
                            dr["street"] = txt_street.Text.ToString().ToUpper();
                            dr["place"] = txt_place.Text.ToString().ToUpper();
                            dr["city"] = txt_city.Text.ToString().ToUpper();
                            dr["district"] = txt_district.Text.ToString().ToUpper();
                            dr["state"] = txt_state.Text.ToString().ToUpper();
                            dr["gst"] = txt_gst.Text.ToString().ToUpper();
                            dr["dlno"] = "@";
                            dr["email"] = txt_email.Text.ToString().ToUpper();
                            dr["phone"] = txt_res.Text.ToString().ToUpper();
                            dr["mobile"] = txt_mob.Text.ToString().ToUpper();
                            dr["landline"] = txt_phone.Text.ToString().ToUpper();
                            dr["acid"] = Globals.GetAccountID(txt_name.Text.ToString());
                            dr["pin"] = txt_pin.Text.ToString().ToUpper();
                            OleDbCommandBuilder cmd = new OleDbCommandBuilder(Globals.Account_PartAdapter);
                            //Globals.cmdbuilder.QuotePrefix = "[";
                            //Globals.cmdbuilder.QuoteSuffix = "]";
                            Globals.Account_PartDataSet.Tables[0].Rows.Add(dr);
                            Globals.Account_PartAdapter.InsertCommand = cmd.GetInsertCommand();
                            int sta = Globals.Account_PartAdapter.Update(Globals.Account_PartDataSet.Tables[0]);
                        }


                        if (stat > 0)
                        {
                            MessageBox.Show("Account Information Updated"); button1_Click(sender, e);
                        }
                    }
                    catch (Exception EX)
                    {
                        MessageBox.Show(EX.Message.ToString());
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Delete
            DialogResult res = new DialogResult();
            DataRow dr;
            string[] takeid = new string[1];

            if (txt_name.Text.Contains("|"))
            {
                string str = null;
                string[] strArr = null;
                int count = 0;
                str = txt_name.Text.ToString();
                char[] splitchar = { '|' };
                strArr = str.Split(splitchar);
                Globals.F5Account();
                Globals.AccountView.Sort = "acid";
                int stat = Globals.AccountView.Find(strArr[1]);
                if (stat >= 0)
                {
                    res = MessageBox.Show("Do you want to Delete this Account", "Edit Account", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        try
                        {

                            string[] ac_str = txt_name.Text.Split('|');
                            if (ac_str.Length > 1)
                            {
                                OleDbDataAdapter tr_rs = new OleDbDataAdapter("select tr_date from transactions where acid=" + ac_str[1] + " order by tr_date asc", Globals.con);
                                DataSet tr_ds = new DataSet();
                                tr_rs.Fill(tr_ds);
                                DataView tr_dv = new DataView(tr_ds.Tables[0]);
                                if (tr_dv.Count > 0)
                                {
                                    MessageBox.Show("Can't delete Accounts which have balance, Please check account report and delete all entries posted ");

                                }
                                else
                                {
                                    OleDbCommand cmd = new OleDbCommand("delete from accounts where acid=" + strArr[1], Globals.con);
                                    int c = cmd.ExecuteNonQuery();
                                    cmd = new OleDbCommand("delete from account_part where acid=" + strArr[1], Globals.con);
                                    cmd.ExecuteNonQuery();
                                    if (c > 0)
                                    {
                                        Globals.DeleteTransactions(int.Parse(strArr[1].ToString()));
                                        int id;
                                        string[] actxt = txt_name.Text.Split('|');
                                        if (actxt.Length > 1)
                                        {
                                            int.TryParse(actxt[1].ToString().Trim(), out id);
                                        }
                                        else
                                        {
                                            id = Globals.GetAccountID(txt_name.Text.ToString());
                                        }

                                        OleDbCommand delAddress = new OleDbCommand("delete from account_part wher acid=" + id + "", Globals.con);
                                        delAddress.ExecuteNonQuery();


                                        MessageBox.Show("Account Deleted");
                                        button1_Click(sender, e);
                                    }
                                }

                            }
                        }
                        catch
                        {

                        }
                    }
                    else
                    {
                        MessageBox.Show("Action Cancelled");
                    }


                }

            }
            else
            {
                MessageBox.Show("Please find a group");
            }

        }

        private void txt_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                System.Drawing.Size p = new Size(485, 503);
                this.Size = p;
            }
            else
            {
                System.Drawing.Size p = new Size(485, 275);
                this.Size = p;

            }
        }
    }
}
