using System;
using System.Collections.Generic;
using ApiClient;
using Biblioteka.ApiClient;
using Biblioteka.Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Biblioteka.WebClient.Controllers
{
    public class NaslovController : Controller
    {
        private NaslovClient _naslovClient;
        private IConfiguration _configuration;


        public NaslovController(IConfiguration configuration)
        {
            _configuration = configuration;
            _naslovClient = new NaslovClient(new ApiSettings(
                configuration.GetValue<string>("ApiSettings:BibliotekaApi"),
                configuration.GetValue<string>("ApiSettings:ContentType")));
        }//.ctor()

        public ActionResult Index()
        {
            return View(_naslovClient.GetAll());
        }

        public ActionResult Create()
        {
            List<JezikDto> jezici = new List<JezikDto>(_naslovClient.GetJezike());
            List<VrstaDto> vrste = new List<VrstaDto>(_naslovClient.GetVrste());
            ViewBag.Vrste = vrste;
            ViewBag.Jezici = jezici;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NaslovDto value)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _naslovClient.AddAsync(value);
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
            List<JezikDto> jezici = new List<JezikDto>(_naslovClient.GetJezike());
            List<VrstaDto> vrste = new List<VrstaDto>(_naslovClient.GetVrste());
            NaslovDto naslovDto = _naslovClient.GetById(id);
            ViewBag.Vrste = vrste;
            ViewBag.Jezici = jezici;
            return View(naslovDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NaslovDto value)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _naslovClient.UpdateAsync(value);
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
            NaslovDto naslovDto = _naslovClient.GetById(id);
            return View(naslovDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(NaslovDto value)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _naslovClient.DeleteAsync(value);
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