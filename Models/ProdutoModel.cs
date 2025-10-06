// No model eu não preciso necessáriamente colocar "Model" no nome da pasta

// Importando a biblioteca 'System.ComponentModel.DataAnnotations'
// Está  biblioteca fornece atributos que permite adicionar regras de validações e metadados de exibição (como nome de campos), as propriedades da classe 
using System.ComponentModel.DataAnnotations;

namespace lojabanco.Models
{
    // A classe precisa sempre ter o mesmo nome do arquivo
    // ProdutoModel serve como a 'ponte' entre a aplicação e o banco de dados
    // Suas propriedades correspondem ás colunas da tabela 'Produtos' no banco de dados
    public class ProdutoModel
    {
        public int Id { get; set; }

        // Para o dotnet string não pode ser vazio igual int então temos que dar um valor
        // O valor null! avisa ao compilador que a propriedade nunca será vazia
        public string Nome { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public decimal Preco { get; set; }
    }
}

// Para cada tabela do seu banco crie um modelo.