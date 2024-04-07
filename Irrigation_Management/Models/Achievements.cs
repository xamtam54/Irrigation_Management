using System.ComponentModel.DataAnnotations;

namespace Irrigation_Management.Models
{
    public class Achievements
    {
        [Key]
        public int Achievement_Id {  get; set; }
        [StringLength(100)]
        public required string Achievement_Name { get; set; }
        [StringLength(250)]
        public required string Achievement_Description { get; set; }
        //--------------------------------------------------------------------
        [Range(0, 1, ErrorMessage = "El valor debe estar entre 0 y 1")]
        public int Achievement_Status { get; set; } = 0;

    }
}
