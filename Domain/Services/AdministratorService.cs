using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore;
using minimal_api.Domain.Entitys;
using minimal_api.DTOs;
using minimal_api.Infra.Db;
using minimal_api.Infra.Interfaces;

namespace minimal_api.Domain.Services;

public class AdministratorService : iAdministratorService
{

    private readonly DatabaseContext _contexto;
    public AdministratorService(DatabaseContext db)
    {
        _contexto = db;
    }

    public Adiministrator? login(LoginDTO login)
    {
        var adm = _contexto.Adiministrators.Where(a => a.Email == login.Email && a.Password == login.Password).FirstOrDefault();
        return adm;
    }

}
