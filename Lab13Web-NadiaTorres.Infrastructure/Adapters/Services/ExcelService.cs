using Lab13Web_NadiaTorres.Application.Interfaces; // Para IExcelService
using ClosedXML.Excel;
using Lab13Web_NadiaTorres.Infrastructure.Models;

namespace Lab13Web_NadiaTorres.Infrastructure.Adapters.Services;

public class ExcelService : IExcelService
{
    public byte[] GenerateOrderDetailsReport(List<Orderdetail> orderDetails)
    {
        // 1. Creamos el libro
        using (var workbook = new XLWorkbook())
        {
            // 2. Creamos la hoja
            var worksheet = workbook.Worksheets.Add("Order Details");

            // 3. Aplicamos formato a la fila 1
            var headerRow = worksheet.Row(1);
            headerRow.Style.Font.Bold = true;
            headerRow.Style.Fill.BackgroundColor = XLColor.LightGray; // Un color más de reporte
            
            // 4. Agregamos los encabezados
            worksheet.Cell(1, 1).Value = "OrderDetailId";
            worksheet.Cell(1, 2).Value = "OrderId";
            worksheet.Cell(1, 3).Value = "ProductId";
            worksheet.Cell(1, 4).Value = "Quantity";

            // 5. Agregamos los datos (Aquí usamos un loop en lugar de datos fijos)
            int currentRow = 2;
            foreach (var detail in orderDetails)
            {
                worksheet.Cell(currentRow, 1).Value = detail.OrderDetailId.ToString();
                worksheet.Cell(currentRow, 2).Value = detail.OrderId;
                worksheet.Cell(currentRow, 3).Value = detail.ProductId;
                worksheet.Cell(currentRow, 4).Value = detail.Quantity;
                currentRow++;
            }

            // 6. Ajustamos el ancho de las columnas (Opcional, pero útil)
            worksheet.Columns().AdjustToContents();

            // 7. EL TRUCO PARA LA API: Guardar en Memoria
            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                return stream.ToArray();
            }
        }
    }
    
    //  Metodo de Product
    public byte[] GenerateProductsReport(List<Product> products)
    {
        // 1. Creamos el libro
        using (var workbook = new XLWorkbook())
        {
            // 2. Creamos la hoja
            var worksheet = workbook.Worksheets.Add("Products");
        
            // 3. Damos estilo al encabezado
            var headerRow = worksheet.Row(1);
            headerRow.Style.Font.Bold = true;
            headerRow.Style.Fill.BackgroundColor = XLColor.LightBlue; // ¡Otro color!

            // 4. Agregamos los encabezados (¡AHORA CON LOS NOMBRES CORRECTOS!)
            worksheet.Cell(1, 1).Value = "ProductId";
            worksheet.Cell(1, 2).Value = "Name";
            worksheet.Cell(1, 3).Value = "Description";
            worksheet.Cell(1, 4).Value = "Price";

            // 5. Agregamos los datos
            int currentRow = 2;
            foreach (var product in products)
            {
                // --- ¡Usando los nombres de tu entidad! ---
                worksheet.Cell(currentRow, 1).Value = product.ProductId;
                worksheet.Cell(currentRow, 2).Value = product.Name;
                worksheet.Cell(currentRow, 3).Value = product.Description;
                worksheet.Cell(currentRow, 4).Value = product.Price;
            
                // Damos formato de moneda a la columna de precio
                worksheet.Cell(currentRow, 4).Style.NumberFormat.Format = "$#,##0.00";

                currentRow++;
            }

            // 6. Ajustamos columnas
            worksheet.Columns().AdjustToContents();

            // 7. Guardamos en memoria y devolvemos bytes
            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                return stream.ToArray();
            }
        }
    }
}