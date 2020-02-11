/**
 *  @filename InvoiceGenerator.cs
 *  @author Vincent Willats - vincentwillats.software@gmail.com
 *  @created 04/12/2019
 *  @version 0.21
 *
 *  History
 *   0.25   11/02/2020
 *          Move Busisness logic to Functions class/out of UI
 *          Added BackgroundWorker for loading settings
 *   0.24   05/02/2020
 *          Moved JobItems into a seperate class
 *   0.23   04/02/2020
 *          Added XmlManager and settings class, removed settings being saved in .txt
 *   0.22   04/02/2020
 *          Fixed settings file, will create if not exists
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
        internal static Settings settings = new Settings();
        internal static Functions functions = new Functions();

        BackgroundWorker bg_worker;

        public object XmlFileManager { get; private set; }

        // List of job items
        List<JobItem> lstJobItems = new List<JobItem>();

        // Billee Details
        internal static int invoiceNo;
        DateTime invoiceDate;
        internal static bool paid;
        internal static string billeeName;
        internal static string[] billeeAddress = new string[3];

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

            bg_worker = new BackgroundWorker();
            bg_worker.DoWork += new DoWorkEventHandler(bg_worker_DoWork);
            bg_worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_worker_RunWorkerCompleted);
            bg_worker.WorkerSupportsCancellation = false;
        }

        // When settings finished loaded comfirm or give error
        void bg_worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Error != null)
            {
                lblSettings.Text = "Error";
                MessageBox.Show("Error loading settings: " + e.ToString());
            }
            else
            {
                lblSettings.Text = "Settings Loaded";
            }
        }

        // Load settings
        void bg_worker_DoWork(object sender, DoWorkEventArgs e)
        {
            settings = functions.retriveSettings("settings.xml");
        }
     
        // On Form Load
        private void Form1_Load(object sender, EventArgs e)
        {
            bg_worker.RunWorkerAsync();                            
            resetItemBox();
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
                functions.saveFile(settings.TemplatePath, settings.NewFilePath, settings.Name, invoiceNo, invoiceDate,
                                    settings.ABN, settings.Email, settings.ContactNo, settings.Address01, settings.Address02,
                                    settings.Address03, settings.BankBSB, settings.BankAccNo, billeeName, billeeAddress, paid, lstJobItems);
                txtInvoiceNo.Text = (invoiceNo + 1).ToString();
                resetItemBox();
                lstJobItems.Clear();
                txtItemDesc.Clear();
                txtItemPrice.Clear();
                txtItemAmount.Clear();
                txtItemTotalPrice.Clear();
            }
            else
            {
                errorProvider1.SetError(btnGenerate, "Invalid prices");
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
                    addItemToListboxAndList();
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
        private void addItemToListboxAndList()

        {
            // Create item
            JobItem newItem = new JobItem(txtItemDesc.Text, dtpItemDate.Value, float.Parse(txtItemPrice.Text), float.Parse(txtItemAmount.Text), float.Parse(txtItemTotalPrice.Text)); 
            // Add detils to list box
            lbxItems.Items.Add(newItem.Details);
            // Add item to list.
            lstJobItems.Add(newItem);
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
                lstJobItems.RemoveAt(lbxItems.SelectedIndex - 1);
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
