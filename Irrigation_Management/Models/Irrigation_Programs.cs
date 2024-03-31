using System.ComponentModel.DataAnnotations;

namespace Irrigation_Management.Models
{
    public class Irrigation_Programs
    {
        [Key]
        public int Irrigation_Program_Id { get; set; }
        //-------------------------------------------------------------------------------------
        public required TimeOnly Start_Hour { get; set; }
        public required TimeOnly End_Hour { get; set; }
        //-------------------------------------------------------------------------------------
        [Range(1, 7, ErrorMessage = "El valor debe estar entre 1 y 7")]
        public int Irrigations_Per_Week { get; set; } = 1;
        //-------------------------------------------------------------------------------------
        public required int Area_Id { get; set; }
        public Planting_Areas? Planting_Areas { get; set; }
    }
}
