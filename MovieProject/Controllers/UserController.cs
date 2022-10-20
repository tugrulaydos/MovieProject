using AutoMapper;
using EntityLayer.Concrete;
using EntityLayer.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EntityLayer.ViewModels;

namespace MovieProject.Controllers
{
    public class UserController : Controller
    {
        readonly UserManager<User> _userManager; //Kullanıcı Yönetimiyle ilgili her şeyi user manager sınıfı sayesinde yapıyoruz.

        readonly IMapper _mapper;  //ViewModel'deki verileri gerçek modele aktarmamız gerekecektir işte bu durumda Automapper bu işi bizim için halledecek.

        readonly SignInManager<User> _signInManager;

        public UserController(UserManager<User> userManager, IMapper mapper, SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
        }

       
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Login(string ReturnUrl)
        {
            TempData["returnUrl"] = ReturnUrl;

            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                User _user = await _userManager.FindByEmailAsync(model.Email);
                if (_user != null)
                {
                    await _signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(_user, model.Password, model.Persistent, model.Lock);

                    if (result.Succeeded)  //Kullanıcı Adı ve Şifre Doğru
                    {

                        await _userManager.ResetAccessFailedCountAsync(_user);

                        if (string.IsNullOrEmpty(TempData["returnUrl"] != null ? TempData["returnUrl"].ToString() : ""))
                            return RedirectToAction("Index","Home");
                        return Redirect(TempData["returnUrl"].ToString());
                    }
                    else
                    {
                        await _userManager.AccessFailedAsync(_user);

                        int failcount = await _userManager.GetAccessFailedCountAsync(_user); //Kullanıcı'nın yapmış olduğu deneme adedini alıyoruz.

                        if(failcount >= 3)
                        {
                            await _userManager.SetLockoutEndDateAsync(_user, new DateTimeOffset(DateTime.Now.AddMinutes(1)));
                            ModelState.AddModelError("Locked", "Art arda 3 başarısız giriş denemesi yaptığınızdan dolayı hesabınız 1 dk kilitlenmiştir.");
                        }
                        else
                        {
                            ModelState.AddModelError("NotUser2", "E-Posta veya şifre yanlış");
                        }
                        
                        ModelState.AddModelError("NotUser", "Böyle Bir Kullanıcı Bulunamadı");
                        ModelState.AddModelError("NotUser2", "E-posta veya şifre yanlış.");
                    }

                }
                else
                {
                    ModelState.AddModelError("NotUser", "Böyle Bir Kullanıcı Bulunamadı");
                    ModelState.AddModelError("NotUser2", "E-posta veya şifre yanlış.");
                }

            }

            return View(model);
        }



        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserVM userVM)
        {
            if (ModelState.IsValid)
            {
                //User _User = new User
                //{
                //    UserName = userVM.UserName,
                //    Email = userVM.Email
                //};

                User _User = _mapper.Map<User>(userVM);
                
                IdentityResult result = await _userManager.CreateAsync(_User, userVM.Password);  //Gerekli Kontroller Yapılıyor.

                if (result.Succeeded)
                    return RedirectToAction("Index","Home");

                else
                {
                    result.Errors.ToList().ForEach(e => ModelState.AddModelError(e.Code, e.Description));
                }


            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login","User");
        }
    }
}
