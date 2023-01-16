using Oiga.Bussines.Interface;
using Oiga.Bussines.Model;
using Oiga.Bussines.Model.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oiga.Bussines.Service
{
    public class EvaluationService : BaseService, IEvaluationService
    {
        private readonly IEvaluationRepository _evaluationRepository;
        private readonly ICourseStudentRepository _courseStudentRepository;

        public EvaluationService(IEvaluationRepository evaluationRepository,
                                    ICourseStudentRepository courseStudentRepository,
                                    INotification notificador) : base(notificador)
        {
            _evaluationRepository = evaluationRepository;
            _courseStudentRepository = courseStudentRepository;
        }

        public async Task Add(Evaluation evaluation)
        {
            if (!RunValidation(new EvaluationValidation(), evaluation)) return;

            evaluation.Id = Guid.NewGuid();

            await _evaluationRepository.Add(evaluation);
        }

        public async Task Delete(Guid id)
        {
            await _evaluationRepository.Delete(id);
        }

        public async Task<Evaluation> Get(Guid id)
        {
            return await _evaluationRepository.Get(id);
        }

        public async Task<IEnumerable<Evaluation>> GetByCourse(Guid courseId, int star)
        {
            return await _evaluationRepository.GetByCourse(courseId, star);
        }

        public async Task<CourseStudent> GetByCourseStudent(Guid courseId, Guid studentId)
        {
            return await _courseStudentRepository.GetByCourseStudent(courseId, studentId);
        }

        public async Task Update(Evaluation evaluation)
        {
            if (!RunValidation(new EvaluationValidation(), evaluation)) return;

            await _evaluationRepository.Update(evaluation);
        }
    }
}
