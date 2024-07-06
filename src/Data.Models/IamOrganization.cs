using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gs.Data.Models;

public class IamOrganization
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Slug { get; set; } = string.Empty;

    public HashSet<IamUser> Users { get; set; } = new();

    public HashSet<IamOrganizationDomain> Domains { get; set; } = new();
}

public class IamOrganizationConfig : IEntityTypeConfiguration<IamOrganization>
{
    public IamOrganizationConfig(bool schema = true)
    {
        this.Schema = schema;
    }

    public bool Schema { get; }

    public virtual void Configure(EntityTypeBuilder<IamOrganization> builder)
    {
        builder.Property(o => o.Name)
            .HasMaxLength(256)
            .IsRequired();

        builder.Property(o => o.Slug)
            .HasMaxLength(256)
            .IsRequired();

        builder.HasMany(o => o.Users)
            .WithOne(o => o.Organization)
            .HasForeignKey(o => o.OrganizationId)
            .IsRequired();


        if (this.Schema)
        {
            builder.ToTable("organizations", "iam");
            builder.HasIndex(o => o.Slug)
                .IsUnique()
                .HasDatabaseName("ix_organizations_slug");
        }
        else
        {
            builder.ToTable("iam_organizations");
            builder.HasIndex(o => o.Slug)
                .IsUnique()
                .HasDatabaseName("ix_iam_organizations_slug");
        }

        builder.HasData(new IamOrganization() { Id = 1, Name = "root", Slug = "root", });
    }
}