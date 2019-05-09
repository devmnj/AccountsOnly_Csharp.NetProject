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
    public partial class GroupAccounts : Form
    {
        string firstDate;
        public GroupAccounts()
        {
            InitializeComponent();
            SetHeaders();
            AddGroupsToNode();
        }
        private void SetHeaders()
        {
            ColumnHeader headers = new ColumnHeader();
            listView1.View = View.Details;
            headers.Text = " ";
            headers.Width = 0;
            listView1.Columns.Add(headers);
            headers = new ColumnHeader();
            headers.Text = "Accounts";
            headers.Width = 200;
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
            headers.Text = "Balance ";
            headers.Width = 120;
            listView1.Columns.Add(headers);

            headers = new ColumnHeader();
            headers.Text = "Note";
            headers.Width = 160;

            listView1.Columns.Add(headers);
            //headers = new ColumnHeader();
            //headers.Text = "";
            //headers.Width = 0;

            listView1.Refresh();
        }
        //public void GetchildAccounts(ref TreeNode n, string p)
        //{
        //    OleDbDataAdapter childAdaptr = new OleDbDataAdapter();
        //    childAdaptr = new OleDbDataAdapter("select  acid,group   from acgroup where group=" + p + "", Globals.con);
        //    DataSet childs = new DataSet();
        //    childAdaptr.Fill(childs, "accounts");
        //    DataView childview = new DataView(childs.Tables[0]);
        //    foreach (DataRowView rv in childview)
        //    {

        //        n.Nodes.Add(p, Globals.GetGroupName(int.Parse(rv["acid"].ToString())));

        //    }

        //}
        public void Getchilds(ref TreeNode n, string p)
        {
            OleDbDataAdapter childAdaptr = new OleDbDataAdapter();
            childAdaptr = new OleDbDataAdapter("select  parent,gid   from acgroup where parent=" + p + " order by gname", Globals.con);
            DataSet childs = new DataSet();
            childAdaptr.Fill(childs, "acgroup");
            DataView childview = new DataView(childs.Tables[0]);
            foreach (DataRowView rv in childview)
            {
                Console.WriteLine("Child GID:" + Globals.GetGroupName(int.Parse(rv["gid"].ToString())));
                n.Nodes.Add(p, Globals.GetGroupName(int.Parse(rv["gid"].ToString())));

            }

        }
        public void FindChilds_Grp(TreeNodeCollection node, int parent)
        {
            OleDbDataAdapter childAdaptr = new OleDbDataAdapter();
            childAdaptr = new OleDbDataAdapter("select  parent,gid   from acgroup where parent=" + parent, Globals.con);
            DataSet childs = new DataSet();
            childAdaptr.Fill(childs, "acgroup");
            DataView childview = new DataView(childs.Tables[0]);
            TreeNode t;
            foreach (DataRowView rv in childview)
            {
                Console.WriteLine("GID:" + rv["gid"].ToString() + "GName:" + Globals.GetGroupName(int.Parse(rv["gid"].ToString())) + "Parent:" + Globals.GetGroupName(int.Parse(rv["parent"].ToString())));
                node[parent.ToString()].Nodes.Add(rv["gid"].ToString(), Globals.GetGroupName(int.Parse(rv["gid"].ToString())));
                t = node[parent.ToString()];
                Getchilds(ref t, rv["gid"].ToString());
            }

        }

        private void AddGroupsToNode()
        {
            try
            {
                treeView1.Nodes.Clear();
                OleDbDataAdapter mastergrps = new OleDbDataAdapter("SELECT  gid    FROM AcGroup where parent=1", Globals.con);
                DataSet acd = new DataSet();
                mastergrps.Fill(acd, "acgroup");
                DataView mgview = new DataView(acd.Tables[0]);
                TreeNodeCollection tn = treeView1.Nodes;
                Console.WriteLine(mgview.Count.ToString());
                tn.Add("Show All");
                foreach (DataRowView rv in mgview)
                {
                    tn.Add(rv["gid"].ToString(), Globals.GetGroupName(int.Parse(rv["gid"].ToString())));
                    Console.WriteLine(Globals.GetGroupName(int.Parse(rv["gid"].ToString())));
                    FindChilds_Grp(tn, int.Parse(rv["gid"].ToString()));
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

        }
        public void GroupListShow(int groupid = 0)
        {

            List<double> drcr = new List<double>();
            listView1.Clear();
            SetHeaders();
            try
            {
                Globals.F5Account();
                ListViewItem tr_items = new ListViewItem();
                double[] total = { 0, 0, 0 };
                int ledid = 0;
                Globals.AppEvents.NewEvent(new Events(DateTime.Now, "Account Group", "All", "Viewed"));
                Globals.history.Subscribe(Globals.AppEvents);
                if (groupid > 0) Globals.AccountView.RowFilter = "group=" + groupid;
                Console.WriteLine(dateTimePicker1.Value.ToShortDateString());

                foreach (DataRowView row in Globals.AccountView)
                {
                    tr_items = new ListViewItem();
                    int id = int.Parse(row["acid"].ToString());
                    drcr = Globals.getGroupListBalance(  dateTimePicker1.Value.ToShortDateString() ,  dateTimePicker2.Value.ToShortDateString(), id);
                    int.TryParse(row["acid"].ToString(), out ledid);
                    tr_items.SubItems.Add(Globals.GetAccountName(ledid));
                    tr_items.SubItems.Add(drcr[0].ToString());
                    total[0] += drcr[0];
                    tr_items.SubItems.Add(drcr[1].ToString());
                    if (drcr[0] > drcr[1])
                    {
                        tr_items.SubItems.Add(drcr[0] - drcr[1] + " Dr");
                        total[2] += drcr[0] - drcr[1];
                    }
                    else if (drcr[1] > drcr[0])
                    {
                        tr_items.SubItems.Add(drcr[1] - drcr[0] + " Cr");
                        total[2] += drcr[1] - drcr[0];
                    }
                    else
                    {
                        tr_items.SubItems.Add("0.00");
                    }
                    total[1] += drcr[1];
                    listView1.Items.Add(tr_items);
                }
                ListViewItem footer = new ListViewItem();
                footer.SubItems.Add("");
                listView1.Items.Add(footer);
                footer = new ListViewItem();
                footer.BackColor = Color.Beige;

                footer.SubItems.Add("Total");

                footer.SubItems.Add(string.Format("{0:0.00}", total[0]));
                footer.SubItems.Add(string.Format("{0:0.00}", total[1]));
                footer.SubItems.Add(string.Format("{0:0.00}", total[2]));
                listView1.Items.Add(footer);
                footer = new ListViewItem();

            }
            catch (Exception e)
            {
                Console.Write(e.Message.ToString());

            }



        }





        private void button1_Click(object sender, EventArgs e)
        {

            GroupListShow();
        }

        private void GroupAccounts_Load(object sender, EventArgs e)
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

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {

                Globals.F5Account();
                if (Globals.AccountView.Count > 0)
                {
                    if (e.Node.Text.ToString().ToUpper().Trim() != "Show All".ToUpper())
                    {

                        int nodid = Globals.GetGroupID(e.Node.Text.ToString());
                        Globals.AccountView.RowFilter = "group=" + nodid;
                        if (Globals.AccountView.Count > 0)
                        {
                            GroupListShow(nodid);
                        }
                        else
                        {
                            listView1.Clear(); SetHeaders();
                        }
                    }
                    else
                    {
                        GroupListShow();
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
