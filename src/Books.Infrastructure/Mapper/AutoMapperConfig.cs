using AutoMapper;
using Books.Core.Domain;
using Books.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Books.Infrastructure.Mapper
{
    public static class AutoMapperConfig
    {
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Author, AuthorDTO>()
                    .ForMember(dest => dest.Books, m => m.MapFrom(src => src.Books.OrderBy(i => i.Title)));

                c.CreateMap<Book, BookDTO>();
            });

            return config.CreateMapper();
        }
    }
}
