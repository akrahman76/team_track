using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TeamTrack.Domain.Entity;

namespace TeamTrack.Infrastructure.Persistence.Configurations
{
    public class OrganizationMemberConfiguration : IEntityTypeConfiguration<OrganizationMember>
    {
        public void Configure(EntityTypeBuilder<OrganizationMember> builder)
        {
            builder.HasKey(m => m.Id);

            builder.HasIndex(m => new { m.OrganizationId, m.UserId })
                   .IsUnique();
        }
    }
}
