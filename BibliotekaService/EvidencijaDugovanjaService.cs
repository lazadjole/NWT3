using System.Collections.Generic;
using AutoMapper;
using Biblioteka.Domain.DomainObjects;
using Biblioteka.Domain.Dto;
using Biblioteka.Domain.Repository;
namespace Biblioteka.Service
{
    public class EvidencijaDugovanjaService:IEvidencijaDugovanjaService
    {
        #region Fields

        private readonly Mapper _evidencijaDugovanjaMapper;
        private readonly IEvidencijaDugovanjaRepository _evidencijaDugovanjaRepository;

        #endregion

        #region Constructors

        public EvidencijaDugovanjaService(IConfigurationProvider evidencijaDugovanjaMapper, IEvidencijaDugovanjaRepository evidencijaDugovanjaRepository)
        {
            _evidencijaDugovanjaMapper = new Mapper(evidencijaDugovanjaMapper);
            _evidencijaDugovanjaRepository = evidencijaDugovanjaRepository;
        }

        #endregion

        #region Methods

        public IEnumerable<EvidencijaDugovanjaDto> GetAll()
        {
            return _evidencijaDugovanjaMapper.Map<IEnumerable<EvidencijaDugovanjaDto>>(_evidencijaDugovanjaRepository
                .GetAll());
        }

        public void Add(EvidencijaDugovanjaDto value)
        {
            EvidencijaDugovanja evidencijaDugovanja = _evidencijaDugovanjaMapper.Map<EvidencijaDugovanja>(value);
             _evidencijaDugovanjaRepository.Save(evidencijaDugovanja);
        }

        public void Delete(EvidencijaDugovanjaDto value)
        {
            EvidencijaDugovanja evidencijaDugovanja = _evidencijaDugovanjaMapper.Map<EvidencijaDugovanja>(value);
            _evidencijaDugovanjaRepository.Delete(evidencijaDugovanja);
        }

        public void Update(EvidencijaDugovanjaDto value)
        {
            EvidencijaDugovanja evidencijaDugovanja = _evidencijaDugovanjaMapper.Map<EvidencijaDugovanja>(value);
            _evidencijaDugovanjaRepository.Update(evidencijaDugovanja);
        }

        public EvidencijaDugovanjaDto GetById(int id)
        {
            return _evidencijaDugovanjaMapper.Map<EvidencijaDugovanjaDto>(_evidencijaDugovanjaRepository
                .GetById(id));
        }

        #endregion
    }//class
}//namespace