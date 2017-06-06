using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IFieldService
    {
        FieldEntity GetField(int id);

        IEnumerable<FieldEntity> GetAllFields();

        int GetFieldSkillsCount(int fieldId);

        void CreateField(FieldEntity field);
        void DeleteBoard(FieldEntity field);
        void UpdateBoard(FieldEntity field);
    }
}
