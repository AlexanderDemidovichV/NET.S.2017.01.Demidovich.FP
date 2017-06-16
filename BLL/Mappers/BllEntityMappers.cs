using BLL.Interface.Entities;
using DAL.Interface.DTO;
using System.Linq;

namespace BLL.Mappers
{
    public static class BllEntityMappers
    {
        public static DalUser ToDalUser(this UserEntity user)
        {
            return new DalUser()
            {
                Id = user.Id,
                Login = user.Login,
                Email = user.Email,
                Password = user.Password,
                RegistrationDate = user.RegistrationDate
            };
        }

        public static UserEntity ToBllUser(this DalUser user)
        {
            return new UserEntity()
            {
                Id = user.Id,
                Login = user.Login,
                Email = user.Email,
                Password = user.Password,
                RegistrationDate = user.RegistrationDate
            };
        }


        public static DalProfile ToDalProfile(this ProfileEntity profile)
        {
            return new DalProfile
            {
                Id = profile.Id,
                ImageData = profile.ImageData,
                ImageMimeType = profile.ImageMimeType
            };
        }

        public static ProfileEntity ToBllProfile(this DalProfile profile)
        {
            return new ProfileEntity
            {
                Id = profile.Id,
                ImageData = profile.ImageData,
                ImageMimeType = profile.ImageMimeType
            };
        }


        public static DalRole ToDalRole(this RoleEntity role)
        {
            return new DalRole
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description
            };
        }

        public static RoleEntity ToBllRole(this DalRole role)
        {
            return new RoleEntity
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description
            };
        }


        public static DalField ToDalField(this FieldEntity field)
        {
            return new DalField
            {
                Id = field.Id,
                Name = field.Name,
                ParentId = field.ParentId
            };
        }

        public static FieldEntity ToBllField(this DalField field)
        {
            var skills = field.Skills.ToList().Select(s => s.ToBllSkill());
            var subFields = field.SubFields.ToList().Select(f => f.ToBllField());

            return new FieldEntity
            {
                Id = field.Id,
                ParentId = field.ParentId,
                Name = field.Name,
                Skills = skills,
                SubFields = subFields
            };
        }


        public static DalSkill ToDalSkill(this SkillEntity skill)
        {
            return new DalSkill
            {
                Id = skill.Id,
                Subject = skill.Subject,
                FieldId = skill.FieldId
            };
        }

        public static SkillEntity ToBllSkill(this DalSkill skill)
        {
            var ratings = skill.Ratings.ToList().Select(m => m.ToBllRating());

            return new SkillEntity
            {
                Id = skill.Id,
                Subject = skill.Subject,
                Ratings = ratings,
                FieldId = skill.FieldId
            };
        }


        public static DalRating ToDalRating(this RatingEntity rating)
        {
            return new DalRating
            {
                Id = rating.Id,
                SkillId = rating.SkillId,
                UserId = rating.UserId,
                Value = rating.Value
            };
        }

        public static RatingEntity ToBllRating(this DalRating rating)
        {
            return new RatingEntity
            {
                Id = rating.Id,
                SkillId = rating.SkillId,
                UserId = rating.UserId,
                Value = rating.Value
            };
        }
    }
}
