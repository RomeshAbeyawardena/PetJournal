using AutoMapper;
using PetJournal.Domains.Data;
using PetJournal.Domains.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetJournal.Domains
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<PetBreedViewModel, PetBreed>()
                .ForMember(member => member.PetType, memberOptions => memberOptions.Ignore());
            CreateMap<PetTypeViewModel, PetType>();
        }
    }
}
