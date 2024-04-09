
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Relacija:Entitet
    {
        [ForeignKey("polaziste")] 
        public Mjesto? Polaziste { get; set; }

        [ForeignKey("odrediste")]
        public Mjesto? Odrediste { get; set; }
        public decimal? Cijena { get; set; }
    }
}
