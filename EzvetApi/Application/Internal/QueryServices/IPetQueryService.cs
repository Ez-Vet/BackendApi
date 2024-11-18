using System.Collections.Generic;
using EzvetApi.Domain.Model;

namespace EzvetApi.Application.Internal.QueryServices
{
    public interface IPetQueryService
    {
        IEnumerable<Pet> GetAllPets();
        Pet GetPetById(int id);
    }
}