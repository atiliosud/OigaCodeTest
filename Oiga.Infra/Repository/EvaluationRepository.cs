using Dapper;
using Microsoft.Extensions.Configuration;
using Oiga.Bussines.Interface;
using Oiga.Bussines.Model;
using static Dapper.SqlMapper;
using System.Data;
using System.Text;
using System.Linq;

namespace Oiga.Infra.Repository
{
    public class EvaluationRepository : BaseRepository<Evaluation>, IEvaluationRepository
    {
        public EvaluationRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<IEnumerable<Evaluation>> GetByCourse(Guid courseId, int star)
        {
            using (var connection = CreateConnection())
            {
                var strbQuery = $"SELECT E.id, E.course_student_id as CourseStudentId, E.stars, E.description, E.creation_date as DateCreated, CS.course_id as courseId, CS.student_id as studentId, CONCAT(s.Name, s.last_name) as NameStudent " +
                    "FROM dbo.Evaluations E " +
                    "INNER JOIN dbo.CourseStudents Cs ON Cs.id = E.course_student_id " +
                    "INNER JOIN dbo.Students S ON S.id = cs.student_id " +
                    "WHERE cs.course_id = @courseId ";
                
                if (star > 0)
                {
                    strbQuery += "and E.stars = @star ";
                }

                strbQuery += "ORDER BY E.creation_date";

                var queryParameters = new
                {
                    courseId = courseId,
                    star = star
                };

                var result = await connection.QueryAsync<Evaluation>(strbQuery, queryParameters);
                return result;
            }
        }

        public async Task<Evaluation> Get(Guid id)
        {
            using (var connection = CreateConnection())
            {
                var sql = $"select E.id, E.course_student_id as CourseStudentId, E.stars, E.description, E.creation_date as DateCreated, CS.course_id as courseId, CS.student_id as studentId, s.Name as NameStudent " +
                           "from Evaluations E " +
                           "INNER JOIN dbo.CourseStudents Cs ON Cs.id = E.course_student_id " +
                           "INNER JOIN dbo.Students S ON S.id = cs.student_id " +
                           "where E.id = @id ";
                var result = await connection.QueryFirstOrDefaultAsync<Evaluation>(sql, new { id = id });
                return result;
            }
        }
    }
}
