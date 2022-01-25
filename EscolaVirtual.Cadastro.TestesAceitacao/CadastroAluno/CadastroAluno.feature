Funcionalidade: Cadastrar um novo Aluno
	Um aluno fará seu cadastro pelo site
	preenchendo os campos necessários
	ao terminar receberá uma notificacao 
	de sucesso ou de falha

@TesteAceitacaoCadastroAluno

Cenário: CadastroAlunoSucesso
	Dado que o aluno está no site, na pagina inicial
	E clica no link de registro
	E preenche os campos com os valores
		| Campo       | Valor                       |
		| Nome        | Eduardo Pires               |
		| Email       | contato@eduardopires.net.br |
		| CPF         | 30390600822                 |
		| Senha       | Teste@123                   |
		| RepitaSenha | Teste@123                   |
	Quando clicar no botao registrar
	Entao Recebe uma mensagem de cadastro com sucesso

Cenário: Cadastro de Aluno com CPF já utilizado
	Dado que o aluno está no site, na pagina inicial
	E clica no link de registro
	E preenche os campos com os valores
		| Campo       | Valor                       |
		| Nome        | Eduardo Pires               |
		| Email       | contato2@eduardopires.net.br |
		| CPF         | 30390600822                 |
		| Senha       | Teste@123                   |
		| RepitaSenha | Teste@123                   |
	Quando clicar no botao registrar
	Entao Recebe uma mensagem de erro de CPF já cadastrado

Cenário: Cadastro de Aluno com Email já utilizado
	Dado que o aluno está no site, na pagina inicial
	E clica no link de registro
	E preenche os campos com os valores
		| Campo       | Valor                       |
		| Nome        | Eduardo Pires               |
		| Email       | contato@eduardopires.net.br |
		| CPF         | 30390600822                 |
		| Senha       | Teste@123                   |
		| RepitaSenha | Teste@123                   |
	Quando clicar no botao registrar
	Entao recebe uma mensagem de erro de email já cadastrado

	Cenário: Cadastro de Aluno com Senha sem números
		Dado que o aluno está no site, na pagina inicial
		E clica no link de registro
		E preenche os campos com os valores
			| Campo       | Valor                       |
			| Nome        | Eduardo Pires               |
			| Email       | contato@eduardopires.net.br |
			| CPF         | 30390600822                 |
			| Senha       | Teste@		                |
			| RepitaSenha | Teste@	                    |
		Quando clicar no botao registrar
		Entao Recebe uma mensagem de erro de que a senha requer numero

	Cenário: Cadastro de Aluno com Senha sem Maiuscula
		Dado que o aluno está no site, na pagina inicial
		E clica no link de registro
		E preenche os campos com os valores
			| Campo       | Valor                       |
			| Nome        | Eduardo Pires               |
			| Email       | contato@eduardopires.net.br |
			| CPF         | 30390600822                 |
			| Senha       | teste@123		            |
			| RepitaSenha | teste@123	                |
		Quando clicar no botao registrar
		Entao Recebe uma mensagem de erro de que a senha requer letra maiuscula

	Cenário: Cadastro de Aluno com Senha sem minuscula
		Dado que o aluno está no site, na pagina inicial
		E clica no link de registro
		E preenche os campos com os valores
			| Campo       | Valor                       |
			| Nome        | Eduardo Pires               |
			| Email       | contato@eduardopires.net.br |
			| CPF         | 30390600822                 |
			| Senha       | TESTE@123		            |
			| RepitaSenha | TESTE@123	                |
		Quando clicar no botao registrar		
		Entao Recebe uma mensagem de erro de que a senha requer letra minuscula

	Cenário: Cadastro de Aluno com Senha sem caracter especial
		Dado que o aluno está no site, na pagina inicial
		E clica no link de registro
		E preenche os campos com os valores
			| Campo       | Valor                       |
			| Nome        | Eduardo Pires               |
			| Email       | contato@eduardopires.net.br |
			| CPF         | 30390600822                 |
			| Senha       | Teste123		            |
			| RepitaSenha | Teste123	                |
		Quando clicar no botao registrar		
		Entao Recebe uma mensagem de erro de que a senha requer caracter especial
		
	Cenário: Cadastro de Aluno com Senha em tamanho inferior ao permitido
		Dado que o aluno está no site, na pagina inicial
		E clica no link de registro
		E preenche os campos com os valores
			| Campo       | Valor                       |
			| Nome        | Eduardo Pires               |
			| Email       | contato@eduardopires.net.br |
			| CPF         | 30390600822                 |
			| Senha       | Te123			            |
			| RepitaSenha | Te123		                |
		Quando clicar no botao registrar
		Entao Recebe uma mensagem de erro de que a senha esta em tamanho inferior ao permitido


	Cenário: Cadastro de Aluno com Senha diferentes
		Dado que o aluno está no site, na pagina inicial
		E clica no link de registro
		E preenche os campos com os valores
			| Campo       | Valor                       |
			| Nome        | Eduardo Pires               |
			| Email       | contato@eduardopires.net.br |
			| CPF         | 30390600822                 |
			| Senha       | Teste@123 		            |
			| RepitaSenha | Teste@133                   |
		Quando clicar no botao registrar
		Entao Recebe uma mensagem de erro de que a senha estao diferentes
