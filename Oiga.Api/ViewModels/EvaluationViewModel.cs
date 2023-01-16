using Microsoft.AspNetCore.Mvc;


namespace Oiga.Api.ViewModels
{
    public class EvaluationViewModel
    {                
        public Guid Id { get; set; }

        public Guid CourseStudentId { get; set; }
        public int Stars { get; set; }
        public string Description { get; set; }

        public string? NameStudent { get; set; }

        public DateTime DateCreated { get; set; }
        public Guid CourseId { get; set; }
        public Guid StudentId { get; set; }
    }
}
