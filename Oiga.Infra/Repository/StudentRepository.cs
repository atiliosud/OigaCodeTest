using Dapper;
using Microsoft.Extensions.Configuration;
using Oiga.Bussines.Interface;
using Oiga.Bussines.Model;

namespace Oiga.Infra.Repository
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<IEnumerable<Student>> GetCourse(Guid courseId)
        {
            using (var connection = CreateConnection())
            {
                var sql = $"select S.id, S.name as Name, S.active, S.last_name as LastName " +
                           "from Students S " +
                           "INNER JOIN dbo.CourseStudents Cs ON Cs.student_id = S.id " +                           
                           "where CS.course_id = @courseId and S.active = 1 ";

                var result = await connection.QueryAsync<Student>(sql, new { courseId = courseId });
                return result;
            }
        }
    }
}
