using System.ComponentModel.DataAnnotations.Schema;

namespace Oiga.Api.ViewModels
{
    public class CourseViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }        
        public Boolean Active { get; set; }
    }
}
