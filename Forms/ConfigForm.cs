using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvoiceGenerator
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DialogResult path = openFileDialog1.ShowDialog();
            if(path == DialogResult.OK)
            {
                txtTemplatePath.Text = openFileDialog1.FileName;
            }
            else
            {
                MessageBox.Show("File Error");
            }
            
        }

        private void BtnSelectOutput_Click(object sender, EventArgs e)
        {
            DialogResult path = folderBrowserDialog1.ShowDialog();
            if (path == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog1.SelectedPath))
            {
                txtSavePath.Text = folderBrowserDialog1.SelectedPath;
            }
            else
            {
                MessageBox.Show("File Error");
            }
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            txtFullName.Text = InvoiceGenerator.settings.Name;
            txtABN.Text = InvoiceGenerator.settings.ABN;
            txtEmail.Text = InvoiceGenerator.settings.Email;
            txtContactNumber.Text = InvoiceGenerator.settings.ContactNo;
            txtAddress01.Text = InvoiceGenerator.settings.Address01;
            txtAddress02.Text = InvoiceGenerator.settings.Address02;
            txtAddress03.Text = InvoiceGenerator.settings.Address03;
            txtBankBSB.Text = InvoiceGenerator.settings.BankBSB;
            txtBankNo.Text = InvoiceGenerator.settings.BankAccNo;
                        
            txtTemplatePath.Text = InvoiceGenerator.settings.TemplatePath;
            txtSavePath.Text = InvoiceGenerator.settings.NewFilePath;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (checkValid())
            {
                saveDetails();                
            }
        }

        private bool checkValid()
        {
            List<String> errorList = new List<String>();
            if (string.IsNullOrEmpty(txtFullName.Text)) //If name empty
            {
                errorList.Add("Name Cannot be Empty.");
            }
            if (txtTemplatePath.Text.Trim() == "") // If Template empty
            {
                errorList.Add("Template Path Cannot be Empty.");
            }
            if (txtSavePath.Text.Trim() == "") // If Save path empty
            {
                errorList.Add("Save Path Cannot be Empty.");
            }                       
            if (errorList.Count == 0)
            {
                return true;
            }
            else
            {
                string errorString = "";
                foreach (string err in errorList)
                {
                    errorString = errorString + err + "\n";
                }
                MessageBox.Show(errorString);
                return false;
            }
        }

        private void saveDetails()
        {

            try
            {
                InvoiceGenerator.settings.Name = txtFullName.Text;
                InvoiceGenerator.settings.ABN = txtABN.Text;
                InvoiceGenerator.settings.Email = txtEmail.Text;
                InvoiceGenerator.settings.ContactNo = txtContactNumber.Text;
                InvoiceGenerator.settings.Address01 = txtAddress01.Text;
                InvoiceGenerator.settings.Address02 = txtAddress02.Text;
                InvoiceGenerator.settings.Address03 = txtAddress03.Text;
                InvoiceGenerator.settings.BankBSB = txtBankBSB.Text;
                InvoiceGenerator.settings.BankAccNo = txtBankNo.Text;
                InvoiceGenerator.settings.TemplatePath = txtTemplatePath.Text;
                InvoiceGenerator.settings.NewFilePath = txtSavePath.Text;

                XmlManager.xmlDataWriter(InvoiceGenerator.settings, "settings.xml");
                MessageBox.Show("Save Successful");
            }
            catch(Exception ea)
            {
                MessageBox.Show("Error " + ea.ToString());
            }

            
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
