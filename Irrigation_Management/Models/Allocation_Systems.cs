using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Irrigation_Management.Models
{
    public class Allocation_Systems
    {
        [Key]
        public int Allocation_Systems_Id { get; set; }

        [ForeignKey("Game")]
        public int? Game_Id { get; set; }
        public Games? Game { get; set; }

        [ForeignKey("System")]
        public int? System_Id { get; set; }
        public Systems? System { get; set; }

        [ForeignKey("User")]
        public int User_Id { get; set; }
        public Users? User { get; set; }
    }
}
