using System;
using System.Xml.Serialization;

namespace XmlConvert
{
    [XmlRoot("TxData")]
    public class TxData
    {
        private string _TxID;
        private string _Item;
        private string _Amount;
        private string _UnitPrice;

        [XmlElement("TxID")]
        public string TxID { 
            get { return this._TxID; }
            set { this._TxID = Convert.ToInt32(value).ToString(); } 
        }

        [XmlElement("Item")]
        public string Item {
            get { return this._Item; }
            set { this._Item = value.Trim(); }
        }

        [XmlElement("Amount")]
        public string Amount {
            get { return this._Amount; }
            set { this._Amount = Convert.ToInt32(value).ToString(); }
        }

        [XmlElement("UnitPrice")]
        public string UnitPrice {
            get { return this._UnitPrice; }
            set { this._UnitPrice = Convert.ToInt32(value).ToString(); }
        }

        private string[] PropertyName = {"TxID","Item","Amount","UnitPrice"};

        [System.Runtime.CompilerServices.IndexerName("Blah")]
        public string this[int index]
        {
            get
            {
                switch (this.PropertyName[index])
                {
                    case "TxID":
                        return this.TxID;
                    case "Item":
                        return this.Item;
                    case "Amount":
                        return this.Amount;
                    case "UnitPrice":
                        return this.UnitPrice;
                    default:
                        return null;
                }
            }
            set
            {
                switch (this.PropertyName[index])
                {
                    case "TxID":
                        this.TxID = value;
                        break;
                    case "Item":
                        this.Item = value;
                        break;
                    case "Amount":
                        this.Amount = value;
                        break;
                    case "UnitPrice":
                        this.UnitPrice = value;
                        break;
                    default:
                        break;
                }
            }
        }

        public string GetPropertyName(int index)
        {
            return this.PropertyName[index]; ;
        }

        public int PropertyLength
        {
            get
            {
                return this.PropertyName.Length;
            }
        }
    }
}
