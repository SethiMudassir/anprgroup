using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication1
{
    public partial class AddUser : Form
    {
        string gender;
        int role;
        public AddUser()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void CloseThis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Exit current form
        private void btExit_Click(object sender, EventArgs e)
        {
           this.Dispose();
        }

        //check email
        public bool TestEmailRegex(string emailAddress)
        {
            string patternStrict = @"^(([^<>()[\]\\.,;:\s@\""]+"
                  + @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"
                  + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"
                  + @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"
                  + @"[a-zA-Z]{2,}))$";
            Regex reStrict = new Regex(patternStrict);
                      
            bool isStrictMatch = reStrict.IsMatch(emailAddress);
            return isStrictMatch;

        }

        //Save to database
        private void btSave_Click(object sender, EventArgs e)
        {
            string depass = "123";
            bool isFail = true;
            bool checkEmail = false;
            //Get Gender info
            try
            {
                if (radioMale.Checked)
                {
                    gender = "Male";
                }
                if (radioFemale.Checked)
                {
                    gender = "Female";
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
            }

            //Get Role info
            try
            {
                if (radioStaff.Checked)
                {
                    role = 0;
                }
                if (radioManager.Checked)
                {
                    role = 1;
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
            }

            //checking email
            if (tbEmail.Text.Trim() == "")
                checkEmail = true;
            else
            {
                checkEmail = TestEmailRegex(tbEmail.Text.Trim());
                if (checkEmail == false)
                    MessageBox.Show("Invalid email");
            }
            //push to database
            if (checkEmail == true)
            {
                try
                {
                    sqlHelper.ExecuteNonQuery(
                        "ins_user",
                        CommandType.StoredProcedure,
                        "@FullName", tbFullName.Text.Trim(),
                        "@Username", tbUsername.Text.Trim(),
                        "@Role", role,
                        "@Sex", gender,
                        "@Address", tbAddress.Text.Trim(),
                        "@Phone", tbMobile.Text.Trim(),
                        "@Birthday", birthdayPicker.Value.Date,
                        "@Email", tbEmail.Text.Trim(),
                        "@IDNumber", tbIDNumber.Text,
                        "@Password", depass);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    isFail = false;
                }
                finally
                {
                    MessageBox.Show("Add User");
                    if (isFail == true)
                        FrameMain.frmManagement.updateTable(tbFullName.Text.Trim(), tbUsername.Text.Trim(), tbAddress.Text.Trim(),
                                                        tbMobile.Text.Trim(), tbEmail.Text.Trim());
                }
            }
        }
    }
}
