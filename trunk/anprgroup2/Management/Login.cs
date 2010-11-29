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
            //sqlHelper.sqlHelper.ExecuteQuery;
            DataTable dtDN = sqlHelper.sqlHelper.ExecuteQuery(
                    "check_login",
                    CommandType.StoredProcedure,
                    "@UsersID", textBoxUserName.Text,
                    "@Pass", textBoxPassword.Text);
            if (dtDN.Rows.Count == 0)
            {
                MessageBox.Show("Đăng nhập lỗi... Kiểm tra lại!", "Cảnh báo");
            }
            else
            {
                this.Hide();
                DataRow user = dtDN.Rows[0];
                FrameMain f = new FrameMain();
                f.getDataLogin(dtDN);
               // f.SetEnable((bool)user["systemRolle"], (bool)user["ReservationRolle"], (bool)user["resourceRolle"], (bool)user["reportRolle"], (bool)user["ServiceRolle"]);
                f.Show();
            }

        }
    }
}
