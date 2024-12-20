using Microsoft.AspNetCore.Mvc;
using SwaggerApp.Models;

namespace SwaggerApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LotController : ControllerBase
    {
        /// <summary>
        /// Получаем список лотов
        /// </summary>
        /// <returns>Список лотов</returns>
        /// <response code="201">Возвращает список доступных лотов</response>
        /// <response code="400">Если вернулся null</response>
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [Produces("application/json")]
        [HttpGet]
        public IActionResult Get()
        {
            var res = GetLots().ToList();
            if(res == null) return NotFound();

            return Ok(res);
        }

        /// <summary>
        /// Получаем нужный лот
        /// </summary>
        /// <param name="id">Идентификатор лота</param>
        /// <returns>Возвращает выбранный лот</returns>
        [Produces("application/json")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var res = GetLots().Find(x => x.Id == id);
            if(res == null) return NotFound();
            return Ok(res);
        }


        internal List<Lot> GetLots()
        {
            return new List<Lot>
            {
                new Lot
                {
                    Id = 1,
                    Title = "Antique Vase",
                    Description = "A beautiful antique vase from the 18th century.",
                    Price = 250.00m,
                    Costume = null,
                    Tags = new List<string> { "Antique", "Vase", "Decoration" }
                },
                new Lot
                {
                    Id = 2,
                    Title = "Vintage Watch",
                    Description = "Classic vintage watch in excellent condition.",
                    Price = 500.00m,
                    Costume = null,
                    Tags = new List<string> { "Vintage", "Watch", "Luxury" }
                },
                new Lot
                {
                    Id = 3,
                    Title = "Handmade Wooden Chair",
                    Description = "A handcrafted wooden chair made from oak.",
                    Price = 120.00m,
                    Costume = null,
                    Tags = new List<string> { "Handmade", "Furniture", "Chair" }
                },
                new Lot
                {
                    Id = 4,
                    Title = "Limited Edition Comic Book",
                    Description = "Rare limited edition comic book.",
                    Price = 75.00m,
                    Costume = null,
                    Tags = new List<string> { "Comic", "Limited Edition", "Rare" }
                },
                new Lot
                {
                    Id = 5,
                    Title = "Old School Vinyl Record",
                    Description = "Classic vinyl record from the 80s.",
                    Price = 30.00m,
                    Costume = null,
                    Tags = new List<string> { "Vinyl", "Music", "Classic" }
                },
                new Lot
                {
                    Id = 6,
                    Title = "Gold Necklace",
                    Description = "Beautiful 18k gold necklace.",
                    Price = 800.00m,
                    Costume = null,
                    Tags = new List<string> { "Jewelry", "Gold", "Necklace" }
                },
                new Lot
                {
                    Id = 7,
                    Title = "Painting by Famous Artist",
                    Description = "A masterpiece by a well-known artist.",
                    Price = 5000.00m,
                    Costume = null,
                    Tags = new List<string> { "Painting", "Art", "Masterpiece" }
                },
                new Lot
                {
                    Id = 8,
                    Title = "Set of Porcelain Dishes",
                    Description = "Complete set of porcelain dishes for dinner.",
                    Price = 200.00m,
                    Costume = null,
                    Tags = new List<string> { "Porcelain", "Dishes", "Tableware" }
                },
                new Lot
                {
                    Id = 9,
                    Title = "Gaming Console",
                    Description = "Latest generation gaming console.",
                    Price = 400.00m,
                    Costume = null,
                    Tags = new List<string> { "Gaming", "Console", "Electronics" }
                },
                new Lot
                {
                    Id = 10,
                    Title = "Sports Bicycle",
                    Description = "Lightweight and durable sports bicycle.",
                    Price = 1500.00m,
                    Costume = null,
                    Tags = new List<string> { "Bicycle", "Sports", "Fitness" }
                }
            };
        }
    }
}
