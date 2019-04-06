using CasaDoCodigo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo
{
    public class DataService : IDataService
    {
        private readonly ApplicationContext _context;

        public DataService(ApplicationContext context)
        {
            _context = context;
        }

        public void InicializaDB()
        {
            _context.Database.EnsureCreated();
            //var json = File.ReadAllText("livros.json");
            //var livros = JsonConvert.DeserializeObject<List<Livro>>(json);
            //foreach (var item in livros)
            //{
            //    _context.Set<Produto>().Add(new Produto(item.Codigo, item.Nome, item.Preco));
            //}
            //_context.SaveChanges();
        }

        //Não utiliza migrations
        //serviceProvider.GetService<ApplicationContext>().Database.EnsureCreated();

        //Utiliza migrations
        //serviceProvider.GetService<ApplicationContext>().Database.Migrate();

        class Livro
        {
            public string Codigo { get; set; }
            public string Nome { get; set; }
            public decimal Preco { get; set; }

            //public void ex()
            //{
            //    var json = File.ReadAllText("livros.json");
            //    var livros = JsonConvert.DeserializeObject<List<Livro>>(json);
            //    foreach (var item in livros)
            //    {
            //        _context.Set<Produto>().Add(new Produto(item.Codigo, item.Nome, item.Preco));
            //    }
            //    _context.SaveChanges();
            //}
        }
    }
}
