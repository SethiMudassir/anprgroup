using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Configuration;
using System.Xml;
using System.Threading;
namespace WindowsFormsApplication1
{
    public partial class Parking_Taking : Form
    {
        Thread th1;
        public Parking_Taking()
        {
            InitializeComponent();
            tickerDelegate1 = new TickerDelegate(SetLeftTicker);
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox19_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void Parking_Taking_Load(object sender, EventArgs e)
        {
            
            th1 = new Thread(new ThreadStart(check));
            th1.IsBackground = true;
            th1.Start();
        }
            

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox17_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void groupBox8_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter=("Image (*.jpg) | *.jpg");
            openFileDialog1.ShowDialog();
            MessageBox.Show(openFileDialog1.FileName);
            Image image;
            image = Image.FromFile(openFileDialog1.FileName);
            
            //pictureBox2.Height = image.Height;
            //pictureBox2.Width = image.Width;
            //pictureBox2.Image = image;

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Bmp File (*.bmp) |*.bmp| Jpg File (*.jpg)|*.jpg";

            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            Image image;
            image = FixedSize(Image.FromFile(openFileDialog1.FileName),487,300);
            try
            {
                pictureBox1.Image = image;
            }
            catch (Exception)
            {
                MessageBox.Show("Error opening file", "File Error",
                                     MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        static Image FixedSize(Image imgPhoto, int Width, int Height)
        {
            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;
            int sourceX = 0;
            int sourceY = 0;
            int destX = 0;
            int destY = 0;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)Width / (float)sourceWidth);
            nPercentH = ((float)Height / (float)sourceHeight);
            if (nPercentH < nPercentW)
            {
                nPercent = nPercentH;
                destX = System.Convert.ToInt16((Width -
                              (sourceWidth * nPercent)) / 2);
            }
            else
            {
                nPercent = nPercentW;
                destY = System.Convert.ToInt16((Height -
                              (sourceHeight * nPercent)) / 2);
            }

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap bmPhoto = new Bitmap(Width, Height,
                              PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                             imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.Clear(Color.Red);
            grPhoto.InterpolationMode =
                    InterpolationMode.HighQualityBicubic;

            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();
            return bmPhoto;
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {    
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                String strCardNumber;
                strCardNumber = textBox3.Text;
                String constring = ConfigurationManager.ConnectionStrings["PNR"].ConnectionString;
                String sqlStr = "select * from Mothly_Ticket where IDCard Like " + strCardNumber;
                SqlConnection con = new SqlConnection(constring);
                con.Open();
                SqlDataAdapter dataAdapt = new SqlDataAdapter(sqlStr, constring);
                DataSet dataSet = new DataSet();
                dataAdapt.Fill(dataSet, "Monthly_Ticket");

                if (dataSet.Tables["Monthly_Ticket"].Rows.Count == 1)
                {
                    foreach (DataRow row in dataSet.Tables["Monthly_Ticket"].Rows)
                    {
                        label18.Text = "M" + textBox3.Text;
                        label18.Visible = true;
                        maskedTextBox9.Text = row["IDCard"].ToString();
                        maskedTextBox1.Text = row["Expire_Date"].ToString();
                        maskedTextBox6.Text = row["V_No1"].ToString();
                        maskedTextBox4.Text = row["V_No2"].ToString();
                        maskedTextBox7.Text = row["CustomerName"].ToString();
                        maskedTextBox8.Text = dateTimePicker2.Text;
                    }
                }
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Anpr.Anprclass anpr = new Anpr.Anprclass();
            anpr.Biensoxe();
            anpr.Dispose();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("C:\\plate.xml");

            XmlNodeList plateNumberNode = doc.GetElementsByTagName("plateNumber");

            String plateNumber;
            foreach (XmlNode plate in plateNumberNode)
            {
                plateNumber = plate.ChildNodes[0].Value.ToString();
                maskedTextBox3.Text = plateNumber;
            }
            XmlNodeList pathFileNode = doc.GetElementsByTagName("pathFile");
            String pathFile;
            foreach (XmlNode path in pathFileNode)
            {
                pathFile = path.ChildNodes[0].Value.ToString();
                pictureBox1.Image = FixedSize(Image.FromFile(pathFile), 487, 300);
            }
            
        }

        //----Thread Dong ho     
        private delegate void TickerDelegate(string s);
        TickerDelegate tickerDelegate1;
        private void disp()
        {
            while (true)
            {
                Thread.Sleep(1000);
            }
        }
        private void SetLeftTicker(string s)
        {
            this.Text = s;
        }

        //----Thread refresh
        delegate void check_load_room_to_formMainCallback();
        private void check_load_room_to_formMain()
        {
            if (this.pictureBox1.InvokeRequired)
            {
                check_load_room_to_formMainCallback d = new check_load_room_to_formMainCallback(check_load_room_to_formMain);
                this.Invoke(d);
            }
            else
            {
                string pathFile;
                string plateNumber;
                Boolean flag = true;
                while (flag)
                {
                    try
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load("C:\\plate.xml");
                        XmlNodeList plateNumberNode = doc.GetElementsByTagName("plateNumber");

                        if (plateNumberNode != null)
                        {
                            foreach (XmlNode plate in plateNumberNode)
                            {

                                if (plate.ChildNodes[0] == null)

                                    flag = false;
                                else
                                {
                                    plateNumber = plate.ChildNodes[0].Value.ToString();
                                    maskedTextBox3.Text = plateNumber;
                                    flag = false;
                                }
                            }

                            // get path of file picture to load on Picture box
                            XmlNodeList pathFileNode = doc.GetElementsByTagName("pathFile");
                            if (pathFileNode != null)
                            {
                                foreach (XmlNode path in pathFileNode)
                                {

                                    if (path.ChildNodes[0] == null)

                                        flag = false;
                                    else
                                    {
                                        pathFile = path.ChildNodes[0].Value.ToString();
                                        pictureBox1.Image = FixedSize(Image.FromFile(pathFile), 487, 300);
                                        flag = false;
                                        //th1.Abort();
                                        
                                        //doc.AppendChild(doc.CreateElement("","root_element",""));
                                        //XmlNode plateNode = doc.CreateElement("plateNumber");
                                        //plateNode.AppendChild(doc.CreateTextNode(""));
                                        //XmlNode pathNode = doc.CreateElement("pathFile");
                                        //pathNode.AppendChild(doc.CreateTextNode(""));
                                        //doc.Save("C:\\plates.xml");
                                    }
                                }

                                //Thread.Sleep(5000);
                            }
                        }
                    
                    }catch (Exception)
                    {
                        flag = true;
                    }
                    refreshXML();
                    
                }    
            }
        }
        private void check()
        {
            while (true)
            {
                check_load_room_to_formMain();
                Thread.Sleep(1000);
            }
        }

        private void refreshXML()
        {
            XmlDocument xmlDom = new XmlDocument();
            xmlDom.AppendChild(xmlDom.CreateElement("", "root_element", ""));
            XmlElement xmlRoot = xmlDom.DocumentElement;
            XmlElement xmlTitle, xmlAuthor, xmlPrice;
            XmlText xmlText;

            xmlTitle = xmlDom.CreateElement("", "plateNumber", "");
            xmlText = xmlDom.CreateTextNode("");
            xmlTitle.AppendChild(xmlText);
            xmlRoot.AppendChild(xmlTitle);


            xmlAuthor = xmlDom.CreateElement("", "pathFile", "");
            xmlText = xmlDom.CreateTextNode("");
            xmlAuthor.AppendChild(xmlText);
            xmlRoot.AppendChild(xmlAuthor);

            xmlDom.Save("C:\\plate.xml");
            
        }


    }
}
 