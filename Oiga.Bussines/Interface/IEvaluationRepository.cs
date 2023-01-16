using Oiga.Bussines.Model;

namespace Oiga.Bussines.Interface
{
    public interface IEvaluationRepository : IBaseRepository<Evaluation>
    {
        Task<IEnumerable<Evaluation>> GetByCourse(Guid courseId, int star);
        //Task<Evaluation> Get(Guid id);
    }
}
