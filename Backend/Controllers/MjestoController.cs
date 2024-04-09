using Backend.Data;
using Backend.Models;
using Backend.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;


namespace Backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MjestoController : EdunovaController<Mjesto, MjestoDTORead, MjestoDTOInsertUpdate>
    {
        public MjestoController(EdunovaContext context) : base(context)
        {
            DbSet = _context.Mjesta;
        }

        protected override void KontrolaBrisanje(Mjesto entitet)
        {

            var lista = _context.Relacije
                .Include(x => x.Polaziste)
                .Include(x => x.Odrediste)
                .Where(x => x.Polaziste.Sifra == entitet.Sifra || x.Odrediste.Sifra == entitet.Sifra)
                .ToList();
            if (lista != null &&  lista.Count > 0) 
            {
                StringBuilder sb = new();
                sb.Append("Mjesto se ne može obrisati jer je postavljen na relacijama: ");
                foreach (var e in lista) 
                {
                    sb.Append(e.Polaziste).Append(", ");
                }
                throw new Exception(sb.ToString()[..^2]);
            }
        }
    }

}
