/**
 *  @filename InvoiceGenerator.cs
 *  @author Vincent Willats - vincentwillats.software@gmail.com
 *  @created 04/12/2019
 *  @version 0.21
 *
 *  History
 *   0.21   04/02/2020
 *          Updated export filename, added name to cell A1
 *          Removed message box on entry add
 *          Added remove item button and function
 *   0.2    06/12/2019 - Expanded for general use
 *          Custom locations, jobs, details, comments added, uploaded to git
 *   0.1    04/12/2019 - Personal Edition
 *          Project started, personal edition made
 *          
 */


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



namespace InvoiceGenerator
{
    public partial class InvoiceGenerator : Form
    {
        // File Paths
        internal static string templatePath;
        internal static string newFilePath;

        // Personal Details
        internal static string name;
        internal static string ABN;
        internal static string email;
        internal static string contactNo;
        internal static string[] addressArr = new string[3];
        // Personal Bank Details
        internal static string bankBSB;
        internal static string bankAccNo;

        // Billee Details
        internal static int invoiceNo;
        DateTime invoiceDate;
        internal static bool paid;
        internal static string billeeName;
        internal static string[] billeeAddress = new string[3];


        // Item Details
        internal struct JobItem
        {
            internal string itemDestription;
            internal DateTime dateOfWork;
            internal float itemPricePerUnit;
            internal float itemQuant;
            internal float itemTotalCost;
        }
        // List of job items
        List<JobItem> lstJobItems = new List<JobItem>();

        // Excel document
        ExcelFile workbook;

        // Entry validation
        bool validItemPrice = false;
        bool validItemAmount = false;
        bool validTotalPrice = false;


        // Pay validation
        float amount;
        float payPerItem;
        float payTotal;



        public InvoiceGenerator()
        {
            InitializeComponent();
        }

        // On Form Load
        private void Form1_Load(object sender, EventArgs e)
        {
            // Opens and reads settings file
            StreamReader settingsFile;
            settingsFile = File.OpenText("./settings.txt");
            string strRead;
            while ((strRead = settingsFile.ReadLine()) != null)
            {
                string[] strTempArr = new string[11];
                strTempArr = strRead.Split('|');
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
                templatePath = strTempArr[9];
                newFilePath = strTempArr[10];
            }
            settingsFile.Close(); // Close settings file

            // Reset/Sets Item Box
            resetItemBox();

        }

        // Load Template to workbook
        private void loadTemplate()
        {
            try
            {
                // Sets license to free limited, max 150 rows
                SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
                SpreadsheetInfo.FreeLimitReached += (sender, e) => e.FreeLimitReachedAction = FreeLimitReachedAction.ContinueAsTrial;

                // Opens the template
                using (Stream input = File.OpenRead(templatePath))
                    workbook = ExcelFile.Load(input, LoadOptions.XlsxDefault);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // On generate click, generate the .xlsx and .pdf if inputs valid
        private void BtnGenerate_Click(object sender, EventArgs e)
        {

            // Set Invoice details
            paid = cbxPaid.Checked;
            billeeName = txtBillee.Text;
            billeeAddress[0] = txtBilleeAddress01.Text;
            billeeAddress[1] = txtBilleeAddress02.Text;
            billeeAddress[2] = txtBilleeAddress03.Text;
            invoiceDate = dtp1.Value;

            // If inputs are currently valid save the xlsx and pdf then clear items
            if (validItemAmount && validItemPrice && validTotalPrice)
            {
                errorProvider1.Dispose();
                saveFile();
                resetItemBox();
                lstJobItems.Clear();
                txtItemDesc.Clear();
                txtItemPrice.Clear();
                txtItemAmount.Clear();
                txtItemTotalPrice.Clear();
            }
            else
            {
                errorProvider1.SetError(btnGenerate, "Something wrong!");
            }
        }

        // Adding details into workbook and saving it
        private void saveFile()
        {
            loadTemplate();

            string newFilePathTotal = newFilePath + "/" + Regex.Replace(name, @"\s+", "") + "Invoice_InvoiceNo-" + invoiceNo.ToString() + "_" + invoiceDate.ToString("dd-MM-yyyy") + ".xlsx";

            // Setting values

            // Personal Details
            workbook.Worksheets[0].Cells["A1"].Value = name;
            workbook.Worksheets[0].Cells["A4"].Value = ABN;
            workbook.Worksheets[0].Cells["A6"].Value = email;
            workbook.Worksheets[0].Cells["A8"].Value = contactNo;
            workbook.Worksheets[0].Cells["A10"].Value = addressArr[0];
            workbook.Worksheets[0].Cells["A11"].Value = addressArr[1];
            workbook.Worksheets[0].Cells["A12"].Value = addressArr[2];
            // Personal Bank Details
            workbook.Worksheets[0].Cells["B14"].Value = bankBSB;
            workbook.Worksheets[0].Cells["B15"].Value = bankAccNo;

            // Set Invoice Details
            workbook.Worksheets[0].Cells["H4"].Value = invoiceDate.ToString("d");
            workbook.Worksheets[0].Cells["H6"].Value = invoiceNo;
            workbook.Worksheets[0].Cells["F9"].Value = billeeName;
            workbook.Worksheets[0].Cells["F12"].Value = billeeAddress[0];
            workbook.Worksheets[0].Cells["F13"].Value = billeeAddress[1];
            workbook.Worksheets[0].Cells["F14"].Value = billeeAddress[2];
            
            // If paid
            if (paid)
            {
                workbook.Worksheets[0].Cells["B32"].Value = "PAID";
            }
            else
            {
                workbook.Worksheets[0].Cells["B32"].Value = "";
            }

            // Job Details

            int cell = 21;
            double totalCost = 0;
            foreach (JobItem item in lstJobItems)
            {
                totalCost += item.itemTotalCost;
                workbook.Worksheets[0].Cells["A"+cell.ToString()].Value = item.itemDestription;
                workbook.Worksheets[0].Cells["D"+cell.ToString()].Value = item.dateOfWork.ToString("d");
                workbook.Worksheets[0].Cells["E"+cell.ToString()].Value = item.itemPricePerUnit;
                workbook.Worksheets[0].Cells["G"+cell.ToString()].Value = item.itemQuant.ToString();
                workbook.Worksheets[0].Cells["H"+cell.ToString()].Value = item.itemTotalCost;
                cell += 1;
            }

            workbook.Worksheets[0].Cells["H29"].Value = totalCost;


            invoiceNo += 1;
            txtInvoiceNo.Text = invoiceNo.ToString();

            using (FileStream output = File.Create(newFilePathTotal))
                workbook.Save(output, SaveOptions.XlsxDefault);
            SaveAsPdf(newFilePathTotal);


        }

        // Saving workbook as pdf
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

        // On Form close save config details
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                StreamWriter sw = new StreamWriter("./settings.txt");

                //Name, ABN, Email, Contact No
                sw.WriteLine(
                      name + "|" 
                    + ABN + "|" 
                    + email + "|" 
                    + contactNo + "|" 
                    + addressArr[0] + "|" 
                    + addressArr[1] + "|" 
                    + addressArr[2] + "|" 
                    + bankBSB + "|" 
                    + bankAccNo + "|"     
                    + templatePath + "|" 
                    + newFilePath);


                sw.Close();
            }
            catch (Exception ea)
            {
                Console.WriteLine("Exception: " + ea.Message);
            }
        }

