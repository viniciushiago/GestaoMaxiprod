using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    //Responsável pelo mapeamento da Entidade Person
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            //Define o nome da tabela no banco
            builder.ToTable("Persons");

            //Chave primária
            builder.HasKey(x => x.Id);
            //Configura o Id como auto incremento
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            //Define que name é obrigatório e com tamanho máximo de 200
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);

            //Define que Age é obrigatório
            builder.Property(x => x.Age)
                .IsRequired();

            //Uma pessoa pode ter várias transações, Chave estrangeira PersonId, Ao excluir uma pessoa, todas as transações associadas serão excluidas
            builder.HasMany(x => x.Transaction)
                .WithOne(x => x.Person)
                .HasForeignKey(x => x.PersonId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
