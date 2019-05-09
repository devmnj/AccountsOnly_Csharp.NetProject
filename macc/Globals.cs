using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Windows.Forms.Design;
namespace macc
{
    static class Globals
    {
        public static MyCompany company;
        public static DataTable BWKTable;
        public static mainMDI main_mdi = new mainMDI();
        public static EventManager AppEvents = new EventManager();
        public static History history = new History("App History");
        public static IList<Events> historyList = new List<Events>();
        public static OleDbConnection con;
        public static OleDbDataAdapter GroupAdapter;
        public static DataSet GroupDataSet;
        public static DataView GroupView;
        public static OleDbCommandBuilder cmdbuilder;
        public static OleDbDataAdapter AccountAdapter;
        public static DataSet AccountDataSet;
        public static DataView AccountView;
        public static string CompanyName;
        public static OleDbDataAdapter RVInfoAdapter;
        public static DataSet RVInfoDataSet;
        public static DataView RVInfoView;

        public static OleDbDataAdapter RVPartAdapter;
        public static DataSet RVPartDataSet;
        public static DataView RVPartView;

        public static OleDbDataAdapter trnsAdapter;
        public static DataSet trnsDataSet;
        public static DataView trnsView;

        public static OleDbDataAdapter PVinfoAdapter;
        public static DataSet PVinfoDataSet;
        public static DataView PVinfoView;

        public static OleDbDataAdapter PVPartAdapter;
        public static DataSet PVPartDataSet;
        public static DataView PVPartView;

        public static OleDbDataAdapter JEInfoAdapter;
        public static DataSet JEInfoDataSet;
        public static DataView JEInfoView;

        public static OleDbDataAdapter JEPartAdapter;
        public static DataSet JEPartDataSet;
        public static DataView JEPartView;

        public static OleDbDataAdapter Account_PartAdapter;
        public static DataSet Account_PartDataSet;
        public static DataView Account_PartView;
        public static OleDbDataAdapter dashboardSettings_Adapter;
        public static DataSet dashboardSettings_DataSet;
        public static DataView dashboardSettings_View;

        public static void Positionform( Form f)
        {
            try
            {
                f.Location = new System.Drawing.Point(12,10);
                f.StartPosition = FormStartPosition.Manual;
            }
            catch (Exception e)
            {
            }
        }
        public static List<string> GetTransPeriods(int acid)
        {
            List<string> b = new List<string>();
            try
            {

                OleDbDataAdapter ad = new OleDbDataAdapter("select tr_date from transactions where  acid=" + acid + " order by tr_date", con);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                DataView v = new DataView(ds.Tables[0]);
                if (v.Count > 0)
                {
                    string dt = v[0].Row["tr_date"].ToString();
                    b.Add(dt);
                    dt = v[v.Count - 1].Row["tr_date"].ToString(); ;
                    b.Add(dt);
                }

            }
            catch (OleDbException eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }

            return b;
        }

        public static void CreateNewTable(string tble, string colstring)
        {
            OleDbCommand updateField = new OleDbCommand();
            try
            {
                var schema = con.GetSchema("TABLES");
                var tbl = schema.Select("TABLE_NAME='" + tble + "'");

                if (tbl.Length > 0)
                {
                    // tbl exist
                }
                else
                {
                    // tbl doesn't exist
                    updateField.CommandText = " CREATE TABLE " + tble + "(" + colstring + "  )";
                    updateField.Connection = con;
                    updateField.ExecuteNonQuery();

                }
            }
            catch (OleDbException exxx)
            {
                Console.WriteLine(exxx.Message.ToString());


            }
        }
        public static void UpdateColumn(string tble, string colname, string type)
        {
            OleDbCommand updateField = new OleDbCommand();
            try
            {
                var schema = con.GetSchema("COLUMNS");
                var col = schema.Select("TABLE_NAME='" + tble + "' AND COLUMN_NAME='" + colname + "'");

                if (col.Length > 0)
                {
                    // Column exist
                }
                else
                {
                    // Column doesn't exist
                    updateField.CommandText = " ALTER TABLE " + tble + " ADD COLUMN " + colname + "  " + type;
                    updateField.Connection = con;
                    updateField.ExecuteNonQuery();

                }
            }
            catch (OleDbException exxx)
            {
                Console.WriteLine(exxx.Message.ToString());


            }
        }


