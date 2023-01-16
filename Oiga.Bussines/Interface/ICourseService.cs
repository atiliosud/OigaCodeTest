using Oiga.Bussines.Model;

namespace Oiga.Bussines.Interface
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetAll();
    }
}
