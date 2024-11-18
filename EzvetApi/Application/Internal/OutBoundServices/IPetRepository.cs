using System.Collections.Generic;
using EzvetApi.Domain.Model;

namespace EzvetApi.Application.Internal.OutBoundServices
{
    public interface IPetRepository
    {
        IEnumerable<Pet> GetAll();
        Pet GetById(int id);
        void Add(Pet pet);
        void Update(Pet pet);
        void Delete(int id);
    }
}