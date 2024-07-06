using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gs.Data.Models;

public class IamOrganizationDomain
{
    public int Id { get; set; }

    public string Domain { get; set; } = string.Empty;

    public int OrganizationId { get; set; }

    public IamOrganization Organization { get; set; } = null!;
}

public class IamOrganizationDomainConfig : IEntityTypeConfiguration<IamOrganizationDomain>
{
    public IamOrganizationDomainConfig(bool schema = true)
    {
        this.Schema = schema;
    }

    public bool Schema { get; }

    public virtual void Configure(EntityTypeBuilder<IamOrganizationDomain> builder)
    {
        builder.Property(o => o.Domain)
            .HasMaxLength(256)
            .IsRequired();

        builder.HasOne(o => o.Organization)
            .WithMany(o => o.Domains)
            .HasForeignKey(o => o.OrganizationId)
            .IsRequired();

        if (this.Schema)
        {
            builder.ToTable("organization_domains", "iam");
            builder.HasIndex(o => o.Domain)
                .IsUnique()
                .HasDatabaseName("ix_organization_domains_domain");
        }
        else
        {
            builder.ToTable("iam_organization_domains");
            builder.HasIndex(o => o.Domain)
                .IsUnique()
                .HasDatabaseName("ix_iam_organization_domains_domain");
        }
    }
}