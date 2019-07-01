#language: pt

Funcionalidade: Login
	Como um usuário
	Quero realizar o login no site
	Para ter acesso à minha área logada

Contexto: 
Dado que acessei o site de compras

Cenário: Login com usuário válido
	Quando realizar um login utilizando um usuário válido
	| Usuario           | Senha    |
	| teste@testing.com | 1234qwer |
	Então devo visualizar a área logada do site
	
Cenário: Login com um email inválido
	Quando realizar um login utilizando um email inválido
	| Usuario     | Senha    |
	| teste@a.com | 1234qwer |
	Então devo visualizar o alerta sobre email inválido
	"""
	There is 1 error Authentication failed.
	"""

Cenário: Login sem preencher o email
	Quando realizar um login utilizando um email vazio
		| Usuario | Senha    |
		|         | 1234qwer |
	Então devo visualizar o alerta sobre email vazio
		"""
		There is 1 error An email address required.
		"""

Cenário: Login com uma senha inválida
	Quando realizar um login utilizando uma senha inválida
		| Usuario     | Senha |
		| teste@a.com | 1     |
	Então devo visualizar o alerta sobre uma senha inválida
		"""
		There is 1 error Invalid password.
		"""

Cenário: Login sem preencher a senha
	Quando realizar um login utilizando uma senha vazia
		| Usuario     | Senha |
		| teste@a.com |       |
	Então devo visualizar o alerta sobre uma senha vazia
		"""
		There is 1 error Password is required.
		"""
#Cenarios negativos com esquema do cenário, agrupando os 4 cenarios negativos nos mesmos passos
Esquema do Cenário: Login cenários negativos
	Quando realizar um login com usuário <usuario> e senha <senha>
	Então devo visualizar o alerta com a mensagem <mensagem>

	Exemplos:
| Tipo           | usuario             | senha      | mensagem                                      |
| Email Invalido | "teste@a.com"       | "12312313" | "There is 1 error Authentication failed."     |
| Email Vazio    | ""                  | "124qewr"  | "There is 1 error An email address required." |
| Senha Invalida | "teste@testing.com" | "1"        | "There is 1 error Invalid password."          |
| Senha Vazia    | "teste@testing.com" | ""         | "There is 1 error Password is required."      |


