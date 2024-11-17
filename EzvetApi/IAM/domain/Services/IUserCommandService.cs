using EzvetApi.IAM.domain.Model.Aggregates;
using EzvetApi.IAM.domain.Model.Commands;

namespace EzvetApi.IAM.domain.Services
{
    public interface IUserCommandService
    {
        Task<User?> Handle(SignUpCommand command);
        Task<(User? user, string token)> Handle(SignInCommand command);
    }
}