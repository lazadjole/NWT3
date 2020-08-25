using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Biblioteka.Database.Models;
using Biblioteka.Domain.DomainObjects;
using Biblioteka.Domain.Repository;

namespace Biblioteka.Database.Repositories
{
    public class ClanRepository : IClanRepository
    {
        private readonly Mapper _clanMapper;
        private readonly BibliotekaContext _context;

        public ClanRepository(IConfigurationProvider clanMapper, BibliotekaContext context)
        {
            _clanMapper = new Mapper(clanMapper);
            _context = context;
        }

        #region Methods

        public IEnumerable<Clan> GetAll()
        {
           return _clanMapper.Map<IEnumerable<Clan>>(_context.ClanModel);
        }

        public void Save(Clan value)
        {
            ClanModel clan =
                _clanMapper.Map<ClanModel>(value);
            _context.Add(clan);
            _context.SaveChanges();
        }
        public void Update(Clan value)
        {
            ClanModel clan =
                _context.ClanModel.SingleOrDefault(t => t.IdClan == value.Id);
            if (clan != null)
            {
                clan.IdClan = value.Id;
                clan.ImePrezime = value.ImePrezime;
                clan.Jmbg = value.JMBG;
            }
            _context.SaveChanges();
        }//Save()
        public Clan GetById(int id)
        {
            ClanModel clanModel =
                _context.ClanModel.SingleOrDefault(t => t.IdClan == id);

            return _clanMapper.Map<Clan>(clanModel);
        }//GetById()
        public void Delete(Clan value)
        {
            ClanModel clanModel =
                _context.ClanModel.SingleOrDefault(t => t.IdClan == value.Id);
            if (clanModel != null) _context.ClanModel.Remove(clanModel);
            _context.SaveChanges();
        }//Delete()

        #endregion
    }//class
}//namespace
