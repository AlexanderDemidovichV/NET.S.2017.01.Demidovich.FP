﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using DAL.Mappers;
using DAL.NLog;
using ORM.Entities;
using DAL.Visitor;

namespace DAL.Concrete
{
    public class UserRepository : IUserRepository
    {
        #region Fields

        private readonly DbContext context;
        private readonly ILogger logger;

        #endregion

        #region Constructor

        public UserRepository(DbContext context, ILogger logger)
        {
            this.context = context;
            this.logger = logger;
        }

        #endregion

        #region Public methods

        public DalUser GetById(int id)
        {
            logger.Info($"{nameof(id)} => {id}");

            return context.Set<User>()
                .FirstOrDefault(user => user.Id == id)
                ?.ToDalUser();
        }

        public DalUser GetByPredicate(Expression<Func<DalUser, bool>> predicate)
        {
            logger.Info($"{nameof(predicate)} => {predicate.ToString()}");

            var newPredicate = predicate.Convert<DalUser, User>();

            return context.Set<User>()
                .FirstOrDefault(newPredicate)
                ?.ToDalUser();
        }

        public IEnumerable<DalUser> GetAll()
        {

            return context.Set<User>()
                .ToList()
                .Select(user => user.ToDalUser());
        }

        public void Create(DalUser user)
        {
            logger.Info($"{nameof(user)} => login:{user.Id} login:{user.Login} email:{user.Email}");

            context.Set<User>()
                .Add(user.ToOrmUser());
        }

        public void Delete(DalUser user)
        {
            logger.Info($"{nameof(user)} => login:{user.Id} login:{user.Login} email:{user.Email}");

            var userToDelete = context.Set<User>().Single(u => u.Id == user.Id);
            context.Set<User>().Remove(userToDelete);
        }

        public void Update(DalUser user)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
