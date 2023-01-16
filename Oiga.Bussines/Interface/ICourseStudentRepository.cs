using Oiga.Bussines.Model;


namespace Oiga.Bussines.Interface
{
    public interface ICourseStudentRepository : IBaseRepository<CourseStudent>
    {
        Task<CourseStudent> GetByCourseStudent(Guid courseId, Guid studentId);
    }
}
