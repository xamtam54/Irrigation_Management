using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Irrigation_Management.Models
{
    public class Score
    {
        [Key]
        public int Score_Id { get; set; }
        [Column(TypeName = "decimal(5,2)")]
        public decimal? Success_Rate { get; set; }
        [Column(TypeName = "decimal(5,2)")]
        public decimal? Water_Saved { get; set; }
        [Column(TypeName = "decimal(5,2)")]
        public decimal? Total { get; set; }
    }
}
