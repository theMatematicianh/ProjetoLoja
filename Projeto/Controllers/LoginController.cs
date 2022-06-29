using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Projeto.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            if(User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public IActionResult Home()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Logar(string email,string password)
        {
            MySqlConnection mySqlConnection = new MySqlConnection("server=localhost;userid=root;password=1234567;database=basep");
            await mySqlConnection.OpenAsync();

            MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = $"SELECT * FROM client WHERE email = '{email}' AND password = '{password}'";

            MySqlDataReader reader = mySqlCommand.ExecuteReader();


            if (await reader.ReadAsync())
            {
                int Id = reader.GetInt32(0);
                string Name = reader.GetString(1);
                string Email = reader.GetString(2);
                DateTime BirthDate = reader.GetDateTime(3);
                string Password = reader.GetString(4);
                int OrderId = (5);
                int Lvl = reader.GetInt32(6);

                List<Claim> direitoAcesso = new List<Claim> { new Claim(ClaimTypes.NameIdentifier, Id.ToString()), new Claim(ClaimTypes.Name, Name) };

                var identity = new ClaimsIdentity(direitoAcesso, "Identity.Login");
                var userPrincipal = new ClaimsPrincipal(new[] { identity });

                await HttpContext.SignInAsync(userPrincipal, new AuthenticationProperties { IsPersistent= false ,ExpiresUtc = DateTime.Now.AddHours(1)});



                return RedirectToAction("Index","Home");
            } 

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
