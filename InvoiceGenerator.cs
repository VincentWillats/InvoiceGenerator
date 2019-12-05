using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GemBox.Spreadsheet;
using System.Text.RegularExpressions;


// Test Branch

namespace InvoiceGenerator
{
    public partial class InvoiceGenerator : Form
    {

        // Personal Details
        internal static string name;
        internal static string ABN;
        internal static string email;
        internal static string contactNo;
        internal static string[] addressArr = new string[3];
        // Personal Bank Details
        internal static string bankBSB;
        internal static string bankAccNo;
        // Invoice Properties
        internal static int invoiceNo;
        internal static float hourly;
        internal static bool paid;
        // File Paths
        internal static string templatePath;
        internal static string newFilePath;



        string venue = "";
        string venueShort = "";
        float hours;
        float pay;

        
                                 

        DateTime invoiceDate;
        DateTime dateOfWork;

        bool validDate = false;
        bool validHours = false;      

        ExcelFile workbook;   
        

        public InvoiceGenerator()
        {
            InitializeComponent();
        }               

        private void Form1_Load(object sender, EventArgs e)
        {            
            // Opens and reads settings file
            StreamReader settingsFile;
            settingsFile = File.OpenText("./settings.txt");
            string strRead;
            while((strRead = settingsFile.ReadLine()) != null)
            {
                string[] strTempArr = new string[14];
                strTempArr = strRead.Split(',');
                // Personal Details
                name = strTempArr[0];
                ABN = strTempArr[1];
                email = strTempArr[2];
                contactNo = strTempArr[3];
                // Address
                addressArr[0] = strTempArr[4];
                addressArr[1] = strTempArr[5];
                addressArr[2] = strTempArr[6];
                // Bank
                bankBSB = strTempArr[7]; 
                bankAccNo = strTempArr[8]; 
                // Invoice Properties
                invoiceNo = int.Parse(strTempArr[9]); 
                hourly = float.Parse(strTempArr[10]);
                paid = bool.Parse(strTempArr[11]);
                // File Paths
                templatePath = strTempArr[12];
                newFilePath = strTempArr[13]; 
    }
            settingsFile.Close();
           
            // Sets invoice no. text
            txtInvoiceNo.Text = invoiceNo.ToString();
            cbxPaid.Checked = paid;

            setVenueAndPaid();
            
        }
        private void loadTemplate()
        {
            try
            {
                SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
                SpreadsheetInfo.FreeLimitReached += (sender, e) => e.FreeLimitReachedAction = FreeLimitReachedAction.ContinueAsTrial;

                using (Stream input = File.OpenRead(templatePath))
                    workbook = ExcelFile.Load(input, LoadOptions.XlsxDefault);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
                     
        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            if (validHours && validDate)
            {
                errorProvider1.Dispose();                
                saveFile();
            }
            else
            {
                errorProvider1.SetError(btnGenerate, "Something wrong!");
            }
        }

        private void saveFile()
        {
            loadTemplate();

            string newFilePathTotal = newFilePath + "/" + Regex.Replace(name, @"\s+", "") + "Invoice_InvoiceNo-" + invoiceNo.ToString() + "_" + venueShort + "_" + invoiceDate.ToString("dd-MM-yyyy") + ".xlsx";

            // Setting values

            // Personal Details
            workbook.Worksheets[0].Cells["B5"].Value = ABN;
            workbook.Worksheets[0].Cells["B6"].Value = email;
            workbook.Worksheets[0].Cells["B7"].Value = contactNo;
            workbook.Worksheets[0].Cells["B8"].Value = addressArr[0];
            workbook.Worksheets[0].Cells["B9"].Value = addressArr[1];
            workbook.Worksheets[0].Cells["B10"].Value = addressArr[2];

            // Personal Bank Details
            workbook.Worksheets[0].Cells["B13"].Value = bankBSB;
            workbook.Worksheets[0].Cells["B14"].Value = bankAccNo;


            // Set Invoice Details
            workbook.Worksheets[0].Cells["G8"].Value = invoiceNo;           
            workbook.Worksheets[0].Cells["G10"].Value = venue;                       
            workbook.Worksheets[0].Cells["G6"].Value = dateOfWork.ToString("dd/MM/yyyy");

            // If paid
            if (paid)
            {
                workbook.Worksheets[0].Cells["E12"].Value = "PAID";
            }

            // Job Details

            // Set Invoice Location
            if(venueShort == "JSA")
            {
                workbook.Worksheets[0].Cells["B21"].Value = "JSA, Miami Beach Prom, WA, 6028";
                
            }
            if (venueShort == "SBC")
            {
                workbook.Worksheets[0].Cells["B21"].Value = "75 Deanmore Road, 6019, WA";     
            }
            workbook.Worksheets[0].Cells["D21"].Value = dateOfWork.ToString("dd/MM/yyyy");
            workbook.Worksheets[0].Cells["E21"].Value = hourly;
            workbook.Worksheets[0].Cells["G21"].Value = hours;
            workbook.Worksheets[0].Cells["H21"].Value = pay;
            workbook.Worksheets[0].Cells["H29"].Value = pay;

            invoiceNo += 1;
            txtInvoiceNo.Text = invoiceNo.ToString();

            using (FileStream output = File.Create(newFilePathTotal))
                workbook.Save(output, SaveOptions.XlsxDefault);
            SaveAsPdf(newFilePathTotal);


        }

        private void SaveAsPdf(string saveAsLocation)
        {
            string saveas = (saveAsLocation.Split('x')[0]) + "pdf";
            try
            {             
                ExcelFile ef = ExcelFile.Load(saveAsLocation);
                ef.Save(saveas);                  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);            
            }
        }   

