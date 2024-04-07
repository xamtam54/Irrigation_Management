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
        [ForeignKey("Users")]
        public int Users_Id { get; set; }
        public Users? Users { get; set; }
        [ForeignKey("Score")]
        public int Score_Id { get; set; }
        public Score? Score { get; set; }
    }
}
