# Implementação de Árvore AVL em C#

Este projeto implementa uma Árvore AVL (Árvore Binária de Busca Balanceada) em C#,
 conforme especificado no trabalho prático.

## Como executar

1. Certifique-se de ter o .NET 6.0 SDK instalado
2. Clone o repositório ou baixe os arquivos
3. Navegue até o diretório do projeto
4. Execute o comando: `dotnet run input.txt`

## Funcionalidades implementadas

- Inserção de valores (comando 'I')
- Remoção de valores (comando 'R')
- Busca de valores (comando 'B')
- Impressão em pré-ordem (comando 'P')
- Exibição dos fatores de balanceamento (comando 'F')
- Exibição da altura da árvore (comando 'H')

## Estrutura do código

- `Node.cs`: Classe que representa um nó da árvore AVL
- `AVLTree.cs`: Implementação da árvore AVL com todas as operações necessárias
- `Program.cs`: Programa principal que lê o arquivo de entrada e executa os comandos

## Testes

O arquivo `input.txt` contém um conjunto de comandos para testar a implementação.
 A saída esperada corresponde ao exemplo fornecido no enunciado do trabalho.