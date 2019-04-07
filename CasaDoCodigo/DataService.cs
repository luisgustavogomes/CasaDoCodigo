using CasaDoCodigo.Models;
using CasaDoCodigo.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static CasaDoCodigo.Repositories.ProdutoRepository;

namespace CasaDoCodigo
{
    public class DataService : IDataService
    {
        private readonly ApplicationContext _context;
        private readonly IProdutoRepository _produtoRepository;

        public DataService(ApplicationContext context, IProdutoRepository produtoRepository)
        {
            _context = context;
            _produtoRepository = produtoRepository;
        }

        /// <summary>
        /// Não utiliza migrations - serviceProvider.GetService<ApplicationContext>().Database.EnsureCreated();
        /// Utiliza migrations - serviceProvider.GetService<ApplicationContext>().Database.Migrate();
        /// </summary>
        public void InicializaDB()
        {
            _context.Database.EnsureCreated();
            _produtoRepository.SaveProdutos(GetLivros());
        }

        private static List<Livro> GetLivros()
        {
            var json = File.ReadAllText("livros.json");
            var livros = JsonConvert.DeserializeObject<List<Livro>>(json);
            return livros;
        }

        

        
    }
}
