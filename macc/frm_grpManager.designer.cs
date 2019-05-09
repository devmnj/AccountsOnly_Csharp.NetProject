namespace macc
{
    partial class frm_GroupManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_GroupManager));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txt_gname = new System.Windows.Forms.TextBox();
            this.txt_pgroup = new System.Windows.Forms.ListBox();
            this.txt_narration = new System.Windows.Forms.TextBox();
            this.txt_pgid = new System.Windows.Forms.TextBox();
            this.txt_gid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.LightSkyBlue;
            this.groupBox3.Controls.Add(this.txt_gname);
            this.groupBox3.Controls.Add(this.txt_pgroup);
            this.groupBox3.Controls.Add(this.txt_narration);
            this.groupBox3.Controls.Add(this.txt_pgid);
            this.groupBox3.Controls.Add(this.txt_gid);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.Location = new System.Drawing.Point(12, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(470, 152);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "General  Settings";
            // 
            // txt_gname
            // 
            this.txt_gname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_gname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_gname.Location = new System.Drawing.Point(180, 19);
            this.txt_gname.Name = "txt_gname";
            this.txt_gname.Size = new System.Drawing.Size(268, 26);
            this.txt_gname.TabIndex = 2;
            this.txt_gname.TextChanged += new System.EventHandler(this.txt_gname_TextChanged);
            this.txt_gname.Enter += new System.EventHandler(this.txt_gname_Enter);
            this.txt_gname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_gname_KeyDown);
            this.txt_gname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_gname_KeyPress);
            this.txt_gname.Leave += new System.EventHandler(this.txt_gname_Leave);
            // 
            // txt_pgroup
            // 
            this.txt_pgroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_pgroup.FormattingEnabled = true;
            this.txt_pgroup.ItemHeight = 15;
            this.txt_pgroup.Items.AddRange(new object[] {
            "ASSET",
            "LIABILITY",
            "CAPITAL",
            "FIXED ASSETS"});
            this.txt_pgroup.Location = new System.Drawing.Point(180, 56);
            this.txt_pgroup.Name = "txt_pgroup";
            this.txt_pgroup.Size = new System.Drawing.Size(268, 34);
            this.txt_pgroup.TabIndex = 4;
            this.txt_pgroup.SelectedIndexChanged += new System.EventHandler(this.txt_pgroup_SelectedIndexChanged);
            this.txt_pgroup.Enter += new System.EventHandler(this.txt_pgroup_Enter);
            this.txt_pgroup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_pgroup_KeyPress);
            this.txt_pgroup.Leave += new System.EventHandler(this.txt_pgroup_Leave);
            // 
            // txt_narration
            // 
            this.txt_narration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_narration.Location = new System.Drawing.Point(126, 101);
            this.txt_narration.Multiline = true;
            this.txt_narration.Name = "txt_narration";
            this.txt_narration.Size = new System.Drawing.Size(322, 44);
            this.txt_narration.TabIndex = 5;
            this.txt_narration.TextChanged += new System.EventHandler(this.txt_narration_TextChanged);
            this.txt_narration.Enter += new System.EventHandler(this.txt_narration_Enter);
            this.txt_narration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_narration_KeyPress);
            this.txt_narration.Leave += new System.EventHandler(this.txt_narration_Leave);
            // 
            // txt_pgid
            // 
            this.txt_pgid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_pgid.Location = new System.Drawing.Point(126, 56);
            this.txt_pgid.Multiline = true;
            this.txt_pgid.Name = "txt_pgid";
            this.txt_pgid.Size = new System.Drawing.Size(48, 34);
            this.txt_pgid.TabIndex = 3;
            this.txt_pgid.Enter += new System.EventHandler(this.txt_pgid_Enter);
            this.txt_pgid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_pgid_KeyPress);
            this.txt_pgid.Leave += new System.EventHandler(this.txt_pgid_Leave);
            // 
            // txt_gid
            // 
            this.txt_gid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_gid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_gid.Location = new System.Drawing.Point(126, 19);
            this.txt_gid.Multiline = true;
            this.txt_gid.Name = "txt_gid";
            this.txt_gid.Size = new System.Drawing.Size(48, 26);
            this.txt_gid.TabIndex = 1;
            this.txt_gid.TextChanged += new System.EventHandler(this.txt_gid_TextChanged);
            this.txt_gid.Enter += new System.EventHandler(this.txt_gid_Enter);
            this.txt_gid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_gid_KeyPress);
            this.txt_gid.Leave += new System.EventHandler(this.txt_gid_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Narration";
            this.label2.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Primary Group";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(21, 27);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(84, 18);
            this.label14.TabIndex = 2;
            this.label14.Text = "Group Name";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_edit);
            this.panel1.Controls.Add(this.btn_save);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.btn_clear);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Location = new System.Drawing.Point(87, 170);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(295, 57);
            this.panel1.TabIndex = 9;
            // 
            // btn_edit
            // 
            this.btn_edit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_edit.BackgroundImage")));
            this.btn_edit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_edit.Location = new System.Drawing.Point(119, 4);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(52, 50);
            this.btn_edit.TabIndex = 20;
            this.btn_edit.Text = " ";
            this.btn_edit.UseVisualStyleBackColor = true;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.Teal;
            this.btn_save.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_save.BackgroundImage")));
            this.btn_save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_save.Location = new System.Drawing.Point(3, 4);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(52, 50);
            this.btn_save.TabIndex = 6;
            this.btn_save.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.button1_Click);
            // 
            // button5
            // 
            this.button5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button5.BackgroundImage")));
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.Location = new System.Drawing.Point(235, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(52, 50);
            this.button5.TabIndex = 8;
            this.button5.Text = " ";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.BackColor = System.Drawing.Color.Teal;
            this.btn_clear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_clear.BackgroundImage")));
            this.btn_clear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_clear.ForeColor = System.Drawing.Color.AliceBlue;
            this.btn_clear.Location = new System.Drawing.Point(61, 4);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(52, 50);
            this.btn_clear.TabIndex = 7;
            this.btn_clear.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_clear.UseVisualStyleBackColor = false;
            this.btn_clear.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(177, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(52, 50);
            this.button2.TabIndex = 21;
            this.button2.Text = " ";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 234);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(490, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // frm_GroupManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(490, 256);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frm_GroupManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Group Manager";
            this.Load += new System.EventHandler(this.frm_GroupManager_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TextBox txt_narration;
        private System.Windows.Forms.TextBox txt_pgid;
        private System.Windows.Forms.TextBox txt_gid;
        private System.Windows.Forms.ListBox txt_pgroup;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TextBox txt_gname;
    }
}