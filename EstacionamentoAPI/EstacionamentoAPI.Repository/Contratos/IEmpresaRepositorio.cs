﻿using EstacionamentoAPI.Domain.Entidades;
using System;

namespace EstacionamentoAPI.Repository.Contratos
{
    public interface IEmpresaRepositorio : IRepositorio<Empresa>
    {
        Task<Empresa> GetAsync(int id);
        Task<List<Empresa>> GetAll();
    }
}
