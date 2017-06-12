using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IFieldService
    {
        FieldEntity GetField(int id);

        IEnumerable<FieldEntity> GetAllFields();
        IEnumerable<FieldEntity> GetSubFields(int? fieldId);

        int GetFieldSkillsCount(int fieldId);

        void CreateField(FieldEntity field);
        void DeleteBoard(FieldEntity field);
        void UpdateBoard(FieldEntity field);
    }
}
