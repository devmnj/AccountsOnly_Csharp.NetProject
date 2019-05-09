namespace macc
{
    partial class addresslookup
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_search_All = new System.Windows.Forms.Button();
            this.btn_search = new System.Windows.Forms.Button();
            this.txt_searchtxt = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radio_name = new System.Windows.Forms.RadioButton();
            this.radio_pin = new System.Windows.Forms.RadioButton();
            this.radio_state = new System.Windows.Forms.RadioButton();
            this.radio_city = new System.Windows.Forms.RadioButton();
            this.radio_contact = new System.Windows.Forms.RadioButton();
            this.radio_place = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btn_search_All);
            this.panel1.Controls.Add(this.btn_search);
            this.panel1.Controls.Add(this.txt_searchtxt);
            this.panel1.Location = new System.Drawing.Point(189, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(439, 94);
            this.panel1.TabIndex = 1;
            // 
            // btn_search_All
            // 
            this.btn_search_All.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_search_All.Location = new System.Drawing.Point(236, 42);
            this.btn_search_All.Name = "btn_search_All";
            this.btn_search_All.Size = new System.Drawing.Size(157, 32);
            this.btn_search_All.TabIndex = 2;
            this.btn_search_All.Text = "List All";
            this.btn_search_All.UseVisualStyleBackColor = true;
            this.btn_search_All.Click += new System.EventHandler(this.btn_search_All_Click);
            // 
            // btn_search
            // 
            this.btn_search.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_search.Location = new System.Drawing.Point(46, 42);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(184, 32);
            this.btn_search.TabIndex = 1;
            this.btn_search.Text = "Search";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_searchtxt
            // 
            this.txt_searchtxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_searchtxt.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_searchtxt.Location = new System.Drawing.Point(11, 13);
            this.txt_searchtxt.Name = "txt_searchtxt";
            this.txt_searchtxt.Size = new System.Drawing.Size(417, 23);
            this.txt_searchtxt.TabIndex = 0;
            this.txt_searchtxt.TextChanged += new System.EventHandler(this.txt_searchtxt_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radio_name);
            this.groupBox1.Controls.Add(this.radio_pin);
            this.groupBox1.Controls.Add(this.radio_state);
            this.groupBox1.Controls.Add(this.radio_city);
            this.groupBox1.Controls.Add(this.radio_contact);
            this.groupBox1.Controls.Add(this.radio_place);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(171, 94);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Options";
            // 
            // radio_name
            // 
            this.radio_name.AutoSize = true;
            this.radio_name.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radio_name.Location = new System.Drawing.Point(18, 67);
            this.radio_name.Name = "radio_name";
            this.radio_name.Size = new System.Drawing.Size(59, 18);
            this.radio_name.TabIndex = 0;
            this.radio_name.Text = "Name";
            this.radio_name.UseVisualStyleBackColor = true;
            // 
            // radio_pin
            // 
            this.radio_pin.AutoSize = true;
            this.radio_pin.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radio_pin.Location = new System.Drawing.Point(90, 67);
            this.radio_pin.Name = "radio_pin";
            this.radio_pin.Size = new System.Drawing.Size(77, 18);
            this.radio_pin.TabIndex = 0;
            this.radio_pin.Text = "PIN Code";
            this.radio_pin.UseVisualStyleBackColor = true;
            // 
            // radio_state
            // 
            this.radio_state.AutoSize = true;
            this.radio_state.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radio_state.Location = new System.Drawing.Point(90, 19);
            this.radio_state.Name = "radio_state";
            this.radio_state.Size = new System.Drawing.Size(56, 18);
            this.radio_state.TabIndex = 0;
            this.radio_state.Text = "State";
            this.radio_state.UseVisualStyleBackColor = true;
            // 
            // radio_city
            // 
            this.radio_city.AutoSize = true;
            this.radio_city.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radio_city.Location = new System.Drawing.Point(90, 43);
            this.radio_city.Name = "radio_city";
            this.radio_city.Size = new System.Drawing.Size(48, 18);
            this.radio_city.TabIndex = 0;
            this.radio_city.Text = "City";
            this.radio_city.UseVisualStyleBackColor = true;
            // 
            // radio_contact
            // 
            this.radio_contact.AutoSize = true;
            this.radio_contact.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radio_contact.Location = new System.Drawing.Point(18, 43);
            this.radio_contact.Name = "radio_contact";
            this.radio_contact.Size = new System.Drawing.Size(85, 18);
            this.radio_contact.TabIndex = 0;
            this.radio_contact.Text = "Contact No";
            this.radio_contact.UseVisualStyleBackColor = true;
            // 
            // radio_place
            // 
            this.radio_place.AutoSize = true;
            this.radio_place.Checked = true;
            this.radio_place.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radio_place.Location = new System.Drawing.Point(18, 19);
            this.radio_place.Name = "radio_place";
            this.radio_place.Size = new System.Drawing.Size(58, 18);
            this.radio_place.TabIndex = 0;
            this.radio_place.TabStop = true;
            this.radio_place.Text = "Place";
            this.radio_place.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 112);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(616, 271);
            this.dataGridView1.TabIndex = 3;
            // 
            // addresslookup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGreen;
            this.ClientSize = new System.Drawing.Size(640, 395);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "addresslookup";
            this.Text = "Contact Book";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_searchtxt;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radio_name;
        private System.Windows.Forms.RadioButton radio_pin;
        private System.Windows.Forms.RadioButton radio_state;
        private System.Windows.Forms.RadioButton radio_city;
        private System.Windows.Forms.RadioButton radio_contact;
        private System.Windows.Forms.RadioButton radio_place;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_search_All;
    }
}