using System.ComponentModel.DataAnnotations;

namespace Irrigation_Management.Models
{
    public class Sensor_Types
    {
        [Key]
        public int Sensor_Type_Id { get; set; }
        //-------------------------------------------------------------------------------------
        [StringLength(50)]
        public required string Sensor_Type { get; set;}
        [StringLength(150)]
        public required string Description { get; set; }
        [StringLength(50)]
        public required string Measure_Unit { get; set; }
        //-------------------------------------------------------------------------------------
        public bool IsDeleted { get; internal set; } = false;
    }
}
