﻿using eCommerce.API.Models;
using System.Collections.Generic;

namespace eCommerce.API.Repositories
{
    public interface IUsuarioRepository
    {
        public List<Usuario> Get();
        public Usuario GetById(int id);
        public void Insert(Usuario usuario);
        public void Update(Usuario usuario);
        public void Delete(int id);
    }
}
