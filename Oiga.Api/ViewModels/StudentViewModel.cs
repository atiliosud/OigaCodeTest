using System.ComponentModel.DataAnnotations.Schema;

namespace Oiga.Api.ViewModels
{
    public class StudentViewModel
    {
        public Guid id { get; set; }
        public string Name { get; set; }        
        public string LastName { get; set; }        
        public Boolean active { get; set; }
    }
}
