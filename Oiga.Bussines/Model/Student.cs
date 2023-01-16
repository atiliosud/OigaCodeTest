using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oiga.Bussines.Model
{
    [Table("Students")]
    public class Student : Entity
    {
        [Column("name")]
        public string Name { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("active")]
        public Boolean active { get; set; }
    }
}
