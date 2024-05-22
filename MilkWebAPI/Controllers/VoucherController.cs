using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkBusiness;
using MilkData;
using MilkData.Models;
using MilkWebAPI.Constants;

namespace MilkWebAPI.Controllers
{
	[ApiController]
	public class VoucherController : ControllerBase
	{
		private readonly VoucherBusiness _voucherBusiness;
		public VoucherController()
		{
			_voucherBusiness = new VoucherBusiness();
		}

		[HttpGet(ApiEndPointConstant.Voucher.VouchersEndpoint)]
		public async Task<IActionResult> GetVoucherList()
		{
			var response = await _voucherBusiness.GetVoucherList();
			if (response.Status >= 0)
				return Ok(response);
			else
				return BadRequest(response);
		}

		[HttpGet(ApiEndPointConstant.Voucher.VoucherEndpoint)]
		public async Task<IActionResult> GetVoucherById(int voucherId)
		{
			var response = await _voucherBusiness.GetVoucherById(voucherId);
			if (response.Status >= 0)
				return Ok(response);
			else
				return BadRequest(response);
		}

		[HttpPost(ApiEndPointConstant.Voucher.VouchersEndpoint)]
		public async Task<IActionResult> CreateVoucher(Voucher voucher)
		{
			var response = await _voucherBusiness.CreateVoucher(voucher);
			if (response.Status >= 0)
				return Ok(response);
			else
				return BadRequest(response);
		}

		[HttpPut(ApiEndPointConstant.Voucher.VoucherEndpoint)]
		public async Task<IActionResult> UpdateVoucher(Voucher voucher)
		{
			var response = await _voucherBusiness.UpdateVoucher(voucher);
			if (response.Status >= 0)
				return Ok(response);
			else
				return BadRequest(response);
		}

		[HttpDelete(ApiEndPointConstant.Voucher.VoucherEndpoint)]
		public async Task<IActionResult> DeleteVoucher(int id)
		{
			var response = await _voucherBusiness.DeleteVoucher(id);
			if (response.Status >= 0)
				return Ok(response);
			else
				return BadRequest(response);
		}	
	}
}
