using Application.Features.Auth;
using Application.Features.Bills.Filters;
using Application.Features.Bills.Models;
using Application.Features.Bills.Services;
using Application.Features.Documents.Model;
using Application.Features.Documents.Model.Bills;
using Application.Features.Documents.Services;
using Application.Features.Files.Options;
using Application.Features.Files.Services;
using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Application.Features.Bills.Controllers;

[ApiController]
[Route("bills")]
public class BillsController(BillsService billsService, FilesService filesService, ExcelService excelService, IOptions<FilesOptions> filesOptions) : ControllerBase
{
	private readonly BillsService _billsService = billsService;
	private readonly FilesService _filesService = filesService;
	private readonly ExcelService _excelService = excelService;
	private readonly FilesOptions _filesOptions = filesOptions.Value;

	[HttpGet]
	public async Task<ICollection<UwBill>> GetBills([FromQuery] BillsFilter filter)
	{
		return await _billsService.GetBills(filter);
	}
	

	[HttpPost("bill")]
	public async Task<UwBill> CreateBill([FromBody] CreateBillModel bill)
	{
		return await _billsService.CreateBill(bill);
	}
	

	[HttpPost("file/excel")]
	public async Task<UwBill> CreateBills([FromForm]CreateBillFromExcel data)
	{
		var fileName = await _filesService.Write(data.File);
		var pathToFile = _filesOptions.StoragePath + fileName;
		var rows = _excelService.Read<ExcelBillModel>(pathToFile);
		_filesService.RemoveFile(pathToFile);

		return await _billsService.AddFromExcel(rows,data);
	}
	


	[HttpPost("admin/file/excel")]
	[UwAuthorize(UwUserClaimTypes.EmployeeId)]
	public async Task<UwBill> AdminCreateWayBills([FromForm]IFormFile file, CreateBillFromExcel data, Guid userId)
	{
		var pathToFile = await _filesService.Write(file);
		var bills = _excelService.Read<ExcelBillModel>(pathToFile);
		_filesService.RemoveFile(pathToFile);

		return await _billsService.AddFromExcel(bills, data, userId);
	}


	[HttpDelete]
	[UwAuthorize(UwUserClaimTypes.EmployeeId)]
	public async Task DeleteBill(Guid id)
	{
		await _billsService.DeleteBill(id);
	}
	
	

	[HttpPut("status")]
	[UwAuthorize(UwUserClaimTypes.EmployeeId)]
	public async Task ChangeBillStatus(Guid billId, BillStatus status)
	{
		await _billsService.ChangeBillStatus(billId, status);
	}
	
}
