using AutoMapper;
using Backend.Models;
using System.Text.RegularExpressions;

namespace Backend.Mappers
{
    public class RelacijaMapper : Mapping<Relacija, RelacijaDTORead, RelacijaDTOInsertUpdate>
    {

        public RelacijaMapper()
        {
            MapperMapReadToDTO = new Mapper(new MapperConfiguration(c => {
                c.AllowNullDestinationValues = true;
                c.CreateMap<Relacija, RelacijaDTORead>()
                .ConstructUsing(entitet =>
                 new RelacijaDTORead(
                    entitet.Sifra,
                    entitet.Polaziste.Naziv,
                    entitet.Odrediste.Naziv,
                    entitet.Cijena

                    ));
            }));

            MapperMapInsertUpdatedFromDTO = new Mapper(new MapperConfiguration(c => {
                c.CreateMap<RelacijaDTOInsertUpdate, Relacija>();
            }));

            MapperMapInsertUpdateToDTO = new Mapper(new MapperConfiguration(c => {
                c.CreateMap<Relacija, RelacijaDTOInsertUpdate>()
                .ConstructUsing(entitet =>
                 new RelacijaDTOInsertUpdate(
                    entitet.Polaziste.Sifra,
                    entitet.Odrediste.Sifra,
                    entitet.Cijena
                    

                     ));
            }));

        }

    }
}