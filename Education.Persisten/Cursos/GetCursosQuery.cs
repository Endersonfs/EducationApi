using Education.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Persistence.Cursos
{
    public class GetCursosQuery
    {
        public class GetCursosQueryRequest : IRequest<List<Curso>> { }
        public class GetCursosQueryHandle : IRequestHandler<GetCursosQueryRequest, List<Curso>>
        {
            private readonly EducationDbContext _context;
            public GetCursosQueryHandle(EducationDbContext context)
            {
                _context= context;
            }
            public async Task<List<Curso>> Handle(GetCursosQueryRequest request, CancellationToken cancellationToken)
            {
                var cursos = await _context.Cursos.ToListAsync();

                return cursos;
            }
        }


    }
}
