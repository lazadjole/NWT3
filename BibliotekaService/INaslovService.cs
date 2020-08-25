using System.Collections.Generic;
using Biblioteka.Domain.Dto;

namespace Biblioteka.Service
{
    public interface INaslovService
    {
        IEnumerable<NaslovDto> GetAll();
        void Add(NaslovDto value);
        void Delete(NaslovDto value);
        void Update(NaslovDto value);
        NaslovDto GetById(int id);
    }//interface
}//namespace
