using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MilkBusiness.Utils;
using MilkData;
using MilkData.DTOs;
using MilkData.Enums;
using MilkData.Models;
using MilkData.Repository.Implements;
using MilkData.Repository.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkBusiness;

public class AccountBusiness
{
    private readonly UnitOfWork _unitOfWork;

    public AccountBusiness()
    {
        _unitOfWork ??= new UnitOfWork();
    }

    #region Authentization

    public async Task<IMilkResult> Login(string email, string password)
    {
        Account account = await _unitOfWork.GetRepository<Account>()
            .SingleOrDefaultAsync(predicate: a => a.Email.Equals(email) && a.Password.Equals(password));

        MilkResult result = new MilkResult();

        if (account == null)
        {
            result.Status = -1;
            result.Message = "Incorrect Email or Password";
            return result;
        }

        if (account.Disable)
        {
            result.Status = -1;
            result.Message = "Your account is currently inactive (banned)";
            return result;
        }

        result.Data = JwtUtil.GenerateJwtToken(account);
        result.Status = 1;
        result.Message = "Login successfully";
        return result;
    }

    #endregion

    #region Account
    public async Task<IMilkResult> GetAllAccount()
    {
        var accList = await _unitOfWork.GetRepository<Account>().GetListAsync(predicate: a => !a.Disable);
        return new MilkResult(accList);
    }

    public async Task<IMilkResult> GetAccountInfo(Guid accountId)
    {
        var acc = await _unitOfWork.GetRepository<Account>()
            .SingleOrDefaultAsync(predicate: a => a.AccountId == accountId && !a.Disable);
        if (acc != null) return new MilkResult(acc);
        return new MilkResult();
    }

    public async Task<IMilkResult> GetAccountInfoByEmail(string email)
    {
        var acc = await _unitOfWork.GetRepository<Account>()
            .SingleOrDefaultAsync(predicate: a => a.Email.Equals(email) && !a.Disable);
        if(acc != null) return new MilkResult(acc);
        return new MilkResult();
    }

    public async Task<IMilkResult> CreateAccount(AccountDTO inputedAccount)
    {
        Account account = await _unitOfWork.GetRepository<Account>()
            .SingleOrDefaultAsync(predicate: a => a.Email.Equals(inputedAccount.Email));

        MilkResult result = new();

        if (account != null)
        {
            result.Status = -1;
            result.Message = "Email has already used";
            return result;
        }

        Account newAccount = new()
        {
            AccountId = new Guid(),
            RoleId = (int)RoleEnum.Member,
            FullName = inputedAccount.FullName,
            Email = inputedAccount.Email,
            Password = inputedAccount.Password,
            DateOfBirth = inputedAccount.DateOfBirth,
            Address = inputedAccount.Address,
            Phone = inputedAccount.Phone,
            Point = 0,
            Disable = false,
            CreatedAt = DateTime.Now
        };

        await _unitOfWork.GetRepository<Account>().InsertAsync(newAccount);
        bool isSuccessful = await _unitOfWork.CommitAsync() > 0;

        if (!isSuccessful)
        {
            result.Status = -1;
            result.Message = "Create unsuccessfully";
        }
        else
        { 
            result = new MilkResult(1, "Create Susscessfull");
        }

        return result;
    }

    public async Task<IMilkResult> UpdateAccountInfo(Account accInfo)
    {
        Account currentAcc = await _unitOfWork.GetRepository<Account>()
            .SingleOrDefaultAsync(predicate: a => a.AccountId == accInfo.AccountId);
        if (currentAcc == null) return new MilkResult(-1, "Account cannot be found");
        else
        {
            //currentAcc

            _unitOfWork.GetRepository<Account>().UpdateAsync(accInfo);
            await _unitOfWork.CommitAsync();
        }

        return new MilkResult(accInfo);
    }

    public async Task<IMilkResult> DeleteAccount(Guid id)
    {
        Account currentAcc = await _unitOfWork.GetRepository<Account>()
           .SingleOrDefaultAsync(predicate: a => a.AccountId == id);
        if (currentAcc == null) return new MilkResult(-1, "Account cannot be found");
        else
        {
            _unitOfWork.GetRepository<Account>().DeleteAsync(currentAcc);
            await _unitOfWork.CommitAsync();
        }

        return new MilkResult("Delete Successfull");
    }

    public async Task<IMilkResult> BanAccount(Guid accountId)
    {
        Account account = await _unitOfWork.GetRepository<Account>()
            .SingleOrDefaultAsync(predicate: a => a.AccountId == accountId);
        if (account == null) return new MilkResult();
        else {
            account.Disable = true;

            _unitOfWork.GetRepository<Account>().UpdateAsync(account);
            await _unitOfWork.CommitAsync();
        }
        return new MilkResult(account);
    }

    public async Task<IMilkResult> UnBanAccount(Guid accountId)
    {
        Account account = await _unitOfWork.GetRepository<Account>()
            .SingleOrDefaultAsync(predicate: a => a.AccountId == accountId);
        if (account == null)
            return new MilkResult();
        else
        {
            account.Disable = false;

            _unitOfWork.GetRepository<Account>().UpdateAsync(account);
            await _unitOfWork.CommitAsync();
        }
        return new MilkResult(account);
    }
    #endregion
}
