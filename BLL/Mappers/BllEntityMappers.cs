﻿using BLL.Interface.Entities;
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
                Name = field.Name
            };
        }

        public static FieldEntity ToBllField(this DalField field)
        {
            var skills = field.Skills.ToList().Select(s => s.ToBllSkill());

            return new FieldEntity
            {
                Id = field.Id,
                Name = field.Name,
                Skills = skills
            };
        }


        public static DalSkill ToDalSkill(this SkillEntity skill)
        {
            return new DalSkill
            {
                Id = skill.Id,
                Name = skill.Name
            };
        }

        public static SkillEntity ToBllSkill(this DalSkill skill)
        {
            var marks = skill.Marks.ToList().Select(m => m.ToBllMark());

            return new SkillEntity
            {
                Id = skill.Id,
                Name = skill.Name,
                Marks = marks
            };
        }


        public static DalMark ToDalMark(this MarkEntity mark)
        {
            return new DalMark
            {
                Id = mark.Id,
                SkillId = mark.SkillId,
                UserId = mark.UserId,
                Value = mark.Value
            };
        }

        public static MarkEntity ToBllMark(this DalMark mark)
        {
            return new MarkEntity
            {
                Id = mark.Id,
                SkillId = mark.SkillId,
                UserId = mark.UserId,
                Value = mark.Value
            };
        }
    }
}
