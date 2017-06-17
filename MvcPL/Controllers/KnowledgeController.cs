using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using MvcPL.Infrastructure.Mappers;
using MvcPL.Models.Input;
using MvcPL.Models.View;

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
        [AllowAnonymous]
        public ActionResult Skill(int id)
        {
            var skill = _skillService.GetSkill(id)
                ?.ToPlSkill();

            if (skill == null)
                return HttpNotFound();

            foreach (var rating in skill.Ratings)
            {
                rating.User = _userService.GetUserEntity(rating.User.Id).ToPlUser();
            }

            var knowledgeSkillViewModel = new KnowledgeSkillViewModel() { Skill = skill };
            knowledgeSkillViewModel.RatingInput.SkillId = id;
            knowledgeSkillViewModel.ParentFields = _skillService.GetSkillParents(id).Select(b => b.ToPlField()).Reverse().ToList();


            return View(knowledgeSkillViewModel);
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
            bool isUpdate = (_ratingService
                                 .GetSkillUserRatings(skillId, _userService.GetUserEntityByLogin(User.Identity.Name).Id)
                                 .Any());


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

        [AllowAnonymous]
        public ActionResult FindSkill(string term)
        {
            var skills = _skillService.FindSkills(term).Select(t => t.ToPlSkill());

            if (Request.IsAjaxRequest())
            {

                var projection = skills.Select(t => new
                {
                    id = t.Id,
                    label = t.Subject
                });

                return Json(projection.ToList(), JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (skills.Count() == 1)
                {
                    return RedirectToAction("Skill", "Knowledge", new { id = skills.First().Id });
                }

                return View(skills);

            }

        }

        #endregion
    }
}