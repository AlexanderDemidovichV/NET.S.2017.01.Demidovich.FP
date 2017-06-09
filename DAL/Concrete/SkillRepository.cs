using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using DAL.Mappers;
using DAL.Visitor;
using ORM.Entities;

namespace DAL.Concrete
{
    public class SkillRepository : ISkillRepository
    {
        #region Fields

        private readonly DbContext context;

        #endregion

        #region Constructor

        public SkillRepository(DbContext context)
        {
            this.context = context;
        }

        #endregion

        public void Create(DalSkill skill)
        {
            context.Set<Skill>()
                .Add(skill.ToOrmSkill());
        }

        public IEnumerable<DalSkill> GetAll()
        {
            return context.Set<Skill>()
                .ToList()
                .Select(skill => skill.ToDalSkill());
        }

        public DalSkill GetById(int id)
        {
            var skill = context.Set<Skill>()
                .FirstOrDefault(s => s.Id == id)
                ?.ToDalSkill();

            if (skill == null)
                return null;

            skill.Ratings = context.Set<Rating>()
                .Where(r =>r.SkillId == skill.Id)
                .ToList()
                .Select(r => r.ToDalRating());

            return skill;
        }

        public DalSkill GetByPredicate(Expression<Func<DalSkill, bool>> predicate)
        {
            var newPredicate = predicate.Convert<DalSkill, Skill>();

            return context.Set<Skill>()
                .FirstOrDefault(newPredicate)
                ?.ToDalSkill();
        }

        public void Update(DalSkill entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(DalSkill entity)
        {
            throw new NotImplementedException();
        }
    }
}
