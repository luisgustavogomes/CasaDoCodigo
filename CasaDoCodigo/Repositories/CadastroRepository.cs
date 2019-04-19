using CasaDoCodigo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public class CadastroRepository : BaseRepository<Cadastro>, ICadastroRepository
    {
        public CadastroRepository(ApplicationContext context) : base(context) { }

        public Cadastro Update(int cadastroId, Cadastro novoCadastro)
        {
            var _cadastro = dbSet.Where(c => c.Id == cadastroId).SingleOrDefault();
            if (_cadastro == null)
            {
                throw new ArgumentNullException("Cadastro não encontrado");
            }
            _cadastro.Update(novoCadastro);
            _context.SaveChanges();
            return _cadastro;
        }
    }
}
