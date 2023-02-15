using Education.Domain;
using Education.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.Cursos.Queries.Get
{
    public class GetCursoByIdQuery
    {
        public class GetCursoByIdQueryRequest : IRequest<List<Curso>> { }
        public class GetCursoByIdQueryHandle : IRequestHandler<GetCursoByIdQueryRequest, List<Curso>>
        {
            private readonly EducationDbContext _context;
            public GetCursoByIdQueryHandle(EducationDbContext context)
            {
                _context = context;
            }

            public Task<List<Curso>> Handle(GetCursoByIdQueryRequest request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
