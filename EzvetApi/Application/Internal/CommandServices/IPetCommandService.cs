using EzvetApi.Domain.Model;

namespace EzvetApi.Application.Internal.CommandServices
{
    public interface IPetCommandService
    {
        Pet CreatePet(Pet newPet);
        bool UpdatePet(int id, Pet updatedPet);
        bool DeletePet(int id);
    }
}