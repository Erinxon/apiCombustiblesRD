using ApiCombustibles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCombustibles.Services
{
    public interface ICombustibleService
    {
        Task<Combustible> GetCombustible();
    }
}
