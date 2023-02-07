using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransferData
{
    public class BankData : BaseData,IBankData
    {
        #region Constructor
        public BankData(string connetionString) : base(connetionString)
        {
        }
        #endregion

        public void CloseConnection()
        {
            cnn.Close();
        }
    }
}
