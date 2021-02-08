using SQLite;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotNetCoreSQLite.Model
{
    [SQLite.Table("authors")]
    public class Author
    {
        [Key]
        [Required]
        [AutoIncrement]
        public int id { get; set; }

        [StringLength(200)]
        public string name { get; set; }
    }
}
