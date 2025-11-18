using Lab13Web_NadiaTorres.Application.Interfaces;
using Lab13Web_NadiaTorres.Application.UseCases.ProductUseCase.Querys;
using Lab13Web_NadiaTorres.Infrastructure.Models;
using MediatR;

namespace Lab13Web_NadiaTorres.Application.Handlers;

public class GetAllProductQueryHandler: IRequestHandler<GetAllProductQuery, List<Product>>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetAllProductQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        // _mapper = mapper;
    }

    public async Task<List<Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        var allProducts = await _unitOfWork.Repository<Product>().GetAllAsync();
        return allProducts;
    }
}