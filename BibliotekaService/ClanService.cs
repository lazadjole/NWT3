using System.Collections.Generic;
using AutoMapper;
using Biblioteka.Domain.DomainObjects;
using Biblioteka.Domain.Dto;
using Biblioteka.Domain.Repository;

namespace Biblioteka.Service
{
    public class ClanService:IClanService
    {
        #region Fields

        private readonly Mapper _clanMapper;
        private readonly IClanRepository _clanRepository;

        #endregion

        #region Constructors

        public ClanService(IConfigurationProvider clanMapper, IClanRepository clanRepository)
        {
            _clanMapper = new Mapper(clanMapper);
            _clanRepository = clanRepository;
        }

        #endregion

        #region Methods

        public IEnumerable<ClanDto> GetAll()
        {
            return _clanMapper.Map<IEnumerable<ClanDto>>(_clanRepository.GetAll());
        }

        public void Add(ClanDto value)
        {
            Clan evidencijaDugovanja = _clanMapper.Map<Clan>(value);
            _clanRepository.Save(evidencijaDugovanja);
        }

        public void Delete(ClanDto value)
        {
            Clan clan = _clanMapper.Map<Clan>(value);
            _clanRepository.Delete(clan);
        }

        public void Update(ClanDto value)
        {
            Clan clan = _clanMapper.Map<Clan>(value);
            _clanRepository.Update(clan);
        }

        public ClanDto GetById(int id)
        {
            return _clanMapper.Map<ClanDto>(_clanRepository
                .GetById(id));
        }
        #endregion
    }//class
}//namespace