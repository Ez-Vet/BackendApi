using EzvetApi.IAM.domain.Model.Commands;
using EzvetApi.IAM.Interface.REST.Resources;

namespace EzvetApi.IAM.Interface.REST.Transform
{
    public class SignInCommandFromResourceAssembler
    {
        public static SignInCommand ToCommandFromResource(SignInResource resource)
        {
            return new SignInCommand(resource.Email, resource.Password);
        }
    }
}