using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace ProjetoBDD
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        /*
                [BeforeTestRun]
                public static void BeforeTestRun()
                {
                    Console.WriteLine("Executando Antes de todas as Features");
                }

                [AfterTestRun]
                public static void AfterTestRun()
                {
                    Console.WriteLine("Executando depois de todas as Features");
                }

                [BeforeFeature]
                public static void BeforeFeature()
                {
                    Console.WriteLine("Executando Antes da Feature");
                }

                [AfterFeature]
                public static void AfterFeature()
                {
                    Console.WriteLine("Executando Depois da Feature");
                }

                [BeforeScenario]
                public void BeforeScenario()
                {
                    Console.WriteLine("Executando Antes do Cenário");
                }

                [AfterScenario]
                public void AfterScenario()
                {
                    Console.WriteLine("Executando Após do Cenário");
                }

                [BeforeStep]
                public void BeforeStep()
                {
                    Console.WriteLine("Executando Antes de cada Passo");
                }

                [AfterStep]
                public void AfterStep()
                {
                    Console.WriteLine("Executando Após de cada Passo");
                }

                [BeforeScenarioBlock]
                public void BeforeScenarioBlock()
                {
                    Console.WriteLine("Executando Antes do bloco de cenário");
                }

                [AfterScenarioBlock]
                public void AfterScenarioBlock()
                {
                    Console.WriteLine("Executando Após o bloco de cenário");
                }
         */
    /*
        [AfterStep]
        public void AfterScenario()
        {
            string tituloFeature = FeatureContext.Current.FeatureInfo.Title;
            string tituloCenario = ScenarioContext.Current.ScenarioInfo.Title;

            //Necessário que possua uma tag, retonra um array com as tags
            var tagCenario = ScenarioContext.Current.ScenarioInfo.Tags;

            //A informação do passo só é obtida no before ou after Step
            string tipoPasso = ScenarioContext.Current.CurrentScenarioBlock.ToString();
            string passo = ScenarioContext.Current.StepContext.StepInfo.Text;

            Console.WriteLine("Titulo da Feature: " + tituloFeature);
            Console.WriteLine("Titulo do Cenario: " + tituloCenario);
            Console.WriteLine("Tag do Cenario: " + tagCenario.First());
            Console.WriteLine("Passo atual: " + tipoPasso + " " + passo);
        }
        */

        [BeforeScenario("web")]
        public static void BeforeWebScenario()
        {
            Console.WriteLine("Executando Antes do Cenário com tag WEB");
        }

        [BeforeScenario("servico")]
        public static void BeforeServiceScenario()
        {
            Console.WriteLine("Executando Antes do Cenário com tag SERVICO");
        }

    }
}
