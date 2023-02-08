using BankTransferData.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransferData
{
    public interface IBankData
    {
        Customer GetCustomerById(int id);
        bool InsertBankAccount(InsertBankAccRequest request);
        BankAccount GetBankAccount(string accountNumber);
        bool UpdateBalance(decimal amount, string accountNumber);
        bool InsertTransaction(string account, decimal amount, string transType, string terminalAcc);
        void CloseConnection();


    }
}
