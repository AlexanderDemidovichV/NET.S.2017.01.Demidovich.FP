using BLL.Interface.Entities;
using System.Collections.Generic;

namespace BLL.Interface.Services
{
    public interface IUserService
    {
        UserEntity GetUserEntity(int id);
        UserEntity GetUserEntityByLogin(string login);
        UserEntity GetUserEntityByEmail(string email);

        IEnumerable<UserEntity> GetAllUserEntities();

        bool ValidateUser(string login, string password);

        void CreateUser(UserEntity user);
        void DeleteUser(UserEntity user);
        void UpdateUser(UserEntity user);
    }
}
