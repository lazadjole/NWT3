using System;
using System.Collections.Generic;
using AutoMapper;
using Biblioteka.Database.Models;
using Biblioteka.Domain.DomainObjects;
using Biblioteka.Domain.Repository;

namespace Biblioteka.Database.Repositories
{
    public class VrstaRepository : IVrstaRepository
    {
        private readonly Mapper _vrstaMapper;
        private readonly BibliotekaContext _context;

        public VrstaRepository(IConfigurationProvider vrstaMapper, BibliotekaContext context)
        {
            _vrstaMapper = new Mapper(vrstaMapper);
            _context = context;
        }

        #region Methods

        public IEnumerable<Vrsta> GetAll()
        {
           return _vrstaMapper.Map<IEnumerable<Vrsta>>(_context.VrstaModel);
        }

        public void Save(Vrsta value)
        {
            throw new NotImplementedException();
        }

        #endregion
    }//class
}//namespace
