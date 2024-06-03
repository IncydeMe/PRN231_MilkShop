﻿using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkBusiness;
using MilkData;
using MilkData.DTOs;
using MilkData.Models;
using MilkWebAPI.Constants;
using Swashbuckle.AspNetCore.Annotations;

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
        [SwaggerOperation(Summary = "Get all Accounts")]
        public async Task<IActionResult> GetAllAccounts()
        {
            var response = await _accountBusiness.GetAllAccount();
            if (response.Status >= 0)
                return Ok(response.Data);
            else
                return BadRequest(response.Message);
        }

        [HttpGet(ApiEndPointConstant.Account.AccountEndpoint)]
        [SwaggerOperation(Summary = "Get Account by its id")]
        public async Task<IActionResult> GetAccountInfo(int id)
        {
            var response = await _accountBusiness.GetAccountInfo(id);
            if (response.Status >= 0)
                return Ok(response.Data);
            else
                return BadRequest(response);
        }

        [HttpPost(ApiEndPointConstant.Account.AccountsEndpoint)]
        [SwaggerOperation(Summary = "Create a new Account")]
        public async Task<IActionResult> CreateAccount(AccountDTO accountDTO)
        {
            var response = await _accountBusiness.CreateAccount(accountDTO);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpPut(ApiEndPointConstant.Account.AccountEndpoint)]
        [SwaggerOperation(Summary = "Update Account Info")] 
        public async Task<IActionResult> UpdateAccountInfo(int id, Account account)
        {
            var response = await _accountBusiness.UpdateAccountInfo(account);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpDelete(ApiEndPointConstant.Account.AccountEndpoint)]
        [SwaggerOperation(Summary = "Delete Account")]
        public async Task<IActionResult> BanAccount(int id)
        {
            var response = await _accountBusiness.BanAccount(id);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }
    }
}
