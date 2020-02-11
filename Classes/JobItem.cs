using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceGenerator
{
    public class JobItem
    {


        private string _itemDescription;
        public string ItemDescription
        {
            get { return _itemDescription; }
            set { _itemDescription = value; }
        }

        private DateTime _dateOfWork;
        public DateTime DateOfWork
        {
            get { return _dateOfWork; }
            set { _dateOfWork = value; }
        }

        private float _itemPricePerUnit;
        public float ItemPricePerUnit
        {
            get { return _itemPricePerUnit; }
            set { _itemPricePerUnit = value; }
        }

        private float _itemQuant;
        public float ItemQuant
        {
            get { return _itemQuant; }
            set { _itemQuant = value; }
        }

        private float _itemTotalCost;
        public float ItemTotalCost
        {
            get { return _itemTotalCost; }
            set { _itemTotalCost = value; }
        }

        private string _details;
        public string Details
        {
            get { return _details; }
            set { _details = value; }
        }


        public JobItem(string itemDescription, DateTime dateOfWork, float itemPricePerUnit, float itemQuant, float itemTotalCost)
        {
            this._itemDescription = itemDescription;
            this._dateOfWork = dateOfWork;
            this._itemPricePerUnit = itemPricePerUnit;
            this._itemQuant = itemQuant;
            this._itemTotalCost = itemTotalCost;
            this._details = setDetails();
        }

        private string setDetails()
        {
            string temp = this.ItemDescription;
            int tempInt = 32 - (temp.Length);
            for (; tempInt > 0; tempInt--)
            {
                temp = temp + " ";
            }

            temp = (temp + "\t" + this.DateOfWork.ToString("d") + "\t" + this.ItemPricePerUnit.ToString() + "\t\t" + this.ItemQuant.ToString() + "\t" + this.ItemTotalCost.ToString());

            return temp;
        }
}
}
