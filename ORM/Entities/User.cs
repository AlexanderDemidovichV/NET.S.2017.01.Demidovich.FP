﻿using System;
using System.Collections.Generic;

namespace ORM.Entities
{
    public class User
    {
        public User()
        {
            Roles = new HashSet<Role>();
            Ratings = new List<Rating>();
        }

        public int Id { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime RegistrationDate { get; set; }

        public virtual Profile Profile { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
