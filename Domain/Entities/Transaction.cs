using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Transaction
    {
        public long Id { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime Date { get; private set; }

        public long PersonId { get; private set; }
        public Person Person { get; private set; }

        protected Transaction() { }

        public Transaction(decimal amount, DateTime date)
        {
            if(amount <= 0)
            {
                throw new ArgumentException("Valor da transação deve ser positivo");
            }

            Amount = amount;
            Date = date;
        }
    }
}
