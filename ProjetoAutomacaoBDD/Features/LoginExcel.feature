#language: pt

Funcionalidade: Login Excel
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

#Lendo os dados pelo excel
Cenário: Login com usuário válido, dados do Excel
	Dado que possuo um usuário "válido"
	E que acessei o site de compras
	Quando realizar um login com os dados que foram lidos
	Então devo visualizar a área logada do site

Cenário: Login com um email inválido, dados do Excel
	Dado que possuo um usuário "inválido"
	E que acessei o site de compras
	Quando realizar um login com os dados que foram lidos
	Então devo visualizar o alerta sobre email inválido
		"""
		There is 1 error Authentication failed.
		"""

