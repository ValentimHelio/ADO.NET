using eCommerce.API.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace eCommerce.API.Repositories
{
    public class ContatoRepository : IContatoRepository
    {
        private IDbConnection _connection;
        public ContatoRepository()
        {
            _connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=eCommerce;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        public List<Contato> Get()
        {
            throw new System.NotImplementedException();
        }

        public Contato GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(Contato contato)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Contato contato)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
