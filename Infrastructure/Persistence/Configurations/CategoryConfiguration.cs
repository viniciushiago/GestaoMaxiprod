using GestaoMaxiprod.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoMaxiprod.Infrastructure.Persistence.Configurations
{
    //Reponsável por mapeamento da entidde Category
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //Nome da tabela no banco
            builder.ToTable("Categories");
            //Chave primária
            builder.HasKey(x => x.Id);
            //Configura o Id com auto incremento
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            //Define o tamanho de Description como 200 e um campo obrigatório
            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(200);

            //Mapeia o Enum como inteiro no banco, e define o campo como obrigatório
            builder.Property(x => x.CategoryPurpose)
                .IsRequired()
                .HasConversion<int>();
        }
    }
}
