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
    public partial class MainFrame : Form
    {
        public MainFrame()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Parking_Taking pt = new Parking_Taking();
            pt.Show();
            button1.Name = "change1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Management().Show();
        }
    }
}
