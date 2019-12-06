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
            txtFullName.Text = InvoiceGenerator.name;
            txtABN.Text = InvoiceGenerator.ABN;
            txtEmail.Text = InvoiceGenerator.email;
            txtContactNumber.Text = InvoiceGenerator.contactNo;
            txtAddress01.Text = InvoiceGenerator.addressArr[0];
            txtAddress02.Text = InvoiceGenerator.addressArr[1];
            txtAddress03.Text = InvoiceGenerator.addressArr[2];
            txtBankBSB.Text = InvoiceGenerator.bankBSB;
            txtBankNo.Text = InvoiceGenerator.bankAccNo;
                        
            txtTemplatePath.Text = InvoiceGenerator.templatePath;
            txtSavePath.Text = InvoiceGenerator.newFilePath;
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
            InvoiceGenerator.name = txtFullName.Text;
            InvoiceGenerator.ABN = txtABN.Text;
            InvoiceGenerator.email = txtEmail.Text;
            InvoiceGenerator.contactNo = txtContactNumber.Text;
            InvoiceGenerator.addressArr[0] = txtAddress01.Text;
            InvoiceGenerator.addressArr[1] = txtAddress02.Text;
            InvoiceGenerator.addressArr[2] = txtAddress03.Text;
            InvoiceGenerator.bankBSB = txtBankBSB.Text;
            InvoiceGenerator.bankAccNo = txtBankNo.Text;                     
            InvoiceGenerator.templatePath = txtTemplatePath.Text;
            InvoiceGenerator.newFilePath = txtSavePath.Text;

            MessageBox.Show("Save Successful");
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
