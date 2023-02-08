using BankTransferDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransferData.Model
{
    public class BankAccount
    {
        [DataNames("CUST_ID")]
        public int CustId { get; set; }
        [DataNames("ACCOUNT_NUMBER")]
        public string AccountNumber { get; set; }
        [DataNames("BALANCE")]
        public decimal Balance { get; set; }
    }
}
