using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using ORM.Entities;

namespace DAL.Mappers
{
    public static class DtoMappers
    {
        public static DalUser ToDalUser(this User user)
        {
            return new DalUser
            {
                Id = user.Id,
                Login = user.Login,
                Email = user.Email,
                Password = user.Password,
                RegistrationDate = user.RegistrationDate
            };
        }

        public static User ToOrmUser(this DalUser user)
        {
            return new User
            {
                Id = user.Id,
                Login = user.Login,
                Email = user.Email,
                Password = user.Password,
                RegistrationDate = user.RegistrationDate
            };
        }


        public static DalProfile ToDalProfile(this Profile profile)
        {
            return new DalProfile
            {
                Id = profile.Id,
                ImageData = profile.ImageData,
                ImageMimeType = profile.ImageMimeType
            };
        }

        public static Profile ToOrmProfile(this DalProfile profile)
        {
            return new Profile
            {
                Id = profile.Id,
                ImageData = profile.ImageData,
                ImageMimeType = profile.ImageMimeType
            };
        }


        public static DalRole ToDalRole(this Role role)
        {
            return new DalRole
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description
            };
        }

        public static Role ToOrmRole(this DalRole role)
        {
            return new Role
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description
            };
        }


        public static DalField ToDalField(this Field board)
        {
            return new DalField
            {
                Id = board.Id,
                Name = board.Name
            };
        }

        public static Field ToOrmField(this DalField field)
        {
            return new Field
            {
                Id = field.Id,
                Name = field.Name
            };
        }


        public static DalSkill ToDalSkill(this Skill skill)
        {
            return new DalSkill
            {
                Id = skill.Id,
                FieldId = skill.FieldId,
                Name = skill.Name
            };
        }

        public static Skill ToOrmSkill(this DalSkill skill)
        {
            return new Skill
            {
                Id = skill.Id,
                FieldId = skill.FieldId,
                Name = skill.Name
            };
        }


        public static DalMark ToDalMark(this Mark mark)
        {
            return new DalMark
            {
                Id = mark.Id,
                UserId = mark.UserId,
                Value = mark.Value,
                SkillId = mark.SkillId
            };
        }

        public static Mark ToOrmMark(this DalMark mark)
        {
            return new Mark
            {
                Id = mark.Id,
                UserId = mark.UserId,
                Value = mark.Value,
                SkillId = mark.SkillId
            };
        }
    }
}
