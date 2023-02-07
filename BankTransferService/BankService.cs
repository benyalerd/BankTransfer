using BankTransferData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransferService
{
    public class BankService : IBankService
    {
        private readonly IBankData _bankData;
        public BankService(IBankData bankData)
        {
            _bankData = bankData;
        }
    }
}
