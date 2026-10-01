using System.ComponentModel.DataAnnotations;

namespace Moviegram.Models
{
    public class MyGenresAttribute : ValidationAttribute
    {
        private readonly string[] _genres =
        {
            "Бойовик",
            "Комедія",
            "Драма",
            "Жахи",
            "Фантастика",
            "Трилер",
            "Мелодрама",
            "Пригоди",
            "Фентезі",
            "Детектив"
        };

        public override bool IsValid(object? value)
        {
            if (value is string strVal)
            {
                return _genres.Contains(strVal);
            }

            return false;
        }
    }
}