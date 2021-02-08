using SQLite;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotNetCoreSQLite.Model
{
    [SQLite.Table("quote_types")]
    public class QuoteType
    {
        [Key]
        [Required]
        [AutoIncrement]
        public int id { get; set; }

        [StringLength(100)]
        public string text { get; set; }
    }
}
