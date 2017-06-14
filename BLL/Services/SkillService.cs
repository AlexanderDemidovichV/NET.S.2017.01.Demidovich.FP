using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.Repository;

namespace BLL.Services
{
    public class SkillService: ISkillService
    {
        #region Fields

        private readonly IUnitOfWork uow;
        private readonly ISkillRepository skillRepository;
        private readonly IFieldRepository fieldRepository;

        #endregion

        #region Constructor

        public SkillService(IUnitOfWork uow, ISkillRepository skillRepository, IFieldRepository fieldRepository)
        {
            this.uow = uow;
            this.skillRepository = skillRepository;
            this.fieldRepository = fieldRepository;
        }

        #endregion

        #region Public Methods

        public void CreateSkill(SkillEntity skill)
        {
            skillRepository.Create(skill.ToDalSkill());
            uow.Commit();
        }

        public IEnumerable<SkillEntity> FindSkills(string term)
        {
            return skillRepository.GetAll()
                .Where(s => s.Subject.ToUpper().Contains(term.ToUpper()))
                .Select(s => s.ToBllSkill());
        }

        public IEnumerable<SkillEntity> GetAllSkills()
        {
            return skillRepository.GetAll()
                .Select(s => s.ToBllSkill());
        }

        public SkillEntity GetSkill(int id)
        {
            return skillRepository.GetById(id)
                ?.ToBllSkill();
        }

        public SkillEntity GetSkillByName(string name)
        {
            return skillRepository.GetByPredicate(t => t.Subject == name)
                ?.ToBllSkill();
        }

        public IEnumerable<FieldEntity> GetSkillParents(int skillId)
        {
            var skill = skillRepository.GetById(skillId).ToBllSkill();
            var skillParents = new List<FieldEntity>();

            var field = fieldRepository.GetById(skill.FieldId).ToBllField();
            skillParents.Add(field);

            while (field.ParentId != null)
            {
                field = fieldRepository.GetById(field.ParentId.GetValueOrDefault()).ToBllField();
                skillParents.Add(field);
            }

            return skillParents;
        }

        public void UpdateSkill(SkillEntity skill)
        {
            throw new NotImplementedException();
        }

        public void DeleteSkill(SkillEntity skill)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SkillEntity> GetAllSkillsByField(FieldEntity field)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
