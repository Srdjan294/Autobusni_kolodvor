using AutoMapper;
using Backend.Mappers;
using Backend.Models;
using System.Text.RegularExpressions;

namespace Backend.Mappers
{
    public class MappingRelacija : Mapping<Relacija, RelacijaDTORead, RelacijaDTOInsertUpdate>
    {

        public MappingRelacija()
        {
            MapperMapReadToDTO = new Mapper(new MapperConfiguration(c => {
                c.CreateMap<Relacija, RelacijaDTORead>()
                .ConstructUsing(entitet =>
                 new RelacijaDTORead(
                    entitet.Sifra,
                    entitet.Polaziste == null ? "" : entitet.Mjesto.Naziv,
                    entitet.Odrediste,
                    entitet.Cijena));
            }));

            MapperMapInsertUpdatedFromDTO = new Mapper(new MapperConfiguration(c => {
                c.CreateMap<RelacijaDTOInsertUpdate, Relacija>();
            }));

            MapperMapInsertUpdateToDTO = new Mapper(new MapperConfiguration(c => {
                c.CreateMap<Relacija, RelacijaDTOInsertUpdate>()
                .ConstructUsing(entitet =>
                 new RelacijaDTOInsertUpdate(
                    entitet.Polaziste,
                    entitet.Odrediste,
                    entitet.Cijena));
            }));
        }



    }
}