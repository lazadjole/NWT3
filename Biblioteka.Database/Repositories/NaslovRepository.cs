using System.Collections.Generic;
using AutoMapper;
using System.Linq;
using Biblioteka.Database.Models;
using Biblioteka.Domain.DomainObjects;
using Biblioteka.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Biblioteka.Database.Repositories
{
    public class NaslovRepository : INaslovRepository
    {
        private readonly Mapper _naslovMapper;
        private readonly BibliotekaContext _context;

        public NaslovRepository(IConfigurationProvider naslovMapper, BibliotekaContext context)
        {
            _naslovMapper = new Mapper(naslovMapper);
            _context = context;
        }

        #region Methods

        public IEnumerable<Naslov> GetAll()
        {
            return _naslovMapper.Map<IEnumerable<Naslov>>(_context.NaslovModel
                .Include(t => t.IdJezikNavigation)
                .Include(u => u.IdVrstaNavigation));
        }

        public void Save(Naslov value)
        {
            NaslovModel naslov =
                _naslovMapper.Map<NaslovModel>(value);
            _context.Add(naslov);
            _context.SaveChanges();
        }
        public void Update(Naslov value)
        {
            NaslovModel naslovModel =
                _context.NaslovModel.SingleOrDefault(t => t.IdNaslov == value.Id);
            if (naslovModel != null)
            {
                naslovModel.IdNaslov = value.Id;
                naslovModel.Naziv = value.Naziv;
                naslovModel.IdJezik = value.Jezik.Id;
                naslovModel.IdVrsta = value.Vrsta.Id;
            }
            _context.SaveChanges();
        }//Save()
        public Naslov GetById(int id)
        {
            NaslovModel naslovModel =
                _context.NaslovModel.SingleOrDefault(t => t.IdNaslov == id);

            return _naslovMapper.Map<Naslov>(naslovModel);
        }//GetById()
        public void Delete(Naslov value)
        {
            NaslovModel naslovModel =
                _context.NaslovModel.SingleOrDefault(t => t.IdNaslov == value.Id);
            if (naslovModel != null) _context.NaslovModel.Remove(naslovModel);
            _context.SaveChanges();
        }//Delete()

        #endregion
    }//class
}//namespace
