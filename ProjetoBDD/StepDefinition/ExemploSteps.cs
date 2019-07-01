using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using SpecFlow.Assist.Dynamic;
using ProjetoBDD.POCO;

namespace ProjetoBDD.StepDefinition
{
    [Binding]
    public class ExemploSteps
    {
        int result = 0;
        public readonly DadosFruta dadosFruta;

        public ExemploSteps(DadosFruta dadosFruta)
        {
            this.dadosFruta = dadosFruta;
        }

        [Given(@"que liguei a calculadora")]
        public void GivenIHaveTurnedACalculatorOn()
        {
            Console.WriteLine("Calculadora Ligada");
            ScenarioContext.Current["result"] = result;
        }

        [When(@"somo (.*)")]
        public void WhenIAdd(int value)
        {
            result = Convert.ToInt32(ScenarioContext.Current["result"]);
            result += value;
            ScenarioContext.Current["result"] = result;
        }

        [Then(@"o resultado na tela deve ser (.*)")]
        public void ThenTheResultShouldBeOnTheScreen(int expectedResult)
        {
            result = Convert.ToInt32(ScenarioContext.Current["result"]);
            Assert.AreEqual(expectedResult, result);
        }

        [When(@"preencher apenas os dados obrigatórios")]
        public void QuandoPreencherApenasOsDadosObrigatorios(Table table)
        {
           DadosUsuario dados = table.CreateInstance<DadosUsuario>();

            Console.WriteLine("Imprimindo nome :" + dados.Nome);
            Console.WriteLine("Imprimindo idade :" + dados.Idade);
            Console.WriteLine("Imprimindo telefone :" + dados.Telefone);
            Console.WriteLine("Imprimindo email :" + dados.Email);
        }

        [When(@"preencher apenas os dados obrigatório de vários usuários")]
        public void QuandoPreencherApenasOsDadosObrigatorioDeVariosUsuarios(Table table)
        {
            var dados = table.CreateSet<DadosUsuario>();

            foreach (DadosUsuario valor in dados)
            {
                Console.WriteLine("Imprimindo nome :" + valor.Nome);
                Console.WriteLine("Imprimindo idade :" + valor.Idade);
                Console.WriteLine("Imprimindo telefone :" + valor.Telefone);
                Console.WriteLine("Imprimindo email :" + valor.Email);
            }

        }

        [When(@"preencher os dados dos produtos")]
        public void QuandoPreencherOsDadosDosProdutos(Table table)
        {
            var produtos = table.CreateDynamicSet();
            ScenarioContext.Current.Pending();
        }

        [When(@"preencher o ""(.*)"" , ""(.*)"" e ""(.*)"" do produto")]
        public void QuandoPreencherOEDoProduto(int id, string nome, Decimal valor)
        {
            Console.WriteLine("id : " + id);
            Console.WriteLine("nome : " + nome);
            Console.WriteLine("valor : " + valor);
        }

        [When(@"informar o usuário ""(.*)""")]
        public void QuandoInformarOUsuario(string usuario)
        {
            Console.WriteLine("usuario : " + usuario);
        }

        [Then(@"devo visualizar os dados preenchidos")]
        public void EntaoDevoVisualizarOsDadosPreenchidos()
        {
            Console.WriteLine("Fruta: " + dadosFruta.fruta);
            Console.WriteLine("Qdte: " + dadosFruta.quantidade);
            Console.WriteLine("Fornecedor: " + dadosFruta.fornecedor);
        }

        [Then(@"a mensagem deve ser visualizada")]
        public void EntaoAMensagemDeveSerVisualizada(string multilineText)
        {
            Console.WriteLine("Texto: " + multilineText);
        }



    }

}
