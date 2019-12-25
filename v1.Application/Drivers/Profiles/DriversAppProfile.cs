using AutoMapper;
using v1.Domain.Drivers.Entities;
using v1.DTO.Drivers.Requests;
using v1.DTO.Drivers.Responses;

namespace v1.Application.Drivers.Profiles
{
    public class DriversAppProfile : Profile
    {
        public DriversAppProfile()
        {
            CreateMap<DriverRequest, Driver>();
            CreateMap<Driver, DriverResponse>();
        }
    }
}
