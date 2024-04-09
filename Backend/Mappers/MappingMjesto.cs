using AutoMapper;
using Backend.Models;


namespace Backend.Mappers
{
    public class MappingMjesto : Mapping<Mjesto, MjestoDTORead, MjestoDTOInsertUpdate>
    {

        public MappingMjesto()
        {
            MapperMapReadToDTO = new Mapper(new MapperConfiguration(c => {
                c.CreateMap<Mjesto, MjestoDTORead>()
                .ConstructUsing(entitet =>
                 new MjestoDTORead(
                    entitet.Sifra,
                    entitet.Naziv));
                   
            }));

            MapperMapInsertUpdatedFromDTO = new Mapper(new MapperConfiguration(c => {
                c.CreateMap<MjestoDTOInsertUpdate, Mjesto>();
            }));

            MapperMapInsertUpdateToDTO = new Mapper(new MapperConfiguration(c => {
                c.CreateMap<Mjesto, MjestoDTOInsertUpdate>()
                .ConstructUsing(entitet =>
                 new MjestoDTOInsertUpdate(
                    entitet.Naziv));
            }));
        }



    }
}