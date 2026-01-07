using GestaoMaxiprod.Domain.Entities;
using GestaoMaxiprod.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    //Entidade de transações
    public class Transaction
    {
        public long Id { get; private set; }
        public decimal Amount { get; private set; }
        public string Description { get; private set; }
        public TransactionType Type { get; private set; }

        public long CategoryId { get; private set; }
        public Category Category { get; private set; }

        public long PersonId { get; private set; }
        public Person Person { get; private set; }

        protected Transaction() { }

        public Transaction(string description, decimal amount, TransactionType type, Person person, Category category)
        {
            Validate(description, amount, type, person, category);

            Description = description;
            Amount = amount;
            Type = type;
            Person = person;
            PersonId = person.Id;
            Category = category;
            CategoryId = category.Id;
        }

        //Validador de todos os campos e regras de negócio
        private static void Validate(
           string description,
           decimal amount,
           TransactionType type,
           Person person,
           Category category)
        {
            //Regra: descrição não pode ser vazia.
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Descrição é obrigatória.");

            // Regra: valor deve ser positivo
            if (amount <= 0)
                throw new ArgumentException("Valor deve ser positivo.");

            // Regra: menor de idade só pode ter despesa
            if (person.Age < 18 && type == TransactionType.Income)
                throw new InvalidOperationException(
                    "Menores de idade não podem registrar receitas.");

            // Regra: categoria deve ser compatível com o tipo da transação
            if (type == TransactionType.Expense &&
                category.CategoryPurpose == CategoryPurpose.Income)
                throw new InvalidOperationException(
                    "Categoria de receita não pode ser usada em despesa.");

            // Regra: categoria deve ser compatível com o tipo da transação
            if (type == TransactionType.Income &&
                category.CategoryPurpose == CategoryPurpose.Expense)
                throw new InvalidOperationException(
                    "Categoria de despesa não pode ser usada em receita.");
        }
    
    }
}
