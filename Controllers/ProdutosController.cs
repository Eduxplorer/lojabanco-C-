// Importa a biblioteca para o padrão MVC do ASP.NET Core. É essencial para usar o nosso 'Controller' e 'IActionResult'
// IActionResult é a propriedade que utilizamos para substituir os href utilizando a sintaxe asp para linkar e passar as informações entre as páginas
using Microsoft.AspNetCore.Mvc;

// Importa o namespace do nosso modelo de dados 
// É necessário ter uma pasta Data com todas as requisições do banco de dados.
// Por questão estrutural não vamos colocar todas as requisições no Controller e sim manter na pasta 'Data'
using lojabanco.Data;

// Importa a Model Produto
using lojabanco.Models;

namespace lojabanco.Controllers
{
    public class ProdutosController : Controller 
    {

        // Declara uma instância do nosso repositório de produtos.
        // O underscore ('_') no iinicio do nome é uma convenção para campos privados.
        private ProdutoRepository _repo = new ProdutoRepository();
        public IActionResult Index()
        {
            var produtos = _repo.GetProdutos;
            return View(produtos);
        }
    }
}

// O que é extender?

// class pai
// {
//     sobrenome;
// }

// Agora a classe 'filha' tem acesso ao sobrenome da classe 'pai'
// class filha : pai {

// }