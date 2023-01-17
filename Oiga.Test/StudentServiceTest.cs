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
    public class StudentServiceTest
    {
        private Mock<IStudentRepository> _studentRepository;
        private IStudentService _studentService;
        private Mock<INotification> _notification;

        public StudentServiceTest()
        {
            _studentRepository = new Mock<IStudentRepository>();
            _notification = new Mock<INotification>();
            _studentService = new StudentService(_studentRepository.Object, _notification.Object);
        }

        [Fact]
        public async void GetAllSucess()
        {
            var student = new Student()
            {
                Id = Guid.Parse("80C0C369-E270-4DC0-B435-029B3D3E4D80"),
                Name = "Calvin",
                LastName = "Leon"
            };

            var students = new List<Student>();
            students.Add(student);

            // Arrange
            _studentRepository.Setup(repo => repo.GetAll())
                .ReturnsAsync(students);


            // Act
            var result = await _studentService.GetAll();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async void GetCourseSucess()
        {
            var student = new Student()
            {
                Id = Guid.Parse("80C0C369-E270-4DC0-B435-029B3D3E4D80"),
                Name = "Calvin",
                LastName = "Leon"
            };

            var students = new List<Student>();
            students.Add(student);

            // Arrange
            _studentRepository.Setup(repo => repo.GetCourse(Guid.Parse("80C0C369-E270-4DC0-B435-029B3D3E4D80")))
                .ReturnsAsync(students);


            // Act
            var result = await _studentService.GetCourse(Guid.Parse("80C0C369-E270-4DC0-B435-029B3D3E4D80"));

            // Assert
            Assert.NotNull(result);
        }
    }
}
