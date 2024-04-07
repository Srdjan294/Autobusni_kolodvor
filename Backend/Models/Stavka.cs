using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Stavka:Entitet
    {
        [ForeignKey("racun")]
        public int? Racun { get; set; }

        [ForeignKey("relacija")]
        public int? Relacija { get; set; }
        public int? Kolicina { get; set; }
        public DateTime DatumPutovanja { get; set; }
    }
}
