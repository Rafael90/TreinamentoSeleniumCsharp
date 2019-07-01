#language: pt

Funcionalidade: FaleConosco
	Como um usuário
	Quero poder entrar em contato com a empresa
	Para poder esclarecer dúvidas sobre o site ou pedidos

Cenário: Enviar uma mensagem válida
	Dado que acessei o site de compras
	Quando acessar a página Contact Us
	E realizar o envio de uma mensagem válida
	Então devo visualizar a mensagem de sucesso
	"""
	Your message has been successfully sent to our team.
	"""

Cenário:  Enviar uma mensagem válida informando um email inválido
	Dado que acessei o site de compras
	Quando acessar a página Contact Us
	E realizar o envio de uma mensagem informando um email inválido
	Então devo visualizar a mensagem de email inválido
		"""
		There is 1 error Invalid email address.
		"""

