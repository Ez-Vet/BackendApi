
using EzvetApi.IAM.domain.Model.Aggregates;
using EzvetApi.IAM.Interface.REST.Resources;

namespace EzvetApi.IAM.Interface.REST.Transform
{
    public class AuthenticatedUserResourceFromEntityAssembler
    {
        public static AuthenticatedUserResource ToResourceFromEntity(
        User user, string token)
        {
            return new AuthenticatedUserResource(user.Id, user.Name, token);
        }
    }
}