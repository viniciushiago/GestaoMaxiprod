using GestaoMaxiprod.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoMaxiprod.Domain.Entities
{
    //Entidade de categoria
    public class Category
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public CategoryPurpose CategoryPurpose { get; set; }

        //Construtor para o EF
        protected Category() { }

        //Construtor com a validação
        public Category(string description, CategoryPurpose categoryPurpose)
        {
            Validate(description);

            Description = description;
            CategoryPurpose = categoryPurpose;
        }

        //Faz a validação do campo
        private static void Validate(string description)
        {
            if(string.IsNullOrEmpty(description))
            {
                throw new ArgumentNullException("Descrição da categoria é obrigatória.");
            }
        }
    }
}
