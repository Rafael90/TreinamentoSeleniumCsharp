using ProjetoBDD.POCO;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ProjetoBDD.StepDefinition
{
    [Binding]
    public class ExemploDoisSteps
    {
        int result;
        public readonly DadosFruta dadosFruta;

        public ExemploDoisSteps(DadosFruta dadosFruta)
        {
            this.dadosFruta = dadosFruta;
        }

        [When(@"subtraio (.*)")]
        public void QuandoSubtraio(int value)
        {
            result = Convert.ToInt32(ScenarioContext.Current["result"]);
            result -= value;
            ScenarioContext.Current["result"] = result;

        }

        [When(@"cadastrar uma fruta")]
        public void QuandoCadastrarUmaFruta(Table table)
        {
            dynamic produtos = table.CreateDynamicInstance();

            dadosFruta.fruta = produtos.Fruta;
            dadosFruta.quantidade = produtos.Quantidade;
            dadosFruta.fornecedor = produtos.Fornecedor;
        }

    }
}
