using DAL.Interface.DTO;

namespace DAL.Interface.Repository
{
    public interface IFieldRepository: IRepository<DalField>
    {
        int GetFieldSkillsCount(int fieldId);
    }
}
