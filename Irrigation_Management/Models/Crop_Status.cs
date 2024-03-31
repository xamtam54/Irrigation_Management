using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Irrigation_Management.Models
{
    public class Crop_Status
    {
        [Key]
        public int Crop_Status_Id { get; set; }
        //-------------------------------------------------------------------------------------
        [StringLength(50)]
        public required string Crop_Status_Name { get; set; }
        [Column(TypeName = "decimal(5,2)")]
        public required decimal Production_Percentage { get; set; }
    }
}
