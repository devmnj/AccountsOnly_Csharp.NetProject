using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;

namespace macc
{
    class MyCompany : System.ComponentModel.INotifyPropertyChanged
    {
        string comp_name;
        string comp_description;
        bool Found;
        string comp_Ownership;
        string comp_loc, comp_city, comp_gst, comp_pin, comp_state, comp_disct, comp_email, comp_officephone, comp_mobile, comp_pan;
        string comp_FYC;
        OleDbDataAdapter com_adap = new OleDbDataAdapter();
        DataSet com_ds = new DataSet();
        OleDbCommandBuilder com_cmd;
        DataView com_dv = new DataView();
        public MyCompany()
        {
            Found = false;
            try
            {
                com_adap = new OleDbDataAdapter("select * from companysettings", Globals.con);
                com_ds = new DataSet();
                com_adap.Fill(com_ds, "companysettings");
                com_dv = new DataView(com_ds.Tables[0]);
                if (com_dv.Count > 0)
                {
                    Found = true;
                    comp_name = com_dv[0]["cname"].ToString();
                    comp_description = com_dv[0]["description"].ToString();
                    COwnership= com_dv[0]["ownership"].ToString();
                    comp_loc = com_dv[0]["location"].ToString();
                    comp_state = com_dv[0]["state"].ToString();
                    comp_disct = com_dv[0]["district"].ToString();
                    comp_city = com_dv[0]["city"].ToString();
                    comp_pin = com_dv[0]["pin"].ToString();
                    comp_pan = com_dv[0]["pan"].ToString();
                    comp_gst = com_dv[0]["gst"].ToString();
                    comp_mobile = com_dv[0]["mobile"].ToString();
                    comp_officephone = com_dv[0]["officeno"].ToString();
                    comp_email = com_dv[0]["email"].ToString();
                    comp_FYC=com_dv[0]["fycode"].ToString();
                }

            }
            catch(OleDbException e)
            {
                MessageBox.Show(e.Message.ToString());

            }

        }
        public string COwnership
        {
            get { return comp_Ownership; 
           

            }
            set
            {
               comp_Ownership = value; 
               OnPropertyChanged("COwnership"); 
            }
        }
        public string CName
        {
            get
            {
                return comp_name;
                
            }
            set
            {
                comp_name = value;
                 OnPropertyChanged("CName"); 

            }
           
        }
        
        //protected virtual void OnPropertyChanged(string property)
        //{
        //    if (PropertyChanged != null)
        //        PropertyChanged(this, new PropertyChangedEventArgs(property));
        //}
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
            }
        }

        public string Description
        {
            get
            {

                return comp_description;
            }
            set
            {
                comp_description = value;
            }
        }
        public string Location
        {
            get
            { return comp_loc; }
            set { comp_loc = value; }
        }
        public string City
        {
            get { return comp_city; }
            set { comp_city = value; }

        }
        public string State
        {
            get { return comp_state; }
            set { comp_state = value; }
        }
        public string District
        {
            get { return comp_disct; }
            set { comp_disct = value; }

        } 
        public string PIN
        {
            get { return comp_pin; }
            set { comp_pin = value; }
        }
        public string GST
        {
            get { return comp_gst; }
            set { comp_gst = value; }
        }
        public string PAN 
        {
            get { return comp_pan; }
            set { comp_pan = value; }
        }
        public string Email
        {
            set { comp_email = value; }
            get { return comp_email; }
        }
        public string OfficeNo
        {
            get { return comp_officephone; }
            set { comp_officephone = value; }
        }
        public string Mobile
        {
            get { return comp_mobile; }
            set { comp_mobile = value; }
        }
        public void  Update()
        {
            try
            {
                if (Found == false)
                {
                    DataRow row = com_ds.Tables[0].NewRow();
                    row["cname"] = comp_name;
                    row["description"] = comp_description ;
                    row["location"] = comp_loc;
                    row["ownership"] = comp_Ownership;
                    row["city"] = comp_city;
                    row["district"] = comp_disct;
                    row["state"] = comp_state;
                    row["pin"] = comp_pin ;
                    row["pan"] = comp_pan ;
                    row["gst"] = comp_gst ;
                    row["dlno"] = "";
                    row["officeno"] = comp_officephone;
                    row["mobile"] = comp_mobile;
                    row["email"] = comp_email;
                    row["fycode"] = comp_FYC;
                    com_ds.Tables[0].Rows.Add(row);
                    OleDbCommandBuilder cmd = new OleDbCommandBuilder(com_adap);
                    com_adap.InsertCommand = cmd.GetInsertCommand();
                    int x=com_adap.Update(com_ds.Tables[0]);
                    if (x > 0)
                    {
                        MessageBox.Show("Company Settings Saved");
                       
                    }
                }
                else
                {
                    DataRow row = com_dv[0].Row;
                    row.BeginEdit();
                    row["cname"] = comp_name;
                    row["description"] = comp_description;
                    row["location"] = comp_loc;
                    row["ownership"] = comp_Ownership;
                    row["city"] = comp_city;
                    row["district"] = comp_disct;
                    row["state"] = comp_state;
                    row["pin"] = comp_pin;
                    row["pan"] = comp_pan;
                    row["gst"] = comp_gst;
                    row["dlno"] = "";
                    row["officeno"] = comp_officephone;
                    row["mobile"] = comp_mobile;
                    row["email"] = comp_email;
                    row["fycode"] = comp_FYC;
                    row.EndEdit();
                    OleDbCommandBuilder cmd = new OleDbCommandBuilder(com_adap);
                    com_adap.UpdateCommand = cmd.GetUpdateCommand();
                    int k=com_adap.Update (com_ds.Tables[0]);
                    if (k > 0) { MessageBox.Show("Company Settings Updated"); }
                }

            }
            catch (OleDbException e)
            {
                MessageBox.Show(e.Message.ToString());
            }
        }
        public string FYC
        {
            get { return comp_FYC; }
            set { comp_FYC = value;
            OnPropertyChanged("FYC");
            }
        }




         
    }
}
