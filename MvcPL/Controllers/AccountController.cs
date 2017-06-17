using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BLL.Interface.Services;
using MvcPL.Infrastructure.Mappers;
using MvcPL.Models.Input;
using MvcPL.Models.Report;
using MvcPL.Models.View;
using MvcPL.Providers;
using Root.Reports;

namespace MvcPL.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        #region Fields

        private readonly IUserService _userService;
        private readonly IProfileService _profileService;
        private readonly IFieldService _fieldService;
        private readonly ISkillService _skillService;


        #endregion

        #region Constructor

        public AccountController(IUserService userService, IProfileService profileService, IFieldService fieldService, ISkillService skillService)
        {
            _userService = userService;
            _profileService = profileService;
            _fieldService = fieldService;
            _skillService = skillService;
        }

        #endregion

        #region Public Methods

        [HttpGet]
        public ActionResult ReportTemplate()
        {
            var skills = _skillService.GetAllSkills();
    
            SelectList skillList = new SelectList(skills, "Id", "Subject");

            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem { Value = "Novice"});
            list.Add(new SelectListItem { Value = "Intermediate" });
            list.Add(new SelectListItem { Value = "Advanced" });
            ViewBag.LevelList = list;

            return View(skillList);
        }

        [HttpGet]
        public ActionResult Knowledges()
        {
            //RT.PrintPDF(new ReportTableLayout());
            //RT.ViewPDF(new ReportTableLayout(), "KnowledgeManagerReport.pdf");

            var mainFields = _fieldService.GetSubFields(null);

            var knowledgeViewModel = new KnowledgesViewModel();

            foreach (var field in mainFields)
            {
                var f = field.ToPlField();

                var subFields = _fieldService.GetSubFields(f.Id).OrderBy(foa => foa.Id).Take(3);
                foreach (var subField in subFields)
                {
                    f.SubFields.Add(subField.ToPlField());
                }

                knowledgeViewModel.fields.Add(f);
            }

            return View(knowledgeViewModel);
        }

        [HttpGet]
        public ActionResult Index()
        {
            var userProfileinput = new UserProfileInputModel();

            userProfileinput.Id = _userService.GetUserEntityByLogin(User.Identity.Name).Id;

            var profileEntity = _profileService.GetProfileEntity(userProfileinput.Id);
            if (profileEntity != null)
            {
                userProfileinput.ImageData = profileEntity.ImageData;
                userProfileinput.ImageMimeType = profileEntity.ImageMimeType;
            }

            return View(userProfileinput);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            //if (User.Identity.IsAuthenticated)
            //    return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserRegistrationInputModel userRegistrationInputModel)
        {

            if (ModelState.IsValid)
            {
                var userWithSameLogin = Membership.GetUser(userRegistrationInputModel.Login);
                if (userWithSameLogin != null)
                {
                    ModelState.AddModelError("", "This login is already exist.");
                    return View(userRegistrationInputModel);
                }

                var userWithSameEmail = Membership.GetUserNameByEmail(userRegistrationInputModel.Email);
                if (userWithSameEmail != null)
                {
                    ModelState.AddModelError("", "This email is already in use.");
                    return View(userRegistrationInputModel);
                }

                var membershipUser = ((CustomMembershipProvider)Membership.Provider).CreateUser(userRegistrationInputModel);

                if (membershipUser != null)
                {
                    FormsAuthentication.SetAuthCookie(userRegistrationInputModel.Login, false);
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Incorrect input.");

            return View(userRegistrationInputModel);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult LogIn()
        {
            //if (User.Identity.IsAuthenticated)
            //    return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(UserLogInInputModel userLogInInputModel)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(userLogInInputModel.Login, userLogInInputModel.Password))
                {
                    FormsAuthentication.SetAuthCookie(userLogInInputModel.Login, userLogInInputModel.RememberMe);

                    if (Url.IsLocalUrl(HttpContext.Request.UrlReferrer.AbsolutePath))
                    {
                        return Redirect(HttpContext.Request.UrlReferrer.AbsolutePath);
                    }
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Incorrect login or password.");

            return View(userLogInInputModel);
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();

            if (Url.IsLocalUrl(HttpContext.Request.UrlReferrer.AbsolutePath))
            {
                return Redirect(HttpContext.Request.UrlReferrer.AbsolutePath);
            }

            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public JsonResult VerifyUserExists(string login)
        {
            MembershipUser userWithSameLogin = Membership.GetUser(login);

            return Json(userWithSameLogin == null, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public JsonResult VerifyEmailExists(string email)
        {
            var userWithSameEmail = Membership.GetUserNameByEmail(email);

            return Json(userWithSameEmail == null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Edit(UserProfileInputModel userProfileInput, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    userProfileInput.ImageMimeType = image.ContentType;
                    userProfileInput.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(userProfileInput.ImageData, 0, image.ContentLength);
                }

                userProfileInput.Id = _userService.GetUserEntityByLogin(User.Identity.Name).Id;

                var profileEntity = userProfileInput.ToBllProfile();
                if (_profileService.GetProfileEntity(profileEntity.Id) == null)
                {
                    _profileService.CreateProfile(profileEntity);

                }
                else
                {
                    _profileService.UpdateProfile(profileEntity);
                }

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("NotFound", "Error");
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public FileContentResult GetImage(int id)
        {
            var profile = _profileService.GetProfileEntity(id);

            if (profile != null)
            {
                return File(profile.ImageData, profile.ImageMimeType);
            }
            else
            {
                return null;
            }
        }

        #endregion
    }
}