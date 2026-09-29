using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moviegram.Models;

namespace Moviegram.Controllers;

public class MovieController(
    MovieContext context,
    IWebHostEnvironment appEnvironment) : Controller
{
    // GET: Movie
    public async Task<IActionResult> Index()
    {
        return View(await context.Movies.ToListAsync());
    }

    // GET: Movie/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id is null)
            return NotFound();

        var movie = await context.Movies
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id);

        return movie is null ? NotFound() : View(movie);
    }

    // GET: Movie/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Movie/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    [RequestSizeLimit(100_000_000)]
    public async Task<IActionResult> Create(
        [Bind("Title,Year,Genre,Description,Director")] Movie movie,
        IFormFile? posterFile)
    {
        // Перевіряємо, чи вибраний постер
        if (posterFile is null || posterFile.Length == 0)
        {
            ModelState.AddModelError("PosterPath", "Будь ласка, виберіть постер");
        }
        else
        {
            var postersPath = Path.Combine(
                appEnvironment.WebRootPath,
                "posters");

            Directory.CreateDirectory(postersPath);

            var extension = Path.GetExtension(posterFile.FileName);

            var fileName = $"{Guid.NewGuid()}{extension}";

            var absolutePath = Path.Combine(
                postersPath,
                fileName);

            var relativePath = $"/posters/{fileName}";

            await using (var fileStream = new FileStream(
                absolutePath,
                FileMode.Create))
            {
                await posterFile.CopyToAsync(fileStream);
            }

            movie.PosterPath = relativePath;

            // Прибираємо помилку Required для PosterPath,
            // оскільки шлях ми вже встановили
            ModelState.Remove(nameof(Movie.PosterPath));
        }

        if (!ModelState.IsValid)
        {
            return View(movie);
        }

        context.Movies.Add(movie);

        await context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    // GET: Movie/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id is null)
            return NotFound();

        var movie = await context.Movies.FindAsync(id);

        return movie is null ? NotFound() : View(movie);
    }

    // POST: Movie/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    [RequestSizeLimit(100_000_000)]
    public async Task<IActionResult> Edit(
        int id,
        [Bind("Id,Title,Year,Genre,Description,Director,PosterPath")]
        Movie movie,
        IFormFile? posterFile)
    {
        if (id != movie.Id)
            return NotFound();

        // Якщо завантажили новий постер
        if (posterFile is not null && posterFile.Length > 0)
        {
            var postersPath = Path.Combine(
                appEnvironment.WebRootPath,
                "posters");

            Directory.CreateDirectory(postersPath);

            var extension = Path.GetExtension(posterFile.FileName);

            var fileName = $"{Guid.NewGuid()}{extension}";

            var absolutePath = Path.Combine(
                postersPath,
                fileName);

            var relativePath = $"/posters/{fileName}";

            await using (var fileStream = new FileStream(
                absolutePath,
                FileMode.Create))
            {
                await posterFile.CopyToAsync(fileStream);
            }

            movie.PosterPath = relativePath;

            ModelState.Remove(nameof(Movie.PosterPath));
        }

        // Якщо новий постер не завантажували,
        // залишаємо старий PosterPath
        if (!ModelState.IsValid)
        {
            return View(movie);
        }

        context.Update(movie);

        await context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    // GET: Movie/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id is null)
            return NotFound();

        var movie = await context.Movies
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id);

        return movie is null ? NotFound() : View(movie);
    }

    // POST: Movie/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var movie = await context.Movies.FindAsync(id);

        if (movie is not null)
        {
            context.Movies.Remove(movie);

            await context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }
}