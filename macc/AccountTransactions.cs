using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows;
using System.ComponentModel;

namespace macc
{
    
    class AccountTransactions : System.ComponentModel.INotifyPropertyChanged
    {
         
        static DataTable BWKTable;
        public AccountTransactions()
        {

        }
        public AccountTransactions(String t)
        {
            if (t == "InitializeAccountView") {  Globals.TrFunctions.ChangedStatus=UpdateTable() ; }
        }
        public  DataTable ChangedStatus
        {
            set { BWKTable = value;
                OnPropertyChanged("ChangedStatus");
            }
            get { return BWKTable; }


        }
        public static DataTable UpdateTable()
        {
            double bal = 0; string str = null;
            try
            {
                BWKTable = new DataTable();
                BWKTable.Columns.Clear();
                BWKTable.Rows.Clear();
                BWKTable.Columns.Add("A/c", typeof(string));
                BWKTable.Columns.Add("Balance", typeof(double));
                Globals.F5DashBoardSettings();
                foreach (DataRowView r in Globals.dashboardSettings_View)
                {
                    str = Globals.GetAccountName(int.Parse(r["acid"].ToString()));
                    if (str == null)
                    {
                        str = Globals.GetGroupName(int.Parse(r["acid"].ToString()));
                        bal = Globals.GetGroupOB(int.Parse(r["acid"].ToString()));
                    }
                    else
                    {
                        bal = Globals.GetOB(DateTime.Now.Date, int.Parse(r["acid"].ToString()), 1);
                        // string stam = String.Format("{{0:0.00}", bal).ToString();                     
                    }
                    string[] arr = { str, bal.ToString() };

                    BWKTable.Rows.Add(arr);

                }

            }
            catch (OleDbException exc)
            {
                MessageBox.Show(exc.Message.ToString());
            }
            return BWKTable;
        }


        public void AddTransactions(string tdate, int acid, int linkid, int eid = 100, int eno = 0, double dr = 0, double cr = 0)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand("insert into transactions (TR_DATE,ACID,LINKD_TR_ID,DR_AMOUNT,CR_AMOUNT,EID,ENO) values('" +
                    tdate + "'," + acid + "," + linkid + "," + dr + "," + cr + "," + eid + "," + eno + ")", Globals.con);
                cmd.ExecuteScalar();

                ChangedStatus = UpdateTable();
            }
            catch (OleDbException ex)
            {
                //Systconsole.Write(ex.Message.ToString());
            }
        }
        public   void DeleteTransactions(int Eno, int eid)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand("delete from transactions WHERE eno=" + Eno + " and eid=" + eid, Globals.con);
                cmd.ExecuteScalar();
                Globals.TrFunctions.ChangedStatus = UpdateTable();
            }
            catch (OleDbException ex)
            {

            }
        }
        public   void DeleteTransactions(int acid)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand("delete from transactions WHERE acid=" + acid, Globals.con);
                cmd.ExecuteScalar();
                Globals.TrFunctions.ChangedStatus = UpdateTable();
            }
            catch (OleDbException ex)
            {

            }
        }
        public   void DeleteTransactions(int acid, string eno = "0")
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand("delete from transactions WHERE acid=" + acid + " and eno=0", Globals.con);
                cmd.ExecuteScalar();
                Globals.TrFunctions.ChangedStatus = UpdateTable();
            }
            catch (OleDbException ex)
            {

            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
            }
        }

    }
}
