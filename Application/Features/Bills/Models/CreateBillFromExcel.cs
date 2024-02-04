using Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Bills.Models;

public class CreateBillFromExcel
{
    public string? Address { get; set; }
    public DateTime? RealizeDate { get; set; }
    public string? Note { get; set; }
    public required Guid WarehouseId { get; set; }
    
    public required IFormFile File { get; set; }
    
    public required BillType Type { get; set; }
}