        public static void F5DashBoardSettings()
        {
            dashboardSettings_Adapter = new OleDbDataAdapter("select * from dashboardsettings", con);
            dashboardSettings_DataSet = new DataSet();
            dashboardSettings_Adapter.Fill(dashboardSettings_DataSet, "dashboardsettings");
            dashboardSettings_View = new DataView(dashboardSettings_DataSet.Tables[0]);
        }

        public static DataTable BackWorker_Accounts()
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
                        bal = Globals.GetOB(DateTime.Now.Date ,int.Parse(r["acid"].ToString()),1);
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

        //Constants -Tables
        public static Dictionary<int, string> DB_TABLES = new Dictionary<int, string>();


        public static void F5Account_Particular()
        {
            Account_PartAdapter = new OleDbDataAdapter("select * from account_part", con);
            Account_PartDataSet = new DataSet();
            Account_PartAdapter.Fill(Account_PartDataSet, "account_part");
            Account_PartView = new DataView(Account_PartDataSet.Tables[0]);
        }

        public static List<double> OpeningAccountBalance()
        {
            OleDbDataAdapter rs = new OleDbDataAdapter();
            DataSet ds = new DataSet();
            List<double> ret = new List<double>();
            DataView dv = new DataView();

            try
            {
                rs = new OleDbDataAdapter("select dr_amount,cr_amount from transactions where eid=0 ", con);
                rs.Fill(ds, "transactions");
                dv = new DataView(ds.Tables[0]);
                double cr = 0, dr = 0;
                foreach (DataRowView r in dv)
                {
                    cr += double.Parse(r["cr_amount"].ToString());
                    dr += double.Parse(r["dr_amount"].ToString());
                }

                ret.Add(dr); ret.Add(cr);

            }
            catch (OleDbException er)
            {
                MessageBox.Show(er.Message.ToString());
            }


            return ret;
        }



