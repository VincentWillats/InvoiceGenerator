using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using GemBox.Spreadsheet;

namespace InvoiceGenerator
{
    public class Functions
    {
        Template template = new Template();

        // Retrive the settings file
        public Settings retriveSettings(string settingsFile)
        {
            if (File.Exists(settingsFile))
            {
                return XmlManager.XmlSettingsReader(settingsFile);
            }
            else
            {    
                return null;
            }
           
        }

        // Save Excel file
        public void saveFile(string savePath, string name, int invoiceNo, DateTime invoiceDate,
                                string ABN, string Email, string ContactNo, string Address01, string Address02, string Address03,
                                string BankBSB, string BankAccNo, string billeeName, string[] billeeAddress, bool paid, List<JobItem> lstJobItems)
        {
            ExcelFile workbook;
            workbook = loadTemplate();
            var worksheet = workbook.Worksheets.Add("New Sheet");
            template.setTemplateFormat(1, ref workbook);
            

            try
            {
                string newFilePathTotal = savePath + "/" + Regex.Replace(name, @"\s+", "") + "Invoice_InvoiceNo-" + invoiceNo.ToString() + "_" + invoiceDate.ToString("dd-MM-yyyy") + ".xlsx";

                // Setting values

                // Personal Details
                workbook.Worksheets[0].Cells["A1"].Value = name;
                workbook.Worksheets[0].Cells["A4"].Value = ABN;
                workbook.Worksheets[0].Cells["A6"].Value = Email;
                workbook.Worksheets[0].Cells["A8"].Value = ContactNo;
                workbook.Worksheets[0].Cells["A10"].Value = Address01;
                workbook.Worksheets[0].Cells["A11"].Value = Address02;
                workbook.Worksheets[0].Cells["A12"].Value = Address03;
                // Personal Bank Details
                workbook.Worksheets[0].Cells["B14"].Value = BankBSB;
                workbook.Worksheets[0].Cells["B15"].Value = BankAccNo;

                // Set Invoice Details
                workbook.Worksheets[0].Cells["G4"].Value = invoiceDate.ToString("d");
                workbook.Worksheets[0].Cells["G6"].Value = invoiceNo;
                workbook.Worksheets[0].Cells["G9"].Value = billeeName;
                workbook.Worksheets[0].Cells["G12"].Value = billeeAddress[0];
                workbook.Worksheets[0].Cells["G13"].Value = billeeAddress[1];
                workbook.Worksheets[0].Cells["G14"].Value = billeeAddress[2];

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
                    totalCost += item.ItemTotalCost;
                    workbook.Worksheets[0].Cells["A" + cell.ToString()].Value = item.ItemDescription;
                    workbook.Worksheets[0].Cells["D" + cell.ToString()].Value = item.DateOfWork.ToString("d");
                    workbook.Worksheets[0].Cells["E" + cell.ToString()].Value = item.ItemPricePerUnit;
                    workbook.Worksheets[0].Cells["F" + cell.ToString()].Value = item.ItemQuant.ToString();
                    workbook.Worksheets[0].Cells["G" + cell.ToString()].Value = item.ItemTotalCost;
                    cell += 1;
                }

                workbook.Worksheets[0].Cells["G29"].Value = totalCost;


                //invoiceNo += 1;
                //InvoiceNo.Text = invoiceNo.ToString();

                using (FileStream output = File.Create(newFilePathTotal))
                    workbook.Save(output, SaveOptions.XlsxDefault);
                SaveAsPdf(newFilePathTotal);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in writing saveFile(): " + ex.Message);
            }

        }

        // Takes the excel file and saves a .pdf version
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

        // load the template to a var
        public ExcelFile loadTemplate()
        {            
            try
            {
                // Sets license to free limited, max 150 rows
                SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
                SpreadsheetInfo.FreeLimitReached += (sender, e) => e.FreeLimitReachedAction = FreeLimitReachedAction.ContinueAsTrial;

                // Opens the template              
                return new ExcelFile();               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
