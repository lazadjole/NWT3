using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Biblioteka.Database.Models;
using Biblioteka.Domain.DomainObjects;
using Biblioteka.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Biblioteka.Database.Repositories
{
    public class EvidencijaDugovanjaRepository : IEvidencijaDugovanjaRepository
    {
        private readonly Mapper _evidencijaDugovanjaMapper;
        private readonly BibliotekaContext _context;

        public EvidencijaDugovanjaRepository(IConfigurationProvider evidencijaDugovanjaMapper, BibliotekaContext context)
        {
            _evidencijaDugovanjaMapper = new Mapper(evidencijaDugovanjaMapper);
            _context = context;
        }

        #region Methods

        public IEnumerable<EvidencijaDugovanja> GetAll()
        {
            return _evidencijaDugovanjaMapper.Map<IEnumerable<EvidencijaDugovanja>>(_context.EvidencijaDugovanjaModel
                .Include(t => t.IdClanNavigation)
                .Include(u => u.IdNaslovNavigation));

        }

        public void Save(EvidencijaDugovanja value)
        {
            EvidencijaDugovanjaModel evidencijaDugovanja =
                _evidencijaDugovanjaMapper.Map<EvidencijaDugovanjaModel>(value);
            if (value.DatumRazduzivanja == DateTime.MinValue)
                value.DatumRazduzivanja = null;
            _context.Add(evidencijaDugovanja);
            _context.SaveChanges();
        }//Save()

        public void Update(EvidencijaDugovanja value)
        {
            EvidencijaDugovanjaModel evidencijaDugovanja =
                _context.EvidencijaDugovanjaModel.SingleOrDefault(t => t.IdEvidencija == value.Id);
            if (value.DatumRazduzivanja == DateTime.MinValue)
                value.DatumRazduzivanja = null;
            if (evidencijaDugovanja != null)
            {
                evidencijaDugovanja.IdClan = value.Clan.Id;
                evidencijaDugovanja.IdNaslov = value.Naslov.Id;
                evidencijaDugovanja.UkupnaCena = value.UkupnaCena;
                evidencijaDugovanja.DatumZaduzivanja = value.DatumZaduzivanja;
                evidencijaDugovanja.DatumRazduzivanja = value.DatumRazduzivanja;
            }
            _context.SaveChanges();
        }//Save()

        public EvidencijaDugovanja GetById(int id)
        {
            EvidencijaDugovanjaModel evidencijaDugovanja =
                _context.EvidencijaDugovanjaModel.SingleOrDefault(t => t.IdEvidencija == id);
      
               return _evidencijaDugovanjaMapper.Map<EvidencijaDugovanja>(evidencijaDugovanja);
        }//GetById()

        public void Delete(EvidencijaDugovanja value)
        {
            EvidencijaDugovanjaModel evidencijaDugovanja =
                _context.EvidencijaDugovanjaModel.SingleOrDefault(t => t.IdEvidencija == value.Id);
            if (evidencijaDugovanja != null) _context.EvidencijaDugovanjaModel.Remove(evidencijaDugovanja);
            _context.SaveChanges();
        }//Delete()

        public IEnumerable<EvidencijaDugovanja> GetByIdClan(int id)
        {
            return _evidencijaDugovanjaMapper.Map<IEnumerable<EvidencijaDugovanja>>(_context.EvidencijaDugovanjaModel.Where(
                    t=>t.IdClan == id)
                .Include(t => t.IdClanNavigation)
                .Include(u => u.IdNaslovNavigation));
        }

        public IEnumerable<EvidencijaDugovanja> GetByIdNaslov(int id)
        {
            return _evidencijaDugovanjaMapper.Map<IEnumerable<EvidencijaDugovanja>>(_context.EvidencijaDugovanjaModel.Where(
                    t => t.IdNaslov == id)
                .Include(t => t.IdClanNavigation)
                .Include(u => u.IdNaslovNavigation));
        }

        #endregion
    }//class
}//namespace
