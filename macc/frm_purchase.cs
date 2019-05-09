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

    public partial class frm_purchase :Form  
    {


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
    }
}
