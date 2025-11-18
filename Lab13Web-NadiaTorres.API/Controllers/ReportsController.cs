using Lab13Web_NadiaTorres.Application.Interfaces;
using Lab13Web_NadiaTorres.Application.UseCases.OrderdetailUseCase.Querys;
using Lab13Web_NadiaTorres.Application.UseCases.ProductUseCase.Querys;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lab13Web_NadiaTorres.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IExcelService _excelService;

    // Inyectamos MediatR y el nuevo servicio de Excel
    public ReportsController(IMediator mediator, IExcelService excelService)
    {
        _mediator = mediator;
        _excelService = excelService;
    }

    [HttpGet("download-order-details")]
    public async Task<IActionResult> DownloadOrderDetailsReport()
    {
        // 1. Obtener los datos usando tu Handler
        var orderDetailsList = await _mediator.Send(new GetAllOrderdetailQuery());

        // 2. Pasar la lista al servicio de Excel
        var fileBytes = _excelService.GenerateOrderDetailsReport(orderDetailsList);

        // 3. Devolver el archivo
        string fileName = $"Reporte_Detalles_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
        
        return File(fileBytes, 
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", 
            fileName);
    }

    [HttpGet("download-product-report")]
    public async Task<IActionResult> DownloadProductReport()
    {
        // 1. Llama al nuevo Handler de Productos
        var productList = await _mediator.Send(new GetAllProductQuery());

        // 2. Llama al nuevo método del servicio de Excel
        var fileBytes = _excelService.GenerateProductsReport(productList);

        // 3. Devuelve el archivo con un nombre diferente
        string fileName = $"Reporte_Productos_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
    
        return File(fileBytes, 
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", 
            fileName);
    }
}