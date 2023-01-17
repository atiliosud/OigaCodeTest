using Moq;
using Oiga.Bussines.Interface;
using Oiga.Bussines.Model;
using Oiga.Bussines.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace Oiga.Test
{
    public class EvaluationServiceTest
    {
        private Mock<IEvaluationRepository> _evaluationRepository;
        private Mock<ICourseStudentRepository> _courseStudentRepository;
        private IEvaluationService _evaluationService;
        private Mock<INotification> _notification;

        public EvaluationServiceTest()
        {
            _evaluationRepository = new Mock<IEvaluationRepository>();
            _courseStudentRepository = new Mock<ICourseStudentRepository>();
            _notification = new Mock<INotification>();
            _evaluationService = new EvaluationService(_evaluationRepository.Object, _courseStudentRepository.Object, _notification.Object);
        }

        [Fact]
        public async void GetSucess()
        {
            var evaluation = new Evaluation()
            {
                Id = Guid.Parse("7d904deb-bec8-45a4-9a2c-329fcc4e69d1"),
                CourseStudentId = Guid.Parse("5822ebbb-4006-41a8-923f-8594fcf34ee0"),
                Stars = 5,
                Description = "Test Evaluation"

            };

            // Arrange
            _evaluationRepository.Setup(repo => repo.Get(Guid.Parse("7d904deb-bec8-45a4-9a2c-329fcc4e69d1")))
                .ReturnsAsync(evaluation);


            // Act
            var result = await _evaluationService.Get(Guid.Parse("7d904deb-bec8-45a4-9a2c-329fcc4e69d1"));

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async void GetByCourseStudentSucess()
        {
            var courseStudent = new CourseStudent()
            {
                Id = Guid.Parse("0f64ac42-0f1d-4593-a26d-004118219b36"),
                CourseId = Guid.Parse("d57db3ce-ba21-4d0a-99b4-55ddd5986d43"),
                StudentId = Guid.Parse("a9d2fd43-fb0b-401d-8f76-eb05d3b19bda")
            };

            // Arrange
            _courseStudentRepository.Setup(repo => repo.GetByCourseStudent(Guid.Parse("d57db3ce-ba21-4d0a-99b4-55ddd5986d43"),
                Guid.Parse("a9d2fd43-fb0b-401d-8f76-eb05d3b19bda")))
                .ReturnsAsync(courseStudent);

            // Act
            var result = await _evaluationService.GetByCourseStudent(Guid.Parse("d57db3ce-ba21-4d0a-99b4-55ddd5986d43"),
                Guid.Parse("a9d2fd43-fb0b-401d-8f76-eb05d3b19bda"));

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async void GetByCourseSucess()
        {
            var evaluation = new Evaluation()
            {
                Id = Guid.Parse("7d904deb-bec8-45a4-9a2c-329fcc4e69d1"),
                CourseStudentId = Guid.Parse("5822ebbb-4006-41a8-923f-8594fcf34ee0"),
                Stars = 5,
                Description = "Test Evaluation"
            };

            var evaluations = new List<Evaluation>();
            evaluations.Add(evaluation);

            // Arrange
            _evaluationRepository.Setup(repo => repo.GetByCourse(Guid.Parse("7d904deb-bec8-45a4-9a2c-329fcc4e69d1"),0))
                .ReturnsAsync(evaluations);


            // Act
            var result = await _evaluationService.GetByCourse(Guid.Parse("7d904deb-bec8-45a4-9a2c-329fcc4e69d1"),0);

            // Assert
            Assert.NotNull(result);
        }
    }
}
