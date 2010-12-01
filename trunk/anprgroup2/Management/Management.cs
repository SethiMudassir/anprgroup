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
        DataTable dtRT;
        int pos = 0;
        int i = 1;
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

        public void Management_Load(object sender, EventArgs e)
        {
            try
            {
                dtRT = sqlHelper.ExecuteQuery(
                "list_User",
                CommandType.StoredProcedure);
                listView1.Items.Clear();
                if (dtRT.Rows.Count > 0)
                {                    
                    foreach (DataRow row in dtRT.Rows)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = i.ToString();
                        item.SubItems.Add(row["Full_Name"].ToString());
                        item.SubItems.Add(row["UserName"].ToString());
                        item.SubItems.Add(row["Address"].ToString());
                        item.SubItems.Add(row["Phone"].ToString());
                        item.SubItems.Add(row["Email"].ToString());
                        listView1.Items.Add(item);
                        i++;
                    }
                    listView1.Items[pos].Selected = true;
                    //listView1_SelectedIndexChanged(listView1.Items[pos], System.EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

                        
        }

        //update table after adding
        public void updateTable(string a1,string a2, string a3,string a4,string a5)
        {
            ListViewItem item = new ListViewItem();
            item.Text = i.ToString();
            item.SubItems.Add(a1);
            item.SubItems.Add(a2);
            item.SubItems.Add(a3);
            item.SubItems.Add(a4);
            item.SubItems.Add(a5);
            listView1.Items.Add(item);
            i++;
        }

        //populate Addnew menu
        private void addUserbt_Click(object sender, EventArgs e)
        {
            new AddUser().Show();
        }

        //populate Edit Menu
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

        private void searchUserbt_Click(object sender, EventArgs e)
        {
            string text = tbSearch.Text.ToLower();
            int i = 1;
            listView1.Items.Clear();
            foreach (DataRow row in dtRT.Rows)
            {
                if (row["Full_Name"].ToString().ToLower().Contains(text) || row["UserName"].ToString().ToLower().Contains(text) ||
                    row["Address"].ToString().ToLower().Contains(text) || row["Phone"].ToString().ToLower().Contains(text) ||
                    row["Email"].ToString().ToLower().Contains(text))
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = i.ToString();
                    item.SubItems.Add(row["Full_Name"].ToString());
                    item.SubItems.Add(row["UserName"].ToString());
                    item.SubItems.Add(row["Address"].ToString());
                    item.SubItems.Add(row["Phone"].ToString());
                    item.SubItems.Add(row["Email"].ToString());
                    listView1.Items.Add(item);
                    i++;
                }
            }
        }

       

    }
}
