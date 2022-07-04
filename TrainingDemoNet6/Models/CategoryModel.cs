using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TrainingDemoNet6.Models
{
    public class CategoryModel
    {
        [Key]
        public int Id { get;set; }
        [Required]
        public string? Name { get;set; }

        [Required]
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage ="Must be between 1 and 100!")]
        public int DisplayOrder { get;set; }
        public DateTime CreatedAt { get;set; } = DateTime.Now;

    }
}
