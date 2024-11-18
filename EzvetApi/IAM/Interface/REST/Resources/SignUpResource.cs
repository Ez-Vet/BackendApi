using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EzvetApi.IAM.Interface.REST.Resources
{
    //TODO docs
    public record SignUpResource(string Name, string Email, string Password, string Speciality, string Phone, string DNI);
}
