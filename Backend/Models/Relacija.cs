
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Relacija:Entitet
    {
        [ForeignKey("mjesto")] 
        public Mjesto? Polaziste { get; set; }

        [ForeignKey("mjesto")]
        public Mjesto? Odrediste { get; set; }
        public decimal? Cijena { get; set; }
    }
}
