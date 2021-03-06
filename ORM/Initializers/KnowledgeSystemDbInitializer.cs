﻿using ORM.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Helpers;

namespace ORM.Initializers
{
    public class KnowledgeSystemDbInitializer: CreateDatabaseIfNotExists<EntityModel>
    {
        protected override void Seed(EntityModel context)
        {

            #region Roles

            var roles = new List<Role>
            {
                new Role {Name = "Administrator", Description = "Administrator"},
                new Role {Name = "Moderator", Description = "Moderator"},
                new Role {Name = "User", Description = "User"}
            };

            #endregion

            context.Roles.AddRange(roles);

            #region Users

            var users = new List<User>
            {
                new User
                {
                    Roles = roles,
                    Login = "admin",
                    Email = "admin@gmail.com",
                    Password = Crypto.HashPassword("111111"),
                    RegistrationDate = DateTime.Now
                },
                new User
                {
                    Roles = new List<Role> {roles[2]},
                    Login = "eva",
                    Email = "eva@gmail.com",
                    Password = Crypto.HashPassword("111111"),
                    RegistrationDate = DateTime.Now
                }
            };

            #endregion

            context.Users.AddRange(users);

            #region Fields

            var fields = new List<Field>
            {
                new Field
                {
                    Name = "Web Development"
                },
                new Field
                {
                    Name = "Mobile Development"
                }
            };

            #endregion

            #region SubFields

            fields.Find(f => f.Name == "Web Development").
                SubFields = new List<Field>
                {
                    new Field
                    {
                        Name = "Front-End"
                    },
                    new Field
                    {
                        Name = "Back-End"
                    }
                };

            #endregion

            #region Skills

            fields.Find(b => b.Name == "Web Development")
                .Skills = new List<Skill>
            {
                new Skill
                {
                    Subject = "jQuery",
                    Ratings = new List<Rating>
                    {
                        new Rating
                        {
                            User = users[0],
                            Value = 0
                        },
                        new Rating
                        {
                            User = users[1],
                            Value = 1
                        },
                    }
                }
            };


            #endregion

            context.Fields.AddRange(fields);

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
