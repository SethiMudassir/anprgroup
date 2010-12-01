using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using sqlHelper;

namespace WindowsFormsApplication1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void cmdLogin_Click(object sender, EventArgs e)
        {

            Login_Main();
        }

        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
                        
            if (e.KeyCode == Keys.Enter)
            {
                Login_Main();
            }
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBoxUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //private void Login_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    Application.Exit();
        //}

        // Login function code

        private void Login_Main()
        {  //sqlHelper.sqlHelper.ExecuteQuery;
            DataTable dtDN = sqlHelper.sqlHelper.ExecuteQuery(
                    "check_login",
                    CommandType.StoredProcedure,
                    "@Username", textBoxUserName.Text,
                    "@Password", textBoxPassword.Text);
            if (dtDN.Rows.Count == 0)
            {
                MessageBox.Show("You have entered an invalid UserName or Password.Please try again!", "Error message");
            }
            else
            {
                this.Hide();
                //DataRow user = dtDN.Rows[0];
                FrameMain f = new FrameMain();
                f.getDataLogin(dtDN);

                // phân quyền
                //f.SetEnable((bool)user["systemRolle"], (bool)user["ReservationRolle"], (bool)user["resourceRolle"], (bool)user["reportRolle"], (bool)user["ServiceRolle"]);

                f.Show();

            }
        }
    }
}
