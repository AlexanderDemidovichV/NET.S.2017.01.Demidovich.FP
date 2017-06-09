using System.Linq;
using BLL.Interface.Entities;
using MvcPL.Models;
using MvcPL.Models.Input;

namespace MvcPL.Infrastructure.Mappers
{
    public static class MvcPlMappers
    {
        public static UserEntity ToBllUser(this UserRegistrationInputModel user)
        {
            return new UserEntity()
            {
                Login = user.Login,
                Email = user.Email,
                Password = user.Password
            };
        }

        public static FieldViewModel ToPlField(this FieldEntity field)
        {
            var subFields = field.SubFields.Select(f => f.ToPlField()).ToList();
            var skills = field.Skills.Select(s => s.ToPlSkill()).ToList();

            return new FieldViewModel
            {
                Id = field.Id,
                Name = field.Name,
                SubFields = subFields,
                Skills = skills
            };
        }

        public static FieldEntity ToBllField(this FieldInputModel field)
        {
            return new FieldEntity
            {
                ParentId = field.ParentId,
                Name = field.Name
            };
        }


        public static SkillViewModel ToPlSkill(this SkillEntity skill)
        {
            var ratings = skill.Ratings.ToList().Select(t => t.ToPlRating()).ToList();

            return new SkillViewModel
            {
                Id = skill.Id,
                FieldId = skill.FieldId,
                Subject = skill.Subject,
                Ratings = ratings
            };
        }

        public static SkillEntity ToBllSkill(this SkillInputModel skill)
        {
            return new SkillEntity
            {
                FieldId = skill.FieldId,
                Subject = skill.Subject
            };
        }


        public static RatingViewModel ToPlRating(this RatingEntity rating)
        {
            var user = new UserViewModel { Id = rating.UserId };

            return new RatingViewModel
            {
                Id = rating.Id,
                SkillId = rating.SkillId,
                User = user,
                Value = rating.Value
            };
        }

        public static RatingEntity ToBllRating(this RatingInputModel rating)
        {
            return new RatingEntity
            {
                Value = rating.Value
            };
        }


        public static UserViewModel ToPlUser(this UserEntity user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                Login = user.Login,
                Email = user.Email,
                RegistrationDate = user.RegistrationDate
            };
        }


        public static ProfileEntity ToBllProfile(this UserProfileInputModel profile)
        {
            return new ProfileEntity
            {
                Id = profile.Id,
                ImageData = profile.ImageData,
                ImageMimeType = profile.ImageMimeType
            };
        }
    }
}