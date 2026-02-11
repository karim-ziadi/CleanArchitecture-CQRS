using Domain.Todos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Todos.Queries.GetTodoById
{
    public sealed record GetTodoByIdQuery(Guid Id):IRequest<Todo?>;
}
