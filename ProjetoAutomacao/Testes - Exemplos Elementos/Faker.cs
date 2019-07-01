using System;
using Bogus;
using Bogus.Extensions.Brazil;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjetoAutomacao.Testes_Exemplos_Elementos
{
    [TestClass]
    public class Faker
    {
        [TestMethod]
        public void TestMethod1()
        {
            Bogus.Faker gerador = new Bogus.Faker("pt_BR");
            string nome = gerador.Name.FirstName();
            string sobrenome = gerador.Name.LastName();
            Console.WriteLine(nome + " " + sobrenome);

            Console.WriteLine(nome);

            string email = gerador.Internet.Email();
            Console.WriteLine(email);

            string emailCustomizado = gerador.Internet.Email(nome, sobrenome);
            Console.WriteLine(emailCustomizado);

            DateTime dataNascimento = gerador.Date.Past();
            Console.WriteLine(dataNascimento);

            //Simular que a data de aniversário seja de alguém entre 18 e 70 anos(agora também formatando a data):

            string birthDate = gerador.Date.Past(70, DateTime.Now.AddYears(-18)).ToString("dd/MM/yyyy");
            Console.WriteLine(birthDate);

            string telefone = gerador.Phone.PhoneNumber().ToString();
            Console.WriteLine(telefone);

            string celular = gerador.Phone.PhoneNumber("(##)9########").ToString();
            Console.WriteLine(celular);

            string lorem = gerador.Lorem.Paragraph(5);
            Console.WriteLine(lorem);

            string cpf = gerador.Person.Cpf();
            Console.WriteLine(cpf);
            string cnpj = gerador.Company.Cnpj();
            Console.WriteLine(cnpj);


        }
    }
}
