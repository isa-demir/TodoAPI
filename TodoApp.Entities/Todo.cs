using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Entities
{
    public class Todo : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; } // Açıklama zorunlu olmayabilir.
        public bool IsCompleted { get; set; }
        public DateTime? DueDate { get; set; } // Bitiş tarihi zorunlu olmayabilir.

        // Foreign Keys
        public Guid UserId { get; set; }
        public Guid? CategoryId { get; set; } // Kategori zorunlu olmayabilir.

        // Navigation Properties
        public virtual User User { get; set; } = null!;
        public virtual Category? Category { get; set; }
    }
}
