using Oiga.Bussines.Model;

namespace Oiga.Bussines.Interface
{
    public interface IStudentRepository : IBaseRepository<Student>
    {
        Task<IEnumerable<Student>> GetCourse(Guid courseId);
    }
}
