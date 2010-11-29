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
    public partial class FrameMain : Form
    {
        public FrameMain()
        {
            InitializeComponent();
        }

        // Login fuction

        private DataTable rowgetLogin;
        public void getDataLogin(DataTable rowlogin)
        {
            rowgetLogin = (DataTable)rowlogin;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            new Parking_Taking().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Management().Show();
        }

        private void FrameMain_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // report for dailly  
            new Report_dailly().Show();

             //report for finance
             //new Report_MonFinace().Show();
        }

        
    }
}
