using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace WindowsFormsApplication1
{
    public partial class Report_dailly : Form
    {
        public Report_dailly()
        {
            InitializeComponent();
        }

        private void Report_dailly_Load(object sender, EventArgs e)
        {
            CreatReport();
        }

        public void CreatReport()
        {
            string source = ConfigurationManager.ConnectionStrings["PNR"].ConnectionString;
            SqlConnection conn = new SqlConnection(source);

            try
            {
                conn.Open();
                string query = "select TicketType.TicketType, V_No, V_Ticket, In_Time, Out_Time from V_detail,TicketType where TicketType.IDTicket = V_detail.Ticket_Type ";
                SqlDataAdapter myDataAdapter = new SqlDataAdapter(query, conn);

                DataSet dataReport = new DataSet();
                myDataAdapter.Fill(dataReport, "Table");

                ReportDailly myDataReport = new ReportDailly();
                myDataReport.SetDataSource(dataReport);
                //crystalReportViewer1.ReportSource = myDataReport;
            }
            catch (SqlException ex) { MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

      
        private void crystalReportViewer1_Load_1(object sender, EventArgs e)
        {
        
        }
    }
}