        private void Dtp1_ValueChanged(object sender, EventArgs e)
        {
            setVenueAndPaid();
        }

        private void setVenueAndPaid()
        {
            DateTime pickedDate = dtp1.Value;
            DayOfWeek day = pickedDate.DayOfWeek;
            

            if (day == DayOfWeek.Tuesday)
            {
                txtVenue.Text = "Joondalup Sports Association";
                venue = "Joondalup Sports Association";
                venueShort = "JSA";
                dateOfWork = pickedDate;
                invoiceDate = pickedDate;
                validDate = true;
            }
            else if (day == DayOfWeek.Thursday)
            {
                txtVenue.Text = "Scarborough Bowling Club";
                venue = "Scarborough Bowling Club";
                venueShort = "SBC";
                dateOfWork = pickedDate;
                invoiceDate = pickedDate;
                validDate = true;
            }
            else
            {
                txtVenue.Text = "No Venue Set for: " + day.ToString();
                venue = "";
                validDate = false;
            }
            if (cbxPaid.Checked)
            {
                paid = true;
            }
            else if (!(cbxPaid.Checked))
            {
                paid = false;
            }
        }

        private void TxtHours_TextChanged(object sender, EventArgs e)
        {
            setHoursAndPay("hours");
            
        }

        private void TxtPrice_TextChanged(object sender, EventArgs e)
        {
            setHoursAndPay("price");
        }

        private void setHoursAndPay(string whatBox)
        {
            if(whatBox == "hours")
            {
                if (!float.TryParse(txtHours.Text, out hours))
                {
                    errorProvider1.SetError(txtHours, "Invalid Hours");
                    txtHours.Clear();
                    txtPrice.Clear();
                    txtHours.Focus();
                    validHours = false;
                }
                else
                {
                    errorProvider1.Dispose();
                    txtPrice.Text = (hours * hourly).ToString();
                    validHours = true;
                }
            }
            if(whatBox == "price")
            {
                if (!float.TryParse(txtPrice.Text, out pay))
                {
                    errorProvider1.SetError(txtPrice, "Invalid Pay");
                    txtHours.Clear();
                    txtPrice.Clear();
                    txtPrice.Focus();
                    validHours = false;
                }
                else
                {
                    int tempHours = (int)hours;
                    txtHours.Text = (pay / hourly).ToString();
                    if ((((((pay / hourly) * 100) / 25) % 25) % 1) == 0)
                    {
                        errorProvider1.Dispose();
                        validHours = true;                        
                    }
                    else 
                    {                        
                        errorProvider1.SetError(txtPrice, "Not valid total price");
                        validHours = false;                        
                    }
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                StreamWriter sw = new StreamWriter("./settings.txt");

                                        //Name, ABN, Email, Contact No
                sw.WriteLine(name + "," + ABN + "," + email + "," + contactNo +
                                        // Address
                    "," + addressArr[0] + "," + addressArr[1] + "," + addressArr[2] +
                                        // Bank BSB, BankAccNo, Invoice No, Hourly Pay, Paid?
                    "," + bankBSB + "," + bankAccNo + "," + invoiceNo + "," + hourly + "," + paid +
                                        // Template Path, NewFilePath
                    "," + templatePath + "," + newFilePath);
                

                sw.Close();
            }
           catch(Exception ea)
            {
                Console.WriteLine("Exception: " + ea.Message);
            }
        }

        private void BtnConfig_Click(object sender, EventArgs e)
        {
            ConfigForm newConfig = new ConfigForm();
            newConfig.ShowDialog();
        }

        private void CbxPaid_CheckedChanged(object sender, EventArgs e)
        {
            setVenueAndPaid();
        }
    }
}
