using Lab13Web_NadiaTorres.Infrastructure.Models;

namespace Lab13Web_NadiaTorres.Application.Interfaces;

public interface IExcelService
{
    byte[] GenerateOrderDetailsReport(List<Orderdetail> orderDetails);
}