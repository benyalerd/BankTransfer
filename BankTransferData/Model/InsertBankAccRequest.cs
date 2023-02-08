using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransferData.Model
{
    public class InsertBankAccRequest
    {
        public string BankAccountNumber { get; set; }
        public int CustId { get; set; }
    }
}
