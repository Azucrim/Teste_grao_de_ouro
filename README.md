# Teste_grao_de_ouro

Este projeto tem como objetivo gerenciar uma lista de tarefas, as quais podem ser feitas pelo Site ou pela Api,
e ambos contam com as funções de cadastro de uma nova tarefa, atualizar tarefa, buscar tarefas e deletar tarefas  

O site possui uma interface mais limpa e amigável, que o torna de fácil entendimento mesmo para quem não tem familiaridade com programação.
Contando com um campo de texto com um botão para adicionar novas tarefas, contém uma lista de tarefas pendentes editável que permite alterar seu nome,
e se ela foi concluída basta marcar a tarefa e ela será enviada para a lista de tarefas concluídas, a qual tem a função de mostrar a tarefas já realizadas.

A Api tem a meta de deixar as informações do programa mais a mostra, porém é necessário o um melhor entendimento de programação para trabalhar com a mesma. 
Entre as suas funcionalidades temos como realizar um GET que serve para chamar as informações já existentes, e o GET também pode ser feito para buscar tarefas
em especifico, então nesta Api também se encontram um função para buscar todas a tarefas prontas sem a necessidade de passar um parâmetro, mas caso queira uma
tarefa em especifico também poderá ser feito um GET pelo ID da tarefa o qual foi fornecido pelo sistema, o POST serve para criar uma nova tarefa,
o PUT tem a função de atualizar uma tarefa já existente, e o DELETE que deleta uma tarefa existente

