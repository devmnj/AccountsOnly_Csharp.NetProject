using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace macc
{
    class Custom_Grid_Voucher : DataGridView
    {
        public double totalCash = 0;
        double takecash = 0;
        bool LastCol = false;
        public double GetTotalCash;
        //{
        //    get
        //    {
        //        return totalCash;
        //    }
        //    set { GetTotalCash = 0; }
        //}

        [System.Security.Permissions.UIPermission(
               System.Security.Permissions.SecurityAction.LinkDemand,
               Window = System.Security.Permissions.UIPermissionWindow.AllWindows)]

        protected override bool ProcessDialogKey(Keys keyData)
        {
            // Extract the key code from the key value. 
            Keys key = (keyData & Keys.KeyCode);
            // Handle the ENTER key as if it were a RIGHT ARROW key. 
            if (key == Keys.Enter)
            {
                 base.EndEdit();
                return this.ProcessRightKey(keyData);
            }
            return base.ProcessDialogKey(keyData);
        }

        [System.Security.Permissions.SecurityPermission(
            System.Security.Permissions.SecurityAction.LinkDemand, Flags =
            System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)]
        protected override bool ProcessDataGridViewKey(KeyEventArgs e)
        {
            // Handle the ENTER key as if it were a RIGHT ARROW key. 
            if (e.KeyCode == Keys.Enter)
            {
                if (base.CurrentCell.ColumnIndex == 2)
                {

                    int cri = base.CurrentRow.Index;
                    try
                    {
                        if (base.Rows[cri ].Cells[0].Value != null)
                        {
                            LastCol = false;
                            base.CurrentCell = base.Rows[cri + 1].Cells[0];
                        }
                        else
                        {
                            InvokeLostFocus(this, e);
                        }
                      //  BeginEdit(true);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        base.Rows.Add();
                        base.CurrentCell = base.Rows[cri + 1].Cells[0];
                       // base.EndEdit();
                        LastCol = true;
                    }

                }

                return ProcessRightKey(e.KeyData);

            }
            return base.ProcessDataGridViewKey(e);
        }
        protected override void OnCellLeave(DataGridViewCellEventArgs e)
        {
            string[] strArr = new string[5];
            char[] splitchar = { '|' };
            string st;
            if (Rows[e.RowIndex].Cells[1].Value != null)
            {
                Rows[e.RowIndex].Cells[0].Value = e.RowIndex + 1;
                takecash = 0;
                if (Rows[e.RowIndex].Cells[1].Value.ToString().Contains("|"))
                {
                    st = Rows[e.RowIndex].Cells[1].Value.ToString();
                    strArr = st.Split(splitchar);
                    Globals.F5Account();

                    try
                    {
                        Globals.AccountView.Sort = "acid";
                    }
                    catch (System.ArgumentException arr)
                    {
                        Globals.F5Account();

                    }

                    int stat = Globals.AccountView.Find(strArr[1]);
                    if (stat >= 0)
                    {
                        Rows[e.RowIndex].Cells[3].Value = strArr[1];
                    }
                    else
                    {
                        MessageBox.Show("The Account may lost!");
                    }

                }
                //if (base.Rows[e.RowIndex].Cells[2].Value != null)
                //{
                //    double.TryParse(base.Rows[e.RowIndex].Cells[2].Value.ToString(), out takecash);
                //    totalCash = totalCash + takecash;
                //}

            }
            //  if (LastCol == true) 
            { base.EndEdit(); }
            base.OnCellLeave(e);
        }
        protected override void OnRowLeave(DataGridViewCellEventArgs e)
        {
            base.EndEdit();
            base.OnRowLeave(e);
        }
        protected override void OnCellEnter(DataGridViewCellEventArgs e)
        {
            //if (LastCol == false)
            base.BeginEdit(true);
            base.OnCellEnter(e);
        }
        protected override void OnLostFocus(EventArgs e)
        {

            // base.EndEdit();
            base.OnLostFocus(e);
        }
        protected override void OnLeave(EventArgs e)
        {
            base.EndEdit();
            base.OnLeave(e);

        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {

            base.OnKeyPress(e);
        }
    }
}
