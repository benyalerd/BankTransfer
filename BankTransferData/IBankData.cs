using BankTransferData.Model;
using System;
using System.Collections.Generic;
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
        void CloseConnection();
        void BeginTransaction();
      
    }
}
