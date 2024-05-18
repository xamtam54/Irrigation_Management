using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Irrigation_management_app.Models
{
    public class Allocation_SystemsVModel
    {
        [Key]
        public int Allocation_Systems_Id { get; set; }
        /*
        [ForeignKey("Game")]
        public int? Game_Id { get; set; }
        public Games? Game { get; set; }
        */
        [ForeignKey("System")]
        public int? System_Id { get; set; }
        public SystemsVModel? System { get; set; }

        [ForeignKey("User")]
        public int User_Id { get; set; }
        public UsersVModel? User { get; set; }
    }
}
