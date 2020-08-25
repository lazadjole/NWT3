using System.Data;
using Biblioteka.Domain.DomainObjects;

namespace Biblioteka.Domain.Repository
{
    public interface IEvidencijaDugovanjaRepository:IAssetsRepository<EvidencijaDugovanja>
    {
        void Update(EvidencijaDugovanja value);
        void Delete(EvidencijaDugovanja value);

        EvidencijaDugovanja GetById(int id);
    }//interface
}//namespace
