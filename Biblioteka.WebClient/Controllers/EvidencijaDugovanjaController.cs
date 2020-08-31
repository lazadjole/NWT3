using System;
using System.Collections.Generic;
using System.Linq;
using ApiClient;
using Biblioteka.Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Biblioteka.WebClient.Controllers
{
    public class EvidencijaDugovanjaController : Controller
    {
        private EvidencijaDugovanjaClient _evidencijaDugovanjaClient;
        private IConfiguration _configuration;


        public EvidencijaDugovanjaController(IConfiguration configuration)
        {
            _configuration = configuration;
            _evidencijaDugovanjaClient = new EvidencijaDugovanjaClient(new ApiSettings(
                configuration.GetValue<string>("ApiSettings:BibliotekaApi"),
                configuration.GetValue<string>("ApiSettings:ContentType")));
        }//.ctor()

        public ActionResult Index()
        {
            return View();

        }

        public ActionResult GetTrenutnoZaduzene()
        {
            return PartialView("_EvidencijaDugovanjaList", _evidencijaDugovanjaClient.GetTrenutnoZaduzeno());
        }

        public ActionResult Get()
        {
            return PartialView("_EvidencijaDugovanjaList", _evidencijaDugovanjaClient.GetAll());
        }

        public ActionResult GetByClan(int id)
        {
            var zana = _evidencijaDugovanjaClient.GetTrenutnoZaduzeno();
            return PartialView("_EvidencijaDugovanjaList", zana);
        }


        public ActionResult<NaslovDto> GetNaslovById(int id)
        {
            NaslovDto naslovDto = _evidencijaDugovanjaClient.GetNaslovById(id);
            return naslovDto;
        }
        public ActionResult Create()
        {
            List<NaslovDto> naslovi = new List<NaslovDto>(_evidencijaDugovanjaClient.GetNaslove());
            List<ClanDto> clanovi = new List<ClanDto>(_evidencijaDugovanjaClient.GetClanove());
            ViewBag.Naslovi = naslovi;
            ViewBag.Clanovi = clanovi;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EvidencijaDugovanjaDto value)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _evidencijaDugovanjaClient.AddAsync(value);
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
            List<NaslovDto> naslovi = new List<NaslovDto>(_evidencijaDugovanjaClient.GetNaslove());
            List<ClanDto> clanovi = new List<ClanDto>(_evidencijaDugovanjaClient.GetClanove());
            EvidencijaDugovanjaDto evidencijaDugovanjaDto = _evidencijaDugovanjaClient.GetById(id);
            ViewBag.Naslovi = naslovi;
            ViewBag.Clanovi = clanovi;
            return View(evidencijaDugovanjaDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EvidencijaDugovanjaDto value)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _evidencijaDugovanjaClient.UpdateAsync(value);
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
            EvidencijaDugovanjaDto evidencijaDugovanjaDto = _evidencijaDugovanjaClient.GetById(id);
            return View(evidencijaDugovanjaDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(EvidencijaDugovanjaDto value)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _evidencijaDugovanjaClient.DeleteAsync(value);
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

    } //class
}//namespace