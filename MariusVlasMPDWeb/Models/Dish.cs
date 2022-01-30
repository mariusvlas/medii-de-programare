using System.ComponentModel.DataAnnotations;

namespace MariusVlasMPDWeb.Models
{
    public class Dish
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}
