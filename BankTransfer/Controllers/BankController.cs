using BankTransferData.Model;
using BankTransferService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankTransfer.Controllers
{
    [Route("api/[controller]")]
    public class BankController : ControllerBase
    {
        private readonly IBankService _bankService;
        public BankController(IBankService bankService)
        {
            _bankService = bankService;
        }


        [HttpPost]
        [Route("InsertBankAccount")]
        public IActionResult InsertBankAccount([FromBody] InsertBankAccRequest request)
        {

            BaseResponse baseResponse = new BaseResponse();
            try
            {
                baseResponse = _bankService.InsertBankAccount(request);
            }
            catch (Exception ex)
            {
                baseResponse.ErrorMessage = ex.Message;
                baseResponse.ErrorCode = "005";
                baseResponse.IsSuccess = false;
            }
            return Ok(baseResponse);
        }

        [HttpPost]
        [Route("Deposit")]
        public IActionResult Deposit([FromBody] DepositRequestModel request)
        {

            BaseResponse baseResponse = new BaseResponse();
            try
            {
                baseResponse = _bankService.Deposit(request);
            }
            catch (Exception ex)
            {
                baseResponse.ErrorMessage = ex.Message;
                baseResponse.ErrorCode = "005";
                baseResponse.IsSuccess = false;
            }
            return Ok(baseResponse);
        }


    }
}
