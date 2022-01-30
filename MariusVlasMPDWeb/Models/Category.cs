using System.ComponentModel.DataAnnotations;

namespace MariusVlasMPDWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Dish> Dishes { get; set; }
    }
}
