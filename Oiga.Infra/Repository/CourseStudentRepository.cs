using Dapper;
using Microsoft.Extensions.Configuration;
using Oiga.Bussines.Interface;
using Oiga.Bussines.Model;

namespace Oiga.Infra.Repository
{
    public class CourseStudentRepository : BaseRepository<CourseStudent>, ICourseStudentRepository
    {
        public CourseStudentRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<CourseStudent> GetByCourseStudent(Guid courseId, Guid studentId)
        {
            using (var connection = CreateConnection())
            {
                var result = await connection.QueryFirstOrDefaultAsync<CourseStudent>("Select * from CourseStudents where course_id = @course_id and student_id = @student_id ", new { course_id = courseId, student_id = studentId });
                return result;
            }
        }
    }
}
