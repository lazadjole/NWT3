using System.Collections.Generic;
using System.Data;
using Biblioteka.Domain.DomainObjects;

namespace Biblioteka.Domain.Repository
{
    public interface IEvidencijaDugovanjaRepository:IAssetsRepository<EvidencijaDugovanja>
    {
        void Update(EvidencijaDugovanja value);
        void Delete(EvidencijaDugovanja value);

        EvidencijaDugovanja GetById(int id);
        IEnumerable<EvidencijaDugovanja> GetByIdClan(int id);
        IEnumerable<EvidencijaDugovanja> GetByIdNaslov(int id);
    }//interface
}//namespace
