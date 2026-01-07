using FluentValidation;
using GestaoMaxiprod.Application.Categories.Commands.CreateCategoryCommand;
using GestaoMaxiprod.Application.Persons.Commands.CreatePerson;
using GestaoMaxiprod.Application.Transactions.Commands.CreateTransaction;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace GestaoMaxiprod.Application
{
    public static class DependencyInjection
    {
        //A injeção de dependência fica de forma isolada e organizada apenas com o que é necessário para essa camada
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //Registra todos os Handles para que funcione o mediator
            services.AddMediatR(x =>
                x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            //Faz com que os validadores funcionem antes do dominio
            services.AddValidatorsFromAssemblyContaining<CreateCategoryCommandValidator>();
            services.AddValidatorsFromAssemblyContaining<CreateTransactionCommandValidator>();
            services.AddValidatorsFromAssemblyContaining<CreatePersonCommandValidator>();

            return services;
        }
    }
}
