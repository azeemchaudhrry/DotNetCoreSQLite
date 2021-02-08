using SQLite;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotNetCoreSQLite.Model
{
    [SQLite.Table("quotes")]
    public class Quote
    {
        [Key]
        [Required]
        [AutoIncrement]
        public int Id { get; set; }
        
        [StringLength(2000)]
        public string Text { get; set; }

        [ForeignKey("author_id")]
        public int author_id { get; set; }

        [ForeignKey("quote_type_id")]
        public int quote_type_id { get; set; }

        public virtual Author author { get; set; }
        public virtual QuoteType quote_type { get; set; }
    }
}
