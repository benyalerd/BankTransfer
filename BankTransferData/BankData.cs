using BankTransferData.Model;
using BankTransferDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransferData
{
    public class BankData : BaseData,IBankData
    {
        private const string INSERT_BANK_ACCOUNT = "[INSERT_BANK_ACCOUNT]";
        private const string INSERT_TRANSACTION = "[INSERT_TRANSACTION]";
        private const string UPDATE_BALANCE_BY_ACCNO = "[UPDATE_BALANCE_BY_ACCNO]";
        private const string GET_ACCOUNT_ACCTNO = "[GET_ACCOUNT_ACCTNO]";
        private const string GET_CUSTOMER_BY_ID = "[GET_CUSTOMER_BY_ID]";
        #region Constructor
        public BankData(string connetionString) : base(connetionString)
        {
        }
        #endregion

        public void CloseConnection()
        {
            cnn.Close();
        }

       
        public BankAccount GetBankAccount(string accountNumber)
        {
            BankAccount account = new BankAccount();
            DataNamesMapper<BankAccount> mapper = new DataNamesMapper<BankAccount>();
            try
            {
                DataSet dsResults = ExecuteDataSet(GET_ACCOUNT_ACCTNO,
                    ("accountNo", ConvertDTA(accountNumber)));
                if ((dsResults != null) && (dsResults.Tables[0].Rows.Count > 0))
                {
                    if (dsResults.Tables[0].Rows[0][0] != System.DBNull.Value)
                    {
                        account = mapper.Map(dsResults.Tables[0].Rows[0]);
                    }
                }
                return account;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public Customer GetCustomerById(int id)
        {
            Customer customer = new Customer();
            DataNamesMapper<Customer> mapper = new DataNamesMapper<Customer>();
            try
            {
                DataSet dsResults = ExecuteDataSet(GET_CUSTOMER_BY_ID,
                    ("customerID", ConvertDTA(id)));
                if ((dsResults != null) && (dsResults.Tables[0].Rows.Count > 0))
                {
                    if (dsResults.Tables[0].Rows[0][0] != System.DBNull.Value)
                    {
                        customer = mapper.Map(dsResults.Tables[0].Rows[0]);
                    }
                }
                return customer;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public bool InsertBankAccount(InsertBankAccRequest request)
        {
            try
            {
                DataSet dsResults = ExecuteDataSet(INSERT_BANK_ACCOUNT,
                    ("custId", ConvertDTA(request.CustId)),
                    ("accountNumber", ConvertDTA(request.BankAccountNumber)));
               
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        public bool InsertTransaction(string account,decimal amount,string transType,string terminalAcc)
        {
            try
            {
                DataSet dsResults = ExecuteDataSet(INSERT_TRANSACTION,
                    ("accountNo", ConvertDTA(account)),
                    ("amount", ConvertDTA(amount)),
                     ("tranType", ConvertDTA(transType)),
                     ("terminalAccNumber", ConvertDTA(terminalAcc)));

                return true;
            }
            catch (SqlException)
            {
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public bool UpdateBalance(decimal amount,string accountNumber)
        {
            try
            {
                DataSet dsResults = ExecuteDataSet(UPDATE_BALANCE_BY_ACCNO,
                    ("balance", ConvertDTA(amount)),
                    ("accountNo", ConvertDTA(accountNumber)));

                return true;
            }
            catch (SqlException)
            {
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
