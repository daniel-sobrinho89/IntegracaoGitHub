using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IntegracaoGitHub.Models;
using System.Net;
using IntegracaoGitHub.Services.Interface;

namespace IntegracaoGitHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search()
        {
            return View();
        }

        public IActionResult Favorites()
        {
            return View();
        }

        /// <summary>
        /// Salva repositório na tabela de favoritos
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> SetFavoriteAsync(SetFavoriteRequest setFavoriteRequest)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = await _homeService.SetFavoriteAsync(setFavoriteRequest);

                    if (response == 1)
                    {
                        return Ok("Favorito salvo com sucesso !!");
                    }
                    else
                    {
                        return StatusCode((int)HttpStatusCode.InternalServerError, "Falha ao salvar favorito.");
                    }

                }
                catch (Exception ex)
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
                }
            }

            return StatusCode((int)HttpStatusCode.BadRequest, "Requisição inválida");
        }

        /// <summary>
        /// Retorna o Nome, Id e Avatar dos diretórios favoritos
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetFavoritesAsync()
        {
            string errorMessage = "";

            if (ModelState.IsValid)
            {
                try
                {
                    var response = await _homeService.GetFavoritesAsync();
                    return Ok(response);
                }
                catch (Exception)
                {
                    errorMessage = "Por favor alguarde alguns minutos e tente novamente, caso o erro persista, favor informar o responsável pelo sistema.";
                }
            }

            return StatusCode((int)HttpStatusCode.InternalServerError, errorMessage == "" ? "Requisição inválida" : errorMessage);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
