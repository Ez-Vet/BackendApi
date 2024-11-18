
using System.Globalization;
using Microsoft.VisualBasic;

using EzvetApi.IAM.domain.Model.Commands;
using EzvetApi.IAM.Interface.REST.Resources;

namespace EzvetApi.IAM.Interface.REST.Transform
{
    public class SignUpCommandFromResourceAssembler
    {
        public static SignUpCommand ToCommandFromResource(SignUpResource resource)
        {
            return new SignUpCommand(
               resource.Name,
               resource.Email,
               resource.Password,
               resource.Speciality,
               resource.Phone,
               resource.DNI
               );
        }
    }
}