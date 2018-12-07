using AutoMapper;
using CourseProject.Core.Contracts.Glossary.Models;
using CourseProject.Domain.Entities;
using System.Collections.Generic;

namespace CourseProject.Core.Implementation.Glossary.Mapping
{
    public class GlossaryMappingProfile : Profile
    {
        public GlossaryMappingProfile()
        {
            CreateMap<GlossaryItem, GlossaryItemModel>();
        }
    }
}
