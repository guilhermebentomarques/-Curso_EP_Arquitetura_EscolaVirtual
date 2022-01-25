using System.Threading.Tasks;

namespace EscolaVirtual.Core.Infra.Email
{
    public interface IEnvioEmail
    {
        Task EnviarAsync(string nome, string email, string assunto, string mensagem);
    }
}