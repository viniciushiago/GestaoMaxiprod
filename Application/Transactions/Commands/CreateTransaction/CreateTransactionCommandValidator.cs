using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoMaxiprod.Application.Transactions.Commands.CreateTransaction
{
    public class CreateTransactionCommandValidator : AbstractValidator<CreateTransactionCommand>
    {
        // Faz a validações do campos antes de chegar no domínio
        public CreateTransactionCommandValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(x => x.Amount)
                .GreaterThan(0);

            RuleFor(x => x.Type)
                .IsInEnum();

            RuleFor(x => x.CategoryId)
                .GreaterThan(0);

            RuleFor(x => x.PersonId) 
                .GreaterThan(0);
        }
    }
}
