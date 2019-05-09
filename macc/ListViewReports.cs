using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace macc
{
    public partial class ListViewReports : Form
    {
        string Filter_Co1, Filter_Col2, Filter_alias1;
        public ListViewReports()
        {
            InitializeComponent();
        }

        private void ListViewReports_Load(object sender, EventArgs e)
        {
            try
            {
                OleDbDataAdapter rs = new OleDbDataAdapter("select  distinct(rmodule)  from reportengine", Globals.con);
                DataSet ds = new DataSet();
                rs.Fill(ds, "reportengine");

                ListBox_modules.DataSource = ds.Tables["reportengine"];
                ListBox_modules.DisplayMember = "rmodule";

                lbl_rows.Text = " ";
            }
            catch (OleDbException eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
        }

        private void ListBox_modules_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ListBox_modules_Click(object sender, EventArgs e)
        {
            try
            {
                Button1.Enabled = false;
                if (ListBox_modules.Text != null)
                {
                    OleDbDataAdapter rs = new OleDbDataAdapter("select  rtitle  from reportengine where rmodule='" + ListBox_modules.Text + "'", Globals.con);
                    DataSet ds = new DataSet();
                    rs.Fill(ds, "reportengine");
                    ListBox1.DataSource = ds.Tables["reportengine"];
                    ListBox1.DisplayMember = "rtitle";
                }
            }
            catch (OleDbException exxx)
            {
                MessageBox.Show(exxx.Message.ToString());
            }
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ListBox1_Click(object sender, EventArgs e)
        {

            DataView dv = new DataView();

            try
            {

                cmb_filter1.Text = "";
                if (ListBox1.SelectedValue.ToString() != null)
                {
                    OleDbDataAdapter rs = new OleDbDataAdapter("select filter1_caption,filter2_caption,filter1_alias,filter2_alias, filter1_table, filter1_col,filter2_col,fromdate,todate,orderbys,filter1,filter2,filter1_caption,filter1_query,filter2_caption,filter2_query from  reportengine where rtitle='" + ListBox1.Text.ToString() + "'", Globals.con);
                    DataSet ds = new DataSet();
                    rs.Fill(ds, "reportengine");
                    dv = new DataView(ds.Tables["reportengine"]);
                    string takeVal = null;
                    if (dv.Count == 1)
                    {
                        takeVal = dv[0]["fromdate"].ToString();
                        if (takeVal == "Y")
                        {
                            DateTimePicker_from.Enabled = true;
                        }
                        else
                        {
                            DateTimePicker_from.Enabled = false;
                        }
                        takeVal = dv[0]["todate"].ToString();
                        if (takeVal == "Y")
                        {
                            DateTimePicker_To.Enabled = true;
                        }
                        else
                        {
                            DateTimePicker_To.Enabled = false;
                        }


                        if (dv[0]["orderbys"].ToString().Length > 0)
                        {
                            string[] ordrbys = dv[0]["orderbys"].ToString().Split('|');
                            ListBox_orderby.DataSource = ordrbys.ToList();
                            GroupBox_orderby.Enabled = true;
                        }
                        else
                        {
                            GroupBox_orderby.Enabled = false;
                        }
                        Button1.Enabled = true;
                        if (dv[0]["filter1"].ToString() == "Yes")
                        {
                            var q = dv[0]["filter1_query"].ToString();
                            OleDbDataAdapter f1_rs = new OleDbDataAdapter(q, Globals.con);
                            DataSet f1_ds = new DataSet();
                            f1_rs.Fill(f1_ds);
                            string f1_tbl = dv[0]["filter1_table"].ToString();
                            string f1_col = dv[0]["filter1_col"].ToString();
                            string f1_alias = dv[0]["filter1_alias"].ToString();
                            Filter_Co1 = f1_col;
                            Filter_alias1 = f1_alias;
                            DataTable dt = new DataTable(f1_tbl);
                            AutoCompleteStringCollection strCol = new AutoCompleteStringCollection();
                            if (f1_alias == f1_col)
                            {
                                var f1_q = from fil1 in f1_ds.Tables[0].AsEnumerable() select fil1.Field<string>(f1_col);
                                strCol.AddRange(f1_q.ToArray());
                            }
                            else
                            {
                                var f1_q = from fil1 in f1_ds.Tables[0].AsEnumerable() select fil1.Field<string>(f1_col) + " | " + fil1.Field<string>(f1_alias);
                                strCol.AddRange(f1_q.ToArray());
                            }



                            cmb_filter1.AutoCompleteMode = AutoCompleteMode.Suggest;
                            cmb_filter1.AutoCompleteSource = AutoCompleteSource.CustomSource;
                            cmb_filter1.AutoCompleteCustomSource = strCol;
                            GroupBox_filter1.Enabled = true;
                            lbl_F1_caption.Text = dv[0]["filter1_caption"].ToString().ToUpper();
                        }

                        else
                        {
                            GroupBox_filter1.Enabled = false;
                        }


                        if (dv[0]["filter2"].ToString() == "Yes")
                        {
                            string q = dv[0]["filter2_query"].ToString();
                            OleDbDataAdapter f1_rs = new OleDbDataAdapter(q, Globals.con);
                            DataSet f1_ds = new DataSet();
                            f1_rs.Fill(f1_ds);
                            string f1_tbl = dv[0]["filter2_table"].ToString();
                            string f1_col = dv[0]["filter2_col"].ToString();
                            string f1_alias = dv[0]["filter1_alias"].ToString();
                            DataTable dt = new DataTable(f1_tbl);
                            var f1_q = from fil1 in f1_ds.Tables[0].AsEnumerable() select fil1.Field<String>(f1_col);
                            AutoCompleteStringCollection strCol = new AutoCompleteStringCollection();
                            Filter_Col2 = f1_alias;
                            strCol.AddRange(f1_q.ToArray());
                            Console.WriteLine(strCol.Count);
                            cmb_filter2.AutoCompleteMode = AutoCompleteMode.Suggest;
                            cmb_filter2.AutoCompleteSource = AutoCompleteSource.CustomSource;
                            cmb_filter2.AutoCompleteCustomSource = strCol;
                            GroupBox_filter2.Enabled = true; ;
                            lbl_f2_caption.Text = dv[0]["filter2_caption"].ToString().ToUpper();
                        }
                        else
                        {
                            GroupBox_filter2.Enabled = false;
                        }
                        Button1.Enabled = true;
                    }
                }
            }
            catch (OleDbException ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OleDbDataAdapter rpadat = new OleDbDataAdapter();

            string takeformat = null;
            try
            {
                if (ListBox1.SelectedValue.ToString() != null)
                {

                    rpadat = new OleDbDataAdapter("select * from  reportengine where rtitle='" + ListBox1.Text.ToString() + "'", Globals.con);
                    DataSet ds = new DataSet();
                    rpadat.Fill(ds, "reportengine");
                    DataView dv = new DataView(ds.Tables["reportengine"]);

                    if (dv.Count == 1)
                    {
                        string q = dv[0]["rquery"].ToString();

                        if (DateTimePicker_from.Enabled == true && DateTimePicker_To.Enabled == true)
                        {
                            q = q.Replace("}", "#" + DateTimePicker_from.Value.Date + "#").Replace("{", "#" + DateTimePicker_To.Value.Date + "#");
                        }
                        else if (DateTimePicker_from.Enabled == true)
                        {
                            if (DateTimePicker_from.Enabled == true) { q = q.Replace("{}", "#" + DateTimePicker_from.Value.Date + "#"); }
                        }

                        if (GroupBox_filter1.Enabled == true)
                        {
                            if (cmb_filter1.Text != null)
                            {
                                if (Filter_Co1 == Filter_alias1)
                                {
                                    q = q.Replace("<where'>", " where " + Filter_Co1 + "='" + cmb_filter1.Text + "'").Replace("<where>", " where " + Filter_Co1 + "=" + cmb_filter1.Text + "");
                                }
                                else
                                {
                                    string[] filt_str = cmb_filter1.Text.ToString().Split('|');
                                    q = q.Replace("<where'>", " where " + Filter_alias1 + "='" + filt_str[1] + "'").Replace("<where>", " where " + Filter_alias1 + "=" + filt_str[1] + "");
                                }
                            }
                            else
                            {
                                q = q.Replace("<where'>", " ").Replace("<where>", " ");
                            }
                        }
                        if (ListBox_orderby.Text != null && GroupBox_orderby.Enabled == true)
                        {
                            q = q + " order by " + ListBox_orderby.Text;
                        }
                        //            Console.WriteLine(q)

                        takeformat = dv[0]["format"].ToString();
                        string[] f = takeformat.Split(',');
                        OleDbDataAdapter rs = new OleDbDataAdapter(q, Globals.con);
                        ds = new DataSet();
                        var alStr = dv[0]["alignment"].ToString().Split(',');
                        rs.Fill(ds);
                        lbl_rows.Text = "Rows:" + ds.Tables[0].Rows.Count.ToString();
                        dv = new DataView(ds.Tables[0]);



                        List<string> TotalFooterList = new List<string>();

                        int k = 0;
                        if (dv.Count >= 1)
                        {
                            ListView1.Clear();
                            ColumnHeader headers = new ColumnHeader();
                            ListView1.View = View.Details;
                            headers.Text = "";
                            headers.Width = 0;
                            ListView1.Columns.Add(headers);

                            headers = new ColumnHeader();

                            headers.Text = "SLNO";
                            headers.Width = 20;
                            ListView1.Columns.Add(headers);
                            foreach (DataColumn col in ds.Tables[0].Columns)
                            {
                                //  if (alStr.Length >= k)  

                                if (alStr[k] == "r")
                                {

                                    ListView1.Columns.Add(col.ColumnName.ToUpper().Trim(), -2, HorizontalAlignment.Right);
                                }
                                else
                                {
                                    ListView1.Columns.Add(col.ColumnName.ToUpper().Trim());
                                }
                                k = k + 1;
                            }


                            headers = new ColumnHeader();
                            headers.Text = "";
                            headers.Width = 0;
                            ListView1.Columns.Add(headers);

                            dv = new DataView(ds.Tables[0]);
                            int i = 0;
                            ListViewItem itms = new ListViewItem();
                            List<string> itemList = new List<string>();
                            int kk = 0;
                            foreach (DataRow r in dv.Table.Rows)
                            {
                                itms = new ListViewItem();
                                itemList.Add((kk + 1).ToString());
                                for (i = 0; i <= ds.Tables[0].Columns.Count - 1; i++)
                                {

                                    if (f.Length >= i)
                                    {
                                        if (f[i].Trim().Length == 0)
                                        {
                                            itemList.Add(r[i].ToString().Trim());
                                        }
                                        else
                                        {
                                            itemList.Add(String.Format("{" + f[i] + "}", r[i].ToString().Trim()));
                                        }
                                    }
                                    else
                                    {
                                        itemList.Add(r[i].ToString().Trim());
                                    }
                                }
                                var arr = itemList.ToArray();
                                itms.SubItems.AddRange(arr);
                                ListView1.Items.Add(itms);
                                itemList.Clear();
                                kk = kk + 1;
                            }

                            //Sum of Columns
                            for (i = 0; i <= ds.Tables[0].Columns.Count - 1; i++)
                            {
                                TotalFooterList.Add("");
                            }
                            itms = new ListViewItem();
                            var a = itemList.ToArray();
                            itms.SubItems.AddRange(a);
                            ListView1.Items.Add(itms);

                            DataSet redataset = new DataSet();
                            rpadat.Fill(redataset);
                            DataView redv = new DataView(redataset.Tables[0]);
                            if (redv.Count > 0)
                            {
                                string[] foo_colnames = redv[0]["footer_colname"].ToString().Split(',');
                                string[] foo_colnums = redv[0]["footer_colnumber"].ToString().Split(',');


                                TotalFooterList.Clear();

                                for (i = 0; i <= ds.Tables[0].Columns.Count - 1; i++)
                                {
                                    TotalFooterList.Add("");
                                }

                                int foo_clsize = foo_colnames[0].Length;

                                if (foo_clsize > 0 && foo_colnames.Count() > 0)
                                {
                                    int po = 0; ListViewItem it = new ListViewItem();
                                    int lp = 0;
                                    int.TryParse(redv[0]["footer_total_colnum"].ToString(), out lp);
                                    TotalFooterList.Insert(lp, redv[0]["footer_total_label"].ToString());
                                    foreach (string col in foo_colnames)
                                    {
                                        var totalFreight = from tbl in ds.Tables[0].AsEnumerable() select tbl.Field<int>(col);
                                        List<int> tot = totalFreight.ToList<int>();
                                        TotalFooterList.Insert(int.Parse(foo_colnums[po]), tot.Sum().ToString());
                                        var el = TotalFooterList.ToArray();
                                        it = new ListViewItem(el);
                                    }

                                    it.ForeColor = Color.Crimson;
                                    it.Font = new System.Drawing.Font(FontFamily.GenericSerif, 12, FontStyle.Bold);
                                    ListView1.Items.Add(it);
                                }
                            }




                            //var totalFreight = from tbl in ds.Tables[0].AsEnumerable() select tbl.Field<decimal>("Amount");
                            //List<decimal > tot = totalFreight.ToList<decimal>();
                            //Console.WriteLine(tot.Sum());
                            //TotalFooterList.Insert(6,tot.Sum().ToString());
                            //var el = TotalFooterList.ToArray();
                            //ListViewItem it =new ListViewItem(el);                           
                            //ListView1.Items.Add(it);

                            //Sum of Columns
                        }
                        ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                    }
                    else
                    {
                        MessageBox.Show("No records found");
                    }
                }
            }

            catch (OleDbException er)
            {
                MessageBox.Show(er.Message.ToString());
            }
        }

        private void btn_excel_Click(object sender, EventArgs e)
        {
            ExportReportsEngine excel = new ExportReportsEngine();
            excel.ExcelExport(ListBox1.Text, ListView1);
        }
    }
}

