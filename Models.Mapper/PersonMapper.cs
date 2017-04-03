using AutoMapperDemo.Model;
using System;

namespace Models.Mapper
{
    public class PersonMapper : AutoMapper.Profile
    {
        public PersonMapper()
        {
            CreateMap<Person, PersonDtos>()
                  .ForMember(dto => dto.Age, option => option.Ignore())
                  .ForMember(dto => dto.Name2, option => option.MapFrom(s => s.Name));
        }
    }
}
