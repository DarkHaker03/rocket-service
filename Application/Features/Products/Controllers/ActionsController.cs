using Application.Features.Auth;
using Application.Features.Products.Filters;
using Application.Features.Products.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Controllers
{
	[ApiController]
	[Route("products/received/actions")]
	public class ActionsController(ProductActionsService productActionsService)
	{
		private readonly ProductActionsService _productActionsService;


		[HttpGet]
		public async Task<IEnumerable<UwProductCellAction>> GetActions([FromQuery] ProductActionsFilter filter)
		{
			return await _productActionsService.GetActions(filter);
		}

		[HttpPost("action")]
		[UwAuthorize(UwUserClaimTypes.EmployeeId)]
		public async Task AddReceivedProductAction(Guid receivedProductId, Guid actionTypeId)
		{
			await _productActionsService.AddAction(receivedProductId, actionTypeId);
		}

	}
}
