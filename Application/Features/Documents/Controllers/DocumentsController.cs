using Application.Features.Bills.Filters;
using Application.Features.Bills.Services;
using Application.Features.Documents.Filters;
using Application.Features.Documents.Model;
using Application.Features.Documents.Model.Bills;
using Application.Features.Documents.Model.Products;
using Application.Features.Documents.Services;
using Application.Features.Products.Filters;
using Application.Features.Products.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;


namespace Application.Features.Documents.Controllers
{
    [ApiController]
	[Route("documents")]
	public class DocumentsController(DocxService docxService, BillsService billsService, ExcelService excelService, ProductsService productsService, IMapper mapper, DocumentsService documentsService) : ControllerBase
	{
		private readonly DocxService _docxService = docxService;
		private readonly ExcelService _excelService = excelService;
		private readonly BillsService _billsService = billsService;
		private readonly ProductsService _productsService = productsService;
		private readonly DocumentsService _documentsService = documentsService;
		private readonly IMapper _mapper = mapper;

		private const string _docxMimeType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
		private const string _xlsxMimeType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

		[HttpGet]
		public async Task<ICollection<DocumentModel>> GetDocumentsList([FromQuery]DocumentsFilter? documentsFilter)
		{
			return await _documentsService.GetDocuments(documentsFilter);
		}


		[HttpGet("docx/bills")]
		public async Task<FileResult> GetDocxBill([FromQuery] Guid wayBillId, Guid? userId = null)
		{
			var model = await _billsService.GetBillDocxModel(wayBillId, userId);
			var bytes = await _docxService.FillTemplate<DocxBillModel>(model);

			return File(bytes, _docxMimeType, $"Bill{model.BillNumber}.docx");
		}

		[HttpGet("excel/bills")]
		public async Task<FileResult> GetExcelBill([FromQuery]BillsFilter? filter)
		{
			var models = await _billsService.GetExcelBillModels(filter);

			var bytes = _excelService.Write(models);

			return File(bytes, _xlsxMimeType, $"Bills.xlsx");
		}
		

		[HttpGet("excel/products/received/{receivedProductId}")]
		public async Task<FileResult> GetExcelReceivedProduct([FromQuery] Guid receivedProductId)
		{
			var entity = await _productsService.GetReceived(receivedProductId);
			var model = _mapper.Map<ExcelReceivedProduct>(entity);
			var bytes = _excelService.Write(new List<ExcelReceivedProduct> { model });

			return File(bytes, _xlsxMimeType, $"Bills.xlsx");
		}

		[HttpGet("excel/products/received")]
		public async Task<FileResult> GetExcelReceivedProducts([FromQuery] ProductsFilter? filter)
		{
			var entities = await _productsService.GetReceived(filter);
			var models = _mapper.Map<IEnumerable<ExcelReceivedProduct>>(entities);
			var bytes = _excelService.Write(models);

			return File(bytes, _xlsxMimeType, $"Bills.xlsx");
		}

	}

}
