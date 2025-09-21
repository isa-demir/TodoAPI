using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        // Foreign Key
        public Guid UserId { get; set; }

        // Navigation Properties
        public virtual User User { get; set; } = null!; // Her kategorinin bir sahibi olmalı.
        public virtual ICollection<Todo> Todos { get; set; } = new List<Todo>();
    }
}
