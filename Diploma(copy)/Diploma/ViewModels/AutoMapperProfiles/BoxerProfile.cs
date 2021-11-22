using AutoMapper;
using Diploma.ViewModels.Boxers;
using Diploma.ViewModels.BoxingClubs;


namespace Diploma.ViewModels.AutoMapperProfiles


{
    public class BoxerProfile : Profile
    {
        public BoxerProfile()
        {
            CreateMap<Diploma.Boxers, InputBoxerViewModel>().ReverseMap();
            CreateMap<Diploma.Boxers, DeleteBoxerViewModel>();
            CreateMap<Diploma.Boxers, EditBoxerViewModel>().ReverseMap();
            CreateMap<Diploma.Boxers, BoxerViewModel>();
            CreateMap<Diploma.BoxingClubs, InputBoxingClubsViewModel>().ReverseMap();
            CreateMap<Diploma.BoxingClubs, DeleteBoxingClubsViewModel>();
            CreateMap<Diploma.BoxingClubs, EditBoxingClubsViewModel>().ReverseMap();
            CreateMap<Diploma.BoxingClubs, BoxingClubsViewModel>();
           
        }
    }
}