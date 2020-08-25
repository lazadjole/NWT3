using System;
using System.Collections.Generic;
using AutoMapper;
using Biblioteka.Database.Repositories;
using Biblioteka.Domain.Dto;
using Biblioteka.Domain.Repository;

namespace Biblioteka.Service
{
    public class VrstaService:IVrstaService
    {
        #region Fields

        private readonly Mapper _vrstaMapper;
        private readonly IVrstaRepository _vrstaRepository;

        #endregion
        #region Constructors

        public VrstaService(IConfigurationProvider vrstaMapper, IVrstaRepository vrstaRepository)
        {
            _vrstaMapper = new Mapper(vrstaMapper);
            _vrstaRepository = vrstaRepository;
        }

        #endregion

        #region Methods

        public IEnumerable<VrstaDto> GetAll()
        {
            return _vrstaMapper.Map<IEnumerable<VrstaDto>>(_vrstaRepository.GetAll());
        }

        #endregion
    }//class
}//namespace