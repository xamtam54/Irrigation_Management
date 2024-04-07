using System.ComponentModel.DataAnnotations;

namespace Irrigation_Management.Models
{
    public class Users
    {
        [Key]
        public int Users_Id { get; set; }
        //-------------------------------------------------------------------------------------
        [StringLength(50)]
        public required string UserName { get; set; }
        [StringLength(100)]
        public required string Names { get; set; }
        [StringLength(100)]
        public required string Surnames { get; set; }
        [StringLength(255)]
        public required string Password { get; set; }
        [StringLength(100)]
        public required string Email { get; set; }
        //-------------------------------------------------------------------------------------
        public DateTime Registration_Date { get; set; } = DateTime.Now;
        [Range(0, 1, ErrorMessage = "El valor debe estar entre 0 y 1")]
        public int Is_Active { get; set; } = 1;
        //-------------------------------------------------------------------------------------
        public required int User_Type_Id { get; set; }
        public User_Types? User_Types { get; set; }
    }
}
