using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Todos.Commands.UpdateTodo
{
    public class UpdateTodoCommandValidator : AbstractValidator<UpdateTodoCommand>
    {
        public UpdateTodoCommandValidator()
        {
            RuleFor(x=>x.Title).NotEmpty().WithMessage("Title should not be empty");

            RuleFor(x => x.Id).NotEmpty().WithMessage("Id should not be empty");
        }
    }
}
