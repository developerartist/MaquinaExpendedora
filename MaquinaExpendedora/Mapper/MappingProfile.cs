using AutoMapper;
using MaquinaExpendedora.DTO;
using MaquinaExpendedora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaquinaExpendedora.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductoDTO, Producto>();
        }
    }
}
