using Microsoft.EntityFrameworkCore;
using Moviegram.Models;

namespace Moviegram.Models
{
    public class MovieContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
            if (Database.EnsureCreated())
            {
                Movies?.Add(new Movie
                {
                    Title = "Матриця",
                    Year = 1999,
                    Genre = "Фантастика",
                    Description = "Програміст Нео дізнається, що світ, у якому він живе, є штучною реальністю.",
                    Director = "Лана та Ліллі Вачовські",
                    PosterPath = "/posters/matrix.jpg"
                });

                Movies?.Add(new Movie
                {
                    Title = "Оселя зла",
                    Year = 2002,
                    Genre = "Жахи, Фантастика",
                    Description = "Еліс бореться з небезпечним вірусом, який перетворює людей на зомбі.",
                    Director = "Пол В. С. Андерсон",
                    PosterPath = "/posters/resident-evil.jpg"
                });

                Movies?.Add(new Movie
                {
                    Title = "Запах жінки",
                    Year = 1992,
                    Genre = "Драма",
                    Description = "Молодий студент супроводжує сліпого ветерана армії під час подорожі Нью-Йорком.",
                    Director = "Мартін Брест",
                    PosterPath = "/posters/scent-of-a-woman.jpg"
                });

                Movies?.Add(new Movie
                {
                    Title = "Час",
                    Year = 2011,
                    Genre = "Фантастика, трилер",
                    Description = "У майбутньому люди перестають старіти після 25 років, але для життя їм потрібно купувати час.",
                    Director = "Ендрю Ніккол",
                    PosterPath = "/posters/in-time.jpg"
                });

                Movies?.Add(new Movie
                {
                    Title = "Піймай мене, якщо зможеш",
                    Year = 2002,
                    Genre = "Кримінал, Комедія",
                    Description = "Молодий шахрай видає себе за різних людей, а агент ФБР намагається його зловити.",
                    Director = "Стівен Спілберг",
                    PosterPath = "/posters/catch-me-if-you-can.jpg"
                });

                Movies?.Add(new Movie
                {
                    Title = "Острів проклятих",
                    Year = 2010,
                    Genre = "Трилер, драма",
                    Description = "Маршал США прибуває на похмурий острів, щоб розслідувати загадкове зникнення пацієнтки психіатричної лікарні.",
                    Director = "Мартін Скорсезе",
                    PosterPath = "/posters/shutter-island.jpg"
                });

                Movies?.Add(new Movie
                {
                    Title = "Завжди кажи «Так»",
                    Year = 2008,
                    Genre = "Комедія",
                    Description = "Чоловік, який звик відмовлятися від усього, вирішує протягом року говорити «так» на будь-яку пропозицію.",
                    Director = "Пейтон Рід",
                    PosterPath = "/posters/yes-man.jpg"
                });

                Movies?.Add(new Movie
                {
                    Title = "Фокус",
                    Year = 2015,
                    Genre = "Кримінал, Комедія, Драма",
                    Description = "Досвідчений шахрай навчає молоду дівчину мистецтву обману, але їхні стосунки ускладнюють небезпечну гру.",
                    Director = "Гленн Фікарра, Джон Рекуа",
                    PosterPath = "/posters/focus.jpg"
                });


                Movies?.Add(new Movie
                {
                    Title = "Зелена книга",
                    Year = 2018,
                    Genre = "Комедія, Драма",
                    Description = "Водій та талановитий піаніст вирушають у подорож американським Півднем.",
                    Director = "Пітер Фарреллі",
                    PosterPath = "/posters/green-book.jpg"
                });

                Movies?.Add(new Movie
                {
                    Title = "Шлях",
                    Year = 2010,
                    Genre = "Драма, Пригоди",
                    Description = "Батько вирушає пішки шляхом Святого Якова, щоб завершити подорож, яку не встиг здійснити його син.",
                    Director = "Еміліо Естевес",
                    PosterPath = "/posters/the-way.jpg"
                });

                SaveChanges();
            }
        }
    }
}