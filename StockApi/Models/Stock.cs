using System.ComponentModel.DataAnnotations.Schema;

namespace StockApi.Models
{
    [Table("stock")]
    public class Stock
    {
        public int Id { get; set; }
        public String Symbol { get; set; } = string.Empty;
        public String CompanyName { get; set; } = string.Empty;
        [Column(TypeName ="decimal(18,2)")]
        public decimal Purchase {  get; set; }
        [Column(TypeName ="decimal(18,2)")]
        public decimal lastDiv { get; set; }
        public String Industry { get; set; } = string.Empty;
        public long MarketCap { get; set; }
        public List<Comment> comments { get; set; } = new List<Comment>();
        public List<Portfolio> portfolios { get; set; } = new List<Portfolio>();
    }
}
