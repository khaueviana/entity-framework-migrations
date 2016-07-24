using System;

namespace KV.Ef6Migrations.Domain.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
    }
}