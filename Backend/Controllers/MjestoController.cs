using Backend.Data;
using Backend.Models;
using Backend.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        }
    }

}
