using Microsoft.EntityFrameworkCore;
using MilkBusiness.Utils;
using MilkData;
using MilkData.Models;
using MilkData.Repository.Implements;
using MilkData.Repository.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkBusiness
{
    public class AccountBusiness
    {
        private readonly IUnitOfWork<Net17112314MilkContext> _unitOfWork;

        public AccountBusiness()
        {
            _unitOfWork ??= new UnitOfWork<Net17112314MilkContext>(new Net17112314MilkContext());
        }

        #region Authentization
        //public async Task<IMilkResult> Login(string email, string password)
        //{
        //    Account account = await _DAO.CheckAuthenInput(email, password);

        //    MilkResult result = new MilkResult();

        //    if (account == null)
        //    {
        //        result.Status = -1;
        //        result.Message = "Incorrect Email or Password";
        //        return result;
        //    }

        //    if (!account.IsActive)
        //    {
        //        result.Status = -1;
        //        result.Message = "Your account is currently inactive (banned)";
        //        return result;
        //    }

        //    result.Data = JwtUtil.GenerateJwtToken(account);
        //    result.Status = 1;
        //    result.Message = "Login successfully";
        //    return result;
        //}

        //public async Task<IMilkResult> Register(string email, string password)
        //{
        //    Account account = await _DAO.CheckAuthenInput(email, password);

        //    MilkResult result = new MilkResult();

        //    if (account != null)
        //    {
        //        result.Status = -1;
        //        result.Message = "Email has already used";
        //        return result;
        //    }

        //    Account newAccount = new Account
        //    {
        //        AccountId = 0,
        //        FullName = email,
        //        Password = password,
        //        Email = email,
        //        Phone = string.Empty,
        //        Address = string.Empty,
        //        Role = "Member",
        //        IsActive = true
        //    };

        //    var createResult = await _DAO.CreateAsync(newAccount);

        //    if (createResult == 0)
        //    {
        //        result.Status = -1;
        //        result.Message = "Create unsuccessfully";
        //    }
        //    else
        //    {
        //        result.Data = JwtUtil.GenerateJwtToken(newAccount);
        //        result.Status = 1;
        //        result.Message = "Register successfully";
        //    }

        //    return result;
        //}
        #endregion

        #region Account
        public async Task<IMilkResult> GetAllAccount()
        {
            var accList = await _unitOfWork.GetRepository<Account>().GetListAsync();
            return new MilkResult(accList);
        }

        //public async Task<IMilkResult> GetAccountInfo(int accountId)
        //{
        //    var acc = await _DAO.GetByIdAsync(accountId);
        //    return new MilkResult(acc);
        //}

        //public async Task<IMilkResult> UpdateAccountInfo(Account accInfo)
        //{
        //    Account currentAcc = await _DAO.GetByIdAsync(accInfo.AccountId);
        //    if (currentAcc == null) return new MilkResult(-1, "Account cannot be found");
        //    else
        //    {
        //        _DAO.UpdateAsync(accInfo);
        //    }

        //    return new MilkResult(accInfo);
        //}

        //public async Task<IMilkResult> BanAccount(int accountId)
        //{
        //    Account account = await _DAO.GetByIdAsync(accountId);
        //    if (account == null) return new MilkResult();
        //    else
        //    {
        //        _DAO.UpdateStatusAsync(account);
        //    }
        //    return new MilkResult(account);
        //}
        #endregion
    }
}
