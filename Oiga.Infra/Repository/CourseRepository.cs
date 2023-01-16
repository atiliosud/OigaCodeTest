using Microsoft.Extensions.Configuration;
using Oiga.Bussines.Interface;
using Oiga.Bussines.Model;

namespace Oiga.Infra.Repository
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
