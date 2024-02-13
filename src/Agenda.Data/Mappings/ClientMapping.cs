using Agenda.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Data.Mappings
{
    public class ClientMapping : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("tb_clients");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                .HasColumnType("varchar(100)");

            builder.Property(t => t.Email)
                .HasColumnType("varchar(100)");

            builder.Property(t => t.PhoneNumber)
                .IsRequired()
                .HasColumnType("varchar(50)");
        }
    }
}
