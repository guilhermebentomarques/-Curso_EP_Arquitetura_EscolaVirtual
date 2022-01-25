using BoDi;
using EscolaVirtual.Cadastro.TestesAceitacao.Config;
using TechTalk.SpecFlow;
using Xunit;

namespace EscolaVirtual.Cadastro.TestesAceitacao.CadastroAluno
{
    [Binding]
    public class CadastrarUmNovoAlunoSteps
    {
        public SeleniumHelper Browser;

        public CadastrarUmNovoAlunoSteps()
        {
            Browser = SeleniumHelper.Instance();
        }

        [Given(@"que o aluno está no site, na pagina inicial")]
        public void DadoQueOAlunoEstaNoSiteNaPaginaInicial()
        {
            var url = Browser.NavegarParaSite("http://localhost/");

            Assert.Equal("http://localhost/", url);
        }
        
        [Given(@"clica no link de registro")]
        public void DadoClicaNoLinkDeRegistro()
        {
            Browser.ClicarLinkSite("Register");
        }
        
        [Given(@"preenche os campos com os valores")]
        public void DadoPreencheOsCamposComOsValores(Table table)
        {
            Browser.PreencherTextBox("Nome", table.Rows[0][1]);
            Browser.PreencherTextBox("Email", table.Rows[1][1]);
            Browser.PreencherTextBox("CPF", table.Rows[2][1]);
            Browser.PreencherTextBox("Password", table.Rows[3][1]);
            Browser.PreencherTextBox("ConfirmPassword", table.Rows[4][1]);
        }
        
        [When(@"clicar no botao registrar")]
        public void QuandoClicarNoBotaoRegistrar()
        {
            Browser.ClicarBotaoSite("Registrar");
        }
        
        [Then(@"Recebe uma mensagem de cadastro com sucesso")]
        public void EntaoRecebeUmaMensagemDeCadastroComSucesso()
        {
            var returnText = Browser.ObterTextoElementoPorClasse("text-info");
            Assert.True(returnText.ToLower().Contains("verifique seu e-mail e confirme seu endereço"));
        }

        [Then(@"Recebe uma mensagem de erro de CPF já cadastrado")]
        public void EntaoRecebeUmaMensagemDeErroDeCPFJaCadastrado()
        {
            var result = Browser.ObterTextoElementoPorClasse("validation-summary-errors");
            Assert.True(result.ToLower().Contains("cpf já cadastrado"));

            Browser.ObterScreenShot("CPF_Erro");
        }

        [Then(@"recebe uma mensagem de erro de email já cadastrado")]
        public void EntaoRecebeUmaMensagemDeErroDeEmailJaCadastrado()
        {
            var result = Browser.ObterTextoElementoPorClasse("validation-summary-errors");
            Assert.True(result.ToLower().Contains("e-mail já registrado"));
        }

        [Then(@"Recebe uma mensagem de erro de que a senha requer numero")]
        public void EntaoRecebeUmaMensagemDeErroDeQueASenhaRequerNumero()
        {
            var result = Browser.ObterTextoElementoPorClasse("validation-summary-errors");
            Assert.True(result.ToLower().Contains("a senha precisa ter ao menos um dígito"));
        }

        [Then(@"Recebe uma mensagem de erro de que a senha requer letra maiuscula")]
        public void EntaoRecebeUmaMensagemDeErroDeQueASenhaRequerLetraMaiuscula()
        {
            var result = Browser.ObterTextoElementoPorClasse("validation-summary-errors");
            Assert.True(result.ToLower().Contains("a senha precisa ter ao menos uma letra em maiúsculo"));
        }

        [Then(@"Recebe uma mensagem de erro de que a senha requer letra minuscula")]
        public void EntaoRecebeUmaMensagemDeErroDeQueASenhaRequerLetraMinuscula()
        {
            var result = Browser.ObterTextoElementoPorClasse("validation-summary-errors");
            Assert.True(result.ToLower().Contains("a senha precisa ter ao menos uma letra em minúsculo"));
        }

        [Then(@"Recebe uma mensagem de erro de que a senha requer caracter especial")]
        public void EntaoRecebeUmaMensagemDeErroDeQueASenhaRequerCaracterEspecial()
        {
            var result = Browser.ObterTextoElementoPorClasse("validation-summary-errors");
            Assert.True(result.ToLower().Contains("a senha precisa ter ao menos um caractere especial"));
        }

        [Then(@"Recebe uma mensagem de erro de que a senha esta em tamanho inferior ao permitido")]
        public void EntaoRecebeUmaMensagemDeErroDeQueASenhaEstaEmTamanhoInferiorAoPermitido()
        {
            var result = Browser.ObterTextoElementoPorClasse("field-validation-error");
            Assert.True(result.ToLower().Contains("the password must be at least 6 characters long"));
        }

        [Then(@"Recebe uma mensagem de erro de que a senha estao diferentes")]
        public void EntaoRecebeUmaMensagemDeErroDeQueASenhaEstaoDiferentes()
        {
            var result = Browser.ObterTextoElementoPorClasse("field-validation-error");
            Assert.True(result.ToLower().Contains("the password and confirmation password do not match"));
        }
    }
}
