using System.ComponentModel.DataAnnotations;

namespace Irrigation_Management.Models
{
    public class Systems
    {
        [Key]
        public int System_Id { get; set; }
        //-------------------------------------------------------------------------------------
        [StringLength(100)]
        public required string Systems_Name { get; set; }
    }
}
