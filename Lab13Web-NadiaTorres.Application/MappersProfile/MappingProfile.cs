using AutoMapper;
using Lab13Web_NadiaTorres.Application.UseCases.OrderdetailUseCase.Querys;
using Lab13Web_NadiaTorres.Infrastructure.Models;

namespace Lab13Web_NadiaTorres.Application.MappersProfile;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Como las propiedades se llaman igual, esto es todo lo que necesitas
        CreateMap<GetAllOrderdetailQuery, Orderdetail>();
    }
}