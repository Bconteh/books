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
                    .ForMember(m => m.Books,
                        m => m.MapFrom(p => p.Books
                            .Select(i => i.Title)
                            .OrderBy(i => i)));

                c.CreateMap<Book, BookDTO>();
            });

            return config.CreateMapper();
        }
    }
}
