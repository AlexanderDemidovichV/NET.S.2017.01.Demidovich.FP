﻿using BLL.Interface.Entities;
using System.Collections.Generic;

namespace BLL.Interface.Services
{
    public interface IUserService
    {
        IEnumerable<RoleEntity> GetUserRoleEntities(int userId);

        RoleEntity GetRoleEntity(int id);
        RoleEntity GetRoleEntityByName(string roleName);

        IEnumerable<RoleEntity> GetAllRoleEntities();

        IEnumerable<UserEntity> GetUserEntitiesInRole(string roleName);

        void AddUsersToRoles(ICollection<UserEntity> users, ICollection<RoleEntity> roles);
        void RemoveUsersFromRoles(ICollection<UserEntity> users, ICollection<RoleEntity> roles);

        void CreateRole(RoleEntity role);
        void DeleteRole(RoleEntity role);
        void UpdateRole(RoleEntity role);
    }
}
