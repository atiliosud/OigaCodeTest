using Dapper;

namespace Oiga.Bussines.Model
{
    [Table("Evaluations")]
    public class Evaluation : Entity
    {
        [Column("course_student_id")]
        public Guid CourseStudentId { get; set; }
        [Column("stars")]
        public int Stars { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("creation_date")]
        public DateTime DateCreated { get; set; }

        [NotMapped]
        public string NameStudent { get; set; }
        [NotMapped]
        public Guid CourseId { get; set; }
        [NotMapped]
        public Guid StudentId { get; set; }
    }
}
