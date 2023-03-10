using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BankTransferData
{

    public class BaseData
    {
        protected SqlConnection cnn;
        protected SqlTransaction transaction;
        
        public BaseData(string connetionString)
        {           
            cnn = new SqlConnection(connetionString);
            cnn.Open();
        }
 
        protected DataSet ExecuteDataSet(string spName, params (string name, object value)[] parameterValues)
        {
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            SqlCommand objCmd = new SqlCommand();
            DataSet ds = new DataSet();
            foreach (var param in parameterValues)
            {
                objCmd.Parameters.AddWithValue(param.name, param.value);
            }
            objCmd.Connection = cnn;
            objCmd.CommandText = spName;
            objCmd.CommandType = CommandType.StoredProcedure;

            dtAdapter.SelectCommand = objCmd;
            dtAdapter.Fill(ds);

            return ds;
        }

        protected void ExecuteNonQuery(string spName, params (string name, object value)[] parameterValues)
        {
            SqlCommand objCmd = new SqlCommand();
            foreach (var param in parameterValues)
            {
                objCmd.Parameters.AddWithValue(param.name, param.value);
            }

            objCmd.Connection = cnn;
            objCmd.Transaction = transaction;
            objCmd.CommandText = spName;
            objCmd.CommandType = CommandType.StoredProcedure;

            objCmd.ExecuteNonQuery();

            

        }

        #region ConvertDTA
        protected object ConvertDTA(bool? inputValue)
        {
            return inputValue == null ? Convert.DBNull : inputValue.Value;
        }
        protected object ConvertDTA(int inputValue)
        {
            return inputValue == default(int) ? default(int) : inputValue;
        }
        protected object ConvertDTA(int? inputValue)
        {
            return inputValue == null ? Convert.DBNull : inputValue.Value;
        }
        protected object ConvertDTA(long inputValue)
        {
            return inputValue == default(long) ? Convert.DBNull : inputValue;
        }
        protected object ConvertDTA(long? inputValue)
        {
            return inputValue == null ? Convert.DBNull : inputValue.Value;
        }
        protected object ConvertDTA(string inputValue)
        {
            return string.IsNullOrEmpty(inputValue) ? Convert.DBNull : inputValue;
        }
        protected object ConvertDTA(DateTime inputValue)
        {
            return inputValue == default(DateTime) ? Convert.DBNull : inputValue;
        }
        protected object ConvertDTA(DateTime? inputValue)
        {
            return inputValue == null ? Convert.DBNull : inputValue.Value;
        }
        protected object ConvertDTA(decimal inputValue)
        {
            return inputValue == default(decimal) ? default(decimal) : inputValue;
        }
        protected object ConvertDTA(decimal? inputValue)
        {
            return inputValue == null ? default(decimal) : inputValue.Value;
        }
        protected object ConvertDTA(Enum inputValue)
        {
            return inputValue == null ? Convert.DBNull : inputValue;
        }
        protected object ConvertDTA<T>(T inputValue)
            where T : struct, Enum
        {
            //return EqualityComparer<T>.Default.Equals(inputValue, default) ? Convert.DBNull : inputValue;
            return inputValue.Equals(null) ? Convert.DBNull : inputValue;
        }

        protected object ConvertDTA(byte[] inputValue)
        {
            return inputValue == null ? Convert.DBNull : inputValue;
        }
        #endregion
    }
}
