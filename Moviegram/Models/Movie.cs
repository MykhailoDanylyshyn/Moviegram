using System.ComponentModel.DataAnnotations;

namespace Moviegram.Models
{
    public class Movie
    {
        [Display(Name = "Ідентифікатор")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Будь ласка, введіть назву фільму")]
        [Display(Name = "Назва фільму")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Будь ласка, введіть рік")]
        [Range(1888, int.MaxValue, ErrorMessage = "Рік має бути не менше 1888")]
        [Display(Name = "Рік")]
        public int? Year { get; set; }


        [Required(ErrorMessage = "Будь ласка, введіть жанр")]
        [MyGenres(ErrorMessage = "Будь ласка, виберіть правильний жанр")]
        [Display(Name = "Жанр")]
        public string? Genre { get; set; }

        [Required(ErrorMessage = "Будь ласка, введіть опис")]
        [Display(Name = "Опис")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Будь ласка, введіть режисера")]
        [Display(Name = "Режисер")]
        public string? Director { get; set; }

        [Required(ErrorMessage = "Будь ласка, вкажіть шлях до постера")]
        [Display(Name = "Постер")]
        public string? PosterPath { get; set; }
    }

}
