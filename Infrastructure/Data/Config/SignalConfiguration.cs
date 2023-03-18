using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class SignalConfiguration : IEntityTypeConfiguration<Signal>
    {
        public void Configure(EntityTypeBuilder<Signal> builder)
        {

            builder.Property(p => p.Id).UseIdentityAlwaysColumn();
            builder.Property(p => p.Name).HasMaxLength(100);

            builder.HasOne(b => b.SignalProtocol).WithMany()
            .HasForeignKey(pi => pi.SignalProtocolId);
        }
    }
}