using System.Collections.Generic;
using Biblioteka.Domain.Dto;

namespace Biblioteka.Service
{
    public interface IEvidencijaDugovanjaService
    { 
        IEnumerable<EvidencijaDugovanjaDto>GetAll();
        void Add(EvidencijaDugovanjaDto value);
        void Delete(EvidencijaDugovanjaDto value);
        void Update(EvidencijaDugovanjaDto value);
        EvidencijaDugovanjaDto GetById(int id);
    }//interface
}//namespace
