using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwaggerApp.Models
{

    public class Lot
    {

        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Заголовок лота обязателен.")]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "Длина заголовка не должна превышат 150 символов")]
        public string Title { get; set; } = String.Empty;

        /// <summary>
        /// Описание элемента
        /// </summary>
        [StringLength(500, ErrorMessage ="Описание не должно превышать 500 символов.")]
        public string Description { get; set; } = String.Empty;

        /// <summary>
        /// Цена аренды
        /// </summary>
        [Range(0, double.MaxValue, ErrorMessage = "Цена должна быть положительным числом")]
        public decimal Price { get; set; }

        /// <summary>
        /// Ссылка на костюм
        /// </summary>
        public Costume? Costume { get; set; } 

        public List<string> Tags { get; set; } = new();
    }


}
