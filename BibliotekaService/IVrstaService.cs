using System.Collections.Generic;
using AutoMapper;
using Biblioteka.Domain.Dto;
using Biblioteka.Domain.Repository;

namespace Biblioteka.Service
{
    public interface IVrstaService
    {
        IEnumerable<VrstaDto> GetAll();
    }//interface
}//class
