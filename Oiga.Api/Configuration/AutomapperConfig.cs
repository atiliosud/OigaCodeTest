using AutoMapper;
using Oiga.Api.ViewModels;
using Oiga.Bussines.Model;

namespace Oiga.Api.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Course, CourseViewModel>().ReverseMap();
            CreateMap<Student, StudentViewModel>().ReverseMap();
            CreateMap<EvaluationViewModel, Evaluation>().ReverseMap();
        }
    }
}
