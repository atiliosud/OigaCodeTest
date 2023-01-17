using Castle.Core.Logging;
using Moq;
using Oiga.Bussines.Interface;
using Oiga.Bussines.Model;
using Oiga.Bussines.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oiga.Test
{
    public class CourseServiceTest
    {
        private Mock<ICourseRepository> _courseRepository;        
        private ICourseService _courseService;
        private Mock<INotification> _notification;

        public CourseServiceTest()
        {
            _courseRepository = new Mock<ICourseRepository>();
            _notification = new Mock<INotification>();
            _courseService = new CourseService(_courseRepository.Object, _notification.Object);
        }

        [Fact]
        public async void GetAllSucess()
        {
            Course course = new Course()
            {
                Id = Guid.Parse("CEBF9A54-5BA6-419A-872A-03E405A25387"),
                Name = "Crime and Criminal Justice"
            };

            var courses = new List<Course>();
            courses.Add(course);

            // Arrange
            _courseRepository.Setup(repo => repo.GetAll())
                .ReturnsAsync(courses);

            
            // Act
            var result = await _courseService.GetAll();

            // Assert
            Assert.NotNull(result);
        }
    }
}
