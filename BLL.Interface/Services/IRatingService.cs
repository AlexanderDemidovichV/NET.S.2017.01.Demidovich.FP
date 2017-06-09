using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IRatingService
    {
        RatingEntity GetRatingEntity(int id);
        IEnumerable<RatingEntity> GetSkillRatings(int skillId);

        void DeleteRating(int id);

        void CreateRating(RatingEntity rating);
        void DeleteRating(RatingEntity rating);
        void UpdateRating(RatingEntity rating);
    }
}
