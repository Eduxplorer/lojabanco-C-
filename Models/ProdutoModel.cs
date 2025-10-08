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

        [Display(Name = "Nome")]
        [Required(ErrorMessage ="O campo Nome é obrigatório.")]
        public string Nome { get; set; } = null!;

        [Display(Name = "Descrição")]
        [Required(ErrorMessage ="O campo Descrição é obrigatório.")]
        public string Descricao { get; set; } = null!;

        [Display(Name = "Preço")]
        [Required(ErrorMessage = "O campo preço é obrigatório")]
        [Range(0.01, (double)decimal.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        public decimal Preco { get; set; }
    }
}

// Para cada tabela do seu banco crie um modelo.