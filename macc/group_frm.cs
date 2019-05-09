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
    public partial class group_frm : Form
    {
        string[] strArr = new string[5];
        string gname, gdescription;
        int gparent;
        string[] takeid = new string[1];
        AutoCompleteStringCollection autotext = new AutoCompleteStringCollection();
        public group_frm()
        {
            InitializeComponent();
            ParentsToList();

            Autotext();



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
            foreach (DataRowView row in Globals.GroupView)
            {
                autotext.Add(row["gname"].ToString() + " | " + row["gid"].ToString());

            }
            txt_name.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_name.AutoCompleteSource = AutoCompleteSource.CustomSource;

            txt_name.AutoCompleteCustomSource = autotext;
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void ParentsToList()
        {
            Globals.F5Group();
            lst_parent.DataSource = null;
            lst_parent.Sorted = true;
            lst_parent.Items.Clear();
            lst_parent.Items.Add("Root");
            lst_parent.Items.Add(" ");
            lst_parent.DataSource = Globals.GroupDataSet.Tables[0];
            lst_parent.DisplayMember = "gname";
            lst_parent.ValueMember = "gid";

        }
        private void txt_name_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txt_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Save 17/April/18
            DataRow dr;
            Globals.F5Group();
            gname = txt_name.Text.ToString().Trim().ToUpper();
            string gpstr = lst_parent.Text.ToString().ToUpper();
            if (gpstr.Trim().Length < 1)
            {
                gparent = 0;
            }
            else
            {
                gparent = Globals.GetGroupID(gpstr);
            }

            gdescription = txt_note.Text.ToString();
            if (gname != null)
            {
                try
                {
                    //OleDbCommand cmd = new OleDbCommand("insert into acgroup(gname,parent,[note]) values('" + gname +  "','" + gparent +  "','" + gdescription + "'" + ")", Globals.con);
                    //cmd.ExecuteScalar();

                    dr = Globals.GroupDataSet.Tables[0].NewRow();
                    dr["gname"] = gname;

                    dr["parent"] = gparent;
                    dr["note"] = gdescription;
                    Globals.cmdbuilder = new OleDbCommandBuilder(Globals.GroupAdapter);
                    Globals.cmdbuilder.QuotePrefix = "[";
                    Globals.cmdbuilder.QuoteSuffix = "]";
                    Globals.GroupDataSet.Tables[0].Rows.Add(dr);
                    Globals.GroupAdapter.InsertCommand = Globals.cmdbuilder.GetInsertCommand();
                    int stat = Globals.GroupAdapter.Update(Globals.GroupDataSet.Tables[0]);
                    if (stat > 0)
                    {
                        MessageBox.Show("Group Information saved");
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

        private void group_frm_Load(object sender, EventArgs e)
        {
            Globals.Positionform(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Clear
            Globals.F5Group();
            txt_name.Clear();
            txt_note.Clear();
            ParentsToList();
            Autotext();
            NormalButtonstate();
            txt_name.Focus();
            strArr = new string[5];
        }

        private void txt_name_KeyDown(object sender, KeyEventArgs e)
        {



            if (e.KeyCode == Keys.Enter && button4.Enabled == true)
            {
                if (txt_name.Text.Contains("|"))
                {
                    string str = null;
                    Globals.F5Group();
                    int count = 0;
                    str = txt_name.Text.ToString();
                    char[] splitchar = { '|' };
                    strArr = str.Split(splitchar);
                    Globals.GroupView.Sort = "gid";
                    txt_gid.Text = strArr[1];
                    int stat = Globals.GroupView.Find(strArr[1]);
                    if (stat >= 0)
                    {
                        this.FindButtonstate();

                        txt_note.Text = Globals.GroupView[stat]["note"].ToString();
                        int takeparent = int.Parse(Globals.GroupView[stat]["parent"].ToString());

                        if (takeparent > 0)
                        {
                            lst_parent.Text = Globals.GetGroupName(takeparent);


                        }
                        else
                        {
                            lst_parent.Text = " ";
                        }

                        lst_parent.Focus();

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
                Globals.F5Group();
                Globals.GroupView.Sort = "gid";
                int stat = Globals.GroupView.Find(strArr[1]);
                if (stat >= 0)
                {
                    res = MessageBox.Show("Do you want to Delete this group", "Edit Group", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        try
                        {
                            string[] grp_str = txt_name.Text.Split('|');
                            if (grp_str.Length > 1)
                            {
                                OleDbDataAdapter ac = new OleDbDataAdapter("select name from accounts where group=" + grp_str[1], Globals.con);
                                DataSet ds = new DataSet();
                                ac.Fill(ds);
                                DataView dv = new DataView(ds.Tables[0]);
                                if (dv.Count > 0)
                                {
                                    MessageBox.Show("Accounts found,Can't delete this group.Delete the accounts first");
                                }
                                else
                                {
                                    OleDbCommand cmd = new OleDbCommand("delete from acGroup where gid=" + strArr[1], Globals.con);
                                    int c = cmd.ExecuteNonQuery();
                                    if (c > 0)
                                    {
                                        MessageBox.Show("Group Deleted");

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

        private void button5_Click(object sender, EventArgs e)
        {
            //Edit
            DataRow dr;
            DialogResult result = new System.Windows.Forms.DialogResult();
            int key = int.Parse(strArr[1].ToString());
            if (key > 0)
            {
                result = MessageBox.Show("Do you want Edit this group", "Edit Group", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        Globals.F5Group();
                        Globals.GroupView.Sort = "gid";
                        DataRowView[] drv = Globals.GroupView.FindRows(strArr[1]);
                        dr = drv[0].Row;
                        dr.BeginEdit();
                        if (txt_name.Text.Contains("|"))
                        {
                            dr["gname"] = strArr[0].Trim();
                        }
                        else
                        {
                            dr["gname"] = txt_name.Text.Trim().ToUpper();
                        }

                        string takeparent = lst_parent.Text.ToString();
                        dr["parent"] = Globals.GetGroupID(takeparent);
                        dr["note"] = txt_note.Text.Trim().ToUpper();
                        dr.EndEdit();
                        Globals.cmdbuilder = new OleDbCommandBuilder(Globals.GroupAdapter);
                        Globals.GroupAdapter.UpdateCommand = Globals.cmdbuilder.GetUpdateCommand();
                        int stat = Globals.GroupAdapter.Update(Globals.GroupDataSet.Tables[0]);
                        if (stat > 0)
                        {
                            MessageBox.Show("Group Information Updated"); button1_Click(sender, e);
                        }
                    }
                    catch
                    {

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
            else
            {
                txt_name.Text = null;
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
