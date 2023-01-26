using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MediaItemConfig : IEntityTypeConfiguration<Media>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Media> entity)
        {
            entity.HasIndex(m => m.Name).HasDatabaseName("idx_MediaItemName");
            entity.Property(m => m.Name).IsRequired().HasColumnType("nvarchar(50)");
            entity.Property(m => m.Uri).IsUnicode(false).HasColumnType("nvarchar(255)");

        }
    }
}
