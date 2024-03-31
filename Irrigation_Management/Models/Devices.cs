using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Irrigation_Management.Models
{
    public class Devices
    {
        [Key]
        public int Device_Id { get; set; }
        //-------------------------------------------------------------------------------------
        [StringLength(50)]
        public required string Device_Name { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public required decimal Device_Price { get; set; }
        //-------------------------------------------------------------------------------------
        [Range(0, 1, ErrorMessage = "El valor debe estar entre 0 y 1")]
        public int Device_Enabled { get; set; } = 1;
        //-------------------------------------------------------------------------------------
        public int System_Id { get; set; }
        public Systems? Systems { get; set; }
        public int? Area_Id { get; set; }
        public Planting_Areas? Planting_Areas { get; set; }
    }
}
