using System.Collections.Generic;

namespace CasaDoCodigo.Repositories
{
    public interface IProdutoRepository
    {
        void SaveProdutos(List<ProdutoRepository.Livro> livros);
    }
}