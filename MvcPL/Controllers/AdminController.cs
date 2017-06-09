using BLL.Interface.Services;
using MvcPL.Attributes;
using MvcPL.Infrastructure.Mappers;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcPL.Controllers
{
    public class AdminController : Controller
    {
        #region Fields

        private readonly IUserService _userService;

        #endregion

        #region Constructor

        public AdminController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion
        public ActionResult ManageUsers()
        {
            var users = _userService.GetAllUserEntities().Select(u => u.ToPlUser()).ToList();

            for (int i = 0; i < users.Count; i++)
            {
                users[i].Roles = Roles.GetRolesForUser(users[i].Login);
            }

            return View(users);
        }
    }
}