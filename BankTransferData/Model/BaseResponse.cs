using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransferData.Model
{
    public class BaseResponse
    {
        public bool IsSuccess { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
