using System.ComponentModel.DataAnnotations;

namespace Irrigation_management_app.Models
{
    public class PlantsVModel
    {
        [Key]
        public int Plant_Id { get; set; }
        //-------------------------------------------------------------------------------------
        [StringLength(50)]
        public required string Plant_Name { get; set; }
        [StringLength(50)]
        public required string Specie { get; set; }
        public required float Min_PH { get; set; }
        public required float Max_PH { get; set; }
        public required float Requirement_Liters { get; set; }
        //-------------------------------------------------------------------------------------
        public DateTime Planting_Date { get; set; } = DateTime.Now;
        //-------------------------------------------------------------------------------------
        public bool IsDeleted { get; internal set; } = false;
    }
}
