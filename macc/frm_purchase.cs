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

    public partial class frm_purchase : Form
    {
        int currentrowIndex = 0;

        public frm_purchase()
        {
            InitializeComponent();



        }

        private void frm_purchase_Load(object sender, EventArgs e)
        {

            //Lets add columns by creating array of datagridview columns
            //DataGridViewColumn[] cols = { new DataGridViewTextBoxColumn(), new DataGridViewTextBoxColumn(), new DataGridViewTextBoxColumn(),
            //                                new DataGridViewTextBoxColumn(), new DataGridViewTextBoxColumn(), new DataGridViewTextBoxColumn(), 
            //                                new DataGridViewTextBoxColumn(), new DataGridViewTextBoxColumn(), new DataGridViewTextBoxColumn(), 
            //                                new DataGridViewTextBoxColumn(), new DataGridViewTextBoxColumn(), new DataGridViewTextBoxColumn(),
            //                                new DataGridViewTextBoxColumn() , new DataGridViewTextBoxColumn()};
            //cols[0].HeaderText = "SLNO";
            //cols[0].Width = 50;
            //cols[1].HeaderText = "PCODE";
            //cols[1].Width = 50;
            //cols[2].HeaderText = "ITEM";
            //cols[2].Width = 170;
            //cols[3].HeaderText = "QTY";
            //cols[3].Width = 40;
            //cols[4].HeaderText = "FREE";
            //cols[4].Width = 40;
            //cols[5].HeaderText = "RATE";
            //cols[5].Width = 40;
            //cols[6].HeaderText = "EXP";
            //cols[6].Width = 60;
            //cols[7].HeaderText = "BATCH";
            //cols[7].Width = 60;
            //cols[8].HeaderText = "D%";
            //cols[8].Width = 40;
            //cols[9].HeaderText = "GROSS";
            //cols[10].HeaderText = "GST%";
            //cols[10].Width = 40;
            //cols[11].HeaderText = "GST";
            //cols[11].Width = 80;
            //cols[12].HeaderText = "NET";

            //cols[13].HeaderText = "ITEMCODE";
            //cols[13].Visible = false;
            ////LETS ADD IT TO THE GRIDVIEW
            //dataGridView1.Columns.AddRange(cols);



        }

        private void textBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            double srate, gross, qty, cost;

            if (e.ColumnIndex == SRATE.Index)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[SRATE.Index].FormattedValue.ToString().ToString() != null)
                {
                    double.TryParse(dataGridView1.Rows[e.RowIndex].Cells[SRATE.Index].Value.ToString(), out srate);
                    double.TryParse(dataGridView1.Rows[e.RowIndex].Cells[COST.Index].Value.ToString(), out cost);
                    double.TryParse(dataGridView1.Rows[e.RowIndex].Cells[cl_QTY.Index].Value.ToString(), out qty);

                    gross = cost * qty;
                    dataGridView1.Rows[e.RowIndex].Cells[cl_GROSS.Index].Value = gross;
                    dataGridView1.Rows[e.RowIndex].Cells[PROFIT.Index].Value = (qty * srate) - gross;

                }
                else
                {
                    txt_narration.Focus();
                }

            }
            else if (e.ColumnIndex == cl_ITEM.Index)
            {
                if (dataGridView1.CurrentCell.Value != null)
                {
                    dataGridView1.EndEdit();
                    txt_size.Focus();
                    currentrowIndex = dataGridView1.CurrentRow.Index;
                }
            }
            dataGridView1.EndEdit();
        }
        public void KeyMovement(KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }

        }

        private void txt_size_KeyDown(object sender, KeyEventArgs e)
        {
            this.KeyMovement(e);
        }

        private void txt_size_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txt_model_KeyDown(object sender, KeyEventArgs e)
        {
            KeyMovement(e);
        }

        private void txt_color_KeyDown(object sender, KeyEventArgs e)
        {
            KeyMovement(e);
        }

        private void txt_catagory_KeyDown(object sender, KeyEventArgs e)
        {
            KeyMovement(e);
        }

        private void txt_type_KeyDown(object sender, KeyEventArgs e)
        {
            KeyMovement(e);
        }

        private void txt_sp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                dataGridView1.Rows[currentrowIndex].Cells[MODEL.Index].Value = txt_model.Text;
                dataGridView1.Rows[currentrowIndex].Cells[SIZE.Index].Value = txt_size.Text;
                dataGridView1.Rows[currentrowIndex].Cells[COLOR.Index].Value = txt_color.Text ;
                dataGridView1.Rows[currentrowIndex].Cells[CATAGORY.Index].Value = txt_catagory.Text;
                dataGridView1.Rows[currentrowIndex].Cells[TYPE.Index].Value = txt_type.Text;
                dataGridView1.Rows[currentrowIndex].Cells[SP.Index].Value = txt_sp.Text;
                dataGridView1.Focus();
                dataGridView1.CurrentCell = dataGridView1.Rows[currentrowIndex].Cells[cl_QTY.Index];
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[cl_ITEM.Index].Value != null)
            {
                txt_size.Text = dataGridView1.Rows[e.RowIndex].Cells[SIZE.Index].Value.ToString();
                txt_model.Text = dataGridView1.Rows[e.RowIndex].Cells[MODEL.Index].Value.ToString();
                txt_color.Text = dataGridView1.Rows[e.RowIndex].Cells[COLOR.Index].Value.ToString();
                txt_catagory.Text = dataGridView1.Rows[e.RowIndex].Cells[CATAGORY.Index].Value.ToString();
                txt_type.Text = dataGridView1.Rows[e.RowIndex].Cells[TYPE.Index].Value.ToString();
                txt_sp.Text = dataGridView1.Rows[e.RowIndex].Cells[SP.Index].Value.ToString();
            }
            else
            {
                txt_sp.Text = "";
                txt_size.Text = "";
                txt_model.Text = "";
                txt_catagory.Text = "";
                txt_color.Text = "";
            }
        }
    }
}
