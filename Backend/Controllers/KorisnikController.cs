using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class KorisnikController:ControllerBase
    {
        // Dependency injection
        // Definiraš privatno svojstvo
        private readonly EdunovaContext _context;

        // Dependency injection
        // U konstruktoru primir instancu i dodjeliš privatnom svojstvu
        public KorisnikController(EdunovaContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(_context.Korisnici.ToList());
        }

        [HttpPost]
        public IActionResult Post(Korisnik korisnik)
        {
            _context.Korisnici.Add(korisnik);
            _context.SaveChanges();
            return new JsonResult(korisnik);
        }

        [HttpPut]
        [Route("{sifra:int}")]
        public IActionResult Put(int sifra, Korisnik korisnik)
        {
            var korisnikIzBaze = _context.Korisnici.Find(sifra);
            // za sada ručno, kasnije će doći Mapper
            korisnikIzBaze.Ime = korisnik.Ime;
            korisnikIzBaze.Prezime = korisnik.Prezime;
            korisnikIzBaze.Email = korisnik.Email;
            korisnikIzBaze.BrojMobitela = korisnik.BrojMobitela;

            _context.Korisnici.Update(korisnikIzBaze);
            _context.SaveChanges();

            return new JsonResult(korisnikIzBaze);
        }

        [HttpDelete]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int sifra)
        {
            var korisnikIzBaze = _context.Korisnici.Find(sifra);
            _context.Korisnici.Remove(korisnikIzBaze);
            _context.SaveChanges();
            return new JsonResult(new { poruka="Obrisano"});
        }

    }
}
