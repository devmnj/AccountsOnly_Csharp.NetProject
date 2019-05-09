using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace macc
{
    public partial class frm_GroupManager : Form
    {
        int gid, pgid;
        AutoCompleteStringCollection autotext = new AutoCompleteStringCollection();
        private void FindButtonstate()
        {
            btn_clear.Enabled = true;
            button2.Enabled = true;//Remove

            btn_save.Enabled = false;
            btn_edit.Enabled = true;
        }
        private void NormalButtonstate()
        {
            btn_clear.Enabled = true;
            button2.Enabled = false;//Remove

            btn_save.Enabled = true;
            btn_edit.Enabled = false;
        }
        public frm_GroupManager()
        {
            InitializeComponent();
            Common.F5Groups();
            this.GroupsToList();
            this.NormalButtonstate();

            Common.F5Groups();


            foreach (DataRowView row in Common.GroupTableView)
            {
                autotext.Add(row["name"].ToString());
               
            }
            txt_gname.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_gname.AutoCompleteSource = AutoCompleteSource.CustomSource;

            txt_gname.AutoCompleteCustomSource = autotext;


            Common.F5Groups();
        }
        private void GroupsToList()
        {
            txt_pgroup.DataSource = null;
            txt_pgroup.Sorted = true; txt_pgroup.Items.Clear();
            txt_pgroup.DataSource = Common.GroupTableDataset.Tables[0];
            txt_pgroup.DisplayMember = "Name";
            txt_pgroup.ValueMember = "gid";

            txt_gid.Text = Common.GenericF5SLNO("accountgroups", "gid");
            txt_gname.Focus();

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txt_gid_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Common.KeyMovement(e);
            if (e.KeyChar == 13)
            {
                Common.F5Groups();
                DataView search = new DataView();
                search = Common.GroupTableView;
                Common.GroupTableView.Sort = "gid";

                int gid ;
                int.TryParse(txt_gid.Text.Trim(), out   gid);
                int i = Common.GroupTableView.Find(gid);
                if (i != -1)
                {   
                    txt_gid.Text  = Common.GroupTableView[i]["gid"].ToString();
                    txt_gname.Text = Common.GroupTableView[i]["name"].ToString();
                    txt_pgid.Text = Common.GroupTableView[i]["pgid"].ToString();
                    txt_narration.Text = Common.GroupTableView[i]["narration"].ToString();
                    search.Sort = "gid"; int k = search.Find(txt_pgid.Text.ToString());
                    if (k != -1)
                    {
                        txt_pgroup.SelectedItem = search[k]["name"].ToString();
                    } 
                    FindButtonstate();
                }
                else
                {
                   button3_Click(sender, e);
                }
                //txt_pgroup.Focus();
                Common.KeyMovement(e);
            }
        }


        private void txt_gid_Enter(object sender, EventArgs e)
        {
            Common.EnetrColor(txt_gid);
           // txt_gid.SelectAll();
            toolStripStatusLabel1.Text = "Enter id , so that I can search for group you are looking at";
        }

        private void txt_gid_Leave(object sender, EventArgs e)
        {
            Common.LeaveColor(txt_gid); toolStripStatusLabel1.Text = "";
        }

        private void frm_GroupManager_Load(object sender, EventArgs e)
        {

        }

        private void txt_pgid_Enter(object sender, EventArgs e)
        {
            button3_Click(sender, e);
            Common.EnetrColor(txt_pgid);
            txt_gid.SelectAll();
            toolStripStatusLabel1.Text = "Enter id , so that I can locate for primary group you are looking at";
        }

        private void txt_pgid_Leave(object sender, EventArgs e)
        {
            Common.LeaveColor(txt_pgid); toolStripStatusLabel1.Text = "";
        }

        private void txt_pgid_KeyPress(object sender, KeyPressEventArgs e)
        {
            Common.KeyMovement(e);
        }

        private void txt_pgroup_KeyPress(object sender, KeyPressEventArgs e)
        {
            Common.KeyMovement(e);
            if (e.KeyChar == 13)
            {
                Common.adap = new System.Data.SqlClient.SqlDataAdapter("select gid from accountgroups where name='" + txt_pgroup.Text.ToString() + "'", Common.con);
                Common.MaccDataset = new DataSet();
                Common.adap.Fill(Common.MaccDataset);
                DataView dv = new DataView(Common.MaccDataset.Tables[0]);
                if (dv.Count > 0)
                {
                    txt_pgid.Text = dv.Table.Rows[0]["gid"].ToString();
                }
            }
        }

        private void txt_pgroup_Enter(object sender, EventArgs e)
        {
            txt_pgroup.Select();
            Common.EnetrColor(txt_pgroup);
            toolStripStatusLabel1.Text = "Choose a primary group";
        }

        private void txt_pgroup_Leave(object sender, EventArgs e)
        {
            Common.LeaveColor(txt_pgroup); toolStripStatusLabel1.Text = "";
        }

        private void txt_narration_Enter(object sender, EventArgs e)
        {
            Common.EnetrColor(txt_narration);
            txt_narration.SelectAll();
            toolStripStatusLabel1.Text = "Give a description of group for better understanding ";
        }

        private void txt_narration_Leave(object sender, EventArgs e)
        {
            Common.LeaveColor(txt_narration);
            toolStripStatusLabel1.Text = "";
        }

        private void txt_narration_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Common.KeyMovement(e);
            if (e.KeyChar == 13)
            {
                if (btn_save.Enabled != true) { btn_edit.Focus(); } else { btn_save.Focus(); }
            }
        }

        private void txt_gname_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Common.KeyMovement(e);

        }

        private void txt_gname_Enter(object sender, EventArgs e)
        {
            Common.EnetrColor(txt_gname);
            txt_gname.SelectAll();
            toolStripStatusLabel1.Text = "Enter group name, I also search for exisitng one ... ";
        }

        private void txt_gname_Leave(object sender, EventArgs e)
        {
            Common.LeaveColor(txt_gname);
            toolStripStatusLabel1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Clear 
            txt_gname.Clear();
            txt_gid.Clear();
            txt_pgid.Clear();
            txt_narration.Clear();
            txt_gid.Focus();
            Common.F5Groups();
            GroupsToList();
            Common.F5Groups();
            NormalButtonstate();

            foreach (DataRowView row in Common.GroupTableView)
            {
                autotext.Add(row["name"].ToString());
                // System.Console.WriteLine(row["name"].ToString());
            }
            txt_gname.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_gname.AutoCompleteSource = AutoCompleteSource.CustomSource;

            txt_gname.AutoCompleteCustomSource = autotext;


            Common.F5Groups();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Save
            try
            {
                if (txt_gid.Text.ToString().Trim() != "" && txt_gname.Text.ToString().Trim() != "" && txt_pgid.Text.ToString().Trim() != "")
                {
                   Globals.cmdbuilder = new System.Data.SqlClient.SqlCommandBuilder(Common.GroupTableAdapter);
                    Common.dro = Common.GroupTableDataset.Tables[0].NewRow();
                    int.TryParse(txt_gid.Text.ToString(), out gid);
                    int.TryParse(txt_pgid.Text.ToString(), out pgid);
                    Common.dro["gid"] = int.Parse(Common.GenericF5SLNO("accountgroups", "gid"));
                    Common.dro["name"] = txt_gname.Text.ToString().Trim().ToUpper();
                    Common.dro["pgid"] = int.Parse(txt_pgid.Text.ToString().Trim());
                    Common.dro["narration"] = txt_narration.Text.ToString().Trim();
                    Common.GroupTableDataset.Tables[0].Rows.Add(Common.dro);
                    Common.GroupTableAdapter.InsertCommand = Common.cmdbuilder.GetInsertCommand();
                    int k = Common.GroupTableAdapter.Update(Common.GroupTableDataset.Tables[0]);
                    if (k > 0)
                    {
                        MessageBox.Show("Group succefully created");
                        button3_Click(sender, e);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid entry, please re-check");
                    txt_gname.Focus();
                }

            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message.ToString());
            }
        }

        private void txt_pgroup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt_gname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_gname.AutoCompleteMode = AutoCompleteMode.None;

                Common.F5Groups();
                DataView search = new DataView();
                search = Common.GroupTableView;
                Common.GroupTableView.Sort = "Name";
                int i = Common.GroupTableView.Find(txt_gname.Text.ToString());
                if (i != -1)
                {
                    txt_gname.Text = Common.GroupTableView[i]["name"].ToString();
                    txt_pgid.Text = Common.GroupTableView[i]["pgid"].ToString();
                    txt_gid.Text = Common.GroupTableView[i]["gid"].ToString();
                    txt_narration.Text = Common.GroupTableView[i]["narration"].ToString();
                    search.Sort = "gid";
                    int k = search.Find(txt_pgid.Text.ToString());
                    if (k != -1)
                    {
                        txt_pgroup.Text = search[k]["name"].ToString();
                    }
                    FindButtonstate();
                    txt_pgroup.Focus();

                }
                else
                {

                    txt_pgroup.Focus();
                    //  txt_gid.Text = Common.GenericF5SLNO("accountgroups", "gid");


                }

            }
        }

        private void txt_gname_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            //Edit
            DialogResult res = new DialogResult();
            res = MessageBox.Show("Do you want to edit the group", "Edit Group", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                try
                {
                    if (txt_gid.Text.ToString().Trim() != "" && txt_gname.Text.ToString().Trim() != "" && txt_pgid.Text.ToString().Trim() != "")


                        Common.cmdbuilder = new System.Data.SqlClient.SqlCommandBuilder(Common.GroupTableAdapter);
                    Common.adap = new System.Data.SqlClient.SqlDataAdapter("select * from accountgroups where gid=" + int.Parse(txt_gid.Text.ToString()) + "", Common.con);
                    Common.adap.Fill(Common.GroupTableDataset);
                    Common.AccountRegistrationTableView = new DataView(Common.GroupTableDataset.Tables[0]);


                    if (Common.AccountRegistrationTableView.Count > 0)
                    {
                        Common.dro = null;
                        Common.dro = (DataRow)Common.AccountRegistrationTableView.Table.Rows[0];
                        Common.dro.BeginEdit();
                        Common.dro["gid"] = txt_gid.Text.ToString();
                        Common.dro["name"] = txt_gname.Text.ToString().Trim().ToUpper();
                        Common.dro["pgid"] = txt_pgid.Text.ToString();
                        Common.dro["narration"] = txt_narration.Text.ToString();
                        Common.dro.EndEdit();

                        Common.GroupTableAdapter.UpdateCommand = Common.cmdbuilder.GetUpdateCommand();
                        int re = Common.GroupTableAdapter.Update(Common.GroupTableDataset.Tables[0]);
                        if (re > 0)
                        {
                            MessageBox.Show("Group Edited");
                            button3_Click(sender, e);

                        }
                        else
                        { MessageBox.Show("Entry not saved"); }

                    }
                    else
                    {
                        MessageBox.Show("Something missing !");
                    }
                }
                catch (Exception editerror)
                {
                    MessageBox.Show(editerror.Message.ToString());
                }
            }
            else
            {
                MessageBox.Show("Action cancelled");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //delete
            DialogResult res = new DialogResult();
            if (txt_gid.Text.ToString().Trim() != null)
            {
                res = MessageBox.Show("Do you want to Delete the group", "Edit Group", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {

                    Common.cmd = new System.Data.SqlClient.SqlCommand("delete from accountGroups where gid=" + txt_gid.Text.ToString() + "", Common.con);
                    Common.cmd.ExecuteNonQuery();

                    MessageBox.Show("Group Deleted");
                    button3_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Action cancelled");
                }

            }
            else
            {
                MessageBox.Show("Please reload the Group, it may be already deleted");

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_gid_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_narration_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
