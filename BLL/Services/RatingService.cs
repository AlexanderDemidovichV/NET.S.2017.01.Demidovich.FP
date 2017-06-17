using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.Interface.Repository;
using DAL.Interface.Repository;

namespace BLL.Services
{
    public class RatingService: IRatingService
    {
        #region Fields

        private readonly IUnitOfWork uow;
        private readonly IRatingRepository ratingRepository;

        #endregion

        #region Constructor

        public RatingService(IUnitOfWork uow, IRatingRepository ratingRepository)
        {
            this.uow = uow;
            this.ratingRepository = ratingRepository;
        }

        #endregion

        #region Public Methods

        public void CreateRating(RatingEntity rating)
        {
            ratingRepository.Create(rating.ToDalRating());
            uow.Commit();
        }

        public void DeleteRating(int id)
        {
            var rating = ratingRepository.GetById(id);
            ratingRepository.Delete(rating);
            uow.Commit();
        }

        public void DeleteRating(RatingEntity rating)
        {
            ratingRepository.Delete(rating.ToDalRating());
            uow.Commit();
        }

        public RatingEntity GetRatingEntity(int id)
        {
            return ratingRepository.GetById(id)?.ToBllRating();
        }

        public IEnumerable<RatingEntity> GetSkillRatings(int skillId)
        {
            return ratingRepository.GetAll()
                .Where(r => r.SkillId == skillId)
                .Select(r => r.ToBllRating());
        }

        public IEnumerable<RatingEntity> GetSkillUserRatings(int skillId, int userId)
        {
            return ratingRepository.GetAll()
                .Where(r => r.SkillId == skillId).Where(r => r.UserId == userId)
                .Select(r => r.ToBllRating());
        }

        public void UpdateRating(RatingEntity rating)
        {
            ratingRepository.Update(rating.ToDalRating());
            uow.Commit();
        }

        #endregion

    }
}
