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
        // O underscore ('_') no inicio do nome é uma convenção para campos privados.
        private ProdutoRepository _repo = new ProdutoRepository();
        public IActionResult Index()
        {
            var produtos = _repo.GetProdutos();
            return View(produtos);
        }

        public IActionResult Detalhes(int id)
        {
            var produto = _repo.GetProduto(id);


            // É comum caso tenha um IF com apenas uma coisa dentro alguns programadores não colocarem chaves
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var produto = _repo.GetProduto(id);

            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);


        }
        [HttpPost]
        public IActionResult Editar(ProdutoModel produto)
        {
            // 'ModelState.isValid' verifica se os dados enviados pelo ormulário correponde as regras de validação que definimos no ProdutoModel usando "Data Annotarions" (como [Required] e [range])
            if (ModelState.IsValid)
            {
                // Se os dados for valido chama o mmétodo do repositorio para atualizar o produto no banco de dados
                bool sucesso = _repo.UpdateProduto(produto);

                if (sucesso)
                {
                    // Se a atualização for bem-sucedida, redireciona para a página de detalhes do produto
                    // 'RedirectToAction' evita o problema de re-submit do formulário 
                    return RedirectToAction("Detalhes", new { id = produto.Id });
                }

                // Se a atualização falhou (por exemplo, um erro de banco de dados), adiciona uma mensagem de erro ao 'ModelState' para que seja exibida na View
                ModelState.AddModelError("", "Ocorreu um erro ao salvar as alterações");
            }
            return View(produto);
        }

        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken] // Para prevenir ataques contra segurança

        public IActionResult DeletarProduto(int id)
        {
            bool sucesso = _repo.DeleteProduto(id);

            if (sucesso)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");

        }


        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Criar(ProdutoModel produto)
        {
            if (ModelState.IsValid)
            {
                bool sucesso = _repo.CreateProduto(produto);
                if (sucesso)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Ocorreu um erro ao salvar um novo produto.");
            };
            return View(produto);
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