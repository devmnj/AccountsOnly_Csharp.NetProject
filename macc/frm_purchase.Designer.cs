 
namespace macc
{
    partial class frm_purchase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cl_slno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_pcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_ITEM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_QTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_FREE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_RATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_DISC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_GROSS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_GSTP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_GSTAMOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_NET = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cl_slno,
            this.cl_pcode,
            this.cl_ITEM,
            this.cl_QTY,
            this.cl_FREE,
            this.cl_RATE,
            this.cl_DISC,
            this.cl_GROSS,
            this.cl_GSTP,
            this.cl_GSTAMOUNT,
            this.cl_NET});
            this.dataGridView1.Location = new System.Drawing.Point(12, 67);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridView1.Size = new System.Drawing.Size(803, 283);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.TabStop = false;
            // 
            // cl_slno
            // 
            this.cl_slno.HeaderText = "SLNO";
            this.cl_slno.Name = "cl_slno";
            this.cl_slno.Width = 40;
            // 
            // cl_pcode
            // 
            this.cl_pcode.HeaderText = "PCODE";
            this.cl_pcode.Name = "cl_pcode";
            this.cl_pcode.Width = 50;
            // 
            // cl_ITEM
            // 
            this.cl_ITEM.HeaderText = "ITEM";
            this.cl_ITEM.Name = "cl_ITEM";
            this.cl_ITEM.Width = 200;
            // 
            // cl_QTY
            // 
            this.cl_QTY.HeaderText = "QTY";
            this.cl_QTY.Name = "cl_QTY";
            this.cl_QTY.Width = 40;
            // 
            // cl_FREE
            // 
            this.cl_FREE.HeaderText = "F";
            this.cl_FREE.Name = "cl_FREE";
            this.cl_FREE.Width = 40;
            // 
            // cl_RATE
            // 
            this.cl_RATE.HeaderText = "RATE";
            this.cl_RATE.Name = "cl_RATE";
            this.cl_RATE.Width = 80;
            // 
            // cl_DISC
            // 
            this.cl_DISC.HeaderText = "D%";
            this.cl_DISC.Name = "cl_DISC";
            this.cl_DISC.Width = 40;
            // 
            // cl_GROSS
            // 
            this.cl_GROSS.HeaderText = "GROSS";
            this.cl_GROSS.Name = "cl_GROSS";
            // 
            // cl_GSTP
            // 
            this.cl_GSTP.HeaderText = "GST%";
            this.cl_GSTP.Name = "cl_GSTP";
            this.cl_GSTP.Width = 40;
            // 
            // cl_GSTAMOUNT
            // 
            this.cl_GSTAMOUNT.HeaderText = "GST";
            this.cl_GSTAMOUNT.Name = "cl_GSTAMOUNT";
            this.cl_GSTAMOUNT.Width = 70;
            // 
            // cl_NET
            // 
            this.cl_NET.HeaderText = "NET";
            this.cl_NET.Name = "cl_NET";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboBox1.Location = new System.Drawing.Point(718, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(97, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // frm_purchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 496);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frm_purchase";
            this.Text = "Stock Purchase";
            this.Load += new System.EventHandler(this.frm_purchase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_slno;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_pcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_ITEM;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_QTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_FREE;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_RATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_DISC;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_GROSS;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_GSTP;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_GSTAMOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_NET;
        private System.Windows.Forms.ComboBox comboBox1;
    
          
    }
}