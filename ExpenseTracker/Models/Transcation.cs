using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.Models
{
    public class Transcation
    {
        [Key]
        public int TranscationId { get; set; }
        public Category Category { get; set; }
        public int Amount { get; set; }
        [Column(TypeName ="nvarchar(75)")]
        public String? Note { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
