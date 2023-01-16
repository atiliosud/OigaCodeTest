using Oiga.Bussines.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oiga.Bussines.Interface
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAll();
        Task<IEnumerable<Student>> GetCourse(Guid courseId);
    }
}
