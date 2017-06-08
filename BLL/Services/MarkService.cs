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
    public class MarkService: IMarkService
    {
        #region Fields

        private readonly IUnitOfWork uow;
        private readonly IMarkRepository markRepository;

        #endregion

        #region Constructor

        public MarkService(IUnitOfWork uow, IMarkRepository markRepository)
        {
            this.uow = uow;
            this.markRepository = markRepository;
        }

        #endregion

        #region Public Methods

        public void CreateMark(MarkEntity mark)
        {
            markRepository.Create(mark.ToDalMark());
            uow.Commit();
        }

        public void DeleteMark(MarkEntity mark)
        {
            markRepository.Delete(mark.ToDalMark());
            uow.Commit();
        }

        public void DeleteMark(int id)
        {
            var mark = markRepository.GetById(id);
            markRepository.Delete(mark);
            uow.Commit();
        }

        public MarkEntity GetMarkEntity(int id)
        {
            return markRepository.GetById(id)?.ToBllMark();
        }

        public IEnumerable<MarkEntity> GetSkillMarks(int skillId)
        {
            return markRepository.GetAll()
                .Where(m => m.SkillId == skillId)
                .Select(m => m.ToBllMark());
        }
        public void UpdateMark(MarkEntity mark)
        {
            markRepository.Update(mark.ToDalMark());
            uow.Commit();
        }

        #endregion
    }
}
