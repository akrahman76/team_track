using System;
using System.Collections.Generic;
using System.Text;
using TeamTrack.Domain.Common;

namespace TeamTrack.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; private set; } = default!;

        private User() { }

        public User(string email)
        {
            Email = email;
        }
    }
}
