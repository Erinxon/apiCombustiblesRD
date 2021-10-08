using ApiCombustibles.AppSettingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCombustibles.Models;

namespace ApiCombustibles.Services
{
    public interface ICombustibleService
    {
        List<Combustible> GetCombustible();
    }
}
