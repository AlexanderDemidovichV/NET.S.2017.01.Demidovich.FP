using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using DAL.Interface.Interface.Repository;
using DAL.Mappers;
using ORM.Entities;
using DAL.Visitor;

namespace DAL.Concrete
{
    public class RatingRepository: IRatingRepository
    {
        #region Fields

        private readonly DbContext context;

        #endregion

        #region Constructor

        public RatingRepository(DbContext context)
        {
            this.context = context;
        }

        #endregion

        #region Public Methods

        public void Create(DalRating entity)
        {
            context.Set<Rating>()
                .Add(entity.ToOrmRating());
        }

        public void Delete(DalRating entity)
        {
            var ratingToDelete = context.Set<Rating>().Single(r => r.Id == entity.Id);
            context.Set<Rating>().Remove(ratingToDelete);
        }

        public IEnumerable<DalRating> GetAll()
        {
            return context.Set<Rating>()
                .ToList()
                .Select(r => r.ToDalRating());
        }

        public DalRating GetById(int id)
        {
            return context.Set<Rating>()
                .FirstOrDefault(r => r.Id == id)
                ?.ToDalRating();
        }

        public DalRating GetByPredicate(Expression<Func<DalRating, bool>> predicate)
        {
            var newPredicate = predicate.Convert<DalRating, Rating>();

            return context.Set<Rating>()
                .FirstOrDefault(newPredicate)
                ?.ToDalRating();
        }

        public void Update(DalRating entity)
        {
            var oldRating = context.Set<Rating>()
                .FirstOrDefault(r => r.Id == entity.Id);

            oldRating.Value = entity.Value;

            context.Entry(oldRating).State = EntityState.Modified;
        }

        #endregion
    }
}
