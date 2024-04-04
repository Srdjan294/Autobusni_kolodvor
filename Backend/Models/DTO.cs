using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
        public record MjestoDTORead(int Sifra, string? Naziv);
        public record MjestoDTOInsertUpdate(
    [Required(ErrorMessage = "Naziv obavezno")]
        string? Naziv);

}
