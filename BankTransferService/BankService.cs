﻿using BankTransferData;
using BankTransferData.Model;
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

        public BaseResponse InsertBankAccount(InsertBankAccRequest request)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                if (request == null || request.CustId == 0 || string.IsNullOrEmpty(request.BankAccountNumber))
                {
                    response.ErrorCode = "001";
                    response.ErrorMessage = "request is invalid";
                    return response;
                }

                Customer customer = _bankData.GetCustomerById(request.CustId);
                if (customer == null || customer.Id == 0)
                {
                    response.ErrorCode = "002";
                    response.ErrorMessage = "customer id not found";
                    return response;
                }
                BankAccount bankAccount = _bankData.GetBankAccount(request.BankAccountNumber);
                if (bankAccount != null && !string.IsNullOrEmpty(bankAccount.AccountNumber))
                {
                    response.ErrorCode = "004";
                    response.ErrorMessage = "bank account is duplicate";
                    return response;
                }
                bool IsInsertSuccess = _bankData.InsertBankAccount(request);
                if (!IsInsertSuccess)
                {
                    response.ErrorCode = "003";
                    response.ErrorMessage = "Insert is failed";
                    return response;
                }
                response.IsSuccess = true;
                response.ErrorCode = "000";
                response.ErrorMessage = "Success";
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _bankData.CloseConnection();
            }
        }

        public BaseResponse Deposit(DepositRequestModel request)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                if (request == null || request.Amount == 0 || string.IsNullOrEmpty(request.BankAccountNumber))
                {
                    response.ErrorCode = "001";
                    response.ErrorMessage = "request is invalid";
                    return response;
                }

               
                BankAccount bankAccount = _bankData.GetBankAccount(request.BankAccountNumber);
                if (bankAccount == null || string.IsNullOrEmpty(bankAccount.AccountNumber))
                {
                    response.ErrorCode = "002";
                    response.ErrorMessage = "bank account not found";
                    return response;
                }
                decimal amount = (Convert.ToDecimal(0.999)*request.Amount);
                bool IsSuccess = _bankData.UpdateBalance(amount,request.BankAccountNumber);
                if (!IsSuccess)
                {
                    response.ErrorCode = "003";
                    response.ErrorMessage = "update is failed";
                    return response;
                }
                response.IsSuccess = true;
                response.ErrorCode = "000";
                response.ErrorMessage = "Success";
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _bankData.CloseConnection();
            }
        }
    }
}
