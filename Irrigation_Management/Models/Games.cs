using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Irrigation_Management.Models
{
    public class Games
    {
        [Key]
        public int Game_Id { get; set; }    
        public int? Stage { get; set; }
        //-------------------------------------------------------------

        [Column(TypeName = "decimal(5,2)")]
        public decimal? End_Score { get; set; } = 0.0m;
        //-------------------------------------------------------------
        [ForeignKey("Achievement")]
        public int Achievement_Id { get; set; }
        public Achievements? Achievement { get; set; }
        [ForeignKey("Scor")]
        public int Score_Id { get; set; }
        public Score? Scor { get; set; }
        //-------------------------------------------------------------------------------------
        public bool IsDeleted { get; internal set; } = false;
    }
}
