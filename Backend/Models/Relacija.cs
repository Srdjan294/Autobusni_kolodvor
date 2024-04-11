
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Relacija:Entitet
    {
        [ForeignKey("polaziste")] 
        public required Mjesto? Polaziste { get; set; }

        [ForeignKey("odrediste")]
        public required Mjesto? Odrediste { get; set; }
        public decimal? Cijena { get; set; }
    }
}
