using LanchesMac.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers
{
    public class AccountController : Controller
    {
        public readonly UserManager<IdentityUser> _userManager;
        public readonly SignInManager<IdentityUser> _singInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> singInManager)
        {
            _userManager = userManager;
            _singInManager = singInManager;
        }

        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel()
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (!ModelState.IsValid) //valida o formulario 
            {
                return View(loginVM);
            }
            var user = await _userManager.FindByNameAsync(loginVM.UserName); //Localiza o usuario na tabela

            if (user != null) // caso nao encontre
            {
                var result = await _singInManager.PasswordSignInAsync(user, loginVM.Password, false, false); // no false nao persiste no cooking, e se o login falhar nao bloqueia usuario
                if (result.Succeeded) // se existe
                {
                    if (string.IsNullOrEmpty(loginVM.ReturnUrl)) 
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    return Redirect(loginVM.ReturnUrl);
                }
            }
            ModelState.AddModelError("", "Falha ao realizar o Login!");
            return View(loginVM);
        }

    }

}
