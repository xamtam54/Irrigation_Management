using Microsoft.EntityFrameworkCore;

namespace Irrigation_Management.Models
{
    [Keyless]
    public class Allocation_Systems
    {
        public int Game_Id { get; set; }
        public Games? Games { get; set; }
        public int System_Id { get; set; }
        public Systems? Systems { get; set; }
    }
}
