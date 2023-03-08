using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.PlayCollector.Model
{
    public class TypeOFDocumentConfig : IEntityTypeConfiguration<TypeOfDocument>
    {
        public void Configure(EntityTypeBuilder<TypeOfDocument> entity)
        {
            entity.HasIndex(m => m.Name).HasDatabaseName("idx_MediaItemName");
            entity.Property(m => m.Name).IsRequired().HasColumnType("nvarchar(50)");
        }
    }
}
