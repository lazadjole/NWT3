using System.Collections.Generic;
using Biblioteka.Domain.Dto;

namespace Biblioteka.Service
{
    public interface IEvidencijaDugovanjaService
    { 
        IEnumerable<EvidencijaDugovanjaDto>GetAll();
        IEnumerable<EvidencijaDugovanjaDto> GetTrenutnoZaduzeno();
        void Add(EvidencijaDugovanjaDto value);
        void Delete(EvidencijaDugovanjaDto value);
        void Update(EvidencijaDugovanjaDto value);
        EvidencijaDugovanjaDto GetById(int id);
        IEnumerable<EvidencijaDugovanjaDto> GetByIdClan(int id);
        IEnumerable<EvidencijaDugovanjaDto> GetByIdNaslov(int id);
    }//interface
}//namespace
