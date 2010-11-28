using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class Report_MonFinace : Form
    {
        public Report_MonFinace()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void Report_MonFinace_Load(object sender, EventArgs e)
        {
            CreatReport();
        }

        public void CreatReport()
        {
            string source = "Data Source=NGOCQT\\SQLEXPRESS;Initial Catalog=PNR;Integrated Security=True";
            SqlConnection conn = new SqlConnection(source);

            try
            {
                conn.Open();
                string query = "select Ticket_Type, V_No, V_Ticket, In_Time, Out_Time from V_detail";
                SqlDataAdapter myDataAdapter = new SqlDataAdapter(query, conn);

                DataSet dataReport = new DataSet();
                myDataAdapter.Fill(dataReport, "Table");

                Report_daily myDataReport = new Report_daily();
                myDataReport.SetDataSource(dataReport);
                crystalReportViewer1.ReportSource = myDataReport;
            }
            catch (SqlException ex) { MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }
    }
}
