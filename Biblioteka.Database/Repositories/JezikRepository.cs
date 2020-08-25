using Biblioteka.Domain.Repository;
using System;
using System.Collections.Generic;
using Biblioteka.Domain.DomainObjects;
using AutoMapper;
using Biblioteka.Database.Models;

namespace Biblioteka.Database.Repositories
{
    public class JezikRepository : IJezikRepository
    {
        private readonly Mapper _jezikMapper;
        private readonly BibliotekaContext _context;

        public JezikRepository(IConfigurationProvider jezikMapper, BibliotekaContext context)
        {
            _context = context;
            _jezikMapper = new Mapper(jezikMapper);
        }

        #region Methods

        public IEnumerable<Jezik> GetAll()
        {
            return _jezikMapper.Map<IEnumerable<Jezik>>(_context.JezikModel);
        }

        public void Save(Jezik value)
        {
            throw new NotImplementedException();
        }

        #endregion
    }//class
}//namespace
