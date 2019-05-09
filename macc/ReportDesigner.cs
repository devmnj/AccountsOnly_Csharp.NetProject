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
    public partial class ReportDesigner : Form
    {
        public ReportDesigner()
        {
            InitializeComponent();
        }

        private void ReportDesigner_Load(object sender, EventArgs e)
        {
            OleDbDataAdapter rs = new OleDbDataAdapter();
            DataSet ds = new DataSet();
            DataView dv = new DataView();

            try
            {
                rs = new OleDbDataAdapter("select rtitle,rmodule from reportengine", Globals.con);
                rs.Fill(ds, "reportengine");
                txt_title.DataSource = ds.Tables["reportengine"];
                txt_title.DisplayMember = "rtitle";
                cmb_module.DataSource = ds.Tables["reportengine"];
                cmb_module.DisplayMember = "rmodule";
            }
            catch (OleDbException eee)
            {

            }



        }
        private void cmd_clear_Click(object sender, EventArgs e)
        {
            txt_footer_total_col.Text = "";
            txt_footer_total_label.Text = "";
            txt_footer_col_num.Text = "";
            txt_footer_col_name.Text = "";
            txt_f1_title.Enabled = false;
            txt_f1_query.Enabled = false;
            txt_f1_table.Enabled = false;
            txt_f1_col.Enabled = false;
            txt_f2_title.Enabled = false;
            txt_f2_query.Enabled = false;
            txt_f2_table.Enabled = false;
            txt_f2_col.Enabled = false;
            txt_filter1_alias.Text = "";
            txt_query.Text = "";
            txt_title.Text = "";
            cmb_module.Text = "";
            Button2.Enabled = false;
            cmd_save.Enabled = true;
            Button1.Enabled = false;
            Button2.Enabled = false;
            txt_orderbys.Text = "";
            txt_f1_query.Text = "";
            txt_f1_title.Text = "";
            txt_f2_query.Text = "";
            txt_f2_title.Text = "";
            txt_f2_col.Text = "";
            txt_f2_table.Text = "";
            txt_f1_col.Text = "";
            txt_f1_table.Text = "";
            txt_filter1_alias.Text = "";
            txt_filter2_alias.Text = "";
            CheckBox_filter1.Checked = false;
            CheckBox_filter2.Checked = false;
            txt_format.Text = "";
            txt_alignment.Text = "";
            CheckBox_frmDate.Checked = false;
            CheckBox_ToDate.Checked = false;
        }

        private void txt_title_KeyDown(object sender, KeyEventArgs e)
        {
            OleDbDataAdapter rs = new OleDbDataAdapter();
            DataSet ds = new DataSet();
            DataView dv = new DataView();
            try
            {
                if (txt_title.Text != null && e.KeyCode == Keys.Enter)
                {
                    rs = new OleDbDataAdapter("select * from reportengine where rtitle='" + txt_title.Text + "'", Globals.con);

                    rs.Fill(ds, "reportengine");
                    dv = new DataView(ds.Tables[0]);
                    if (dv.Count >= 1)
                    {
                        txt_title.Text = dv[0]["rtitle"].ToString();
                        cmb_module.Text = dv[0]["rmodule"].ToString();
                        txt_query.Text = dv[0]["rquery"].ToString();
                        txt_format.Text = dv[0]["format"].ToString();
                        txt_alignment.Text = dv[0]["alignment"].ToString();
                        if (dv[0]["fromdate"].ToString() == "Y")
                        {
                            CheckBox_frmDate.Checked = true;
                        }
                        else
                        {
                            CheckBox_frmDate.Checked = false;
                        }

                        if (dv[0]["todate"].ToString() == "Y")
                        {
                            CheckBox_ToDate.Checked = true;
                        }
                        else
                        {
                            CheckBox_ToDate.Checked = false;
                        }

                        string T = dv[0]["filter1"].ToString();

                        if (T == "Yes")
                        {
                            CheckBox_filter1.Checked = true;
                            txt_f1_query.Enabled = true;
                            txt_f1_title.Enabled = true;
                            txt_f1_table.Enabled = true;
                            txt_f1_col.Enabled = true;
                            txt_f1_title.Text = dv[0]["filter1_caption"].ToString();
                            txt_f1_query.Text = dv[0]["filter1_query"].ToString();
                            txt_f1_table.Text = dv[0]["filter1_table"].ToString();
                            txt_f1_col.Text = dv[0]["filter1_col"].ToString();
                            txt_filter1_alias.Text = dv[0]["filter1_alias"].ToString();
                        }
                        T = dv[0]["filter2"].ToString();
                        if (T == "Yes")
                        {
                            CheckBox_filter2.Checked = true;
                            txt_f2_query.Enabled = true;
                            txt_f2_title.Enabled = true;
                            txt_f2_table.Enabled = true;
                            txt_f2_col.Enabled = true;
                            txt_f2_title.Text = dv[0]["filter2_caption"].ToString();
                            txt_f2_query.Text = dv[0]["filter2_query"].ToString();
                            txt_f2_table.Text = dv[0]["filter2_table"].ToString();
                            txt_f2_col.Text = dv[0]["filter2_col"].ToString();
                            txt_filter2_alias.Text = dv[0]["filter2_alias"].ToString();
                        }
                        txt_footer_col_name.Text = dv[0]["footer_colname"].ToString();
                        txt_footer_col_num.Text = dv[0]["footer_colnumber"].ToString();
                        txt_orderbys.Text = dv[0]["orderbys"].ToString();
                        txt_footer_total_label.Text = dv[0]["footer_total_label"].ToString();
                        txt_footer_total_col.Text = dv[0]["footer_total_colnum"].ToString();

                        cmd_save.Enabled = false;
                        Button1.Enabled = true;
                        Button2.Enabled = true;
                    }



                }

            }
            catch (OleDbException e56) { }
        }

        private void txt_f1_col_TextChanged(object sender, EventArgs e)
        {
            txt_f1_query.Text = "select " + txt_f1_col.Text + " from  " + txt_f1_table.Text;
            txt_filter1_alias.Text = txt_f1_col.Text;
        }

        private void cmb_module_Enter(object sender, EventArgs e)
        {
            cmb_module.DroppedDown = true;
        }

        private void CheckBox_filter1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CheckBox_filter1_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckBox_filter1.Checked == false)
                {
                    txt_f1_title.Enabled = false;
                    txt_f1_query.Enabled = false;
                    txt_f1_table.Enabled = false;
                    txt_f1_col.Enabled = false;
                }
                else
                {
                    txt_f1_title.Enabled = true;
                    txt_f1_query.Enabled = true;
                    txt_f1_table.Enabled = true;
                    txt_f1_col.Enabled = true;
                }

                if (CheckBox_filter2.Checked == false)
                {
                    txt_f2_title.Enabled = false;
                    txt_f2_query.Enabled = false;
                    txt_f2_table.Enabled = false;
                    txt_f2_col.Enabled = false;
                }
                else
                {
                    txt_f2_title.Enabled = true;
                    txt_f2_query.Enabled = true;
                    txt_f2_table.Enabled = true;
                    txt_f2_col.Enabled = true;
                }

            }

            catch (OleDbException Excn)
            {

                MessageBox.Show(Excn.Message.ToString());


            }
        }

        private void txt_title_Enter(object sender, EventArgs e)
        {
            txt_title.DroppedDown = true;
        }

        private void cmd_save_Click(object sender, EventArgs e)
        {

            //Save
            string fdate, todate;
            string f1, f2;
            string f1_caption, f1_query, f1_table, f1_col;
            string f2_caption, f2_query, f2_table, f2_col;

            try
            {

                if (txt_title.Text != null && txt_title.Text != null && cmb_module.Text != null)
                {

                    if (CheckBox_filter1.Checked == true)
                    {
                        f1 = "Yes";
                        f1_caption = txt_f1_title.Text;
                        f1_query = txt_f1_query.Text;
                        f1_col = txt_f1_table.Text;
                        f1_table = txt_f1_table.Text;
                    }
                    else
                    {
                        f1 = "No";
                        f1_caption = "";
                        f1_col = "";
                        f1_query = "";
                        f1_table = "";

                    }

                    if (CheckBox_filter2.Checked == true)
                    {

                        f2 = "Yes";
                        f2_caption = txt_f2_title.Text;
                        f2_query = txt_f2_query.Text;
                        f2_col = txt_f2_table.Text;
                        f2_table = txt_f2_table.Text;
                    }
                    else
                    {
                        f2 = "No";
                        f2_caption = "";
                        f2_col = "";
                        f2_query = "";
                        f2_table = "";
                    }




                    fdate = "N";
                    todate = "N";
                    if (CheckBox_frmDate.Checked == true) { fdate = "Y"; }
                    if (CheckBox_ToDate.Checked == true) { todate = "Y"; }
                    OleDbDataAdapter repadapter = new OleDbDataAdapter("select * from reportengine", Globals.con);
                    DataSet dataset = new DataSet();
                    DataRow newRow;
                    repadapter.Fill(dataset);
                    newRow = dataset.Tables[0].NewRow();
                    newRow["rtitle"] = txt_title.Text;
                    newRow["rmodule"] = cmb_module.Text;
                    newRow["fromdate"] = fdate;
                    newRow["todate"] = todate;
                    newRow["alignment"] = txt_alignment.Text.ToString();
                    newRow["format"] = txt_format.Text.ToString();
                    newRow["rquery"] = txt_query.Text.ToString();
                    newRow["filter1"] = f1;
                    newRow["filter2"] = f2;
                    newRow["filter1_caption"] = f1_caption;
                    newRow["filter1_col"] = f1_col;
                    newRow["filter1_table"] = f1_table;
                    newRow["filter1_query"] = f1_query;
                    newRow["filter2_caption"] = f2_caption;
                    newRow["filter2_col"] = f2_col;
                    newRow["filter2_table"] = f2_table;
                    newRow["filter2_query"] = f2_query;
                    newRow["filter2_alias"] = txt_filter2_alias.Text;
                    newRow["filter1_alias"] = txt_filter1_alias.Text;
                    newRow["orderbys"] = txt_orderbys.Text;
                    newRow["footer_colname"] = txt_footer_col_name.Text.ToString();
                    newRow["footer_colnumber"] = txt_footer_col_num.Text.ToString();
                     newRow["footer_total_label"] = txt_footer_total_label.Text.ToString();
                    newRow["footer_total_colnum"] = txt_footer_total_col.Text.ToString();

                    dataset.Tables[0].Rows.Add(newRow);
                    OleDbCommandBuilder cmd = new OleDbCommandBuilder(repadapter);
                    repadapter.InsertCommand = cmd.GetInsertCommand();
                    int j = repadapter.Update(dataset.Tables[0]);
                    if (j != -1)
                    {
                        MessageBox.Show("Report Saved");
                    }
                    else
                    {
                        MessageBox.Show("Enter data correctly");
                    }



                }
            }

            catch (Exception exc)
            {
                MessageBox.Show(exc.Message.ToString());

            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            String fdate, toDate;
            String f1, f2;
            String f1_caption, f1_query, f1_table, f1_col;
            String f2_caption, f2_query, f2_table, f2_col;


            try
            {


                if (txt_title.Text != null && txt_title.Text != null && cmb_module.Text != null)
                {
                    OleDbDataAdapter repadapter = new OleDbDataAdapter("select * from reportengine where rtitle='" + txt_title.Text + "'", Globals.con);
                    DataSet ds = new DataSet();
                    repadapter.Fill(ds);
                    DataView dv = new DataView(ds.Tables[0]);
                    DataRow row;


                    if (dv.Count == 1)
                    {
                        row = dv.Table.Rows[0];
                        fdate = "N";
                        toDate = "N";

                        if (CheckBox_filter1.Checked == true)
                        {
                            f1 = "Yes";
                            f1_caption = txt_f1_title.Text;
                            f1_query = txt_f1_query.Text;
                            f1_col = txt_f1_col.Text;
                            f1_table = txt_f1_table.Text;
                        }

                        else
                        {
                            f1 = "No";
                            f1_caption = "";
                            f1_col = "";
                            f1_query = "";
                            f1_table = "";
                        }

                        if (CheckBox_filter2.Checked == true)
                        {
                            f2 = "Yes";
                            f2_caption = txt_f2_title.Text;
                            f2_query = txt_f2_query.Text;
                            f2_col = txt_f2_table.Text;
                            f2_table = txt_f2_table.Text;
                        }
                        else
                        {
                            f2 = "No";
                            f2_caption = "";
                            f2_col = "";
                            f2_query = "";
                            f2_table = "";
                        }
                        fdate = "N";
                        toDate = "N";
                        if (CheckBox_frmDate.Checked == true) { fdate = "Y"; }
                        if (CheckBox_ToDate.Checked == true) { toDate = "Y"; }

                        if (CheckBox_frmDate.Checked == true) { fdate = "Y"; }
                        if (CheckBox_ToDate.Checked == true) { toDate = "Y"; }
                        row.BeginEdit();
                        row["rtitle"] = txt_title.Text;
                        row["rmodule"] = cmb_module.Text;
                        row["fromdate"] = fdate;
                        row["todate"] = toDate;
                        row["alignment"] = txt_alignment.Text.ToString();
                        row["format"] = txt_format.Text.ToString();
                        row["rquery"] = txt_query.Text.ToString();
                        row["filter1"] = f1;
                        row["filter2"] = f2;
                        row["filter1_caption"] = f1_caption;
                        row["filter1_col"] = f1_col;
                        row["filter1_table"] = f1_table;
                        row["filter1_query"] = f1_query;
                        row["filter2_caption"] = f2_caption;
                        row["filter2_col"] = f2_col;
                        row["filter2_table"] = f2_table;
                        row["filter2_query"] = f2_query;
                        row["filter1_alias"] = txt_filter1_alias.Text;
                        row["filter2_alias"] = txt_filter2_alias.Text;
                        row["footer_colname"] = txt_footer_col_name.Text.ToString();
                        row["footer_colnumber"] = txt_footer_col_num.Text.ToString();

                        row["footer_total_label"] = txt_footer_total_label.Text.ToString();
                        row["footer_total_colnum"] = txt_footer_total_col.Text.ToString();

                        row["orderbys"] = txt_orderbys.Text;
                        row.EndEdit();
                        OleDbCommandBuilder cmdbuilder = new OleDbCommandBuilder(repadapter);
                        repadapter.UpdateCommand = cmdbuilder.GetUpdateCommand();
                        int jj = repadapter.Update(ds.Tables[0]);
                        if (jj != -1) { MessageBox.Show("Report Edited"); }
                    }
                }



            }
            catch (OleDbException exc)
            {
                MessageBox.Show(exc.Message.ToString());

            }
        }

        private void txt_title_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt_footer_col_num_TextChanged(object sender, EventArgs e)
        {

        }

    }
}