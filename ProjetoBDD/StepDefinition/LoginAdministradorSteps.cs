using System;
using TechTalk.SpecFlow;

namespace ProjetoBDD
{
    [Binding]
    public class LoginAdministradorSteps
    {
        [Given(@"que acessei minha aplicação")]
        [Scope(Tag = "administracao", Feature = "Login Administração")]
        public void DadoQueAcesseiMinhaAplicacao()
        {
            Console.WriteLine("Acesso a aplicacao de Administracao");
        }

        [When(@"realizar o login")]
        [Scope(Feature = "Login Administração")]
        [Scope(Tag = "administracao")]
        public void QuandoRealizarOLogin()
        {
            Console.WriteLine("Login aplicacao A");
        }

        [Then(@"devo visualizar a área logada")]
        [Scope(Feature = "Login Administração")]
        [Scope(Tag = "administracao")]
        [Scope(Scenario = "Relizar o login na aplicação A")]
        public void EntaoDevoVisualizarAAreaLogada()
        {
            Console.WriteLine("Area logada da aplicacao A (Adm)");
        }

    }
}
