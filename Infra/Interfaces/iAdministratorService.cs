using minimal_api.Domain.Entitys;
using minimal_api.DTOs;

namespace minimal_api.Infra.Interfaces;

public interface iAdministratorService
{
    Adiministrator? login(LoginDTO login);
    
}
