﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkBusiness;
using MilkData;
using MilkData.Models;
using MilkWebAPI.Constants;

namespace MilkWebAPI.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountBusiness _accountBusiness;
        public AccountController()
        {
            _accountBusiness = new AccountBusiness();
        }

        [HttpGet(ApiEndPointConstant.Account.AccountsEndpoint)]
        public async Task<IActionResult> GetAllAccounts()
        {
            var response = await _accountBusiness.GetAllAccount();
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }

        //[HttpGet(ApiEndPointConstant.Account.AccountEndpoint)]
        //public async Task<IActionResult> GetAccountInfo(int accountId)
        //{
        //    var response = await _accountBusiness.GetAccountInfo(accountId);
        //    if (response.Status >= 0)
        //        return Ok(response);
        //    else
        //        return BadRequest(response);
        //}

        //[HttpPut(ApiEndPointConstant.Account.AccountEndpoint)]
        //public async Task<IActionResult> UpdateAccountInfo(Account account)
        //{
        //    var response = await _accountBusiness.UpdateAccountInfo(account);
        //    if (response.Status >= 0)
        //        return Ok(response);
        //    else
        //        return BadRequest(response);
        //}

        //[HttpDelete(ApiEndPointConstant.Account.AccountsEndpoint)]
        //public async Task<IActionResult> BanAccount(int accountId)
        //{
        //    var response = await _accountBusiness.BanAccount(accountId);
        //    if (response.Status >= 0)
        //        return Ok(response);
        //    else
        //        return BadRequest(response);
        //}
    }
}
