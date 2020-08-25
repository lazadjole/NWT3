using Biblioteka.Domain.DomainObjects;

namespace Biblioteka.Domain.Repository
{
    public interface IClanRepository:IAssetsRepository<Clan>
    {
        void Update(Clan value);
        void Delete(Clan value);
        Clan GetById(int id);
    }//interface
}//namespace
