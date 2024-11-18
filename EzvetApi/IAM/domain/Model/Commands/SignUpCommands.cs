namespace EzvetApi.IAM.domain.Model.Commands
{
    public record SignUpCommand(
        string Name,
        string Email,
        string Password,
        string Speciality,
        string Phone,
        string DNI
        );
}

