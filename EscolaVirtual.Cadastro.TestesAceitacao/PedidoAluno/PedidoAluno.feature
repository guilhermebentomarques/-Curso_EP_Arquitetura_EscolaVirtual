Funcionalidade: Aluno realizando uma compra
	Um aluno registrado faz uma compra de 
	um curso e realiza o pagamento

@TesteAceitacaoPedidoAluno

Cenário: Aluno realizando o pedido e pagamento
	Dado Que um aluno navega até o site
	E Realiza login
	E Clica no link de cursos
	E Clica no primeiro curso da lista para adicionar no carrinho
	E O aluno é direcionado ao carrinho
	E Clica no botao de realizar pagamento
	E É direcionado para a pagina de pagamento
	E Preenche os dados de pagamento
	Quando Confirma a compra
	Então Recebe uma mensagem de confirmacao

