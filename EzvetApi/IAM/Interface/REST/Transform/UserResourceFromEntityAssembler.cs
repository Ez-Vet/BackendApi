
using EzvetApi.IAM.domain.Model.Aggregates;
using EzvetApi.IAM.Interface.REST.Resources;

namespace EzvetApi.IAM.Interface.REST.Transform
{
    public class UserResourceFromEntityAssembler
    {
        public static UserResource ToResourceFromEntity(User user)
        {
            return new UserResource(user.Id, user.Email);
        }
    }
}