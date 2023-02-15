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
        public class GetAllCursosQueryRequest : IRequest<List<Curso>> { }
        public class GetAllCursosQueryHandle : IRequestHandler<GetAllCursosQueryRequest, List<Curso>>
        {
            private readonly EducationDbContext _context;
            public GetAllCursosQueryHandle(EducationDbContext context)
            {
                    _context= context;
            }
            public async Task<List<Curso>> Handle(GetAllCursosQueryRequest request, CancellationToken cancellationToken)
            {
                var cursos = await _context.Cursos.ToListAsync();
                return cursos;
            }
        }
    }
}
