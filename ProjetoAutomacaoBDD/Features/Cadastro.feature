#language: pt

Funcionalidade: Cadastro
	Como um novo usuário
	Quero poder me cadastrar no site

Cenário: Realizar um cadastro
	Dado que possuo um usuário não cadastrado no site
	E que acessei o site de compras
	Quando acessar a página de login
	E informar o email do novo usuário
	E realizar seu cadastro
	Então devo visualizar a área logada do site