        // Open Config Form
        private void BtnConfig_Click(object sender, EventArgs e)
        {
            ConfigForm newConfig = new ConfigForm();
            newConfig.ShowDialog();
        }

        // Add Item if valid inputs
        private void btnAdd_Click(object sender, EventArgs e)
        {

            bool validPrice = false;

            // Checks all are valid
            if (validItemPrice && validItemAmount && validTotalPrice)
            {
                validPrice = true;
            }

            if (validPrice)
            {
                // Checks no more than 8 items
                if(lstJobItems.Count < 8)
                {
                    addItemToList();
                }
                else
                {
                    errorProvider1.SetError(btnAdd, "Already at Max Items");
                }
            }            
            else
            {
                errorProvider1.SetError(btnAdd, "Invalid input");
            }
        }

        // Adds items to lstJobItems and ListBox
        private void addItemToList()

        {
            JobItem newItem = new JobItem();

            newItem.itemDestription = txtItemDesc.Text;        
            newItem.dateOfWork = dtpItemDate.Value;
            newItem.itemPricePerUnit = float.Parse(txtItemPrice.Text);
            newItem.itemQuant = float.Parse(txtItemAmount.Text);
            newItem.itemTotalCost = float.Parse(txtItemTotalPrice.Text);

            string temp = newItem.itemDestription;
            int tempInt = 32 - (temp.Length);
            for(;tempInt > 0; tempInt--)
            {
                temp = temp + " ";
            }

            lbxItems.Items.Add(temp + "\t" + newItem.dateOfWork.ToString("d") + "\t" + newItem.itemPricePerUnit.ToString() + "\t\t" + newItem.itemQuant.ToString() + "\t" + newItem.itemTotalCost.ToString());

            lstJobItems.Add(newItem);
            
            //MessageBox.Show("Entered");

        }

        // When unit price changes
        private void txtItemPrice_TextChanged(object sender, EventArgs e)
        {
            setHoursAndPay("pricePerItem");
        }

        // When unit amount changes
        private void txtQuantOrHours_TextChanged(object sender, EventArgs e)
        {
            setHoursAndPay("itemAmount");
        }

        // When total price changes
        private void txtTotalPrice_TextChanged(object sender, EventArgs e)
        {
            setHoursAndPay("priceOfItemTotal");
        }

