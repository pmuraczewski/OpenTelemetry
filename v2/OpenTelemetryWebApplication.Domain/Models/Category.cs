using System.Collections.Generic;

namespace OpenTelemetryWebApplication.Domain.Models
{
    public class Category : Entity
    {
        public string Name { get; set; }
        
        public IEnumerable<Book> Books { get; set; }
    }
}