using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Irrigation_management_app.Models
{
    public class Crop_StatusVModel
    {
        [Key]
        public int Crop_Status_Id { get; set; }
        //-------------------------------------------------------------------------------------
        [StringLength(50)]
        public required string Crop_Status_Name { get; set; }
        [Column(TypeName = "decimal(5,2)")]
        public required decimal Production_Percentage { get; set; }
        //-------------------------------------------------------------------------------------
        public bool IsDeleted { get; internal set; } = false;
    }
}
