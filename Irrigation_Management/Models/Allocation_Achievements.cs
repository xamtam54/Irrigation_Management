using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Irrigation_Management.Models
{
    [Keyless]
    public class Allocation_Achievements
    {
        [ForeignKey("Users")]
        public int Users_Id { get; set; }
        public Users? Users { get; set; }
        [ForeignKey("Achievements")]
        public int Achievement_Id { get; set; }
        public Achievements? Achievements { get; set; }
    }
}
