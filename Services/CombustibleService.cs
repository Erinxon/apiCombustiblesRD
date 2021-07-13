using ApiCombustibles.Models;
using HtmlAgilityPack;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCombustibles.Services
{
    public class CombustibleService : ICombustibleService
    {
        private readonly SectionUrlPage _sectionUrlPage;

        public CombustibleService(IOptions<SectionUrlPage> sectionUrlPage)
        {
            this._sectionUrlPage = sectionUrlPage.Value;
        }

        public async Task<Combustible> GetCombustible()
        {
            Combustible combustible = new();
            var listaPreciosCombustibles = await RequestPage();
            combustible.GasolinaPremium = listaPreciosCombustibles[(int)EnumCombistible.GasolinaPremium];
            combustible.GasolinaRegular = listaPreciosCombustibles[(int)EnumCombistible.GasolinaRegular];
            combustible.GasoilOptimo = listaPreciosCombustibles[(int)EnumCombistible.GasoilOptimo];
            combustible.GasoilRegular = listaPreciosCombustibles[(int)EnumCombistible.GasoilRegular];
            combustible.Kerosene = listaPreciosCombustibles[(int)EnumCombistible.Kerosene];
            combustible.GasLicuadoPetroleoGLP = listaPreciosCombustibles[(int)EnumCombistible.GasLicuadoPetroleoGLP];
            combustible.GasNaturalVehicularGNV = listaPreciosCombustibles[(int)EnumCombistible.GasNaturalVehicularGNV];
            return combustible;
        }

        private async Task<string[]> RequestPage()
        {
            HtmlWeb htmlWeb = new();
            HtmlDocument htmlDoc = await htmlWeb
                .LoadFromWebAsync(this._sectionUrlPage.Url);
            var regs = htmlDoc.DocumentNode
                .SelectSingleNode(@"(//table[@class='art-data-table art-data-table-condensed'])[last()]");

            var listaPreciosCombustibles = regs.InnerText
              .Replace("CombustiblesPreciosGasolina PremiumRD$ ", "")
              .Replace("Gasolina RegularRD$ ", ";")
              .Replace("Gasoil ÓptimoRD$ ", ";")
              .Replace("Gasoil RegularRD$ ", ";")
              .Replace("KeroseneRD$ ", ";")
              .Replace("Gas Licuado de Petróleo (GLP)RD$ ", ";")
              .Replace("Gas Natural Vehicular (GNV)RD$ ", ";").Split(";");

            return listaPreciosCombustibles;

        }
    }

    public enum EnumCombistible
    {
        GasolinaPremium,
        GasolinaRegular,
        GasoilOptimo,
        GasoilRegular,
        Kerosene,
        GasLicuadoPetroleoGLP,
        GasNaturalVehicularGNV  
    }
}
