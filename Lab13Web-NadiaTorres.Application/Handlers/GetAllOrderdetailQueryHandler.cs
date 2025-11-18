// Eliminamos "using AutoMapper;" porque ya no se usa
using Lab13Web_NadiaTorres.Application.Interfaces;
using Lab13Web_NadiaTorres.Application.UseCases.OrderdetailUseCase.Querys;
using Lab13Web_NadiaTorres.Infrastructure.Models; // Necesario para List<Orderdetail>
using MediatR;

namespace Lab13Web_NadiaTorres.Application.Handlers;

internal sealed class GetAllOrderdetailQueryHandler : IRequestHandler<GetAllOrderdetailQuery, List<Orderdetail>>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetAllOrderdetailQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        // _mapper = mapper;
    }

    public async Task<List<Orderdetail>> Handle(GetAllOrderdetailQuery request, CancellationToken cancellationToken)
    {
        var allOrderDetails = await _unitOfWork.Repository<Orderdetail>().GetAllAsync();
        return allOrderDetails;
    }
}