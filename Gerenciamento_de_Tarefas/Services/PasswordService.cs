using Gerenciamento_de_Tarefas.Models;
using Microsoft.AspNetCore.Identity;

namespace Gerenciamento_de_Tarefas.Services;

public class PasswordService
{
    private readonly PasswordHasher<Usuario> _passwordHasher = new();

    public string HashPassword(Usuario usuario)
    {
        return _passwordHasher.HashPassword(usuario, usuario.Senha);
    }

    public bool VerificarSenha(Usuario usuario, string senhaInformada)
    {
        var resultado = _passwordHasher.VerifyHashedPassword(usuario, usuario.Senha, senhaInformada);

        return resultado == PasswordVerificationResult.Success;
    }
}
