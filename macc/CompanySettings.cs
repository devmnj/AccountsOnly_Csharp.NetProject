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
    public partial class CompanySettings : Form
    {
        public CompanySettings()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void CompanySettings_Load(object sender, EventArgs e)
        {

            //foreach (Control c in this.Controls) {
            //    if (c.GetType() == typeof(TextBox))
            //    {
            //        c.KeyDown += new KeyEventHandler(txt_companyName_KeyDown);
            //    }
            //}
            
            try
            {
                txt_companyName.Text = Globals.company.CName;
                txt_ownership.Text  = Globals.company.COwnership;
                txt_location.Text  = Globals.company.Location;
                txt_city.Text  = Globals.company.City;
                txt_state.Text = Globals.company.State;
                txt_pin.Text = Globals.company.PIN;
                txt_pan.Text  = Globals.company.PAN;
                txt_mob.Text = Globals.company.Mobile;
                txt_officeno.Text = Globals.company.OfficeNo;
                txt_email.Text = Globals.company.Email;
                cmb_fyc.Text = Globals.company.FYC;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message.ToString());
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                Globals.company.CName = txt_companyName.Text.ToString();
                Globals.company.COwnership = txt_ownership.Text.ToString();
                Globals.company.FYC = cmb_fyc.Text.ToString();
                Globals.company.Description = txt_description.Text.ToString();
                Globals.company.City = txt_city.Text.ToString();
                Globals.company.District = txt_district.Text.ToString();
                Globals.company.State= txt_state.Text.ToString();
                Globals.company.PIN = txt_pin.Text.ToString();
                Globals.company.Location = txt_location.Text.ToString();
                Globals.company.Mobile = txt_mob.Text.ToString();
                Globals.company.OfficeNo = txt_officeno.Text.ToString();
                Globals.company.Email = txt_email.Text.ToString();
                Globals.company.PAN = txt_pan.Text.ToString();
                Globals.company.GST = txt_gst.Text.ToString();
                Globals.company.Update();
                Globals.company = new MyCompany();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message.ToString());
            }
        }

        private void txt_companyName_MouseEnter(object sender, EventArgs e)
        {
            txt_companyName.SelectAll();
        }

        private void txt_description_Enter(object sender, EventArgs e)
        {
            txt_description.SelectAll ();
        }

        private void txt_ownership_Enter(object sender, EventArgs e)
        {
            txt_ownership.SelectAll();
        }

        private void txt_location_Enter(object sender, EventArgs e)
        {
            txt_location.SelectAll();
        }

        private void txt_city_Enter(object sender, EventArgs e)
        {
            txt_city.SelectAll();
        }

        private void txt_gst_Enter(object sender, EventArgs e)
        {
            txt_gst.SelectAll();
        }

        private void txt_mob_Enter(object sender, EventArgs e)
        {
            txt_mob.SelectAll();
        }

        private void txt_email_Enter(object sender, EventArgs e)
        {
            txt_email.SelectAll();
        }

        private void txt_state_Enter(object sender, EventArgs e)
        {
            txt_state.SelectAll();
        }

        private void txt_district_Enter(object sender, EventArgs e)
        {
            txt_district.SelectAll();
        }

        private void txt_pin_Enter(object sender, EventArgs e)
        {
            txt_pin.SelectAll();
        }

        private void txt_pan_Enter(object sender, EventArgs e)
        {
            txt_pin.SelectAll();
        }

        private void txt_officeno_Enter(object sender, EventArgs e)
        {
            txt_officeno.SelectAll();
        }

        private void cmb_fyc_Enter(object sender, EventArgs e)
        {
            cmb_fyc.SelectAll();
        }

        private void txt_companyName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txt_companyName_Enter(object sender, EventArgs e)
        {

        }
    }
}
