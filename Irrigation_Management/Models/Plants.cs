using System.ComponentModel.DataAnnotations;

namespace Irrigation_Management.Models
{
    public class Plants
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

    }
}
