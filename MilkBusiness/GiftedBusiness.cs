using MilkData.DTOs.Gifted;
using MilkData.Models;
using MilkData.Repository.Implements;

namespace MilkBusiness;

public class GiftedBusiness
{
    private readonly UnitOfWork unitOfWork;

    public GiftedBusiness()
    {
        unitOfWork = new UnitOfWork();
    }

    // ==== Get all ==== //
    public async Task<IMilkResult> GetAll()
    {
        var giftedList = await unitOfWork.GetRepository<Gifted>().GetListAsync(selector: g => new GiftedDTO
        {
            GiftedId = g.GiftedId,
            GiftId = g.GiftId,
            AccountId = g.AccountId,
            Status = g.Status,
            CreatedAt = g.CreatedAt,
        });

        return new MilkResult(giftedList);
    }

    // ==== Get gifted by gifted id ==== //
    public async Task<IMilkResult> GetGiftedInfo(int giftedId)
    {
        var gifted = await unitOfWork.GetRepository<Gifted>()
            .SingleOrDefaultAsync(predicate: p => p.GiftedId == giftedId, selector: s => new GiftedDTO
            {
                GiftedId = s.GiftedId,
                GiftId = s.GiftId,
                AccountId = s.AccountId,
                Status = s.Status,
                CreatedAt = s.CreatedAt,
            });

        return new MilkResult(gifted);
    }

    // ==== Create new gifted ==== //
    public async Task<IMilkResult> CreateGifted(GiftedDTO gifted)
    {
        MilkResult result = new();

        Gifted newgifted = new Gifted()
        {
            GiftedId = gifted.GiftedId,
            GiftId = gifted.GiftId,
            AccountId = gifted.AccountId,
            Status = gifted.Status,
            CreatedAt = DateTime.Now,
        };

        await unitOfWork.GetRepository<Gifted>().InsertAsync(newgifted);

        bool isSuccessful = await unitOfWork.CommitAsync() > 0;

        if (isSuccessful)
        {
            result.Status = 1;
            result.Message = "Create successfully";
        }
        else
        {
            result.Status = -1;
            result.Message = "Create gifted failed";
        }

        return result;
    }

    // ==== Update gifted ==== //
    public async Task<IMilkResult> UpdateGifted(int giftedId, GiftedDTO gifted)
    {
        Gifted currentGifted = await unitOfWork.GetRepository<Gifted>()
            .SingleOrDefaultAsync(predicate: p => p.GiftedId == giftedId);

        if (currentGifted is null)
        {
            return new MilkResult(-1, "Gifted not found");
        }
        else
        {
            currentGifted.GiftId = gifted.GiftId;
            currentGifted.AccountId = gifted.AccountId;
            currentGifted.Status = gifted.Status;

            unitOfWork.GetRepository<Gifted>().UpdateAsync(currentGifted);
            await unitOfWork.CommitAsync();
        }

        return new MilkResult(gifted);
    }

    // ==== Delete gifted ==== //
    public async Task<IMilkResult> DeleteGifted(int giftedId)
    {
        Gifted gifted = await unitOfWork.GetRepository<Gifted>()
            .SingleOrDefaultAsync(predicate: p => p.GiftedId == giftedId);

        if (gifted is null)
        {
            return new MilkResult();
        }
        else
        {
            unitOfWork.GetRepository<Gifted>().DeleteAsync(gifted);
            await unitOfWork.CommitAsync();
        }

        return new MilkResult(1, "Delete successfully");
    }

    // ==== Change gifted Status ==== //
    public async Task<IMilkResult> ChangeGiftedStatus(int giftedId, string status)
    {
        if (!status.ToLower().Equals("Inactive") && !status.ToLower().Equals("Active"))
        {
            return new MilkResult(-4, "Invalid status. Status must be 'inactive' or 'active'");
        }

        Gifted currentGifted = await unitOfWork.GetRepository<Gifted>()
            .SingleOrDefaultAsync(predicate: p => p.GiftedId == giftedId);

        if (currentGifted is null)
        {
            return new MilkResult(-1, "Gifted not found");
        }
        else
        {
            currentGifted.Status = status;

            unitOfWork.GetRepository<Gifted>().UpdateAsync(currentGifted);
            await unitOfWork.CommitAsync();
        }

        return new MilkResult(1, "Status changed successfully");
    }
}
