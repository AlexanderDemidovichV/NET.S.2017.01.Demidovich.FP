using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.Repository;

namespace BLL.Services
{
    public class FieldService: IFieldService
    {
        #region Fields

        private readonly IUnitOfWork uow;
        private readonly IFieldRepository fieldRepository;

        #endregion

        #region Constructor

        public FieldService(IUnitOfWork uow, IFieldRepository fieldRepository)
        {
            this.uow = uow;
            this.fieldRepository = fieldRepository;
        }

        #endregion

        #region Public Methods

        public void CreateField(FieldEntity field)
        {
            fieldRepository.Create(field.ToDalField());
            uow.Commit();
        }

        public void DeleteBoard(FieldEntity field)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FieldEntity> GetSubFields(int? fieldId)
        {
            return fieldRepository.GetAll()
                .Where(f => f.ParentId == fieldId)
                .Select(f => f.ToBllField());
        }

        public IEnumerable<FieldEntity> GetAllFields()
        {
            return fieldRepository.GetAll()
                .Select(field => field.ToBllField());
        }

        public FieldEntity GetField(int id)
        {
            return fieldRepository.GetById(id)
                ?.ToBllField();
        }

        public int GetFieldSkillsCount(int fieldId)
        {
            return fieldRepository.GetFieldSkillsCount(fieldId);
        }

        public void UpdateBoard(FieldEntity field)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FieldEntity> GetFieldParents(int fieldId)
        {
            var field = fieldRepository.GetById(fieldId).ToBllField();
            var fieldParents = new List<FieldEntity>();

            while (field.ParentId != null)
            {
                field = fieldRepository.GetById(field.ParentId.GetValueOrDefault()).ToBllField();
                fieldParents.Add(field);
            }

            return fieldParents;
        }

        #endregion

    }
}
