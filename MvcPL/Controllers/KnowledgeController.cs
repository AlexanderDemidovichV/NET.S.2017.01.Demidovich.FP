using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using MvcPL.Infrastructure.Mappers;
using MvcPL.Models.Input;
using MvcPL.Models.Report;
using MvcPL.Models.View;
using Root.Reports;

namespace MvcPL.Controllers
{
    public class KnowledgeController : Controller
    {
        #region Fields

        private readonly IFieldService _fieldService;
        private readonly ISkillService _skillService;
        private readonly IRatingService _ratingService;
        private readonly IUserService _userService;

        #endregion

        #region Constructor

        public KnowledgeController(IFieldService fieldService, ISkillService skillService, 
            IRatingService ratingService, IUserService userService)
        {
            _fieldService = fieldService;
            _skillService = skillService;
            _ratingService = ratingService;
            _userService = userService;
        }

        #endregion

        #region Public methods

        

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Field(int id)
        {
            ViewBag.UserVM = _userService.GetUserEntityByLogin(User.Identity.Name).ToPlUser(); 
            var field = _fieldService.GetField(id)
                ?.ToPlField();

            if (field == null)
                return HttpNotFound();

            var knowledgeFieldViewModel = new KnowledgeFieldViewModel
            {
                Field = field,
                SkillInput = {FieldId = id},
                FieldInput = {ParentId = id},
                ParentFields = _fieldService.GetFieldParents(id).Select(f => f.ToPlField()).Reverse().ToList()
            };


            return View(knowledgeFieldViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, Moderator")]
        public ActionResult AddField(FieldInputModel fieldInput, int parentId)
        {
            if (ModelState.IsValid)
            {
                fieldInput.ParentId = parentId;

                _fieldService.CreateField(fieldInput.ToBllField());

                if (Url.IsLocalUrl(HttpContext.Request.UrlReferrer.AbsolutePath))
                {
                    return Redirect(HttpContext.Request.UrlReferrer.AbsolutePath);
                }

                return RedirectToAction("Field", "Knowledge", new { id = parentId });
            }
            else
            {
                ModelState.AddModelError("", "Incorrect input.");

                var field = _fieldService.GetField(parentId)
                    ?.ToPlField();

                if (field == null)
                    return View("Error");

                var knowledgeFieldViewModel = new KnowledgeFieldViewModel() { Field = field };
                knowledgeFieldViewModel.SkillInput.FieldId = parentId;
                knowledgeFieldViewModel.FieldInput = fieldInput;

                return View("Field", knowledgeFieldViewModel);
            }

        }

        [HttpGet]
        public ActionResult ReportTemplate()
        {
            var skills = _skillService.GetAllSkills();

            SelectList skillList = new SelectList(skills, "Id", "Subject");

            return View(skillList);
        }

        [HttpPost]
        public ActionResult ReportTemplate(string skill, string level)
        {
            var skills = _skillService.GetAllSkills();

            SelectList skillList = new SelectList(skills, "Id", "Subject");
            Report(int.Parse(skill), level);
            return View(skillList);
        }

        [NonAction]
        public void Report(int skillId, string level)
        {
            int rate = 1;
            switch (level)
            {
                case "Novice":
                    rate = 1; break;
                case "Intermediate":
                    rate = 2; break;
                case "Advanced":
                    rate = 3;
                    break;
            }
            var ratings = _ratingService.GetSkillRatings(skillId).Where(r => r.Value == rate);
            var ratingEntities = ratings as IList<RatingEntity> ?? ratings.ToList();
            var users = new List<UserReportModel>();
           
            foreach (var rating in ratingEntities)
            {
                var user = _userService.GetUserEntity(rating.UserId);
                var userReport = new UserReportModel()
                {
                    Login = user.Login,
                    Email = user.Email,
                    Level = rating.Value
                };
                users.Add(userReport);
            }
            RT.ViewPDF(new ReportTableLayout(users), "KnowledgeManagerReport.pdf");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddSkill(SkillInputModel skillInput, int fieldId)
        {

            if (ModelState.IsValid)
            {
                var skillEntity = skillInput.ToBllSkill();
                skillEntity.FieldId = fieldId;

                _skillService.CreateSkill(skillEntity);

                if (Url.IsLocalUrl(HttpContext.Request.UrlReferrer.AbsolutePath))
                {
                    return Redirect(HttpContext.Request.UrlReferrer.AbsolutePath);
                }

                return RedirectToAction("Field", "Knowledge", new { id = fieldId });
            }
            else
            {
                ModelState.AddModelError("", "Incorrect input.");

                var field = _fieldService.GetField(fieldId)
                    ?.ToPlField();

                if (field == null)
                    return View("Error");

                var knowledgeFieldViewModel = new KnowledgeFieldViewModel
                {
                    Field = field,
                    SkillInput = skillInput,
                    FieldInput = {ParentId = fieldId}
                };

                return View("Field", knowledgeFieldViewModel);
            }
        }

        [HttpPost]
        public ActionResult AddRating(int skillId, int value, int fieldId)
        {
            bool isUpdate = _ratingService
                                 .GetSkillUserRatings(skillId, _userService.GetUserEntityByLogin(User.Identity.Name).Id)
                                 .Any();


            if (!isUpdate)
            {
                var ratingEntity = new RatingEntity
                {
                    UserId = _userService.GetUserEntityByLogin(User.Identity.Name).Id,
                    Value = value,
                    SkillId = skillId
                };
                _ratingService.CreateRating(ratingEntity);
            }
            else
            {
                var ratingEntity = new RatingEntity
                {
                    Id = _ratingService.GetSkillUserRatings(skillId, _userService.GetUserEntityByLogin(User.Identity.Name).Id).First(r => r.SkillId == skillId).Id,
                    UserId = _userService.GetUserEntityByLogin(User.Identity.Name).Id,
                    Value = value,
                    SkillId = skillId
                };
                _ratingService.UpdateRating(ratingEntity);
            }
            

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Rated");
            }
            return RedirectToAction("Field", new { id = fieldId });
        }


        #endregion
    }
}