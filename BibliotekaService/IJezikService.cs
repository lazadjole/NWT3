using System.Collections.Generic;
using Biblioteka.Domain.Dto;

namespace Biblioteka.Service
{
    public interface IJezikService
    {
        IEnumerable<JezikDto> GetAll();
    }//interface
}//namespace
