#language: pt
Funcionalidade: Exemplo
	Como um analista de teste
	Quero escrever cenários de exemplo
	Para aprender a usar o specflow

@mytag
Cenário: Somar dois números
	Dado que liguei a calculadora
	Quando somo 50
	E somo 70
	Então o resultado na tela deve ser 120

Cenario: Somar um número e subtrair um
	Dado que liguei a calculadora
	Quando somo 50
	E subtraio 30
	Então o resultado na tela deve ser 20

Cenario: Subtrair um número e somar um
	Dado que liguei a calculadora
	Quando subtraio 25
	E somo 10
	Então o resultado na tela deve ser -15

Cenario: Realizar um cadastro de usuário apenas com os dados obrigatórios
	#Dado que acessei minha aplicação
	#E acessei a área de cadastro de usuários
	#Quando preencher apenas os dados obrigatórios
	#	| Nome | Idade | Telefone    | Email          |
    #   | Jose | 44    | 11963822718 | jose@teste.com |
	Quando preencher apenas os dados obrigatório de vários usuários
		| Nome  | Idade | Telefone    | Email           |
		| Jose  | 44    | 11963822718 | jose@teste.com  |
		| Carla | 23    | 11956218312 | carla@teste.com |
		| Roger | 31    | 1136956486  | roger@teste.com |
	#E realizar o cadastro
	#Então o usuário deve ser cadastrado

Cenario: Realizar o cadastro de vários produtos
	#Dado que acessei minha aplicação
	#E acessei a área de cadastro de produtos
	Quando preencher os dados dos produtos
		| Id | Nome     | Valor |
		| 10 | Vassoura | 5,00  |
		| 11 | Cadeira  | 20,00 |
		| 12 | Mesa     | 35,00 |
	#E realizar o cadastro
	#Então os produtos devem ser cadastrados

Esquema do Cenário: Realizar o cadastro de um produto
	#Dado que acessei minha aplicação
	#E acessei a área de cadastro de produtos
	Quando preencher o <Id> , <Nome> e <Valor> do produto
	E informar o usuário <Usuário>
	#E realizar o cadastro
	#Então o produto deve ser cadastrado
	Exemplos: 		
	    | Nome       | Id   | Valor   | Usuário  |
	    | "Vassoura" | "10" | "5,00"  | "Amanda" |
	    | "Cadeira"  | "11" | "20,00" | "Tulio"  |
	    | "Mesa"     | "12" | "35,00" | "Maria"  |

Cenario: Realizar um cadastro de uma fruta
	#Dado que acessei minha aplicação
	Quando cadastrar uma fruta
	   | Fruta   | Quantidade | Fornecedor |
	   | Abacaxi | 8          | Atacadao   |
	Então devo visualizar os dados preenchidos

Cenario: Visualizar a mensagem de alerta
    #Dado que acessei minha aplicação
	#E acessei a área de cadastro de animais
	#Quando tentar incluir um animal
	Então a mensagem deve ser visualizada
	  """
      Animal incluído com sucesso !
      Não se esqueça de manter os registros atualizados.
      """
