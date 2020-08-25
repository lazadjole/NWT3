using System.Collections.Generic;
using AutoMapper;
using Biblioteka.Domain.Dto;
using Biblioteka.Domain.Repository;

namespace Biblioteka.Service
{
    public class JezikService:IJezikService
    {
        #region Fields
        private readonly Mapper _jezikMapper;
        private readonly IJezikRepository _jezikRepository;
        #endregion

        #region Constructors

        public JezikService(IConfigurationProvider jezikConfigurationProvider, IJezikRepository jezikRepository)
        {
            _jezikRepository = jezikRepository;
            _jezikMapper = new Mapper(jezikConfigurationProvider);
        }

        #endregion
        #region Methods

        public IEnumerable<JezikDto> GetAll()
        {
            return _jezikMapper.Map<IEnumerable<JezikDto>>(_jezikRepository.GetAll());
        }

        #endregion
    }//class
}//namespace