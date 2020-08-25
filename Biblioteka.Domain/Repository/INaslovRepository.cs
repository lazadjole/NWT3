using Biblioteka.Domain.DomainObjects;

namespace Biblioteka.Domain.Repository
{
    public interface INaslovRepository:IAssetsRepository<Naslov>
    {
        void Update(Naslov value);
        void Delete(Naslov value);
        Naslov GetById(int id);
    }//interface
}//namespace
