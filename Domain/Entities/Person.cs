using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Domain.Entities
{
    //Entidade de pessoas
    public class Person
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        private readonly List<Transaction> _transaction = new();
        public IReadOnlyCollection<Transaction> Transaction => _transaction;

        protected Person() { }  
        
        public Person(string name,  int age)
        {
            Validate(name, age);

            Name = name;
            Age = age;
        }

        //Validador dos campos de pessoas
        public static void Validate(string name, int age)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }

            if (age < 0)
            {
                throw new ArgumentException("Idade deve ser um número positivo");
            }
        }
    }
}
