using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq.Expressions;

namespace Resorter.Infrastructure.Persistance.Configuration;

public abstract class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : class
{
    public abstract void Configure(EntityTypeBuilder<T> builder);

    protected void ConfigureBase<TProperty>
        (
            EntityTypeBuilder<T> builder,
            Expression<Func<T, TProperty>> propertyExpression,
            int maxLength
        )
    {
        builder.Property(propertyExpression)
            .IsRequired()
            .HasMaxLength(maxLength);
    }
    
}
