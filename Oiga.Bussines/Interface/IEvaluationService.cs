using Oiga.Bussines.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oiga.Bussines.Interface
{
    public interface IEvaluationService
    {
        Task Add(Evaluation evaluation);
        Task Update(Evaluation evaluation);
        Task Delete(Guid id);
        Task<Evaluation> Get(Guid id);
        Task<IEnumerable<Evaluation>> GetByCourse(Guid courseId, int star);
        Task<CourseStudent> GetByCourseStudent(Guid courseId, Guid studentId);
    }
}
