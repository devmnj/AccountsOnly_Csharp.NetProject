using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;

namespace macc
{
    public partial class addresslookup : Form
    {
        public addresslookup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.search();
        }
        void search()
        {


            string querry = null;
            try
            {
                if (radio_name.Checked == true)
                {
                    querry = "SELECT Accounts.acname,   account_part.place, account_part.city, account_part.Mobile" +
                        " FROM Accounts INNER JOIN account_part ON Accounts.acid = account_part.acid WHERE (((Accounts.acname) Like '*" + txt_searchtxt.Text.ToString() + "*') AND ((Accounts.extended)=True))";
                }
                else if (radio_place.Checked == true)
                {
                    querry = "SELECT Accounts.acname, account_part.place, account_part.city, account_part.Mobile FROM account_part INNER JOIN Accounts ON account_part.acid = Accounts.acid" +
 " WHERE  account_part.place  Like '*" + txt_searchtxt.Text.ToString().Trim() + "*'  AND  Accounts.extended =True  ";

                    //"SELECT Accounts.acname,   account_part.place, account_part.city, account_part.Mobile" +
                    //    " FROM Accounts INNER JOIN account_part ON Accounts.acid = account_part.acid WHERE (((Accounts.extended)=True) AND ((account_part.place) Like '*" + txt_searchtxt.Text.ToString() + "*'))";

                }
                else if (radio_city.Checked == true)
                {
                    querry = "SELECT Accounts.acname,  account_part.place, account_part.city, account_part.Mobile" +
                        " FROM Accounts INNER JOIN account_part ON Accounts.acid = account_part.acid WHERE (((Accounts.extended)=True) AND ((account_part.city) Like '*" + txt_searchtxt.Text.ToString() + "*'))";

                }
                else if (radio_pin.Checked == true)
                {
                    querry = "SELECT Accounts.acname, Accounts.extended, account_part.place, account_part.city, account_part.Mobile" +
                        " FROM Accounts INNER JOIN account_part ON Accounts.acid = account_part.acid WHERE (((Accounts.extended)=True) AND ((account_part.pin) Like '*" + txt_searchtxt.Text.ToString() + "*'))";

                }

                else if (radio_contact.Checked == true)
                {
                    querry = "SELECT Accounts.acname, Accounts.extended, account_part.place, account_part.city, account_part.Mobile" +
                        " FROM Accounts INNER JOIN account_part ON Accounts.acid = account_part.acid WHERE (((Accounts.extended)=True) AND ((account_part.mobile) Like '*" + txt_searchtxt.Text.ToString() + "*'))";
                }

                else if (radio_state.Checked == true)
                {
                    querry = "SELECT Accounts.acname, Accounts.extended, account_part.place, account_part.city, account_part.Mobile" +
                        " FROM Accounts INNER JOIN account_part ON Accounts.acid = account_part.acid WHERE (((Accounts.extended)=True) AND ((account_part.state) Like '*" + txt_searchtxt.Text.ToString() + "*'))";
                }

                Console.WriteLine(querry);
                OleDbDataAdapter searchAdptr = new OleDbDataAdapter(querry, Globals.con);
                DataSet ds = new System.Data.DataSet();
                searchAdptr.Fill(ds);
                DataView dv = new System.Data.DataView(ds.Tables[0]);
                if (dv.Count > 0)
                {
                    dataGridView1.DataSource = dv;
                }


            }
            catch (OleDbException ele)
            {
                MessageBox.Show(ele.Message.ToString());
            }

        }

        private void txt_searchtxt_TextChanged(object sender, EventArgs e)
        {
            //this.search();
        }

        private void btn_search_All_Click(object sender, EventArgs e)
        {
            try
            {

                OleDbDataAdapter ad = new OleDbDataAdapter("SELECT Accounts.acname, account_part.city, account_part.place, account_part.Mobile, account_part.district " +
    " FROM account_part INNER JOIN Accounts ON account_part.acid = Accounts.acid WHERE (((Accounts.extended)=True))", Globals.con);
                DataSet ds = new System.Data.DataSet();
                ad.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];

            }
            catch (OleDbException E)
            {
                MessageBox.Show(E.Message.ToString());
            }

        }
    }
}
