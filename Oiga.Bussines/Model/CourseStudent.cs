using Dapper;
using System.ComponentModel;

namespace Oiga.Bussines.Model
{
    [Table("CourseStudents")]
    public class CourseStudent : Entity
    {
        [Column("course_id")]
        public Guid CourseId { get; set; }
        [Column("student_id")]
        public Guid StudentId { get; set; }
        [Column("grade")]
        public int Grade { get; set; }

        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
