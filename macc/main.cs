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

    public partial class mainMDI : Form

    {
        DataTable qview;
        private int childFormNumber = 0;

        public mainMDI()
        {
            InitializeComponent();


        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();

        }

        private void OpenFile(object sender, EventArgs e)
        {
            //frmcompany c = new frmcompany();
            //c.MdiParent = this;
            //c.Show();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);

        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }






        private void mainMDI_Load(object sender, EventArgs e)
        {

            toolStrip1.ImageScalingSize = new Size(140, 140);
            this.ContextMenuStrip = contextMenuStrip1;
            Globals.OpenDBConnection();
            Globals.company = new macc.MyCompany();

            toolStripStatusLabel1.DataBindings.Add("Text", Globals.company, "CName");
            toolStripStatusLabel5.DataBindings.Add("Text", Globals.company, "COwnership");
            toolStripStatusLabel3.DataBindings.Add("Text", Globals.company, "FYC");
            backgroundWorker1.RunWorkerAsync();
            //historyboard his = new historyboard();
            //his.MdiParent = this;

            //his.Location = new Point(this.Width-his.Width - 70, 0);

            //his.Show();

        }


        private void groupbtn_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {





        }

        private void timer1_Tick(object sender, EventArgs e)
        {


        }

        private void toolStrip4_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            //Group
            group_frm gform = new group_frm();
            gform.MdiParent = this;
            
            gform.Show();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            //Account Registration
            account_frm acform = new account_frm();
            acform.MdiParent = this;
           
            acform.Show();
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            //Account Report
            AcReport2 ar = new AcReport2();
            ar.MdiParent = this;
            ar.Show();
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            //Receipt
            frm_rec_voucher rec = new frm_rec_voucher();
            rec.MdiParent = this;
           
            rec.Show();
            rec.BringToFront();
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            //Payment
            frm_paymentvoucher pay = new frm_paymentvoucher();
            pay.MdiParent = this;
           
            pay.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frm_JEntry je = new frm_JEntry();
            je.MdiParent = this;
          
            je.Show();
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            historyboard his = new historyboard();
            his.MdiParent = this;

            his.Location = new Point(this.Width - his.Width - 70, 0);

            his.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frm_trial trial = new frm_trial();
            trial.MdiParent = this;
            
            trial.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            GroupAccounts grouplist = new GroupAccounts();
            grouplist.MdiParent = this;
            Globals.Positionform(this);
            grouplist.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            frm_PLstatement pl = new frm_PLstatement();
            pl.MdiParent = this;
           
            pl.Show();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void mainMDI_Activated(object sender, EventArgs e)
        {
            //if (Globals.con.State == ConnectionState.Open)
            //{
            //    toolStrip1.Visible = true;
            //    menuStrip.Visible = true;

            //}
            //else
            //{ 
            // toolStrip1.Visible = false;
            //    menuStrip.Visible = false;

            //}
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            //Purchase 
            frm_purchase purchase = new frm_purchase();
            purchase.MdiParent = this;
            purchase.Show();
        }

        private void RenameAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton16_Click(object sender, EventArgs e)
        {

        }

        private void toolStripRepDesigner_Click(object sender, EventArgs e)
        {
            //ReportDesigner repd = new ReportDesigner();
            //repd.MdiParent = this;
            //repd.Show();
        }

        private void toolStripReports_Click(object sender, EventArgs e)
        {
            ListViewReports report = new ListViewReports();
            report.MdiParent = this;
            report.Show();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            addresslookup addressBook = new addresslookup();
            addressBook.MdiParent = this;
            addressBook.Show();
        }

        private void toolStripRenameAccounts_Click(object sender, EventArgs e)
        {
            try
            {
                frmRenameAccount renameac = new frmRenameAccount();
                renameac.MdiParent = this;
                renameac.Show();
            }

            catch (Exception eee)
            {


            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.MdiParent = this;
            ab.Show();
        }

        private void fYRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FinancialYearSettings fys = new FinancialYearSettings();
            fys.MdiParent = this;
            fys.Show();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            CompanySettings mycomp = new CompanySettings();
            mycomp.MdiParent = this;
            mycomp.Show();
        }

        private void accountsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            //dashboard db = new dashboard();
            //db.MdiParent = this;
            //db.Dock = DockStyle.Right;
            //db.Show();
        }

        private void mainMDI_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                contextMenuStrip1.Show();

            }

        }

        private void mainMDI_Click(object sender, EventArgs e)
        {

        }

        private void openCompanyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmcompany comp = new frmcompany();
            comp.MdiParent = this;
            comp.Show();

        }

        private void entrToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void paymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_paymentvoucher payment = new frm_paymentvoucher();
            payment.MdiParent = this;
            payment.Show();
        }

        private void receiptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_rec_voucher recept = new frm_rec_voucher();
            recept.MdiParent = this;
            recept.Show();
        }

        private void journalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_JEntry journal = new frm_JEntry();
            journal.MdiParent = this;
            journal.Show();
        }

        private void reportDesignerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void dashBoardSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DashboardSettings dash = new DashboardSettings();
            dash.MdiParent = this;
            dash.Show();
        }

        private void dashBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //dashboard dashboard = new dashboard();
            //dashboard.MdiParent = this;
            //dashboard.Show();
            if (DGV_quickview.Visible == true)
            {
                DGV_quickview.Visible = false;
            }
            else
            {
                qview = Globals.BackWorker_Accounts();
               // DGV_quickview.SendToBack();
                
                DGV_quickview.Visible = true;
                DGV_quickview.Location = new Point(1130 , 30);
            }

        }

        private void accountViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
          

        }

        private void updateDataBaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Update Database
            Globals.UpdateColumn("Accounts", "extended", "bit");
            Globals.CreateNewTable("Accounts", "extended");
            MessageBox.Show("DataBase Upgraded Successfully");

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            qview = Globals.BackWorker_Accounts();


        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DGV_quickview.DataSource = qview;
        }

        private void DGV_quickview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {

        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            CompanySettings settings = new CompanySettings();
            settings.MdiParent = this;
            settings.Show();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void accountViewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AcReport2 r1 = new AcReport2();
            r1.MdiParent = this;
            r1.Show();
        }

        private void accountGroupBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reporDeseignerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportDesigner designer = new ReportDesigner();
            designer.MdiParent = this;
            designer.Show();
        }

        private void DGV_quickview_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int acid = 0;
            try
            {
                string ac = DGV_quickview[e.ColumnIndex, e.RowIndex].Value.ToString();
                if (ac != null && e.ColumnIndex==0 )
                {

                    acid = Globals.GetAccountID(ac);
                    AcReport2 rep = new AcReport2(acid);
                   
                    rep.MdiParent = this;
 
                    
                    rep.Show();


                }
            }
            catch (Exception e1) { MessageBox.Show(e1.Message.ToString()); }
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            DashboardSettings dashboard = new DashboardSettings();
            dashboard.MdiParent = this;dashboard.Show();
        }

        private void toolStripButton16_Click_1(object sender, EventArgs e)
        {
            frmRenameAccount acren = new frmRenameAccount();
            acren.MdiParent = this;acren.Show();
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            ListViewReports reports = new ListViewReports();
            reports.MdiParent = this;
            reports.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ListViewReports reports = new ListViewReports();
            reports.MdiParent = this;
            reports.Show();
        }
    }
}
