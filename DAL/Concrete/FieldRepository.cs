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
    public class FieldRepository : IFieldRepository
    {
        #region Fields

        private readonly DbContext context;

        #endregion

        #region Constructor

        public FieldRepository(DbContext context)
        {
            this.context = context;
        }

        #endregion

        #region Public methods

        public void Create(DalField field)
        {
            context.Set<Field>()
                .Add(field.ToOrmField());
        }


        public IEnumerable<DalField> GetAll()
        {
            return context.Set<Field>()
                .ToList()
                .Select(field => field.ToDalField());
        }

        public DalField GetById(int id)
        {
            var field = context.Set<Field>()
                .FirstOrDefault(f => f.Id == id)
                ?.ToDalField();

            if (field == null)
                return null;

            field.Skills = context.Set<Skill>()
                .Where(s => s.FieldId == field.Id)
                .ToList()
                .Select(s => s.ToDalSkill());

            return field;
        }

        public DalField GetByPredicate(Expression<Func<DalField, bool>> predicate)
        {
            var newPredicate = predicate.Convert<DalField, Field>();

            return context.Set<Field>()
                .FirstOrDefault(newPredicate)
                ?.ToDalField();
        }

        public void Delete(DalField entity)
        {
            throw new NotImplementedException();
        }

        public int GetFieldSkillsCount(int fieldId)
        {
            var field = context.Set<Field>().FirstOrDefault(f => f.Id == fieldId);

            if (ReferenceEquals(field, null))
                return 0;

            int count = field.Skills.Count;

            return count;
        }

        public void Update(DalField entity)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
