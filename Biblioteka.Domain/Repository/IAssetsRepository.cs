using System.Collections.Generic;

namespace Biblioteka.Domain.Repository
{
    public interface IAssetsRepository<T> where T : IAssetId
    {
       IEnumerable<T> GetAll();
        void Save(T value);
    }

    public interface IAssetId
    {
        int Id { get; }
    }
}
