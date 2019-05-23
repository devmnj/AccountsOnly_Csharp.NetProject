 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_purchase));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.button_FIND = new System.Windows.Forms.Button();
            this.txt_findrcno = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_print = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.button14 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DTP_date = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_rvno = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TOTAL = new System.Windows.Forms.Label();
            this.txt_tgross = new System.Windows.Forms.TextBox();
            this.txt_tqty = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_narration = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_color = new System.Windows.Forms.TextBox();
            this.txt_sp = new System.Windows.Forms.TextBox();
            this.txt_type = new System.Windows.Forms.TextBox();
            this.txt_catagory = new System.Windows.Forms.TextBox();
            this.txt_model = new System.Windows.Forms.TextBox();
            this.txt_size = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new macc.PurchaseGridView();
            this.cl_slno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MODEL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COLOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CATAGORY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_pcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_ITEM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SIZE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_QTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SRATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_GROSS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROFIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Location = new System.Drawing.Point(613, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(122, 48);
            this.panel4.TabIndex = 21;
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
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DimGray;
            this.panel3.Controls.Add(this.btn_delete);
            this.panel3.Controls.Add(this.btn_edit);
            this.panel3.Controls.Add(this.btn_clear);
            this.panel3.Controls.Add(this.btn_print);
            this.panel3.Controls.Add(this.btn_save);
            this.panel3.Location = new System.Drawing.Point(748, 10);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(52, 414);
            this.panel3.TabIndex = 20;
            // 
            // btn_delete
            // 
            this.btn_delete.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_delete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_delete.BackgroundImage")));
            this.btn_delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_delete.Location = new System.Drawing.Point(4, 192);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(45, 43);
            this.btn_delete.TabIndex = 4;
            this.btn_delete.Text = " ";
            this.btn_delete.UseVisualStyleBackColor = false;
            // 
            // btn_edit
            // 
            this.btn_edit.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_edit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_edit.BackgroundImage")));
            this.btn_edit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_edit.Location = new System.Drawing.Point(3, 146);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(45, 43);
            this.btn_edit.TabIndex = 3;
            this.btn_edit.Text = " ";
            this.btn_edit.UseVisualStyleBackColor = false;
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
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel12);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.DTP_date);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txt_rvno);
            this.panel1.Location = new System.Drawing.Point(4, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(740, 60);
            this.panel1.TabIndex = 0;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.button14);
            this.panel12.Controls.Add(this.button11);
            this.panel12.Controls.Add(this.button12);
            this.panel12.Controls.Add(this.button13);
            this.panel12.Location = new System.Drawing.Point(437, 3);
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
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 6);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(61, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "Entry No";
            // 
            // DTP_date
            // 
            this.DTP_date.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTP_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTP_date.Location = new System.Drawing.Point(85, 28);
            this.DTP_date.Name = "DTP_date";
            this.DTP_date.Size = new System.Drawing.Size(109, 23);
            this.DTP_date.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 33);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(35, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "Date";
            // 
            // txt_rvno
            // 
            this.txt_rvno.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_rvno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_rvno.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_rvno.Location = new System.Drawing.Point(85, 6);
            this.txt_rvno.Name = "txt_rvno";
            this.txt_rvno.ReadOnly = true;
            this.txt_rvno.Size = new System.Drawing.Size(109, 23);
            this.txt_rvno.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.TOTAL);
            this.panel2.Controls.Add(this.txt_tgross);
            this.panel2.Controls.Add(this.txt_tqty);
            this.panel2.Location = new System.Drawing.Point(4, 290);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(740, 23);
            this.panel2.TabIndex = 19;
            // 
            // TOTAL
            // 
            this.TOTAL.AutoSize = true;
            this.TOTAL.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TOTAL.Location = new System.Drawing.Point(3, 1);
            this.TOTAL.Name = "TOTAL";
            this.TOTAL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TOTAL.Size = new System.Drawing.Size(37, 18);
            this.TOTAL.TabIndex = 8;
            this.TOTAL.Text = "Total";
            // 
            // txt_tgross
            // 
            this.txt_tgross.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_tgross.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_tgross.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_tgross.Location = new System.Drawing.Point(520, 0);
            this.txt_tgross.Name = "txt_tgross";
            this.txt_tgross.ReadOnly = true;
            this.txt_tgross.Size = new System.Drawing.Size(142, 23);
            this.txt_tgross.TabIndex = 0;
            this.txt_tgross.TabStop = false;
            // 
            // txt_tqty
            // 
            this.txt_tqty.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_tqty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_tqty.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_tqty.Location = new System.Drawing.Point(360, 0);
            this.txt_tqty.Name = "txt_tqty";
            this.txt_tqty.ReadOnly = true;
            this.txt_tqty.Size = new System.Drawing.Size(72, 23);
            this.txt_tqty.TabIndex = 0;
            this.txt_tqty.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(320, 371);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(67, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "Narration";
            // 
            // txt_narration
            // 
            this.txt_narration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_narration.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_narration.Location = new System.Drawing.Point(323, 392);
            this.txt_narration.Multiline = true;
            this.txt_narration.Name = "txt_narration";
            this.txt_narration.Size = new System.Drawing.Size(421, 32);
            this.txt_narration.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 18);
            this.label5.TabIndex = 21;
            this.label5.Text = "Size";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 18);
            this.label6.TabIndex = 21;
            this.label6.Text = "Model";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(7, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 18);
            this.label7.TabIndex = 21;
            this.label7.Text = "Color";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(150, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 18);
            this.label8.TabIndex = 21;
            this.label8.Text = "Style";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(170, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(16, 18);
            this.label9.TabIndex = 21;
            this.label9.Text = "T";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.LemonChiffon;
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.txt_color);
            this.panel5.Controls.Add(this.txt_sp);
            this.panel5.Controls.Add(this.txt_type);
            this.panel5.Controls.Add(this.txt_catagory);
            this.panel5.Controls.Add(this.txt_model);
            this.panel5.Controls.Add(this.txt_size);
            this.panel5.Location = new System.Drawing.Point(4, 324);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(288, 100);
            this.panel5.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(159, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 18);
            this.label2.TabIndex = 21;
            this.label2.Text = "S.P";
            // 
            // txt_color
            // 
            this.txt_color.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_color.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_color.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_color.Location = new System.Drawing.Point(50, 66);
            this.txt_color.Name = "txt_color";
            this.txt_color.Size = new System.Drawing.Size(78, 23);
            this.txt_color.TabIndex = 2;
            this.txt_color.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_color_KeyDown);
            // 
            // txt_sp
            // 
            this.txt_sp.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_sp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_sp.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_sp.Location = new System.Drawing.Point(192, 66);
            this.txt_sp.Name = "txt_sp";
            this.txt_sp.Size = new System.Drawing.Size(86, 23);
            this.txt_sp.TabIndex = 5;
            this.txt_sp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_sp_KeyDown);
            // 
            // txt_type
            // 
            this.txt_type.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_type.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_type.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_type.Location = new System.Drawing.Point(192, 37);
            this.txt_type.Name = "txt_type";
            this.txt_type.Size = new System.Drawing.Size(86, 23);
            this.txt_type.TabIndex = 4;
            this.txt_type.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_type_KeyDown);
            // 
            // txt_catagory
            // 
            this.txt_catagory.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_catagory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_catagory.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_catagory.Location = new System.Drawing.Point(192, 10);
            this.txt_catagory.Name = "txt_catagory";
            this.txt_catagory.Size = new System.Drawing.Size(86, 23);
            this.txt_catagory.TabIndex = 3;
            this.txt_catagory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_catagory_KeyDown);
            // 
            // txt_model
            // 
            this.txt_model.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_model.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_model.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_model.Location = new System.Drawing.Point(50, 37);
            this.txt_model.Name = "txt_model";
            this.txt_model.Size = new System.Drawing.Size(78, 23);
            this.txt_model.TabIndex = 1;
            this.txt_model.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_model_KeyDown);
            // 
            // txt_size
            // 
            this.txt_size.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_size.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_size.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_size.Location = new System.Drawing.Point(50, 8);
            this.txt_size.Name = "txt_size";
            this.txt_size.Size = new System.Drawing.Size(53, 23);
            this.txt_size.TabIndex = 0;
            this.txt_size.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_size_KeyDown);
            this.txt_size.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_size_KeyPress);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cl_slno,
            this.MODEL,
            this.COLOR,
            this.CATAGORY,
            this.TYPE,
            this.SP,
            this.cl_pcode,
            this.cl_ITEM,
            this.SIZE,
            this.cl_QTY,
            this.COST,
            this.SRATE,
            this.cl_GROSS,
            this.PROFIT});
            this.dataGridView1.Location = new System.Drawing.Point(4, 76);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridView1.Size = new System.Drawing.Size(740, 213);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.TabStop = false;
            this.dataGridView1.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellLeave);
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            // 
            // cl_slno
            // 
            this.cl_slno.HeaderText = "SLNO";
            this.cl_slno.Name = "cl_slno";
            this.cl_slno.Width = 60;
            // 
            // MODEL
            // 
            this.MODEL.HeaderText = "MODEL";
            this.MODEL.Name = "MODEL";
            this.MODEL.Visible = false;
            // 
            // COLOR
            // 
            this.COLOR.HeaderText = "COLOR";
            this.COLOR.Name = "COLOR";
            this.COLOR.Visible = false;
            // 
            // CATAGORY
            // 
            this.CATAGORY.HeaderText = "CATAGORY";
            this.CATAGORY.Name = "CATAGORY";
            this.CATAGORY.Visible = false;
            // 
            // TYPE
            // 
            this.TYPE.HeaderText = "TYPE";
            this.TYPE.Name = "TYPE";
            this.TYPE.Visible = false;
            // 
            // SP
            // 
            this.SP.HeaderText = "S.P";
            this.SP.Name = "SP";
            this.SP.Visible = false;
            // 
            // cl_pcode
            // 
            this.cl_pcode.HeaderText = "DCODE";
            this.cl_pcode.Name = "cl_pcode";
            // 
            // cl_ITEM
            // 
            this.cl_ITEM.HeaderText = "ITEM";
            this.cl_ITEM.Name = "cl_ITEM";
            this.cl_ITEM.Width = 200;
            // 
            // SIZE
            // 
            this.SIZE.HeaderText = "SIZE";
            this.SIZE.Name = "SIZE";
            this.SIZE.Visible = false;
            this.SIZE.Width = 40;
            // 
            // cl_QTY
            // 
            this.cl_QTY.HeaderText = "QTY";
            this.cl_QTY.Name = "cl_QTY";
            this.cl_QTY.Width = 40;
            // 
            // COST
            // 
            this.COST.HeaderText = "COST";
            this.COST.Name = "COST";
            this.COST.Width = 60;
            // 
            // SRATE
            // 
            this.SRATE.HeaderText = "SRATE";
            this.SRATE.Name = "SRATE";
            this.SRATE.Width = 60;
            // 
            // cl_GROSS
            // 
            this.cl_GROSS.HeaderText = "GROSS";
            this.cl_GROSS.Name = "cl_GROSS";
            this.cl_GROSS.Width = 80;
            // 
            // PROFIT
            // 
            this.PROFIT.HeaderText = "P+";
            this.PROFIT.Name = "PROFIT";
            this.PROFIT.Width = 60;
            // 
            // frm_purchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 428);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txt_narration);
            this.Name = "frm_purchase";
            this.Text = "Finished Stock Entry";
            this.Load += new System.EventHandler(this.frm_purchase_Load);
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PurchaseGridView dataGridView1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button button_FIND;
        private System.Windows.Forms.TextBox txt_findrcno;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DTP_date;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_rvno;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label TOTAL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_narration;
        private System.Windows.Forms.TextBox txt_tgross;
        private System.Windows.Forms.TextBox txt_tqty;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txt_color;
        private System.Windows.Forms.TextBox txt_type;
        private System.Windows.Forms.TextBox txt_catagory;
        private System.Windows.Forms.TextBox txt_model;
        private System.Windows.Forms.TextBox txt_size;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_sp;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_slno;
        private System.Windows.Forms.DataGridViewTextBoxColumn MODEL;
        private System.Windows.Forms.DataGridViewTextBoxColumn COLOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn CATAGORY;
        private System.Windows.Forms.DataGridViewTextBoxColumn TYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn SP;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_pcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_ITEM;
        private System.Windows.Forms.DataGridViewTextBoxColumn SIZE;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_QTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn COST;
        private System.Windows.Forms.DataGridViewTextBoxColumn SRATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_GROSS;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROFIT;
    }
}