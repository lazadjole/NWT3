using System.Collections.Generic;
using AutoMapper;
using Biblioteka.Domain.DomainObjects;
using Biblioteka.Domain.Dto;
using Biblioteka.Domain.Repository;

namespace Biblioteka.Service
{
    public class NaslovService:INaslovService
    {
        #region Fields

        private readonly Mapper _naslovMapper;
        private readonly INaslovRepository _naslovRepository;

        #endregion

        #region Constructors

        public NaslovService(IConfigurationProvider naslovMapper, INaslovRepository naslovRepository)
        {
            _naslovMapper = new Mapper(naslovMapper);
            _naslovRepository = naslovRepository;
        }

        #endregion

        #region Methods

        public IEnumerable<NaslovDto> GetAll()
        {
            return _naslovMapper.Map<IEnumerable<NaslovDto>>(_naslovRepository.GetAll());
        }
        public void Add(NaslovDto value)
        {
            Naslov naslov = _naslovMapper.Map<Naslov>(value);
            _naslovRepository.Save(naslov);
        }

        public void Delete(NaslovDto value)
        {
            Naslov naslov = _naslovMapper.Map<Naslov>(value);
            _naslovRepository.Delete(naslov);
        }

        public void Update(NaslovDto value)
        {
            Naslov naslov = _naslovMapper.Map<Naslov>(value);
            _naslovRepository.Update(naslov);
        }

        public NaslovDto GetById(int id)
        {
            return _naslovMapper.Map<NaslovDto>(_naslovRepository
                .GetById(id));
        }
        #endregion
    }//class
}//namespace