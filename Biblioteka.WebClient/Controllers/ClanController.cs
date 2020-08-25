using System;
using ApiClient;
using Biblioteka.ApiClient;
using Biblioteka.Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Biblioteka.WebClient.Controllers
{
    public class ClanController : Controller
    {
        private ClanClient _clanClient;
        private IConfiguration _configuration;


        public ClanController(IConfiguration configuration)
        {
            _configuration = configuration;
            _clanClient = new ClanClient(new ApiSettings(
                configuration.GetValue<string>("ApiSettings:BibliotekaApi"),
                configuration.GetValue<string>("ApiSettings:ContentType")));
        }//.ctor()

        public ActionResult Index()
        {
            return View(_clanClient.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClanDto value)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _clanClient.AddAsync(value);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Nije moguce sacuvati promene. " +
                                             "Pokusaj ponovo, ako se problem nastavi " +
                                             "kontaktiraj administratora.");
            }
            return View(value);
        }
        public ActionResult Edit(int id)
        {
            ClanDto clanDto = _clanClient.GetById(id);
            return View(clanDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClanDto value)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _clanClient.UpdateAsync(value);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Nije moguce sacuvati promene. " +
                                             "Pokusaj ponovo, ako se problem nastavi " +
                                             "kontaktiraj administratora.");
            }
            return View(value);
        }

        public ActionResult Delete(int id)
        {
            ClanDto clanDto = _clanClient.GetById(id);
            return View(clanDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ClanDto value)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _clanClient.DeleteAsync(value);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Nije moguce obrisati item. " +
                                             "Pokusaj ponovo, ako se problem nastavi " +
                                             "kontaktiraj administratora.");
            }
            return View(value);
        }
    }
}