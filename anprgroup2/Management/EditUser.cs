using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class EditUser : Form
    {
        public EditUser(Staff a)
        {
            InitializeComponent();
            tbFullName.Text = a.fullName;
            tbUserName.Text = a.userName;
            tbAddress.Text = a.address;
            tbID.Text = a.idnumber;
            tbPhone.Text = a.phone;
            tbEmail.Text = a.email;
            dateTimePicker1.Value = a.birthday.Date;
            //Set gender value
            if (a.gender.Equals("Female"))
                radioFemale.Checked = true;
            else
                radioMale.Checked = true;
            //Set role value
            if (a.role == 0)
                radioStaff.Checked = true;
            else
                radioManager.Checked = true;
        }

        private void CloseThis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btPassReset_Click(object sender, EventArgs e)
        {
            bool isFail = true;
            try
            {
                sqlHelper.ExecuteNonQuery(
                    "resetPass",
                    CommandType.StoredProcedure,
                    "@Username", tbUserName.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                isFail = false;
            }
            finally
            {
                //MessageBox.Show("Add User");
                if (isFail == true)
                    MessageBox.Show("Reseted to 12345");
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {

        }
    }
}
