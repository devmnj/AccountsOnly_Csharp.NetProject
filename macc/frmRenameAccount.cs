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
    public partial class frmRenameAccount : Form
    {
        public frmRenameAccount()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        void FillAcName()
        {
            try
            {
                Globals.F5Account();
                AutoCompleteStringCollection str = new AutoCompleteStringCollection();
                txt_oldname.AutoCompleteMode = AutoCompleteMode.Suggest;
                txt_oldname.AutoCompleteSource = AutoCompleteSource.CustomSource;
                var complteStr = from acs in Globals.AccountDataSet.Tables[0].AsEnumerable() select acs.Field<string>("acname");
                str.AddRange(complteStr.ToArray());
                txt_oldname.AutoCompleteCustomSource = str;
            }
            catch (Exception e) { }
        }
        private void frmRenameAccount_Load(object sender, EventArgs e)
        {
            FillAcName();
            btn_apply.Enabled = false;
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            try
            {
                FillAcName();
                txt_acid.Text = "";
                txt_newname.Text = "";
                txt_oldname.Text = "";
                btn_apply.Enabled = false;
            }
            catch
            {

            }


        }
        void Reset()
        {
            try
            {
                txt_acid.Text = "";
                txt_newname.Text = "";
                txt_oldname.Text = "";
                FillAcName();

            }
            catch (Exception e) { 
            
            }
        }
        private void txt_newname_KeyDown(object sender, KeyEventArgs e)
        {
            OleDbCommand updateCmd = new OleDbCommand();
            try
            {
                if (e.KeyCode == Keys.Enter && txt_oldname.Text.Trim() != null)
                {

                    if (Globals.CheckAccount(txt_oldname.Text) == false)
                    {
                        txt_newname.Text = "";
                    }
                    else
                    {
                        btn_apply.Enabled = true;
                    }
                }
            }
            catch (Exception E) { }
        }

        private void txt_oldname_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.Enter && txt_oldname.Text.Trim() != null)
                {
                    string acname = txt_oldname.Text.ToString();
                    txt_acid.Text = Globals.GetAccountID(acname).ToString();
                }
                else
                {

                }

            }
            catch (Exception e1) { }
        }

        private void btn_apply_Click(object sender, EventArgs e)
        {
            OleDbCommand updateCmd = new OleDbCommand();
            try
            {

                if (txt_oldname.Text.Length > 0 && txt_newname.Text.Length > 0 && txt_acid.Text.Length > 0)
                {
                    updateCmd = new OleDbCommand("update accounts set acname='" + txt_newname.Text + "' where acid=" + txt_acid.Text, Globals.con);
                  int cc=  updateCmd.ExecuteNonQuery();
                  if (cc > 0) { MessageBox.Show("Account information updated");
                  txt_acid.Text = "";
                  txt_newname.Text = "";
                  txt_oldname.Text = "";
                  btn_apply.Enabled = false;
                  }
                }
                else
                {

                }

            }

            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
