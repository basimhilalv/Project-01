using System.ComponentModel.DataAnnotations;

namespace Project_01.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
