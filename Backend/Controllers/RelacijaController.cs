using Backend.Data;
using Backend.Models;
using Backend.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RelacijaController : EdunovaController<Relacija, RelacijaDTORead, RelacijaDTOInsertUpdate>
    {
        public RelacijaController(EdunovaContext context) : base(context)
        {
            DbSet = _context.Relacije;
            _mapper = new RelacijaMapper();
        }
        protected override void KontrolaBrisanje(Relacija entitet)
        {

        }

        protected override Relacija KreirajEntitet(RelacijaDTOInsertUpdate dto)
        {
            var polaziste = _context.Mjesta.Find(dto.PolazisteSifra) ?? throw new Exception("Ne postoji polazište s šifrom " + dto.PolazisteSifra + " u bazi");
            var odrediste = _context.Mjesta.Find(dto.OdredisteSifra) ?? throw new Exception("Ne postoji odredište s šifrom " + dto.OdredisteSifra + " u bazi");
          //  var cijena = _context.Relacije.Find(dto.Cijena) ?? throw new Exception("Nema cijene");
            var entitet = new Relacija
            {
                Polaziste = polaziste,
                Odrediste = odrediste,
                Cijena = dto.Cijena
            };

            entitet.Polaziste = polaziste;
            entitet.Odrediste = odrediste;
            entitet.Cijena = dto.Cijena;
            return entitet;
        }

        protected override List<RelacijaDTORead> UcitajSve()
        {
            var lista = _context.Relacije
                    .Include(g => g.Polaziste)
                    .Include(g => g.Odrediste)
                    .ToList();
            if (lista == null || lista.Count == 0)
            {
                throw new Exception("Ne postoje podaci u bazi");
            }
            return _mapper.MapReadList(lista);
        }

        protected override Relacija NadiEntitet(int sifra)
        {
            return _context.Relacije.Include(g => g.Polaziste)
                    .Include(g => g.Odrediste)
                   // .Include(g => g.Cijena)
                    .FirstOrDefault(x => x.Sifra == sifra) ?? throw new Exception("Ne postoji relacija s šifrom " + sifra + " u bazi");
        }



        protected override Relacija PromjeniEntitet(RelacijaDTOInsertUpdate dto, Relacija entitet)
        {
            var polaziste = _context.Mjesta.Find(dto.PolazisteSifra) ?? throw new Exception("Ne postoji polaziste s šifrom " + dto.PolazisteSifra + " u bazi");
            var odrediste = _context.Mjesta.Find(dto.OdredisteSifra) ?? throw new Exception("Ne postoji odredište s šifrom " + dto.OdredisteSifra + " u bazi");
            //var cijena = _context.Relacije.Find(dto.Cijena) ?? throw new Exception("Nema cijene");


       

            // ovdje je možda pametnije ići s ručnim mapiranje
            entitet.Polaziste = polaziste;
            entitet.Odrediste = odrediste;
            entitet.Cijena = dto.Cijena;

            return entitet;
        }
    }
}