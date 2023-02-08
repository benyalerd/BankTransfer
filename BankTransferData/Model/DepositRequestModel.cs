using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransferData.Model
{
    public class DepositRequestModel
    {
        public string BankAccountNumber { get; set; }
        public decimal Amount { get; set; }
    }
}
