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
    }
}
