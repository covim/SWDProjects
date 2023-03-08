using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Swd.PlayCollector.Model;

public class CollectionItem
{
    public int Id { get; set; }
    
    [MaxLength(50)]
    [NotNull]
    public string Name { get; set; }
    
    [MaxLength(50)]
    public string Number { get; set; }
    
    public int ReleaseYear { get; set; }

    public Location Location { get; set; }
    
    public Theme Theme { get; set; }
}