using System.Collections.Generic;
using DAL.Interface.DTO;

namespace DAL.Interface.Repository
{
    public interface IRoleRepository: IRepository<DalRole>
    {
        IEnumerable<DalRole> GetUserRoles(int userId);
        IEnumerable<DalUser> GetUsersInRole(DalRole role);

        void AddUserToRole(DalUser user, DalRole role);
        void RemoveUserFromRole(DalUser user, DalRole role);
    }
}
