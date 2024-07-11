using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkBusiness;
using MilkData.DTOs.Account;
using MilkData.Models;
using MilkWebAPI.Constants;
using Swashbuckle.AspNetCore.Annotations;

namespace MilkWebAPI.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountBusiness _accountBusiness;
        private readonly OrderBusiness _orderBusiness;

        public AccountController()
        {
            _accountBusiness = new AccountBusiness();
            _orderBusiness = new OrderBusiness();
        }

        [Authorize(Roles = "admin")]
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

        [Authorize]
        [HttpGet(ApiEndPointConstant.Account.AccountEndpoint)]
        [SwaggerOperation(Summary = "Get Account by its id")]
        public async Task<IActionResult> GetAccountInfo(Guid id)
        {
            var response = await _accountBusiness.GetAccountInfo(id);
            if (response.Status >= 0)
                return Ok(response.Data);
            else
                return BadRequest(response);
        }

        [Authorize(Roles = "admin")]
        [HttpGet(ApiEndPointConstant.Account.EmailAccountsEndpoint)]
        [SwaggerOperation(Summary = "Get Account by its email")]
        public async Task<IActionResult> GetAccountByEmail(string email)
        {
            var response = await _accountBusiness.GetAccountInfoByEmail(email);
            if (response.Status >= 0)
                return Ok(response.Data);
            else
                return BadRequest(response);
        }

        [Authorize(Roles = "admin")]
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

        [Authorize]
        [HttpPut(ApiEndPointConstant.Account.AccountEndpoint)]
        [SwaggerOperation(Summary = "Update Account Info")]
        public async Task<IActionResult> UpdateAccountInfo(int id, AccountDTO account)
        {
            var response = await _accountBusiness.UpdateAccountInfo(account);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete(ApiEndPointConstant.Account.AccountEndpoint)]
        [SwaggerOperation(Summary = "Delete Account")]
        public async Task<IActionResult> BanAccount(Guid id)
        {
            var response = await _accountBusiness.BanAccount(id);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [Authorize]
        [HttpGet(ApiEndPointConstant.Account.OrderHistoryEndpoint)]
        [SwaggerOperation(Summary = "Get Order History")]
        public async Task<IActionResult> GetOrderHistory(int id)
        {
            var response = await _orderBusiness.GetOrdersByAccount(id);
            if (response.Status >= 0)
                return Ok(response.Data);
            else
                return BadRequest(response);
        }
    }
}
