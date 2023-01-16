using Dapper;

namespace Oiga.Bussines.Model
{
    [Table("Courses")]
    public class Course : Entity
    {
        [Column("name")]
        public string Name { get; set; }
        [Column("active")]
        public Boolean Active { get; set; }
    }
}
