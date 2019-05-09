namespace macc
{
    partial class frm_paymentvoucher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_paymentvoucher));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.button_FIND = new System.Windows.Forms.Button();
            this.txt_findrcno = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_print = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_dr = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_narration = new System.Windows.Forms.TextBox();
            this.disc_perc = new System.Windows.Forms.TextBox();
            this.txt_disc_amount = new System.Windows.Forms.TextBox();
            this.txt_netamount = new System.Windows.Forms.TextBox();
            this.txt_totalCash = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new macc.Custom_Grid_Voucher();
            this.SLNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RECFRM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CASH1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CRID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.button14 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DTP_rvdate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_acname = new System.Windows.Forms.TextBox();
            this.txt_rvno = new System.Windows.Forms.TextBox();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel12.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Location = new System.Drawing.Point(341, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(122, 92);
            this.panel4.TabIndex = 18;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.button_FIND);
            this.panel6.Controls.Add(this.txt_findrcno);
            this.panel6.Location = new System.Drawing.Point(3, 4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(114, 30);
            this.panel6.TabIndex = 13;
            // 
            // button_FIND
            // 
            this.button_FIND.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_FIND.BackgroundImage")));
            this.button_FIND.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_FIND.Location = new System.Drawing.Point(84, 3);
            this.button_FIND.Name = "button_FIND";
            this.button_FIND.Size = new System.Drawing.Size(25, 23);
            this.button_FIND.TabIndex = 1;
            this.button_FIND.Text = " ";
            this.button_FIND.UseVisualStyleBackColor = true;
            this.button_FIND.Click += new System.EventHandler(this.button_FIND_Click);
            // 
            // txt_findrcno
            // 
            this.txt_findrcno.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_findrcno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_findrcno.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_findrcno.Location = new System.Drawing.Point(3, 2);
            this.txt_findrcno.Name = "txt_findrcno";
            this.txt_findrcno.Size = new System.Drawing.Size(75, 23);
            this.txt_findrcno.TabIndex = 0;
            this.txt_findrcno.TabStop = false;
            this.txt_findrcno.TextChanged += new System.EventHandler(this.txt_findrcno_TextChanged_1);
            this.txt_findrcno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_findrcno_KeywwwDown);
            this.txt_findrcno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_findrcno_KeyPress_1);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Pink;
            this.panel5.Controls.Add(this.btn_delete);
            this.panel5.Controls.Add(this.btn_edit);
            this.panel5.Location = new System.Drawing.Point(470, 156);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(52, 91);
            this.panel5.TabIndex = 16;
            // 
            // btn_delete
            // 
            this.btn_delete.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_delete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_delete.BackgroundImage")));
            this.btn_delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_delete.Location = new System.Drawing.Point(4, 46);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(45, 43);
            this.btn_delete.TabIndex = 2;
            this.btn_delete.Text = " ";
            this.btn_delete.UseVisualStyleBackColor = false;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_edit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_edit.BackgroundImage")));
            this.btn_edit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_edit.Location = new System.Drawing.Point(3, 0);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(45, 43);
            this.btn_edit.TabIndex = 1;
            this.btn_edit.Text = " ";
            this.btn_edit.UseVisualStyleBackColor = false;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Pink;
            this.panel3.Controls.Add(this.btn_clear);
            this.panel3.Controls.Add(this.btn_print);
            this.panel3.Controls.Add(this.btn_save);
            this.panel3.Location = new System.Drawing.Point(470, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(52, 146);
            this.panel3.TabIndex = 15;
            // 
            // btn_clear
            // 
            this.btn_clear.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_clear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_clear.BackgroundImage")));
            this.btn_clear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_clear.Location = new System.Drawing.Point(3, 99);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(45, 43);
            this.btn_clear.TabIndex = 2;
            this.btn_clear.Text = " ";
            this.btn_clear.UseVisualStyleBackColor = false;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_print
            // 
            this.btn_print.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_print.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_print.BackgroundImage")));
            this.btn_print.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_print.Location = new System.Drawing.Point(3, 52);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(45, 43);
            this.btn_print.TabIndex = 1;
            this.btn_print.Text = " ";
            this.btn_print.UseVisualStyleBackColor = false;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_save.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_save.BackgroundImage")));
            this.btn_save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_save.Location = new System.Drawing.Point(3, 3);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(45, 43);
            this.btn_save.TabIndex = 0;
            this.btn_save.Text = " ";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txt_dr);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txt_narration);
            this.panel2.Controls.Add(this.disc_perc);
            this.panel2.Controls.Add(this.txt_disc_amount);
            this.panel2.Controls.Add(this.txt_netamount);
            this.panel2.Controls.Add(this.txt_totalCash);
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Location = new System.Drawing.Point(7, 103);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(456, 301);
            this.panel2.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(231, 244);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label6.Size = new System.Drawing.Size(29, 18);
            this.label6.TabIndex = 10;
            this.label6.Text = "Net";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(224, 202);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label9.Size = new System.Drawing.Size(37, 18);
            this.label9.TabIndex = 10;
            this.label9.Text = "Total";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(202, 220);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label7.Size = new System.Drawing.Size(61, 18);
            this.label7.TabIndex = 10;
            this.label7.Text = "Discount";
            // 
            // txt_dr
            // 
            this.txt_dr.BackColor = System.Drawing.Color.Salmon;
            this.txt_dr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_dr.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_dr.Location = new System.Drawing.Point(3, 220);
            this.txt_dr.Name = "txt_dr";
            this.txt_dr.ReadOnly = true;
            this.txt_dr.Size = new System.Drawing.Size(138, 20);
            this.txt_dr.TabIndex = 7;
            this.txt_dr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_dr.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1, 252);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(58, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Narration";
            // 
            // txt_narration
            // 
            this.txt_narration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_narration.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_narration.Location = new System.Drawing.Point(3, 271);
            this.txt_narration.Name = "txt_narration";
            this.txt_narration.Size = new System.Drawing.Size(447, 23);
            this.txt_narration.TabIndex = 6;
            // 
            // disc_perc
            // 
            this.disc_perc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.disc_perc.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.disc_perc.Location = new System.Drawing.Point(269, 220);
            this.disc_perc.Name = "disc_perc";
            this.disc_perc.Size = new System.Drawing.Size(48, 23);
            this.disc_perc.TabIndex = 4;
            this.disc_perc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.disc_perc_KeyPress);
            // 
            // txt_disc_amount
            // 
            this.txt_disc_amount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_disc_amount.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_disc_amount.Location = new System.Drawing.Point(316, 220);
            this.txt_disc_amount.Name = "txt_disc_amount";
            this.txt_disc_amount.Size = new System.Drawing.Size(134, 23);
            this.txt_disc_amount.TabIndex = 5;
            this.txt_disc_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_netamount
            // 
            this.txt_netamount.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txt_netamount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_netamount.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_netamount.Location = new System.Drawing.Point(269, 242);
            this.txt_netamount.Name = "txt_netamount";
            this.txt_netamount.ReadOnly = true;
            this.txt_netamount.Size = new System.Drawing.Size(181, 23);
            this.txt_netamount.TabIndex = 7;
            this.txt_netamount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_totalCash
            // 
            this.txt_totalCash.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txt_totalCash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_totalCash.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_totalCash.Location = new System.Drawing.Point(269, 200);
            this.txt_totalCash.Name = "txt_totalCash";
            this.txt_totalCash.ReadOnly = true;
            this.txt_totalCash.Size = new System.Drawing.Size(181, 23);
            this.txt_totalCash.TabIndex = 7;
            this.txt_totalCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_totalCash.TextChanged += new System.EventHandler(this.txt_totalCash_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SLNO,
            this.RECFRM,
            this.CASH1,
            this.CRID});
            this.dataGridView1.Location = new System.Drawing.Point(-1, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Khaki;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Size = new System.Drawing.Size(454, 197);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            this.dataGridView1.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellLeave);
            this.dataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            // 
            // SLNO
            // 
            this.SLNO.Frozen = true;
            this.SLNO.HeaderText = "SL#";
            this.SLNO.Name = "SLNO";
            this.SLNO.Width = 40;
            // 
            // RECFRM
            // 
            this.RECFRM.Frozen = true;
            this.RECFRM.HeaderText = "Paid To";
            this.RECFRM.Name = "RECFRM";
            this.RECFRM.Width = 270;
            // 
            // CASH1
            // 
            this.CASH1.HeaderText = "Cash";
            this.CASH1.Name = "CASH1";
            this.CASH1.Width = 140;
            // 
            // CRID
            // 
            this.CRID.HeaderText = "FID";
            this.CRID.Name = "CRID";
            this.CRID.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel12);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.DTP_rvdate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txt_acname);
            this.panel1.Controls.Add(this.txt_rvno);
            this.panel1.Location = new System.Drawing.Point(7, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(335, 92);
            this.panel1.TabIndex = 14;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.button14);
            this.panel12.Controls.Add(this.button11);
            this.panel12.Controls.Add(this.button12);
            this.panel12.Controls.Add(this.button13);
            this.panel12.Location = new System.Drawing.Point(160, 5);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(170, 48);
            this.panel12.TabIndex = 25;
            // 
            // button14
            // 
            this.button14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button14.Image = global::macc.Properties.Resources.Knob_Fast_Forward_icon;
            this.button14.Location = new System.Drawing.Point(126, 3);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(41, 41);
            this.button14.TabIndex = 19;
            this.button14.Text = " ";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button11
            // 
            this.button11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button11.Image = global::macc.Properties.Resources.Knob_Forward_icon;
            this.button11.Location = new System.Drawing.Point(86, 3);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(40, 41);
            this.button11.TabIndex = 20;
            this.button11.Text = " ";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button12
            // 
            this.button12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button12.Image = global::macc.Properties.Resources.Knob_Left_icon;
            this.button12.Location = new System.Drawing.Point(45, 3);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(41, 41);
            this.button12.TabIndex = 21;
            this.button12.Text = " ";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button13
            // 
            this.button13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button13.Image = global::macc.Properties.Resources.Knob_Fast_Rewind_icon;
            this.button13.Location = new System.Drawing.Point(4, 3);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(41, 41);
            this.button13.TabIndex = 22;
            this.button13.Text = " ";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(36, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "V.No";
            // 
            // DTP_rvdate
            // 
            this.DTP_rvdate.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTP_rvdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTP_rvdate.Location = new System.Drawing.Point(46, 31);
            this.DTP_rvdate.Name = "DTP_rvdate";
            this.DTP_rvdate.Size = new System.Drawing.Size(109, 23);
            this.DTP_rvdate.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 60);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(28, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "A/c";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 34);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(35, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "Date";
            // 
            // txt_acname
            // 
            this.txt_acname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_acname.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_acname.Location = new System.Drawing.Point(46, 59);
            this.txt_acname.Name = "txt_acname";
            this.txt_acname.Size = new System.Drawing.Size(280, 23);
            this.txt_acname.TabIndex = 2;
            this.txt_acname.TextChanged += new System.EventHandler(this.txt_acname_TextChanged);
            this.txt_acname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_acname_KeyDown);
            // 
            // txt_rvno
            // 
            this.txt_rvno.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_rvno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_rvno.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_rvno.Location = new System.Drawing.Point(46, 4);
            this.txt_rvno.Name = "txt_rvno";
            this.txt_rvno.ReadOnly = true;
            this.txt_rvno.Size = new System.Drawing.Size(109, 23);
            this.txt_rvno.TabIndex = 0;
            this.txt_rvno.TabStop = false;
            // 
            // frm_paymentvoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Pink;
            this.ClientSize = new System.Drawing.Size(526, 405);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frm_paymentvoucher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment Voucher";
            this.Load += new System.EventHandler(this.frm_paymentvoucher_Load);
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button button_FIND;
        private System.Windows.Forms.TextBox txt_findrcno;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_dr;
        private System.Windows.Forms.TextBox txt_narration;
        private System.Windows.Forms.TextBox disc_perc;
        private System.Windows.Forms.TextBox txt_disc_amount;
        private System.Windows.Forms.TextBox txt_netamount;
        private System.Windows.Forms.TextBox txt_totalCash;
        private Custom_Grid_Voucher dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DTP_rvdate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_acname;
        private System.Windows.Forms.TextBox txt_rvno;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn RECFRM;
        private System.Windows.Forms.DataGridViewTextBoxColumn CASH1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CRID;
    }
}