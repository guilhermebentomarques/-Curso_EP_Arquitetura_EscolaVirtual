using System.Linq;
using EscolaVirtual.Cadastro.TestesAceitacao.Config;
using TechTalk.SpecFlow;
using Xunit;

namespace EscolaVirtual.Cadastro.TestesAceitacao.PedidoAluno
{
    [Binding]
    public class AlunoRealizandoUmaCompraSteps
    {
        public SeleniumHelper Browser;

        public AlunoRealizandoUmaCompraSteps()
        {
            Browser = SeleniumHelper.Instance();
        }

        [Given(@"Que um aluno navega até o site")]
        public void DadoQueUmAlunoNavegaAteOSite()
        {
            var url = Browser.NavegarParaSite("http://localhost/");
            Assert.Equal("http://localhost/", url);
        }

        [Given(@"Realiza login")]
        public void DadoRealizaLogin()
        {
            Browser.ClicarLinkSite("Log in");
            Browser.PreencherTextBox("Email", "contato@eduardopires.net.br");
            Browser.PreencherTextBox("Password", "Teste@123");
            Browser.ClicarBotaoSite("Login");
        }
      
        [Given(@"Clica no link de cursos")]
        public void DadoClicaNoLinkDeCursos()
        {
            Browser.ClicarLinkSite("Cursos");
        }
        
        [Given(@"Clica no primeiro curso da lista para adicionar no carrinho")]
        public void DadoClicaNoPrimeiroCursoDaListaParaAdicionarNoCarrinho()
        {
            var cursos = Browser.ObterListaPorClasse("glyphicon-shopping-cart");
            cursos.FirstOrDefault().Click();
        }
        
        [Given(@"O aluno é direcionado ao carrinho")]
        public void DadoOAlunoEDirecionadoAoCarrinho()
        {
            Assert.True(Browser.ValidarConteudoUrl("http://localhost/carrinho/adicionar/"));
        }
        
        [Given(@"Clica no botao de realizar pagamento")]
        public void DadoClicaNoBotaoDeRealizarPagamento()
        {
            Browser.ClicarBotaoSite("Comprar");
        }
        
        [Given(@"É direcionado para a pagina de pagamento")]
        public void DadoEDirecionadoParaAPaginaDePagamento()
        {
            Assert.True(Browser.ValidarConteudoUrl("http://localhost/pagamento"));
        }
        
        [Given(@"Preenche os dados de pagamento")]
        public void DadoPreencheOsDadosDePagamento()
        {
            Browser.PreencherTextBox("NumeroCartao", "1111222233334444");
            Browser.PreencherTextBox("MesVencimento", "12");
            Browser.PreencherTextBox("AnoVencimento", "17");
            Browser.PreencherTextBox("CodigoSeguranca", "236");
        }
        
        [When(@"Confirma a compra")]
        public void QuandoConfirmaACompra()
        {
            Browser.ClicarBotaoSite("Confirmar");
        }
        
        [Then(@"Recebe uma mensagem de confirmacao")]
        public void EntaoRecebeUmaMensagemDeConfirmacao()
        {
            Assert.True(Browser.ObterTextoElementoPorClasse("alert-info") == "Sucesso!");
        }
    }
}
