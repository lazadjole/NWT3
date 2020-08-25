using System.Collections.Generic;
using Biblioteka.Domain.Dto;

namespace Biblioteka.Service
{
    public interface IClanService
    {
        IEnumerable<ClanDto> GetAll();
        void Add(ClanDto value);
        void Delete(ClanDto value);
        void Update(ClanDto value);
        ClanDto GetById(int id);
    }//interface
}//class
