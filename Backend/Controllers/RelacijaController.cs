using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Backend.Data;
using Backend.Mappers;




namespace Backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RelacijaController : EdunovaController<Relacija, RelacijaDTORead, RelacijaDTOInsertUpdate>
    {
        public RelacijaController(EdunovaContext context) : base(context)
        {
            DbSet = _context.Relacije;
            _mapper = new MappingRelacija();
        }
        protected override void KontrolaBrisanje(Relacija entitet)
        {
            if (entitet != null && entitet.Mjesto != null && entitet.Mjesta.Count() > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Mjesto se ne može obrisati jer su na njemu relacije: ");
                foreach (var e in entitet.Mjesta)
                {
                    sb.Append(e.Ime).Append(' ').Append(e.Prezime).Append(", ");
                }

                throw new Exception(sb.ToString()[..^2]);
            }
        }

        protected override Relacija KreirajEntitet(RelacijaDTOInsertUpdate dto)
        {
            var polaziste = _context.Relacije.Find(dto.MjestoSifra) ?? throw new Exception("Ne postoji polazište s šifrom " + dto.MjestoSifra + " u bazi");
            var odrediste = _context.Relacije.Find(dto.MjestoSifra) ?? throw new Exception("Ne postoji odredište s šifrom " + dto.MjestoSifra + " u bazi");
            var cijena = _context.Relacije.Find(dto.CijenaSifra);
            var entitet = _mapper.MapInsertUpdatedFromDTO(dto);
            entitet.Mjesta = []; // može i new List<Polaznik>()
            entitet.Odrediste = odrediste;
            entitet.Polaziste = polaziste;
            entitet.Cijena = cijena;
            return entitet;
        }

        protected override List<RelacijaDTORead> UcitajSve()
        {
            var lista = _context.Relacije
                    .Include(g => g.Polaziste)
                    .Include(g => g.Odrediste)
                    .Include(g => g.Cijena)
                    .ToList();
            if (lista == null || lista.Count == 0)
            {
                throw new Exception("Ne postoje podaci u bazi");
            }
            return _mapper.MapReadList(lista);
        }

        protected override Relacija NadiEntitet(int sifra)
        {
            return _context.Relacije.Include(i => i.Mjesto).Include(i => i.Predavac)
                    .Include(i => i.Polaznici).FirstOrDefault(x => x.Sifra == sifra) ?? throw new Exception("Ne postoji relacija s šifrom " + sifra + " u bazi");
        }



        protected override Relacija PromjeniEntitet(RelacijaDTOInsertUpdate dto, Relacija entitet)
        {
            var polaziste = _context.Mjesta.Find(dto.MjestoSifra) ?? throw new Exception("Ne postoji mjesto s šifrom " + dto.MjestoSifra + " u bazi");
            var odrediste = _context.Mjesta.Find(dto.MjestoSifra) ?? throw new Exception("Ne postoji mjesto s šifrom " + dto.MjestoSifra + " u bazi");
            var cijena = _context.Mjesta.Find(dto.Cijena);


            /*
            List<Polaznik> polaznici = entitet.Polaznici;
            entitet = _mapper.MapInsertUpdatedFromDTO(dto);
            entitet.Polaznici = polaznici;
            */

            // ovdje je možda pametnije ići s ručnim mapiranje
            entitet.Odrediste = dto.Odrediste;
            entitet.Polaziste = dto.Polaziste;
            entitet.Cijena = dto.Cijena;
           

            return entitet;
        }
    }
}