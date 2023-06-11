using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateAppProject.Services.Extensions
{
    public static class MappingExtensions
    {
        public static Tout ConvertToDTO<Tin, Tout>(this Tin value, IMapper mapper)
        {
            return mapper.Map<Tout>(value);
        }
    }
}
