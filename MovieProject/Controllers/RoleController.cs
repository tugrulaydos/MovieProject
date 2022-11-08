using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrete;
using EntityLayer.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MovieProject.Controllers
{
    public class RoleController : Controller
    {
        readonly RoleManager<UserRole> _roleManager;

        readonly UserManager<User> _userManager;

        readonly IUserService _userManagerService;
        public RoleController(RoleManager<UserRole> roleManager, UserManager<User> UserManagerIdentity, IUserService userManagerService)
        {
            _roleManager = roleManager;

            _userManager = UserManagerIdentity;

            _userManagerService = userManagerService;


        }

        //UserManager userManager = new UserManager(new EFUserDal()); //Business Layer Katmanı.

        public IActionResult UserList()
        {
            return View(_userManagerService.TGetList());
        }

        public IActionResult Index()
        {
            return View(_roleManager.Roles.ToList());
        }

        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleViewModel model)
        {
            IdentityResult result = await _roleManager.CreateAsync(new UserRole { Name = model.Name,CreationDate = model.CreationDate});

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public async Task<IActionResult> Update(string id)
        {
            UserRole role = await _roleManager.FindByIdAsync(id);

            RoleViewModel rwm = new RoleViewModel
            {
                Name = role.Name,
                
            };

            return View(rwm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(RoleViewModel rwm,string id)
        {
            UserRole role = await _roleManager.FindByIdAsync(id);
            role.Name = rwm.Name;
            await _roleManager.UpdateAsync(role);
            return RedirectToAction("Index", "Role");
        }



        public async Task<IActionResult> RoleAssign(string id)
        {
            User user = await _userManager.FindByIdAsync(id); //ID'si eşleşen kullanıcıyı getir.

            List<UserRole> allRoles = _roleManager.Roles.ToList();  //Tüm rolleri Listele.

            List<string> userRoles = await _userManager.GetRolesAsync(user) as List<string>; //O anki kullanıcının mevcut tüm rolleri.

            List<RoleAssignVM> assignRolesVM = new List<RoleAssignVM>();



            allRoles.ForEach(role => assignRolesVM.Add(new RoleAssignVM
            {
                HasAssign = userRoles.Contains(role.Name),
                RoleId = role.Id,
                RoleName = role.Name

            }));          


            return View(assignRolesVM);
            
        }

        [HttpPost]
        public async Task<IActionResult> RoleAssign(List<RoleAssignVM> modelList, string id)
        {
            User user = await _userManager.FindByIdAsync(id);

            foreach(RoleAssignVM role in modelList)
            {
                if (role.HasAssign)
                {
                    await _userManager.AddToRoleAsync(user, role.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user,role.RoleName);
                }
            }

            return RedirectToAction("UserList", "Role");

        }



        
    }
}
