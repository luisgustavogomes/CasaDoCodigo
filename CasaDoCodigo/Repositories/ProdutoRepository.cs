using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ApplicationContext context) : base(context) { }

        public void SaveProdutos(List<Livro> livros)
        {
            foreach (var item in livros)
            {
                if (!dbSet.Where(p => p.Codigo == item.Codigo).Any())
                {
                    dbSet.Add(new Produto(item.Codigo, item.Nome, item.Preco));
                }
            }
            _context.SaveChanges();
        }

        public IList<Produto> GetProdutos()
        {
            return dbSet.ToList();
        }

        public class Livro
        {
            public string Codigo { get; set; }
            public string Nome { get; set; }
            public decimal Preco { get; set; }

        }
    }
}
