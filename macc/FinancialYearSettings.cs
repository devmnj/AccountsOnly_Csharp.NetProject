using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace macc
{
    public partial class FinancialYearSettings : Form
    {
        public FinancialYearSettings()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button_save_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (OleDbException erd)
            {
                MessageBox.Show(erd.Message.ToString());
            }
        }
    }
}
