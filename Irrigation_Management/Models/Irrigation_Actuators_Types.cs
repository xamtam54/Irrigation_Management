using System.ComponentModel.DataAnnotations;

namespace Irrigation_Management.Models
{
    public class Irrigation_Actuators_Types
    {
        [Key]
        public int Irrigation_Actuators_Type_Id { get; set; }
        //-------------------------------------------------------------------------------------
        [StringLength(50)]
        public required string Type_Name { get; set; }
        [StringLength(150)]
        public required string Description { get; set; }

    }
}
