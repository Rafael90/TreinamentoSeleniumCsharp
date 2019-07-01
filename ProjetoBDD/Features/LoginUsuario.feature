#language: pt

Funcionalidade: Login Usuário
	Como um usuário
	Quero realizar um login

@usuario @web
Cenario: Relizar o login na aplicação B
	Dado que acessei minha aplicação
	Quando realizar o login
	Então devo visualizar a área logada 
