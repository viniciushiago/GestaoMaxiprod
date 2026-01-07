using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoMaxiprod.Infrastructure.Persistence.Configurations
{
    //Responsável por mapeamento da entidade Transaction
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            //Define o nome da tabela
            builder.ToTable("Transactions");

            //Define a chave primária
            builder.HasKey(x => x.Id);
            //Configura o ID como auto incremento
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            //Define que Description é obrigatório e com tamanho máximo de 200
            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(200);

            //Define que Amount é obrigatório, e que trabalhe com precisão os valores decimais
            builder.Property(x => x.Amount)
                .IsRequired()
                .HasPrecision(18, 2);

            //Define que type é obrigatório
            builder.Property(x => x.Type)
                .IsRequired();

            //Uma pessoa pode ter muitas Transações, PersonId como chave estrangeira, e se a pessoa for excluida as transações associadas a ela também serão
            builder.HasOne(x => x.Person)
                .WithMany(x => x.Transaction)
                .HasForeignKey(x => x.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            //Define que as transações podem ter apenas uma categoria, CategoriaId é a chave estrangeira,
            //e impede que a categoria seja excluida mesmo com alguma transação associada a ela
            builder.HasOne(x => x.Category)
                .WithMany()
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
