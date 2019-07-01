using System;
using TechTalk.SpecFlow;

namespace ProjetoBDD
{
    [Binding]
    public class LoginUsuarioSteps
    {
        [Given(@"que acessei minha aplicação")]
        [Scope(Feature = "Login Usuário")]
        public void DadoQueAcesseiMinhaAplicacao()
        {
            Console.WriteLine("Acesso a aplicacao de Usuario");
        }

        [When(@"realizar o login")]
        [Scope(Scenario = "Relizar o login na aplicação B")]
        public void QuandoRealizarOLogin()
        {
            Console.WriteLine("Login aplicacao B");
        }

        [Then(@"devo visualizar a área logada")]
        [Scope(Tag = "usuario")]
        public void EntaoDevoVisualizarAAreaLogada()
        {
            Console.WriteLine("Area logada da aplicacao B (Usuário)");
        }

    }
}
