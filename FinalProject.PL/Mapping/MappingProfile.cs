using AutoMapper;
using FinalProject.DAL.Data.Models;
using FinalProject.PL.Areas.Dashboard.ViewModels;

namespace FinalProject.PL.Mapping
{
    public class MappingProfile :Profile

    {
        public MappingProfile() {
            CreateMap<ServiceFormVM, Service>().ReverseMap();
            CreateMap<Service,ServicesVM>();
            CreateMap<Service, ServiceDetailsVM>();
        }

    }
}
