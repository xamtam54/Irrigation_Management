using System.ComponentModel.DataAnnotations;

namespace Irrigation_management_app.Models
{
    public class SystemsVModel
    {
        [Key]
        public int System_Id { get; set; }
        //-------------------------------------------------------------------------------------
        [StringLength(100)]
        public required string Systems_Name { get; set; }
        //-------------------------------------------------------------------------------------
        public bool IsDeleted { get; internal set; } = false;
    }
}
