using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace WindowsFormsApplication1
{
    public partial class Management : Form
    {
        public Management()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            managementTab.TabPages.Clear();
            managementTab.TabPages.Add(tabPage1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            managementTab.TabPages.Clear();
            
        }

      

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void User_MouseMove(object sender, MouseEventArgs e)
        {
            //User.BackColor = Color.DarkOrange;
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Management_Load(object sender, EventArgs e)
        {
            managementTab.TabPages.Clear();
            managementTab.TabPages.Add(tabPage1);

            String constring=ConfigurationManager.ConnectionStrings["PNR"].ConnectionString;
            String sqlStr="select * from Staff";
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlDataAdapter dataAdapt = new SqlDataAdapter(sqlStr,constring);
            DataSet dataSet = new DataSet();
            dataAdapt.Fill(dataSet,"Staff");
            listView1.Items.Clear();
            int count = 0;
            foreach(DataRow row in dataSet.Tables["Staff"].Rows)
            {
                ListViewItem item = new ListViewItem();
                item.Text = (++count).ToString();
                item.SubItems.Add(row["Full_Name"].ToString());
                item.SubItems.Add(row["UserName"].ToString());
                item.SubItems.Add(row["Address"].ToString());
                item.SubItems.Add(row["Phone"].ToString());
                item.SubItems.Add(row["Email"].ToString());

                listView1.Items.Add(item);
            }

            
        }

        private void addUserbt_Click(object sender, EventArgs e)
        {
            new AddUser().Show();
        }

        private void editUserbt_Click(object sender, EventArgs e)
        {
            new EditUser().Show();
        }

        private void ticketbt_Click(object sender, EventArgs e)
        {
            managementTab.TabPages.Clear();
            managementTab.TabPages.Add(tabPage3);
            managementTab.TabPages.Add(tabPage4);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            new AddMonthlyTicket().Show();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            new UpdateMTicket().Show();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            new ViewMonthlyTicket().Show();
        }

       

    }
}
