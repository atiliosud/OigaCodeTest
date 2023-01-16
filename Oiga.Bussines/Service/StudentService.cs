using Oiga.Bussines.Interface;
using Oiga.Bussines.Model;

namespace Oiga.Bussines.Service
{
    public class StudentService : BaseService, IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository,
                                 INotification notificador) : base(notificador)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            return await _studentRepository.GetAll();
        }

        public async Task<IEnumerable<Student>> GetCourse(Guid courseId)
        {
            return await _studentRepository.GetCourse(courseId);
        }
    }
}
