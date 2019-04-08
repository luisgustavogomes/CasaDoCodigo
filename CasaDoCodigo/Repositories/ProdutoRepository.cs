using CasaDoCodigo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ApplicationContext _context;

        public ProdutoRepository(ApplicationContext context)
        {
            _context = context;
        }

        

        public void SaveProdutos(List<Livro> livros)
        {
            foreach (var item in livros)
            {
                _context.Set<Produto>().Add(new Produto(item.Codigo, item.Nome, item.Preco));
            }
            _context.SaveChanges();
        }

        public IList<Produto> GetProdutos()
        {
            return _context.Set<Produto>().ToList();
        }

        public class Livro
        {
            public string Codigo { get; set; }
            public string Nome { get; set; }
            public decimal Preco { get; set; }

        }
    }
}
