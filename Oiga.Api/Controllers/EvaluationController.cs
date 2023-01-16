using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Oiga.Api.ViewModels;
using Oiga.Bussines.Interface;
using Oiga.Bussines.Model;

namespace Oiga.Api.Controllers
{
    [Route("api/Evaluation")]
    public class EvaluationController : MainController
    {
        private readonly IEvaluationService _evaluationService;
        private readonly IMapper _mapper;

        public EvaluationController(INotification notification,
                                   IEvaluationService evaluationService,
                                   IMapper mapper) : base(notification)
        {
            _evaluationService = evaluationService;
            _mapper = mapper;
        }

        [HttpGet("{courseId:guid}/{star:int}")]
        public async Task<IEnumerable<EvaluationViewModel>> GetByCourse(Guid courseId, int star)
        {
            return _mapper.Map<IEnumerable<EvaluationViewModel>>(await _evaluationService.GetByCourse(courseId, star));
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<EvaluationViewModel>> Get(Guid id)
        {
            var evaluationViewModel = await GetEvaluation(id);

            if (evaluationViewModel == null) return NotFound();

            return evaluationViewModel;
        }

        [HttpPost]
        public async Task<ActionResult<EvaluationViewModel>> Add(EvaluationViewModel evaluationViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var courseStudent = await _evaluationService.GetByCourseStudent(evaluationViewModel.CourseId, evaluationViewModel.StudentId);

            if (courseStudent == null)
            {
                NotificationError("Course and Student not found");
                return CustomResponse();
            }

            evaluationViewModel.CourseStudentId = courseStudent.Id;
            evaluationViewModel.DateCreated = DateTime.Now;
            
            await _evaluationService.Add(_mapper.Map<Evaluation>(evaluationViewModel));

            return CustomResponse(evaluationViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, EvaluationViewModel evaluationViewModel)
        {
            if (id != evaluationViewModel.Id)
            {
                NotificationError("The ids entered are not the same;");
                return CustomResponse();
            }

            var evaluationUpdate = await GetEvaluation(id);
            if (!ModelState.IsValid) return CustomResponse(ModelState);


            evaluationUpdate.Stars = evaluationViewModel.Stars;
            evaluationUpdate.Description = evaluationViewModel.Description;
            evaluationUpdate.CourseStudentId = _evaluationService.GetByCourseStudent(evaluationViewModel.CourseId, evaluationViewModel.StudentId).Result.Id;
            
            await _evaluationService.Update(_mapper.Map<Evaluation>(evaluationUpdate));

            return CustomResponse(evaluationViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<EvaluationViewModel>> Delete(Guid id)
        {
            var evaluation = await GetEvaluation(id);

            if (evaluation == null) return NotFound();

            await _evaluationService.Delete(id);

            return CustomResponse(evaluation);
        }

        private async Task<EvaluationViewModel> GetEvaluation(Guid id)
        {
            return _mapper.Map<EvaluationViewModel>(await _evaluationService.Get(id));
        }

    }
}
