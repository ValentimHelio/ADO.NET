using eCommerce.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    public class ContatosController : Controller
    {
        private IContatoRepository _repository;
        public ContatosController()
        {
            _repository = new ContatoRepository();
        }
    }
}