        public static bool CheckAccount(string str)
        {
            Boolean ret = false;
            OleDbDataAdapter acc = new OleDbDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                acc = new OleDbDataAdapter("select acname from accounts where acname='" + str + "'", con);
                acc.Fill(ds, "acccounts");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ret = true;
                }
            }
            catch (OleDbException e)
            {

            }
            return ret;
        }




        public static int iseno(int eno, string eid)
        {
            int result = 0;
            try
            {
                OleDbDataAdapter eadapt = new OleDbDataAdapter("select entryno from " + eid + " where entryno=" + eno, con);
                DataSet ds = new DataSet();
                eadapt.Fill(ds);
                DataView dv = new DataView(ds.Tables[0]);
                if (dv.Count == 1) { result = 1; }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message.ToString());
            }

            return result;
        }
        public static double GetGroupOB(int acid)
        {
            double b = 0;
            try
            {

                OleDbDataAdapter ad = new OleDbDataAdapter("select acid,group from accounts inner join acgroup on accounts.group=acgroup.gid where acgroup.gid=" + acid, con);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                DataView v = new DataView(ds.Tables[0]);
                if (v.Count > 0)
                {
                    string acn = null;
                    int acd = 0;
                    foreach (DataRowView r in v)
                    {
                        acd = int.Parse(r["acid"].ToString());

                        b += GetOB(DateTime.Now.Date, acd, 1);

                    }
                }

            }
            catch (OleDbException eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }

            return b;
        }

        public static double GetOB(int acid)
        {
            double bal, dr, cr;
            bal = cr = dr = 0;
            try
            {
                OleDbDataAdapter obadapter = new OleDbDataAdapter("select dr_amount,cr_amount,acid from transactions WHERE eid=0 and  acid=" + acid, con);
                DataSet obdset = new DataSet();
                obadapter.Fill(obdset);
                DataView obview = new DataView(obdset.Tables[0]);
                //obview.Sort = "acid";
                //obview.RowFilter = "acid=" + acid;

                if (obview.Count > 0)
                {
                    foreach (DataRowView r in obview)
                    {
                        dr += double.Parse(r["dr_amount"].ToString());
                        cr += double.Parse(r["cr_amount"].ToString());
                    }


                    if (dr > 0) { bal = dr; } else { bal = cr; }

                }
            }
            catch (OleDbException ee)
            {
                Console.WriteLine(ee.Message.ToString());
            }
            return bal;
        }
        public static List<string> OBToList(int acid)
        {
            double bal, dr, cr;
            bal = cr = dr = 0;
            string dt = DateTime.Now.ToShortDateString();
            List<string> ret = new List<string>();
            try
            {
                OleDbDataAdapter obadapter = new OleDbDataAdapter("select dr_amount,cr_amount,acid,tr_date from transactions WHERE eid=0 and  acid=" + acid, con);
                DataSet obdset = new DataSet();
                obadapter.Fill(obdset);
                DataView obview = new DataView(obdset.Tables[0]);
                //obview.Sort = "acid";
                //obview.RowFilter = "acid=" + acid;

                if (obview.Count > 0)
                {
                    dt = obview[0]["tr_date"].ToString();
                    foreach (DataRowView r in obview)
                    {
                        dr += double.Parse(r["dr_amount"].ToString());
                        cr += double.Parse(r["cr_amount"].ToString());
                    }


                    if (dr > 0) { bal = dr; } else { bal = cr; }


                }
                ret.Add(bal.ToString());
                ret.Add(dt);



            }
            catch (OleDbException ee)
            {
                Console.WriteLine(ee.Message.ToString());
            }
            return ret;
        }
        public static List<double> GetOB(DateTime opdate, int acid)
        {
            //Ret. Opbal,Dr,Cr
            double dr, cr;
            double opb, drbal = 0, crbal = 0;
            List<Double> ret = new List<double>();
            cr = dr = 0;
            try
            {
                OleDbDataAdapter obadapter = new OleDbDataAdapter("select dr_amount,cr_amount,acid from transactions WHERE  TR_DATE < #" + opdate.ToShortDateString() + "# and acid=" + acid, con);
                DataSet obdset = new DataSet();
                obadapter.Fill(obdset);
                DataView obview = new DataView(obdset.Tables[0]);
                //obview.Sort = "acid";
                //obview.RowFilter = "acid=" + acid;

                if (obview.Count > 0)
                {
                    foreach (DataRowView r in obview)
                    {
                        dr += double.Parse(r["dr_amount"].ToString());
                        cr += double.Parse(r["cr_amount"].ToString());
                    }

                    if (dr > cr)
                    {
                        opb = dr - cr;
                        drbal = opb;

                    }
                    else if (cr > dr)
                    {
                        opb = cr - dr;
                        crbal = opb;
                    }
                    else
                    {
                        opb = 0;
                        crbal = drbal = 0;
                    }

                }
                ret.Add(drbal);
                ret.Add(crbal);
            }
            catch (OleDbException ee)
            {
                Console.WriteLine(ee.Message.ToString());
            }
            return ret;
        }

        public static double GetOB(DateTime opdate, int acid, int x = 0)
        {
            //Ret. Opbal,Dr,Cr
            F5Account();
            double dr, cr;
            double opb = 0, drbal = 0, crbal = 0;

            cr = dr = 0;
            try
            {
                OleDbDataAdapter obadapter = new OleDbDataAdapter("select dr_amount,cr_amount,acid from transactions WHERE  TR_DATE <= #" + opdate.ToShortDateString() + "# and acid=" + acid, con);
                DataSet obdset = new DataSet();
                obadapter.Fill(obdset);
                DataView obview = new DataView(obdset.Tables[0]);
                //obview.Sort = "acid";
                //obview.RowFilter = "acid=" + acid;

                if (obview.Count > 0)
                {
                    foreach (DataRowView r in obview)
                    {
                        dr += double.Parse(r["dr_amount"].ToString());
                        cr += double.Parse(r["cr_amount"].ToString());
                    }

                    if (dr > cr)
                    {
                        opb = dr - cr;


                    }
                    else if (cr > dr)
                    {
                        opb = cr - dr;

                    }
                    else
                    {
                        opb = 0;
                        crbal = drbal = 0;
                    }

                }
                else
                {
                    opb = 0;
                }

            }
            catch (OleDbException ee)
            {
                Console.WriteLine(ee.Message.ToString());
            }
            return opb;
        }
        public static double PreviousTransactionsToGrid(DataGridView dg, string amnt_col, int eno, int eid = 100, int acid = 0)
        {
            OleDbDataAdapter a = new OleDbDataAdapter("select  tr_date as [Date], eno as [R#], " + amnt_col + "  from transactions where eno<>" + eno + " and eid=" + eid + " and acid=" + acid + "  order by tr_date", con);
            DataSet d = new DataSet();
            a.Fill(d);
            DataView dv = new DataView(d.Tables[0]);
            dg.DataSource = d.Tables[0];
            double dvt = 0;
            foreach (DataRowView r in dv)
            {
                dvt += double.Parse(r[2].ToString());
            }
            return dvt;
        }
        public static void F5JEIN()
        {
            JEInfoAdapter = new OleDbDataAdapter("select * from JE_info", con);
            JEInfoDataSet = new DataSet();
            JEInfoAdapter.Fill(JEInfoDataSet, "JE_info");
            JEInfoView = new DataView(JEInfoDataSet.Tables[0]);
        }
        public static void F5JEPart()
        {
            JEPartAdapter = new OleDbDataAdapter("select * from JE_part", con);
            JEPartDataSet = new DataSet();
            JEPartAdapter.Fill(JEPartDataSet, "JE_part");
            JEPartView = new DataView(JEPartDataSet.Tables[0]);
        }
        public static void F5PVIN()
        {
            PVinfoAdapter = new OleDbDataAdapter("select * from pv_info", con);
            PVinfoDataSet = new DataSet();
            PVinfoAdapter.Fill(PVinfoDataSet, "pv_info");
            PVinfoView = new DataView(PVinfoDataSet.Tables[0]);
        }
        public static void F5PVPA()
        {
            PVPartAdapter = new OleDbDataAdapter("select * from pv_part", con);
            PVPartDataSet = new DataSet();
            PVPartAdapter.Fill(PVPartDataSet, "pv_part");
            PVPartView = new DataView(PVPartDataSet.Tables[0]);
        }
        public static void OpenDBConnection()
        {
            try
            {
                con = new OleDbConnection();
                //con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["macc.Properties.Settings.macdbConnectionString"].ConnectionString;
                con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["macc.Properties.Settings.macdbConnectionString"].ConnectionString;

                con.Open();

                DB_TABLES.Clear();
                DB_TABLES.Add(1021, "je_info");
                DB_TABLES.Add(1022, "je_part");
                DB_TABLES.Add(1011, "pv_info");
                DB_TABLES.Add(1012, "pv_part");
                DB_TABLES.Add(1001, "rv_info");
                DB_TABLES.Add(1002, "rv_part");

            }
            catch (Exception ex)
            {
                con.Close();
                con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["macc.Properties.Settings.macdbConnectionString"].ConnectionString;
                con.Open();

            }

        }
        public static void OpenDBConnection(string dbloc)
        {
            try
            {
                if (dbloc != null)
                {
                    con = new OleDbConnection();
                    //con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["macc.Properties.Settings.macdbConnectionString"].ConnectionString;
                    con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= " + dbloc;
                    //connectionString="Provider=Microsoft.ACE.OLEDB.12.0;Data Source= E:\DeveloperM\Projects\macc\macc\DB\macdb.accdb"
                    con.Open();

                    DB_TABLES.Clear();
                    DB_TABLES.Add(1021, "je_info");
                    DB_TABLES.Add(1022, "je_part");
                    DB_TABLES.Add(1011, "pv_info");
                    DB_TABLES.Add(1012, "pv_part");
                    DB_TABLES.Add(1001, "rv_info");
                    DB_TABLES.Add(1002, "rv_part");
                }

            }
            catch (Exception ex)
            {
                con.Close();
                con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= " + dbloc; ;
                con.Open();

            }

        }

        public static void F5Transactions()
        {
            trnsAdapter = new OleDbDataAdapter("select * from transactions", con);
            trnsDataSet = new DataSet();
            trnsAdapter.Fill(trnsDataSet, "transaactions");
            trnsView = new DataView(trnsDataSet.Tables[0]);
        }
        public static void AddTransactions(string tdate, int acid, int linkid, int eid = 100, int eno = 0, double dr = 0, double cr = 0)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand("insert into transactions (TR_DATE,ACID,LINKD_TR_ID,DR_AMOUNT,CR_AMOUNT,EID,ENO) values('" +
                    tdate + "'," + acid + "," + linkid + "," + dr + "," + cr + "," + eid + "," + eno + ")", con);
                cmd.ExecuteScalar();
            }
            catch (OleDbException ex)
            {
                Console.Write(ex.Message.ToString());
            }
        }
        public static void DeleteTransactions(int Eno, int eid)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand("delete from transactions WHERE eno=" + Eno + " and eid=" + eid, con);
                cmd.ExecuteScalar();
            }
            catch (OleDbException ex)
            {

            }
        }
        public static void DeleteTransactions(int acid)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand("delete from transactions WHERE acid=" + acid, con);
                cmd.ExecuteScalar();
            }
            catch (OleDbException ex)
            {

            }
        }
        public static void DeleteTransactions(int acid, string eno = "0")
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand("delete from transactions WHERE acid=" + acid + " and eno=0", con);
                cmd.ExecuteScalar();
            }
            catch (OleDbException ex)
            {

            }
        }

        public static void F5RVIN()
        {
            RVInfoAdapter = new OleDbDataAdapter("select * from rv_info", con);
            RVInfoDataSet = new DataSet();
            RVInfoAdapter.Fill(RVInfoDataSet, "rv_info");
            RVInfoView = new DataView(RVInfoDataSet.Tables[0]);
        }
        public static void F5RVPA()
        {
            RVPartAdapter = new OleDbDataAdapter("select * from rv_part", con);
            RVPartDataSet = new DataSet();
            RVPartAdapter.Fill(RVPartDataSet, "rv_part");
            RVPartView = new DataView(RVPartDataSet.Tables[0]);
        }
        public static void F5Trns()
        {
            trnsAdapter = new OleDbDataAdapter("select * from transactions order by tr_date", con);
            trnsDataSet = new DataSet();
            trnsAdapter.Fill(trnsDataSet, "transactions");
            trnsView = new DataView(trnsDataSet.Tables[0]);
        }
        public static void F5Account()
        {

            AccountAdapter = new OleDbDataAdapter("select * from accounts order by group", con);
            AccountDataSet = new DataSet();
            AccountAdapter.Fill(AccountDataSet, "accounts");
            AccountView = new DataView(AccountDataSet.Tables[0]);

        }
        public static void F5Group()
        {
            GroupAdapter = new OleDbDataAdapter("select * from acgroup order by parent asc", con);
            GroupDataSet = new DataSet();
            GroupAdapter.Fill(GroupDataSet, "acgroup");
            GroupView = new DataView(GroupDataSet.Tables[0]);
        }
        public static int GetGroupID(string gnstr)
        {
            OleDbDataAdapter lookup_adapter = new OleDbDataAdapter("select gid from  acgroup where gname='" + gnstr + "'", con);
            DataSet lookup_ds = new DataSet(); lookup_adapter.Fill(lookup_ds, "acgroup");
            DataView lookup_dv = new DataView(lookup_ds.Tables[0]);



            int r;
            try
            {

                if (lookup_dv.Count > 0)
                {
                    r = int.Parse(lookup_dv[0]["gid"].ToString());
                }
                else
                {
                    r = -1;
                }
            }
            catch
            {
                r = -1;
            }

            return r;
        }
        public static string GetGroupName(int gid)
        {
            OleDbDataAdapter lookup_adapter = new OleDbDataAdapter("select gname from  acgroup where gid=" + gid + "", con);
            DataSet lookup_ds = new DataSet(); lookup_adapter.Fill(lookup_ds, "acgroup");
            DataView lookup_dv = new DataView(lookup_ds.Tables[0]);
            string ret_str;
            try
            {

                if (lookup_dv.Count > 0)
                {
                    ret_str = lookup_dv[0]["gname"].ToString();
                }
                else
                {
                    ret_str = " ";
                }
            }
            catch
            {
                ret_str = " ";
            }

            return ret_str;
        }
        public static string GetEntryName(int gid)
        {
            OleDbDataAdapter lookup_adapter = new OleDbDataAdapter("select ename from  entries where eid=" + gid + "", con);
            DataSet lookup_ds = new DataSet(); lookup_adapter.Fill(lookup_ds, "entries");
            DataView lookup_dv = new DataView(lookup_ds.Tables[0]);
            string ret_str;
            try
            {

                if (lookup_dv.Count > 0)
                {
                    ret_str = lookup_dv[0]["ename"].ToString();
                }
                else
                {
                    ret_str = null;
                }
            }
            catch
            {
                ret_str = null;
            }

            return ret_str;
        }
        public static int GetEntryID(string ename)
        {
            OleDbDataAdapter lookup_adapter = new OleDbDataAdapter("select eid from  entries where ename='" + ename.Trim() + "'", con);
            DataSet lookup_ds = new DataSet(); lookup_adapter.Fill(lookup_ds, "entries");
            DataView lookup_dv = new DataView(lookup_ds.Tables[0]);
            int ret_str;
            try
            {

                if (lookup_dv.Count > 0)
                {
                    int.TryParse(lookup_dv[0]["eid"].ToString(), out ret_str);

                }
                else
                {
                    ret_str = 0;
                }
            }
            catch
            {
                ret_str = 0;
            }

            return ret_str;
        }
        public static int GetAccountGroupRoot(int acid)
        {
            int ret = 0;
            int gid = 0;
            try
            {
                F5Account();
                AccountView.Sort = "acid";
                AccountView.RowFilter = "acid=" + acid;
                if (AccountView.Count == 1)
                {

                    // Console.WriteLine(AccountView[0]["acname"].ToString());
                    F5Group();
                    GroupView.Sort = "gid";
                    gid = int.Parse(AccountView[0]["group"].ToString());
                // Console.WriteLine(AccountView[0]["group"].ToString());
                Re:
                    GroupView.RowFilter = "gid=" + gid;

                    if (GroupView.Count == 1)
                    {
                        // Console.WriteLine(GroupView[0]["parent"].ToString());
                        if (int.Parse(GroupView[0]["parent"].ToString()) == 1)
                        {

                            ret = int.Parse(GroupView[0]["gid"].ToString());

                        }
                        else
                        {

                            gid = int.Parse(GroupView[0]["parent"].ToString());
                            goto Re;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message.ToString());
            }
            return ret;
        }
        public static string GetNarration(int eid, int eno)
        {
            string takenarration = null;
            switch (eid)
            {
                case 100:
                    F5RVIN();
                    RVInfoView.Sort = "entryno";
                    RVInfoView.RowFilter = "entryno=" + eno;
                    takenarration = RVInfoView[0]["narration"].ToString();
                    break;
                case 101:
                    F5PVIN();
                    PVinfoView.Sort = "entryno";
                    PVinfoView.RowFilter = "entryno=" + eno;
                    takenarration = PVinfoView[0]["narration"].ToString();
                    break;
                case 102:
                    F5JEIN();
                    JEInfoView.Sort = "entryno";
                    JEInfoView.RowFilter = "entryno=" + eno;
                    takenarration = JEInfoView[0]["narration"].ToString();
                    break;
            }

            return takenarration;
        }
        public static int GetAccountID(string gnstr)
        {
            OleDbDataAdapter lookup_adapter = new OleDbDataAdapter("select acid from  accounts where acname='" + gnstr + "'", con);
            DataSet lookup_ds = new DataSet(); lookup_adapter.Fill(lookup_ds, "accounts");
            DataView lookup_dv = new DataView(lookup_ds.Tables[0]);
            int r;
            try
            {
                if (lookup_dv.Count > 0)
                {
                    r = int.Parse(lookup_dv[0]["acid"].ToString());
                }
                else
                {
                    r = -1;
                }
            }
            catch
            {
                r = -1;
            }
            return r;
        }
        public static string GetAccountName(int gid)
        {
            OleDbDataAdapter lookup_adapter = new OleDbDataAdapter("select acname from  accounts where acid=" + gid + "", con);
            DataSet lookup_ds = new DataSet(); lookup_adapter.Fill(lookup_ds, "accounts");
            DataView lookup_dv = new DataView(lookup_ds.Tables[0]);
            string ret_str;
            try
            {

                if (lookup_dv.Count > 0)
                {
                    ret_str = lookup_dv[0]["acname"].ToString();
                }
                else
                {
                    ret_str = null;
                }
            }
            catch
            {
                ret_str = null;
            }

            return ret_str;
        }
        public static List<string> GenericTolist(string tble, string fld)
        {
            OleDbDataAdapter gnric_adapter = new OleDbDataAdapter("select distinct(" + fld + ") from " + tble, con);
            DataSet gnric_ds = new DataSet();
            gnric_adapter.Fill(gnric_ds);
            List<string> dest = new List<string>();
            return dest;
        }
        public static string GenericF5SLNO(string Tname, string fld = "billno")
        {
            // Generic Entryno 
            OleDbDataAdapter a = new OleDbDataAdapter("select " + fld + " from " + Tname + " order by " + fld, con);
            String pid;
            DataSet ds = new DataSet();

            a.Fill(ds, Tname);
            DataView dv = new DataView(ds.Tables[0]);
            if (dv.Table.Rows.Count > 0)
            {
                pid = dv.Table.Rows[dv.Table.Rows.Count - 1][fld].ToString();
                pid = (int.Parse(pid) + 1).ToString();
            }
            else
            {
                pid = "1";
            }
            return pid;
        }

        public static List<double> getGroupListBalance(string frmdtstr, string todtstr, int ledid)
        {
            List<double> bal = new List<double>();
            OleDbDataAdapter ad = new OleDbDataAdapter("select dr_amount,cr_amount from transactions where  tr_date>=#" + string.Format("{0:MM/dd/yy}",todtstr) + "#  AND  tr_date<=#" + string.Format("{0:MM/dd/yy}",frmdtstr) + "# AND ACID=" + ledid + "",con);
            DataSet dx = new DataSet();
            ad.Fill(dx,"transactions");

            trnsView = new DataView(dx.Tables[0]);
            double[] tot = { 0, 0 };
            foreach (DataRowView rv in trnsView)
            {
                tot[0] += double.Parse(rv["dr_amount"].ToString());
                tot[1] += double.Parse(rv["cr_amount"].ToString());
            }
            bal.Add(tot[0]);
            bal.Add(tot[1]);
            return bal;

        }
        public static int GetSubGroupCount(int gid)
        {
            int ret = 0;

            try
            {
                F5Group();
                GroupView.Sort = "parent";
                GroupView.RowFilter = "[parent]=" + gid;
                ret = GroupView.Count;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message.ToString());
            }
            return ret;
        }
        public static void InitializeJson()
        {
            try
            {


                Accounts[] ac = new Accounts[] { new Accounts( ),
                    new Accounts( )
                };
                ac[0] = new Accounts("Office Account", "A1", "D:/macdata.mdb");
                ac[0].Code = "A1";
                ac[0].DBloc = "E:/DeveloperM/Projects/macc/macc/DB/macdb.accdb";
                ac[1].CompanyName = "Personal Account";
                ac[1].Code = "A2";
                ac[1].DBloc = "E:/DeveloperM/db/macdata.mdb";
                string json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(ac);
                // Write that JSON to txt file
                File.WriteAllText("d:/dbjason.jason", json);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
        }

    }





    class Accounts
    {
        string acname;
        string code;
        string dbloc;
        public Accounts(string a, string c, string loc)
        {
            acname = a; code = c; dbloc = loc;

        }

        public Accounts()
        {
            // TODO: Complete member initialization
        }
        //public string Company
        //{
        //    get { return "Company"; }
        //}
        public string CompanyName
        {
            get
            {
                return this.acname;
            }
            set
            {
                this.acname = value;
            }


        }
        public string Code
        {
            get { return this.code; }
            set
            {
                this.code = value;
            }
        }
        public string DBloc
        {

            get { return this.dbloc; }
            set
            {
                this.dbloc = value;
            }
        }

    }
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.StatusStrip)]
    public class BindableToolStripStatusLabel : ToolStripStatusLabel, IBindableComponent
    {
        private BindingContext _context = null;
        public BindingContext BindingContext
        {
            get
            {
                if (null == _context)
                {
                    _context = new BindingContext();
                }

                return _context;
            }
            set { _context = value; }
        }

        private ControlBindingsCollection _bindings;

        public ControlBindingsCollection DataBindings
        {
            get
            {
                if (null == _bindings)
                {
                    _bindings = new ControlBindingsCollection(this);
                }
                return _bindings;
            }
            set { _bindings = value; }
        }
    }

}
