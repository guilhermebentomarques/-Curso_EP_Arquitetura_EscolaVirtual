
namespace EscolaVirtual.Cadastro.Domain.Enderecos
{
    public class CEP
    {
        public string CepCod { get; private set; }
        public const int CepMaxLength = 8;

        public CEP(string cep)
        {
            CepCod = cep;
        }

        public string ObterCepFormatado()
        {
            if (CepCod == null)
                return "";
            
            while (CepCod.Length < 8)
                CepCod = "0" + CepCod;

            return CepCod.Substring(0, 5) + "-" + CepCod.Substring(5);
        }
    }
}