using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceGenerator
{
    public class Settings
    {
        // Personal Details
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _abn;
        public string ABN
         {
            get { return _abn; }
            set { _abn = value; }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _contactNo;
        public string ContactNo
        {
            get { return _contactNo; }
            set { _contactNo = value; }
        }

        // Address
        private string _address01;
        public string Address01
        {
            get { return _address01; }
            set { _address01 = value; }
        }
        private string _address02;
        public string Address02
        {
            get { return _address02; }
            set { _address02 = value; }
        }
        private string _address03;
        public string Address03
        {
            get { return _address03; }
            set { _address03 = value; }
        }

        // Bank

        private string _bankBSB;
        public string BankBSB
        {
            get { return _bankBSB; }
            set { _bankBSB = value; }
        }

      
        private string _bankAccNo;
        public string BankAccNo
        {
            get { return _bankAccNo; }
            set { _bankAccNo = value; }
        }

        // File settings
        private string _templatePath;
        public string TemplatePath
        {
            get { return _templatePath; }
            set { _templatePath = value; }
        }


        private string _newFilePath;
        public string NewFilePath
        {
            get { return _newFilePath; }
            set { _newFilePath = value; }
        }
    }
}
