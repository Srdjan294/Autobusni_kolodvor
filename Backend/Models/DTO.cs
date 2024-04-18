using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
        public record MjestoDTORead(int Sifra, string? Naziv);
        public record MjestoDTOInsertUpdate(
        [Required(ErrorMessage = "Naziv obavezno")]
        string? Naziv);



        public record KorisnikDTORead(int Sifra, string? Ime, string? Prezime, string? Email, string? BrojMobitela);

        public record KorisnikDTOInsertUpdate(
            [Required (ErrorMessage = "Ime obavezno")]
            string? Ime,

            [Required (ErrorMessage = "Prezime obavezno")]
            string? Prezime,

            [Required (ErrorMessage = "Email obavezan")]
            string? Email,

            [Required (ErrorMessage = "Broj mobitela obavezan")]
            string BrojMobitela);
    



        public record RacunDTORead(int Sifra, int? Korisnik, DateTime? DatumKupnje);

        public record RacunDTOInsertUpdate(
            [Required(ErrorMessage = "Korisnik obavezan")]
            int? Korisnik,
            [Required(ErrorMessage = "Datum kupnje obavezan")]
            DateTime? DatumKupnje
            );

        

        public record StavkaDTORead(int Sifra, int? Racun, int? Relacija, int? Kolicina, DateTime? DatumPutovanja);

            public record StavkaDTOInsertUpdate(
                [Required(ErrorMessage = "Račun obavezan")]
                int? Racun,
                [Required(ErrorMessage = "Relacija obavezna")]
                int? Relacija,
                [Required(ErrorMessage = "Količina obavezna")]
                int? Kolicina,
                [Required(ErrorMessage = "Datum putovanja obavezan")]
                DateTime? DatumPutovanja
                );



        public record RelacijaDTORead(int Sifra, string? PolazisteNaziv, string? OdredisteNaziv, decimal? Cijena);

         public record RelacijaDTOInsertUpdate(
             [Required(ErrorMessage = "Polazište obavezno")]
                string? PolazisteSifra,
             [Required(ErrorMessage = "Odredište obavezno")]
                string? OdredisteSifra,
             [Required(ErrorMessage = "Cijena obavezna")]
                decimal? Cijena
        );




}
