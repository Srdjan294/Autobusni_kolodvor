﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Korisnik:Entitet
    {
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public string? Email { get; set; }
        public string? BrojMobitela { get; set; }
    }
}