        // Called when price changes
        private void setHoursAndPay(string whatBox)
        {            
            if (whatBox == "itemAmount")
            {
                if (!float.TryParse(txtItemAmount.Text, out amount))
                {
                    errorProvider1.SetError(txtItemAmount, "Invalid Hours");
                    txtItemAmount.Clear();
                    txtItemTotalPrice.Clear();
                    txtItemAmount.Focus();
                    validItemAmount = false;
                }
                else
                {
                    if (payPerItem != 0)
                    {
                        txtItemTotalPrice.Text = (amount * payPerItem).ToString();
                    }
                    errorProvider1.Dispose();                   
                    validItemAmount = true;
                }
            }
            if (whatBox == "pricePerItem")
            {
                if (!float.TryParse(txtItemPrice.Text, out payPerItem))
                {
                    errorProvider1.SetError(txtItemPrice, "Invalid Price Per Item");
                    txtItemPrice.Clear();
                    txtItemPrice.Focus();
                    validItemPrice = false;
                }
                else
                {
                    if(amount != 0)
                    {
                        txtItemTotalPrice.Text = (amount * payPerItem).ToString();
                    }
                    errorProvider1.Dispose();
                    validItemPrice = true;
                }
            }
            if (whatBox == "priceOfItemTotal")
            {
                if (!float.TryParse(txtItemTotalPrice.Text, out payTotal))
                {
                    errorProvider1.SetError(txtItemTotalPrice, "Invalid total price. Can leave blank if per item and total items is filled.");
                    txtItemTotalPrice.Clear();
                    txtItemTotalPrice.Focus();
                    validTotalPrice = false;
                }
                else
                {
                    if (payPerItem != 0)
                    {
                        
                        float tempNum = (float)Math.Round((payTotal / payPerItem), 2);                        
                        if ((tempNum % 0.25) == 0)
                        {
                            errorProvider1.Dispose();
                            txtItemAmount.Text = (payTotal / payPerItem).ToString();
                            validTotalPrice = true;
                        }
                        else
                        {
                            errorProvider1.SetError(txtItemTotalPrice, "Not valid total price.");
                            validTotalPrice = false;
                        }                        
                    }                  
                }
            }
        }

        // Resets item list box
        private void resetItemBox()
        {
            lbxItems.Items.Clear();
            lbxItems.Items.Add("Description\t\tDate\t\tUnit Price\t\tAmount\tTotal");
        }

        // When description changes
        private void txtItemDesc_TextChanged(object sender, EventArgs e)
        {
            if(txtItemDesc.Text.Length > 22)
            {
                errorProvider1.SetError(txtItemDesc, "Max 22 Chars");
                string temp = txtItemDesc.Text;
                string temp01 = temp.Substring(0, 21);
                txtItemDesc.Text = temp01;                
            }
        }

        // When invoice no changes
        private void txtInvoiceNo_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(txtInvoiceNo.Text, out invoiceNo))
            {
                errorProvider1.SetError(txtInvoiceNo, "Number Only");
                txtInvoiceNo.Clear();
                txtInvoiceNo.Focus();
            }
            else
            {
                errorProvider1.Dispose();
            }
        }

        // when address changed
        private void txtBilleeAddress01_TextChanged(object sender, EventArgs e)

        {
            if (txtBilleeAddress01.Text.Length > 28)
            {
                errorProvider1.SetError(txtBilleeAddress01, "Max 28 Chars");
                string temp = txtBilleeAddress01.Text;
                string temp01 = temp.Substring(0, 27);
                txtBilleeAddress01.Text = temp01;
            }
        }

        // when address changed
        private void txtBilleeAddress02_TextChanged(object sender, EventArgs e)

        {
            if (txtBilleeAddress02.Text.Length > 28)
            {
                errorProvider1.SetError(txtBilleeAddress02, "Max 28 Chars");
                string temp = txtBilleeAddress02.Text;
                string temp01 = temp.Substring(0, 27);
                txtBilleeAddress02.Text = temp01;
            }
        }

        // when address changed
        private void txtBilleeAddress03_TextChanged(object sender, EventArgs e)

        {
            if (txtBilleeAddress03.Text.Length > 28)
            {
                errorProvider1.SetError(txtBilleeAddress03, "Max 28 Chars");
                string temp = txtBilleeAddress03.Text;
                string temp01 = temp.Substring(0, 27);
                txtBilleeAddress03.Text = temp01;
            }
        }

        // when address changed
        private void txtBillee_TextChanged(object sender, EventArgs e)
        {
            if (txtBillee.Text.Length > 32)
            {
                errorProvider1.SetError(txtBillee, "Max 32 Chars");
                string temp = txtBillee.Text;
                string temp01 = temp.Substring(0, 31);
                txtBillee.Text = temp01;
            }
        }

        // Remove item/job from list
        private void btn_removeItem_Click(object sender, EventArgs e)
        {
            if(lbxItems.SelectedIndex > 0)
            {
                lbxItems.Items.RemoveAt(lbxItems.SelectedIndex);
                MessageBox.Show("Item removed");
            }
            else
            {
                MessageBox.Show("No item in list selected");
            }
        }
    }
}
