using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace macc
{
    public partial class frmcompany : Form
    {
        public frmcompany()
        {
            InitializeComponent();
        }

        private void frmcompany_Load(object sender, EventArgs e)
        {
            //  Globals.InitializeJson();

            ColumnHeader headers = new ColumnHeader();
            listView1.View = View.Details;
            headers.Text = " ";
            headers.Width = 0;
            listView1.Columns.Add(headers);
            headers = new ColumnHeader();
            headers.Text = "Code";
            headers.Width = 80;
            listView1.Columns.Add(headers);
            headers = new ColumnHeader();
            headers.Text = "Company";
            headers.Width = 300;
            listView1.Columns.Add(headers);
            headers = new ColumnHeader();
            headers.Text = "";
            headers.Width = 0;
            listView1.Columns.Add(headers);
            listView1.FullRowSelect = true;

            try
            {
                Accounts[] a;
                string json = File.ReadAllText("d:/dbjason.jason");

                a = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<Accounts[]>(json);
                ListViewItem tr_items = new ListViewItem();
                foreach (Accounts ac in a)
                {
                    tr_items = new ListViewItem();
                    tr_items.SubItems.Add(ac.Code);
                    tr_items.SubItems.Add(ac.CompanyName);
                    tr_items.SubItems.Add(ac.DBloc);
                    listView1.Items.Add(tr_items);
                }
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string code, cname, path;
            cname = listView1.SelectedItems[0].SubItems[1].Text.ToString();
            path = listView1.SelectedItems[0].SubItems[3].Text.ToString();
            cname = listView1.SelectedItems[0].SubItems[2].Text.ToString();
            if (path != null)
            {
                Globals.CompanyName = cname;
                 Globals.OpenDBConnection(path);
                //mainMDI p1 = (mainMDI) this.Parent;
                Globals.company.CName = cname;
                 
              
                
              
                this.Close();
            }
            else
            {
                MessageBox.Show("Data Base may Missing");
            }

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label7_DragDrop(object sender, DragEventArgs e)
        {
            //Point p;
            //p.X=   e.X;
            //p.Y = e.Y;
            //this.Location = p;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
