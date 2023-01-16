using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Oiga.Api.ViewModels;
using Oiga.Bussines.Interface;

namespace Oiga.Api.Controllers
{
    [Route("api/Course")]
    public class CourseController : MainController
    {
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;

        public CourseController(INotification notification,
                                   ICourseService courseService,
                                   IMapper mapper) : base(notification)
        {
            _courseService = courseService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CourseViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<CourseViewModel>>(await _courseService.GetAll());
        }

    }
}
