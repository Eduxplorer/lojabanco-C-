// permite o uso de classes para intergir com o SQL.
// Sem essa linha, o C# não saberia o que é um 'SqlConnection' ou 'SqlCommand'
using Microsoft.Data.SqlClient;


// Importa o Model Produto
using lojabanco.Models;

// Permite o uso da coleções genéricas, como a 'List<>'
using System.Collections.Generic;

namespace lojabanco.Data {
    public class ProdutoRepository
    {

        // A 'connection string' é como um endereço para o banco de dados.
        // Ela diz ao programa onde encontrar o servidor, qual banco usar e
        // como se autenticar (neste caso, com a "conexão confiável" do Windows).
        // 

        // ATENÇÃO: A connectionString em código para produção não pode ser armazenada diretamente no código. Então nunca armazene senhas ou informações sensíveis diretamente aqui.
        // Use arquivos de configuração para manter os dados de conexão separados do código.

        // Explicação de cada Atributo da connectionString:

        // Server: indica o servidor onde o banco de dados está hospedado.
        // No caso, "TIT0577564W11-1\\SQLEXPRESS" é o nome do computador + instância do SQL Server.
        // Repare que a contrabarra (\) precisa ser duplicada (\\) em C#, para não causar erro de escape.


        // Database: Nome do seu banco de dados.

        // Trusted_Connection=true: significa que será usada a autenticação do Windows
        // (ou seja, o login do usuário do Windows é usado para conectar).
        
        // MultipleActiveResultSets=true: permite que várias consultas (SELECT, por exemplo)
        // sejam executadas ao mesmo tempo na mesma conexão.

        private string connectionString = "Server=TIT0577564W11-1\\SQLEXPRESS;Database=LojaMvc;TrustServerCertificate=True;Trusted_Connection=true; MultipleActiveResuktSets=true;";

        public List<ProdutoModel> GetProdutos()
        {
            // Cria uma lista vazia para armazenar o produtoModel que serão lidos no banco
            var produtos = new List<ProdutoModel>();

            // O bloco using garante que o objeto 'connection' será fechado e liberado automaticamente no final, mesmo que ocorra um erro  
            using (var connection = new SqlConnection(connectionString))
            {
                // Abre a conexão a conexão com o banco de dados
                connection.Open();

                // Cria um objeto de comando que contém a instrução SQL a ser executada.
                // A instrução 'SELECT' busca as colunas Id, Nome, Preco, Descricao
                var command = new SqlCommand("SELECT Id, Nome, Descricao, Preco FROM Produtos", connection);


                // O using que garante que o reader também será fechado, liberando recursos. 'ExecuteReader()' enviar a consulta ao banco de dados e retorna um objeto que pode ler os resultados
                using (var reader = command.ExecuteReader())
                {
                    // loop while executa enquanto houver linhas para ler no resultado da consulta
                    // 'reader.Read()' move o cursor do ponteiro para próxima linha e retorna true se houver uma.
                    while (reader.Read())
                    {
                        produtos.Add(new ProdutoModel
                        {
                            Id = reader.GetInt32(0),
                            Nome = reader.GetString(1),
                            Descricao = reader.GetString(2),
                            Preco = reader.GetDecimal(3)
                        });
                    }
                }
            }

            return produtos;
        }
    }
}