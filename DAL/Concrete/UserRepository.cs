using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using DAL.Mappers;
using ORM.Entities;
using DAL.Visitor;

namespace DAL.Concrete
{
    public class UserRepository : IUserRepository
    {
        #region Fields

        private readonly DbContext context;

        #endregion

        #region Constructor

        public UserRepository(DbContext context)
        {
            this.context = context;
        }

        #endregion

        #region Public methods

        public DalUser GetById(int id)
        {

            return context.Set<User>()
                .FirstOrDefault(user => user.Id == id)
                ?.ToDalUser();
        }

        public DalUser GetByPredicate(Expression<Func<DalUser, bool>> predicate)
        {

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
            context.Set<User>()
                .Add(user.ToOrmUser());
        }

        public void Delete(DalUser user)
        {
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
