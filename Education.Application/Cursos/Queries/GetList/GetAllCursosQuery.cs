using AutoMapper;
using Education.Application.DTO;
using Education.Domain;
using Education.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.Cursos.Queries.GetList
{
    public class GetAllCursosQuery
    {
        public class GetAllCursosQueryRequest : IRequest<List<CursoDTO>> { }
        public class GetAllCursosQueryHandle : IRequestHandler<GetAllCursosQueryRequest, List<CursoDTO>>
        {
            private readonly EducationDbContext _context;
            private readonly IMapper _mapper;
            public GetAllCursosQueryHandle(EducationDbContext context, IMapper mapper)
            {
                    _context= context;
                    _mapper= mapper;    
            }
            public async Task<List<CursoDTO>> Handle(GetAllCursosQueryRequest request, CancellationToken cancellationToken)
            {
                var cursos = await _context.Cursos.ToListAsync();
                var cursosDTO = _mapper.Map<List<Curso>, List<CursoDTO>>(cursos); 
                return cursosDTO;
            }
        }
    }
}
