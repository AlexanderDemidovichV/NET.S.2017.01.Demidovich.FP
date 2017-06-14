using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface ISkillService
    {
        SkillEntity GetSkill(int id);
        SkillEntity GetSkillByName(string name);

        IEnumerable<SkillEntity> FindSkills(string term);

        IEnumerable<SkillEntity> GetAllSkills();
        IEnumerable<SkillEntity> GetAllSkillsByField(FieldEntity field);

        IEnumerable<FieldEntity> GetSkillParents(int skillId);

        void CreateSkill(SkillEntity skill);
        void DeleteSkill(SkillEntity skill);
        void UpdateSkill(SkillEntity skill);
    }
}
