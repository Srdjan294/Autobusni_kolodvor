using Backend.Controllers;
using Backend.Data;
using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;

namespace EdunovaAPP.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class KorisnikController : EdunovaController<Korisnik, KorisnikDTORead, KorisnikDTOInsertUpdate>
    {
        public KorisnikController(EdunovaContext context) : base(context)
        {
            DbSet = _context.Korisnici;
        }
        protected override void KontrolaBrisanje(Korisnik entitet)
        {
            var lista = _context.Racuni
                .Include(x => x.Korisnik)
                .Where(x => x.Korisnik.Sifra == entitet.Sifra)
                .ToList();
            if (lista != null && lista.Count > 0)
            {
                StringBuilder sb = new();
                sb.Append("Korisnik se ne može obrisati jer ima račun: ");
                foreach (var e in lista)
                {
                    sb.Append(e.Sifra).Append(", ");
                }
                throw new Exception(sb.ToString()[..^2]); // umjesto sb.ToString().Substring(0, sb.ToString().Length - 2)
            }
        }

    }
}