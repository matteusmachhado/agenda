using Agenda.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Data.Mappings
{
    public class VerificationCodeMapping : IEntityTypeConfiguration<VerificationCode>
    {
        public void Configure(EntityTypeBuilder<VerificationCode> builder)
        {
            builder.ToTable("tb_verificationcodes");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.CreateDate)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(t => t.TypeCheck)
               .IsRequired()
               .HasColumnType("int");

            builder.Property(t => t.Code)
                .IsRequired()
                .HasColumnType("varchar(8)");

            builder.Property(t => t.PhoneNumber)
                .HasColumnType("varchar(50)");

            builder.Property(t => t.Email)
                .HasColumnType("varchar(100)");

            builder.Property(t => t.DateCheck)
                .HasColumnType("datetime");
        }
    }
}
