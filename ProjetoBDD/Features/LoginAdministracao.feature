#language: pt

Funcionalidade: Login Administração
	Como um Administrador
	Quero realizar um login

@administracao @serivco
Cenario: Relizar o login na aplicação A
	Dado que acessei minha aplicação
	Quando realizar o login
	Então devo visualizar a área logada 
