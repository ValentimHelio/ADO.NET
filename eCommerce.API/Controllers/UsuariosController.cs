﻿using eCommerce.API.Models;
using eCommerce.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _repository;
        public UsuariosController()
        {
            _repository = new UsuarioRepository();
        }

        /*
         * CRUD
         * - GET -> Obter a lista de Usuários.
         * - GET -> Obter o usuário passando o ID.
         * - POST -> Cadastar un usuário.
         * - PUT -> Atualizar um usuário.
         * - Delete -> Remover um usuário.
         * 
         */


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var usuario = _repository.GetById(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult Insert([FromBody] Usuario usuario)
        {
            _repository.Insert(usuario);
            return Ok(usuario);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Usuario usuario)
        {
            _repository.Update(usuario);
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return Ok();
        }
    }
}
