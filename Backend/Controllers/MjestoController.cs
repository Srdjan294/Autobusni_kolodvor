using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MjestoController:ControllerBase
    {
        private readonly EdunovaContext _context;

        public MjestoController(EdunovaContext context)
        {
            _context = context;
        }

        [HttpGet]

        public IActionResult Get()
        {
            return new JsonResult(_context.Mjesta.ToList());
        }

        [HttpPost]

        public IActionResult Post(Mjesto mjesto)
        {
            _context.Mjesta.Add(mjesto);
            _context.SaveChanges();
            return new JsonResult(mjesto);
        }

        [HttpPut]
        [Route("{sifra:int}")]

        public IActionResult Put(int sifra,Mjesto mjesto)
        {
            var mjestoIzBaze = _context.Mjesta.Find(sifra);

            mjestoIzBaze.Naziv = mjesto.Naziv;

            _context.Mjesta.Update(mjestoIzBaze);
            _context.SaveChanges();

            return new JsonResult(mjestoIzBaze);
        }

        [HttpDelete]
        [Route("{sifra:int}")]
        [Produces("application/json")]

        public IActionResult Delete(int sifra)
        {
            var mjestoIzBaze = _context.Mjesta.Find(sifra);
            _context.Mjesta.Remove(mjestoIzBaze);
            _context.SaveChanges();
            return new JsonResult(new { poruka = "Obrisano" });
        }
    }

}
