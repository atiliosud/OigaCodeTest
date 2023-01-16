using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Oiga.Api.ViewModels;
using Oiga.Bussines.Interface;
using Oiga.Bussines.Service;

namespace Oiga.Api.Controllers
{
    [Route("api/Student")]
    public class StudentController : MainController
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentController(IStudentService studentRepository,
                                    IMapper mapper,
                                    INotification notification) : base(notification)
        {
            _studentService = studentRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<StudentViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<StudentViewModel>>(await _studentService.GetAll());
        }

        [HttpGet("{courseId:guid}")]
        public async Task<IEnumerable<StudentViewModel>> GetCourse(Guid courseId)
        {
            return _mapper.Map<IEnumerable<StudentViewModel>>(await _studentService.GetCourse(courseId));
        }

    }
}
