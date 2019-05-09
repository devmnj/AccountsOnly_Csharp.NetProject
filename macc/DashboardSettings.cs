using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace macc
{
    public partial class DashboardSettings : Form
    {
        public DashboardSettings()
        {
            InitializeComponent();
            Globals.F5Account();
        }

        private void DashboardSettings_Load(object sender, EventArgs e)
        {
            try
            {

                dataGridView1.Rows.Clear();
                Globals.F5DashBoardSettings();
                foreach(DataRowView row in Globals.dashboardSettings_View)
                {
                    string acname = Globals.GetAccountName(int.Parse(row["acid"].ToString())) ;
                    if (acname == null) { acname = Globals.GetGroupName(int.Parse(row["acid"].ToString())) ; }
                    dataGridView1.Rows.Add(acname + " | " + row["acid"].ToString());              
                
                }
                dataGridView1.Refresh();



            }
            catch (OleDbException e11)
            {
                MessageBox.Show(e11.Message.ToString());
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                TextBox auto = e.Control as TextBox;

                if (dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].Index == 0)
                {

                    AutoCompleteStringCollection auto1 = new AutoCompleteStringCollection();

                    foreach (DataRowView row in Globals.AccountView)
                    {
                        auto1.Add(row["acname"].ToString() + " | " + row["acid"].ToString());
                    }
                    Globals.F5Group();
                    foreach (DataRowView row in Globals.GroupView)
                    {
                        auto1.Add(row["gname"].ToString() + " | " + row["gid"].ToString());
                    }



                    auto.AutoCompleteMode = AutoCompleteMode.Suggest;
                    auto.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    auto.AutoCompleteCustomSource = auto1;
                }
                else
                {
                    auto.AutoCompleteMode = AutoCompleteMode.None;
                    auto.AutoCompleteSource = AutoCompleteSource.None;
                    auto.AutoCompleteCustomSource = null;


                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message.ToString());
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbCommand xcmd = new OleDbCommand("delete from  dashboardSettings", Globals.con);
                xcmd.ExecuteNonQuery();
                char[] splitchar = { '|' };
                string[] strArr = new string[2];
                int svd=0;
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    if (r.Cells[0].FormattedValue.ToString().Length > 0)
                    {
                        string str = r.Cells[0].FormattedValue.ToString();
                        strArr = str.Split(splitchar);
                        if (strArr[1].ToString().Length > 0)
                        {
                            xcmd = new OleDbCommand("insert into dashboardsettings (acid) values(" + strArr[1] + ")", Globals.con);
                            xcmd.ExecuteNonQuery();
                            svd++;
                        }
                    }
                }
                if (svd > 0) { MessageBox.Show("Groups/Accounts Saved"); }


            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
