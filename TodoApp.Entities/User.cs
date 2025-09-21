using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        // Şifreyi asla metin olarak saklamayacağız.
        public byte[] PasswordHash { get; set; } = new byte[0];
        public byte[] PasswordSalt { get; set; } = new byte[0];

        // Navigation Properties (İlişkisel Bağlantılar)
        public virtual ICollection<Todo> Todos { get; set; } = new List<Todo>();
        public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
    }
}
