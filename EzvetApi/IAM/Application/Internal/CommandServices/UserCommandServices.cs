
using EzvetApi.IAM.Application.Internal.OutBoundServices;
using EzvetApi.IAM.domain.Model.Aggregates;
using EzvetApi.IAM.domain.Model.Commands;
using EzvetApi.IAM.domain.Repositories;
using EzvetApi.IAM.domain.Services;
using EzvetApi.Shared.Domain.Repositories;

namespace EzvetApi.IAM.Application.Internal.CommandServices
{
    public class UserCommandService(
         IUserRepository userRepository,
         ITokenService tokenService,
         IHashingService hashingService,
         IUnitOfWork unitOfWork) : IUserCommandService
    {
        public async Task<User?> Handle(SignUpCommand command)
        {
            var hashedCommand = command with { Password = hashingService.GenerateHash(command.Password) };
            var user = new User(hashedCommand);

            try
            {
                await userRepository.AddAsync(user);
                await unitOfWork.CompleteAsync();
            }
            catch (Exception)
            {
                return null;
            }

            return user;
        }

        public async Task<(User?, string)> Handle(SignInCommand command)
        {
            var user = await userRepository.FindByEmailAsync(command.Email);

            if (user == null || !hashingService.VerifyHash(command.Password, user.Password))
                throw new Exception("Invalid username or password");

            var token = tokenService.GenerateToken(user);
            return (user, token);
        }
    }
}