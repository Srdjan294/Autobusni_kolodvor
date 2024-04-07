using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Racun:Entitet
    {
        [ForeignKey("korisnik")]
        public required Korisnik Korisnik { get; set; }
        public DateTime? DatumKupnje { get; set; }
    }
}
