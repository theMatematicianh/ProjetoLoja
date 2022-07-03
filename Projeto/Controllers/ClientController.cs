using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto.Data;
using Projeto.Services;
using Projeto.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Pages.Account.Internal;

namespace Projeto.Controllers
{
    public class ClientController : Controller
    {
        private readonly ClientService _clientService;

        public ClientController(ClientService clientService)
        {
            _clientService = clientService;
        }
        public IActionResult Index()
        {
            var List = _clientService.FindAll();

            return View(List);
        }
        public IActionResult Creat()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Creat(Client client)
        {
            _clientService.Insert(client);
            return RedirectToAction(nameof(Index));
        }
   

    }
}
