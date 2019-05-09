using Microsoft.Reporting.WinForms;
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
    public partial class AcReport : Form
    {
        ReportDataSource RDS;
        public AcReport()
        {
            InitializeComponent();
            Globals.F5Trns(); 
            

        }

        private void AcReport_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Globals.trnsDataSet.Tables[0];
            
        }
 
    }
}
