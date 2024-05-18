using System.ComponentModel.DataAnnotations;

namespace Irrigation_management_app.Models
{
    public class Water_Management_TypesVModel
    {
        [Key]
        public int Water_Management_Type_Id { get; set; }
        [StringLength(50)]
        public required string Type_Name { get; set; }
        [StringLength(150)]
        public required string Description { get; set; }
        [StringLength(50)]
        public required string Material { get; set; }
        //-------------------------------------------------------------------------------------
        public bool IsDeleted { get; internal set; } = false;
    }
}
