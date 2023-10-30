using eCommerce.API.Models;
using System.Collections.Generic;

namespace eCommerce.API.Repositories
{
    public interface IContatoRepository
    {
        public List<Contato> Get();
        public Contato GetById(int id);
        public void Insert(Contato contato);
        public void Update(Contato contato);
        public void Delete(int id);
    }
}
