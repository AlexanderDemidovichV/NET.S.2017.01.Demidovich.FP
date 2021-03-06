﻿using System;

namespace DAL.Interface.DTO
{
    public class DalUser: IEntity
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
