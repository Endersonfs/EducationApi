using Education.Domain;
using Education.Persistence;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.Cursos.Commands.Create
{
    public class CreateCursoCommand
    {
        public class CreateCursoCommandRequest : IRequest 
        {
            public string Titulo { get; set;}
            public string Description { get; set; }
            public DateTime FechaPublicaion { get; set; }
            public Decimal Precio { get; set; }
        }
        //validaciones
        public class CreateCursoCommandRequestValidation : AbstractValidator<CreateCursoCommandRequest>
        {
            public CreateCursoCommandRequestValidation()
            {
                RuleFor(x => x.Description);
                RuleFor(x => x.Titulo);
                RuleFor(x => x.Precio);
            }
        }
        public class CreateCursoCommandHandler : IRequestHandler<CreateCursoCommandRequest>
        {
            private readonly EducationDbContext _context;
            public CreateCursoCommandHandler(EducationDbContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(CreateCursoCommandRequest request, CancellationToken cancellationToken)
            {
                var curso = new Curso
                {
                    CursoId = Guid.NewGuid(),
                    Titulo = request.Titulo,
                    Descripcion = request.Description,
                    FechaPublicacion = request.FechaPublicaion,
                    FechaCreacion= DateTime.UtcNow,
                };

                _context.AddAsync(curso);

                var valor =  await _context.SaveChangesAsync();

                if (valor > 0) 
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo agregar curso");
            }
        }
    }
}
