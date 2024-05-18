using System.ComponentModel.DataAnnotations;

namespace Irrigation_management_app.Models
{
    public class User_TypesVModel
    {
        [Key]
        public int User_Type_Id { get; set; }
        //-------------------------------------------------------------------------------------
        [StringLength(50)]
        public required string User_Type_Name { get; set; }
        //-------------------------------------------------------------------------------------
        public bool IsDeleted { get; internal set; } = false;
    }
}
