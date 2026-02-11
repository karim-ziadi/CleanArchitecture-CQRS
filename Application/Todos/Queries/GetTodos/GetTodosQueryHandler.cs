using Application.Common.Interfaces;
using Domain.Todos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Todos.Queries.GetTodos
{
    public sealed class GetTodoByIdQueryHandler(IAppDbContext context) : IRequestHandler<GetTodosQuery, List<Todo>>
    {
        public async Task<List<Todo>> Handle(GetTodosQuery request, CancellationToken cancellationToken)
        {
            var todos = await context.Todos.ToListAsync(cancellationToken);
            return todos;   
        }
    }
}
