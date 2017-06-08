using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IMarkService
    {
        MarkEntity GetMarkEntity(int id);
        IEnumerable<MarkEntity> GetSkillMarks(int skillId);

        void DeleteMark(int id);

        void CreateMark(MarkEntity mark);
        void DeleteMark(MarkEntity mark);
        void UpdateMark(MarkEntity mark);
    }
}
