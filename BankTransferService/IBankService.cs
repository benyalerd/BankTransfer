using BankTransferData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransferService
{
    public interface IBankService
    {
        BaseResponse InsertBankAccount(InsertBankAccRequest request);
        BaseResponse Deposit(DepositRequestModel request);
        BaseResponse Transfer(TransferRequestModel request);
    }
}
