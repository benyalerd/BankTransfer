﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransferData.Model
{
    public class TransferRequestModel
    {
        public string AccountNumber { get; set; }
        public decimal Amount { get; set; }
        public string TerminalAccountNumber { get; set; }
    }
}
