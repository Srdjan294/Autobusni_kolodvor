using System.ComponentModel.DataAnnotations.Schema;

using Backend.Models;

namespace Backend
{
    public class Mjesto : Entitet
    {
        public string? Naziv { get; set; }
    }
}