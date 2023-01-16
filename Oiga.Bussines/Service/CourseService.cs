using Oiga.Bussines.Interface;
using Oiga.Bussines.Model;

namespace Oiga.Bussines.Service
{
    public class CourseService : BaseService, ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository,
                                INotification notificador) : base(notificador)
        {
            _courseRepository = courseRepository;
        }

        public async Task<IEnumerable<Course>> GetAll()
        {
            return await _courseRepository.GetAll(); 
        }
    }
}
